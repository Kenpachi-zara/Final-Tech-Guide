using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using Final_Tech_Guide.Utility;
using DAL; // notice 

namespace Final_Tech_Guide.Models
{
    public class LoginModel
    {


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide User Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Should be min 5 and max 20 length")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Password")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Should Be At Least 5 Characters")]
        public string Password { get; set; }


    }


}
