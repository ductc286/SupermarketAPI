using SupermarketAPI.Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Core.ViewModels
{
    public class EndOfShiftViewModel : BaseViewModel
    {
        public EndOfShiftViewModel() { }

        public EndOfShiftViewModel(EndOfShift endOfShift)
        {
            EndOfShiftId = endOfShift.EndOfShiftId;
            StaffId = endOfShift.StaffId;
            CreatedDate = endOfShift.CreatedDate;
            Date = endOfShift.Date;
            From = endOfShift.From;
            To = endOfShift.To;
            TotalHours = endOfShift.TotalHours;
            IsApproved = endOfShift.IsApproved;
            Note = endOfShift.Note;
            Staff = endOfShift.Staff;
            TotalMoney = endOfShift.TotalMoney;
        }

        public int EndOfShiftId { get; set; }

        public int StaffId { get; set; }

        public DateTime CreatedDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Now;

        public int From { get; set; }

        public int To { get; set; }

        public byte TotalHours { get; set; }

        public bool IsApproved { get; set; } = false;

        private string _note;
        [MaxLength(255, ErrorMessage = "Ghi chú có độ dài tối đa là {1}")]
        public string Note
        {
            get { return _note; }
            set
            {
                OnPropertyChanged(ref _note, value);
            }
        }

        private long _totalMoney;
        public long TotalMoney
        {
            get
            {
                return _totalMoney;
            }
            set
            {
                OnPropertyChanged(ref _totalMoney, value);
            }
        }

        public virtual Staff Staff { get; set; }

        public EndOfShift MapToEndOfShift()
        {
            var endOfShift = new EndOfShift()
            {
                EndOfShiftId = this.EndOfShiftId,
                CreatedDate = this.CreatedDate,
                Date = this.Date,
                From = this.From,
                IsApproved = this.IsApproved,
                Note = this.Note,
                Staff = this.Staff,
                StaffId = this.StaffId,
                To = this.To,
                TotalHours = this.TotalHours,
                TotalMoney = this.TotalMoney
            };
            return endOfShift;
        }
    }
}
