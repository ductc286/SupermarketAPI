namespace Supermarket.Core.ViewModels
{
    public class StatisticsViewModel : BaseViewModel
    {
        public int TotalSaleBill { get; set; }
        public long TotalProductsSold { get; set; }
        public long TotalSalesMoney { get; set; }

        public int TotalPurchaseBill { get; set; }
        public long TotalProductsPurchased { get; set; }
        public long TotalPurchaseMoney { get; set; }
    }
}
