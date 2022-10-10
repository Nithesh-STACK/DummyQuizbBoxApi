using DummyQuizbBoxApi.Models;

namespace DummyQuizbBoxApi.Services
{
    public interface IPortfolioServices
    {
        public List<Portfolio> GetPortfolios();
        public string CreatePortfolio(Guid _id, string _name, bool _isActive, bool _isDeleted, DateTime _CreatedDate);
        public string updatePortfolio(Guid _id, string _name, bool _isActive, bool _isDeleted, DateTime _CreatedDate);
        public string DeletePortfolio(Guid Id);
        public List<Portfolio> GetPortfolioByid(Guid Id);




    }
}
