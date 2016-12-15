using OshudhwalaDotCom.Core.DAL;
using OshudhwalaDotCom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OshudhwalaDotCom.Core.BLL
{
    public class UserManager
    {
         UserGateway userGateway = new UserGateway();

        public int AddUser(Registration registration)
        {
          return userGateway.AddUser(registration);

        }

        public Registration LoginValidation(Login login)
        {
            return userGateway.LoginValidation(login);
        }

    }
}