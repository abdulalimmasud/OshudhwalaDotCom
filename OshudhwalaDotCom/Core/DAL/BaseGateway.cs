using System.Configuration;
using System.Data.SqlClient;

namespace OshudhwalaDotCom.Core.DAL
{
    public class BaseGateway
    {
        public string ConnectionString { get; set; }
        public SqlConnection SqlConnection { get; set; }
        public SqlCommand SqlCommand { get; set; }

        public BaseGateway()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["PharmacyDatabase"].ConnectionString;
            SqlConnection = new SqlConnection(ConnectionString);
            SqlCommand = new SqlCommand();
            SqlCommand.Connection = SqlConnection;
        }
    }
}