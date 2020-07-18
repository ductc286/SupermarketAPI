using System.Text;

namespace Supermarket.Core.Utilities
{
    public class MoneyUtilities
    {
        public static string GetMoneyString(object money)
        {
            var moneyString = money.ToString().Trim();
            StringBuilder stringBuilder = new StringBuilder();
            
            if (moneyString == null || moneyString.Length == 0)
            {
                return "";
            }
            var length = moneyString.Length;
            var commaNumber = ((length - 1) / 3) + 2;
            var resultArray = new char[length + commaNumber];
            int j = 0;
            for (int i = (length - 1); i >= 0; i--)
            {
                if (i % 3 == 0)
                {
                    resultArray[j] = ',';
                    j++;
                }
                resultArray[j] = moneyString[i];
                j++;
            }
            
            return resultArray.ToString().Trim(',');
        }
    }
}
