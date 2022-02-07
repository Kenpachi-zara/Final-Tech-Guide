using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAL;

namespace Final_Tech_Guide.Models
{
    public class ContactModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Full Name")]
        [StringLength(20, MinimumLength = 5 , ErrorMessage = "Should be min 5 and max 20 length")]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false , ErrorMessage = "Please Provide Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false , ErrorMessage = "Please Provide Description")]
        [StringLength(300, MinimumLength = 30, ErrorMessage = "Description should be at least 30 characters long and 300 maximum")]
        public string Description { get; set; }

        public static Boolean InsertContactSubmission(ContactModel model)
        {
            

            bool IsInserted = DB.insertContactSubmission(model.FullName, model.Email, model.Description);
            return IsInserted;


        }

    }
}