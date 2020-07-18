using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Supermarket.Core.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region AcceptValidModel
        ////Use to do not validate model in first constructor
        ////If do not use this, when window open then always display errors
        protected bool acceptValidModel = false;
        public bool AcceptValidModel { set { acceptValidModel = value; } }
        #endregion

        public void ClearValidError()
        {
            ErrorCollection = new Dictionary<string, string>();
            OnPropertyChanged("ErrorCollection");
        }
        #region Implement INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify a property change
        /// </summary>
        /// <param name="propertyName">Name of property to update</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Notify a property change that uses CallerMemberName attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingField">Backing field of property</param>
        /// <param name="value">Value to give backing field</param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            AcceptValidModel = true;
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region Implement IDataErrorInfo interface
        public string Error { get { return GetAllErrorCollection(); } }
        private string GetAllErrorCollection()
        {
            StringBuilder errorBuider = new StringBuilder();
            foreach (var item in ErrorCollection)
            {
                errorBuider.Append(item.Value).AppendLine();
            }
            return errorBuider.ToString().Trim();
        }
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();


        public virtual string this[string columnName]
        {
            get
            {
                //If we don't want to validation then set AcceptValidModel = false, this for first open view!
                if (!acceptValidModel)
                {
                    return null;
                }
                string error = GetErrorFromDataAnnotations(columnName);
                AddErrorCollection(columnName, error);
                OnPropertyChanged("ErrorCollection");
                return error;
            }
        }

        /// <summary>
        /// Add element to ErrorCollection Dictionary and update OnPropertyChanged("ErrorCollection")
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        protected void AddErrorCollection(string name, string value)
        {
            if (name == null)
            {
                return;
            }
            if (ErrorCollection.ContainsKey(name))
                ErrorCollection[name] = value;
            else if (value != null)
                ErrorCollection.Add(name, value);

        }
        protected string GetErrorFromDataAnnotations(string columnName)
        {
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();

            if (Validator.TryValidateProperty(
                    GetType().GetProperty(columnName).GetValue(this)
                    , new ValidationContext(this)
                    {
                        MemberName = columnName
                    }
                    , validationResults))
                return null;
            return validationResults.First().ErrorMessage;
        }

        #endregion

        /// <summary>
        /// Validates the model's properties and returns true or false
        /// </summary>
        /// <returns></returns>
        public bool IsValidModel()
        {
            ////Browse properties that have modifier that are public and BindingFlags.Instance
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
            foreach (PropertyInfo property in properties)
            {
                ////Add to ErrorCollection for property has get,set
                if (property.CanRead && property.CanWrite)
                {
                    var error = GetErrorFromDataAnnotations(property.Name);
                    AddErrorCollection(property.Name, error);

                }
            }
            ////Update changed to window and return result
            OnPropertyChanged("ErrorCollection");
            return string.IsNullOrEmpty(Error);
        }
    }
}
