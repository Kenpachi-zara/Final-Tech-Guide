using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Final_Tech_Guide.Models;

namespace Final_Tech_Guide.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<HomeModel> users = HomeModel.getAllUsers();
            return View(users);
        }


        public ActionResult Products()
        {

            ProductsModel model = new ProductsModel();
            var products = model.Products();
            return View(products);
        }


        [HttpGet]
        public ActionResult ProductDetails ( String fuckingID)
        {
            ProductsModel products = new ProductsModel();
            var allproducts = products.Products();
            var model = allproducts.ElementAt(Convert.ToInt32(fuckingID)-1);
         
            return View(model);
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            if (Request.QueryString["IsSuccess"] == "1")
            {
                ViewBag.IsSubmitted = "Query Submitted Successfully!";
            }
            else if (Request.QueryString["IsSuccess"] == "0")
            {

                ViewBag.IsSubmitted = "Couldn't Submit Query";

            }
            else if (Request.QueryString["IsSuccess"] == "-1")
            {
                ViewBag.IsSubmitted = "Please Fill All Fields.";

            }
            return View();
        }
        [HttpPost]
        public ActionResult InsertContactSubmission(ContactModel model)
        {

            if (ModelState.IsValid)
            {
                
                    bool IsInserted = ContactModel.InsertContactSubmission(model);

                    if (IsInserted)
                    {
                        return RedirectToAction("Contact", new { IsSuccess = 1 });
                    }
                    else
                    {
                        return RedirectToAction("Contact", new { IsSuccess = 0 });
                    }
            }
            else 
            {

                return View("Contact", model);

            }


           
        }








        // Full Explanation
        //  https://stackoverflow.com/questions/28776486/understanding-httppost-httpget-and-complex-actionmethod-parameters-in-mvc
        public ActionResult Authentication()
        {

            LoginModel model = new LoginModel();

            
            if (Request.QueryString["IsSuccess"] == "1" )
            {
                ViewBag.SuccessMsg = "Signed In Successfully!";
            }
            if (Request.QueryString["IsSuccess"] == "0")
            {
                ViewBag.SuccessMsg = "Username Doesn't Exist";
            }
            return View(model);

        }

        //OverLoaded because we're using forms.
        [HttpPost]
        public ActionResult Authentication(LoginModel model)
        // After submit details are passed to Above arguments
        {
            DB dB = new DB();

            if (ModelState.IsValid)
            {
             

                if (model != null)
                {
                    if (dB.IsRegistered(model.Username, model.Password))
                    {
                       
                        return RedirectToAction("/Authentication", new { IsSuccess = 1 } );

                    }
                    else
                    {
                        
                        return RedirectToAction("/Authentication", new { IsSuccess = 0} );


                    }
                }

                // this means model == null
                return RedirectToAction("/Authentication", new { IsSuccess = -1 } );


                //TempData is used to transfer data from view to controller, controller to view,
                //or from one action method to another action method of the same or a different controller.
                // Below is example of TempData
            }
            else
            {
                return View(model);

            }
        }
        //In the Index ActionMethod with HttpPost we are checking the ModelState.IsValid property.
        //if modelstate.isvalid is true the form is successfully submitted without any form validation errors, then returning details view in home controller.
        //if modelstate.isvalid is false then the form is not successfully submitted with form validation error,
        //then returning same view with employee object for repopulating the submitted values and error messages for model object.



        #region Registration 
        public ActionResult Registration( )
        {
            if (Request.QueryString["IsSuccess"] == "1" )
            {
                ViewBag.SuccessMsg = "User has been Added";
                // ViewBag.SuccessMsg to @ViewBag.Success msg in .cshtml view 
            }
            else if (Request.QueryString["IsSuccess"] == "0")
            {
                ViewBag.SuccessMsg = "Could not register user";
            }
          
            return View();  
        }
       


       
       
        [HttpPost]
        // notice how this action is not associated with a view, but each return redirects to Registration which is connnected to a view
        public ActionResult InsertUser(AuthenticationModel passedModel) // using anything other then Model's object won't work
        {


            AuthenticationModel model = new AuthenticationModel();

            DB dB = new DB();
            if (ModelState.IsValid)
            {
               

                
                    if (dB.IsRegistered(Request["Username"], Request["Password"])) // Username and Passwrd are <input name="Username"
                    {
                        // Registered
                        return RedirectToAction("Authentication", new { IsSuccess = 1 }); // this goes to login page, just pass a message along
                    }
                    else
                    {
                        // Not Registered
                        model.Username = Request["Username"]; // I could use passedModel.Username instead 
                        model.Password = Request["Password"];
                        model.Email = Request["Email"];
                        model.Phone = Convert.ToInt32(Request["Phone"]); 
                        // thorws an exception Value was either too large or too small for an Int32.'
                        // Change Type of Phone proeprty in model to String 

                    Boolean success = AuthenticationModel.InsertUser(model.Username , model.Password, model.Email, model.Phone);

                        if (success)
                        {
                            return RedirectToAction("Registration", new { IsSuccess = 1 }); // if insertion of new User works
                            //Url : home/action?IsSuccess=1  
                        }
                        else
                        {
                            return RedirectToAction("Registration", new {IsSuccess = 0 }); // if it doesn't work
                        }

                    }
                
                  

                //TempData is used to transfer data from view to controller, controller to view,
                //or from one action method to another action method of the same or a different controller.
                // Below is example of TempData
            }
            else
            {
                return View("Registration", passedModel); // action , model

            }
            
        }

        #endregion
    }
}