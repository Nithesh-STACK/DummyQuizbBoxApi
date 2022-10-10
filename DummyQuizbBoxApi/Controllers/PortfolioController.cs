using DummyQuizbBoxApi.Models;
using DummyQuizbBoxApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DummyQuizbBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioServices _portfolioService;
        public PortfolioController(IPortfolioServices portfolioService)
        {
            _portfolioService = portfolioService;
        }   
        [HttpGet]
        public async Task<IActionResult> GetPortfoliosData()
        {
            List<Portfolio> portfolios = new List<Portfolio>();
            portfolios=_portfolioService.GetPortfolios().ToList();
            return Ok(portfolios);

        }
        [HttpPost]
        public string CreatePortfolios(Portfolio obj)
        {
           var status=_portfolioService.CreatePortfolio(obj.Id,obj.name,obj.isActive,obj.isDeleted,obj.CreatedDate);
            return "item added";
        }
        [HttpPut]
        public string UpdatePortfolio(Portfolio obj)
        {
            var status = _portfolioService.updatePortfolio(obj.Id, obj.name, obj.isActive, obj.isDeleted, obj.CreatedDate);
            return "record modified";

        }
        [HttpDelete]
        public string DeletePortfolios(Guid Id)
        {

            var status = _portfolioService.DeletePortfolio(Id);
            return "record deleted";

        }
        [Route("GetPortfolioById")]
        [HttpGet]
        public async Task<IActionResult> GetPortfoliosDatById(Guid Id)
        {
            List<Portfolio> portfolios = new List<Portfolio>();
            portfolios = _portfolioService.GetPortfolioByid(Id).ToList();
            return Ok(portfolios);

        }

    }
}
