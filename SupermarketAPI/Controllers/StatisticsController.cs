using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.ViewModels;
using Supperket.BLL.IBusiness;
using System;

namespace SupermarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsBusiness _statisticsBusiness;

        public StatisticsController(IStatisticsBusiness statisticsBusiness)
        {
            _statisticsBusiness = statisticsBusiness;
        }

        // GET: api/Categories
        [HttpGet]
        public ActionResult<StatisticsViewModel> GetOverview(DateTime fromDate, DateTime toDate)
        {
            return _statisticsBusiness.GetStatisticsViewModel(fromDate, toDate);
        }
    }
}
