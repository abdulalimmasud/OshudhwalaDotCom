using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using OshudhwalaDotCom.Models;

namespace OshudhwalaDotCom.Core.DAL
{
    public class MedicineGateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["PharmacyDatabase"].ConnectionString;
    }
}