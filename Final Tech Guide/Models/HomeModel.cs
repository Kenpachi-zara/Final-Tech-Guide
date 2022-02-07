using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DAL;
using Final_Tech_Guide.Utility;



namespace Final_Tech_Guide.Models
{
    public class HomeModel
    {
        // each attribute corresponds with a column in table
        public int ID { get; set; }

         
        public int Phone { get; set; }

      
        public string Username { get; set; }

    
        public string Password { get; set; }


        public string Email { get; set; }




        // mapping table data to IEnumerable
        public static IEnumerable<HomeModel> getAllUsers()
        {
            DB db = new DB();
            DataTable dt = db.getUsersDataTable(); // this returns a Datable

            var users = Tools.ConvertDataTable<HomeModel>(dt); // using Simple_Tech_Guide.Utility;  our own

            // If you select a block of code and use the key sequence Ctrl+K+C, you'll comment out the section of code. Ctrl+K+U will uncomment the code.

            //var users = new List<HomeModel> ();
            //HomeModel user = null;


            //foreach (DataRow dr in dt.Rows) // getting each row 
            //{

            //    user = new HomeModel ();
            //    user.ID = Convert.ToInt32(dr["ID"]); // getting each column
            //    user.Username = dr["Username"].ToString();
            //    user.Password = dr["Password"].ToString();
            //    user.Email = dr["Email"].ToString();
            //    users.Add (user); 

            //}

            var finalUsers = from u in users select u;
            return finalUsers; // we'll use this in controller then in view .cshtml
        }
    }
}