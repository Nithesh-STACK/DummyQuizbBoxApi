using DummyQuizbBoxApi.Models;
using System.Data.SqlClient;

namespace DummyQuizbBoxApi.Services
{
    public class PortfolioServices:IPortfolioServices
    {
        public string val { get; set; }
        public IConfiguration Configuration;
        public SqlConnection conn;
        public PortfolioServices(IConfiguration configuration)
        {
            Configuration = configuration;
            val = Configuration.GetConnectionString("QuizBoxDatabase");
        }
       

        public List<Portfolio> GetPortfolios()
        {
            List<Portfolio> porfolios = new List<Portfolio>();
            try
            {
                using (conn = new SqlConnection(val))
                {
                    conn.Open();
                    var cmd = new SqlCommand("Select * from portfolio", conn);
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Portfolio p = new Portfolio();
                        p.Id = dr.GetGuid(0);
                        p.name = dr.GetValue(1).ToString();
                        p.isActive = Convert.ToBoolean(dr.GetValue(2));
                        p.isDeleted = Convert.ToBoolean(dr.GetValue(3));
                        p.CreatedDate = Convert.ToDateTime(dr.GetValue(4));
                        porfolios.Add(p);

                    }
                }
                return porfolios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public string CreatePortfolio(Guid _id, string _name, bool _isActive, bool _isDeleted, DateTime _CreatedDate)
        {
            try
            {
                using (conn = new SqlConnection(val))
                {
                    conn.Open();
                    var cmd = new SqlCommand("insert into portfolio values(NEWID(),@name,@isActive,@isDeleted,@CreatedDate)", conn);
                   // cmd.Parameters.AddWithValue("@Id", _id);
                    cmd.Parameters.AddWithValue("@name", _name);
                    cmd.Parameters.AddWithValue("@isActive", _isActive);
                    cmd.Parameters.AddWithValue("@isDeleted", _isDeleted);
                    cmd.Parameters.AddWithValue("@CreatedDate", _CreatedDate);
                    cmd.ExecuteNonQuery();

                }

            }

            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return "record added";
        }
        public string updatePortfolio(Guid Id, string name, bool isActive, bool isDeleted, DateTime CreatedDate)
        {
            try
            {
                using (conn = new SqlConnection(val))
                {
                    conn.Open();
                    var cmd = new SqlCommand("update portfolio set name=@name,isActive=@isActive,isDeleted=@isDeleted,CreatedDate=@CreatedDate where Id=@Id", conn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@isActive", isActive);
                    cmd.Parameters.AddWithValue("@isDeleted", isDeleted);
                    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    cmd.ExecuteNonQuery();

                }

            }

            catch (Exception)
            {
                throw;
;            }
            finally
            {
                conn.Close();
            }
            return "record modified";
        }
        public string DeletePortfolio(Guid Id)
        {
            try
            {
                using (conn = new SqlConnection(val))
                {
                    conn.Open();
                    var cmd = new SqlCommand("delete from portfolio where Id=@Id", conn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return "record deleted";
        }
        public List<Portfolio> GetPortfolioByid(Guid Id)
        {
            List<Portfolio> porfolios = new List<Portfolio>();
            try
            {
                using(conn=new SqlConnection(val))
                {
                    conn.Open();
                    var cmd = new SqlCommand("select * from portfolio where Id=@Id",conn);
                    cmd.Parameters.AddWithValue("@Id", Id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Portfolio p = new Portfolio();
                        p.Id = dr.GetGuid(0);
                        p.name = dr.GetValue(1).ToString();
                        p.isActive = Convert.ToBoolean(dr.GetValue(2));
                        p.isDeleted = Convert.ToBoolean(dr.GetValue(3));
                        p.CreatedDate = Convert.ToDateTime(dr.GetValue(4));
                        porfolios.Add(p);

                    }
                }
                return porfolios.ToList();


            
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
