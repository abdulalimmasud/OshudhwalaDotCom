using OshudhwalaDotCom.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace OshudhwalaDotCom.Core.DAL
{
    public class UserGateway:BaseGateway
    {
        public int AddUser(Registration registration)
        {
            int rowsAffected = 0;
            try
            {                
                SqlConnection.Open();
                SqlCommand.CommandText = "spInsertUser";
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Parameters.AddWithValue("@Name", registration.Name);
                SqlCommand.Parameters.AddWithValue("@Email", registration.Email);
                SqlCommand.Parameters.AddWithValue("@Phone", registration.Phone);
                SqlCommand.Parameters.AddWithValue("@Password", registration.Password);
                SqlCommand.Parameters.AddWithValue("@Address", registration.Address);
                SqlCommand.Parameters.AddWithValue("@DateOfBirth", registration.DateOfBirth);
                rowsAffected = SqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex) { }
            finally{
                SqlConnection.Close();
            }
            return rowsAffected; 
        }

        public Registration LoginValidation(Login login)
        {
            Registration registration = new Registration();
            try
            {
                string queryString = "Select * from Person.Users where Email=@email and Password=@password;";
                SqlConnection.Open();
                SqlCommand.CommandText = queryString;
                SqlParameter param = new SqlParameter("@email", login.Email);
                SqlCommand.Parameters.Add(param);
                SqlParameter param2 = new SqlParameter("@password", login.Password);
                SqlCommand.Parameters.Add(param2);

                SqlDataReader reader = SqlCommand.ExecuteReader();
                while (reader.Read())
                {

                    registration.Id = Convert.ToInt32(reader["Id"]);
                    registration.Name = Convert.ToString(reader["Name"]);
                    registration.Email = Convert.ToString(reader["Email"]);
                    registration.Phone = Convert.ToString(reader["Phone"]);
                    registration.Address = Convert.ToString(reader["Address"]);
                    registration.DateOfBirth = Convert.ToString(reader["DateOfBirth"]);

                }
                reader.Close();
            }
            catch (Exception ex) { }
            finally
            {
                SqlConnection.Close();
            }
            return registration;
        }
     }


}
