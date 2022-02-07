using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using Final_Tech_Guide.Utility;
using DAL; // notice 



/* Notice that you can't use StringLength on an int property
 * [StringLength(20, MinimumLength = 6, ErrorMessage ="Should Be At Least 6")] can't be used with int property
 */

namespace Final_Tech_Guide.Models
{
    public class AuthenticationModel
    {
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Phone Number")]
        [RegularExpression("[0-9]+", ErrorMessage = "Phone Number Should Be In Digits Only")]
        public int Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide User Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Should be min 5 and max 20 length")]
        [CustomValidationByMe(ErrorMessage ="Already Signed Up")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Password")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Should Be At Least 5 Characters")]
        public string Password { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Eamil")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string Email { get; set; }


        // mapping table data to IEnumerable
        public static IEnumerable<AuthenticationModel> getAllUsers()
        {

            DB db = new DB();
            DataTable dt = db.getUsersDataTable(); // this returns a Datable

            var users = Tools.ConvertDataTable<AuthenticationModel>(dt); // using Simple_Tech_Guide.Utility;  our own

            // If you select a block of code and use the key sequence Ctrl+K+C, you'll comment out the section of code. Ctrl+K+U will uncomment the code.

            //var users = new List<HomeModel> ();
            //HomeModel user = null;

            var ListOfUsers = from u in users select u;
            return ListOfUsers; // we'll use this in controller then in view .cshtml

        }

        public static Boolean InsertUser (String Username, String Password, String Email, int Phone )
        {
            Boolean result = DB.InsertUser(Username, Password, Email, Phone);
            return result;

        }

        }



    // Custom validation for no reason
     public class CustomValidationByMe : ValidationAttribute
    {
        bool isExist = false;

        DB db = new DB ();  
        // object value   == the value within a field in from like input text 's value
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            // reason for override keyword is because in original abstract class, we have 'virtual' keyword, which means this method
            // can be possibly changed 
        {

          
            if (value != null)
            {
                isExist = db.IsRegistered(value.ToString()); // true if inside database, false otherwise
            }
            else 
            { 
            
               isExist = true;
               ErrorMessage = "Please Provide Username";
            } 
            
            return isExist ? new ValidationResult(ErrorMessage) : ValidationResult.Success ;
            // [CustomValidationByMe(ErrorMessage ="Already Signed Up")] if user is registered this returns Already Signed Up
            // otherwise it passes 
        }

    }
}