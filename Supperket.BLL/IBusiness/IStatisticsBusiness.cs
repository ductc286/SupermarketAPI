using Supermarket.Core.ViewModels;
using System;

namespace Supperket.BLL.IBusiness
{
    public interface IStatisticsBusiness
    {
        #region Sale
        int CountSaleBillByInterval(DateTime fromDate, DateTime toDate);
        long CountSaleMoneyByInterval(DateTime fromDate, DateTime toDate);
        long CountProductsSoldByInterval(DateTime fromDate, DateTime toDate);

        #endregion

        #region Purchase
        int CountPurchaseBillByInterval(DateTime fromDate, DateTime toDate);
        long CountPurchaseMoneyByInterval(DateTime fromDate, DateTime toDate);
        long CountProductsPurchasedByInterval(DateTime fromDate, DateTime toDate);

        #endregion

        StatisticsViewModel GetStatisticsViewModel(DateTime fromDate, DateTime toDate);
    }
}
