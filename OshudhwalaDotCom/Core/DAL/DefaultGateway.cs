using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace OshudhwalaDotCom.Core.DAL
{
    public class DefaultGateway
    {
        string 
        public SqlConnection SqlConnection { get; set; }
        public SqlCommand SqlCommand { get; set; }
        public SqlDataReader SqlReader { get; set; }
    }
}