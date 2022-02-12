# Final Tech Guide (ASP.NET MVC)

***The project is mostly about goruping Tech Gadgets or Items that provide useful solutions or trending ones, it basically overviews each item with credit to the author with a link-through to purchase from Online platforms. The project is still half way through and is yet in the works for the final form. I believe it could help anyone who is a beginner ASP.net web-developer as it presents clarified MVC architecture with javascrip and bootstrap. All are welcome to contribute :shipit:.***


## Below technologies are applied : 

###### ASP.net MVC, Javascript, Bootstrap, JQuery and ofc html, css. 

###### Application is divided into the following : 

- Home Page (Index.cshtml)
- Authentication Page (Authentication.cshtml)
- Registeration Page (Registeration.cshtml)
- Contact Page (Contact.cshtml)
- Products Page (Products.cshtml)
- ProductDetails Page (ProductDetails.cshtml)
- About Page (About.cshtml)
- DAL (Data Access Layer as a sperate project within solution )
- __Layout.cshtml 

  ## Home Page (Index.cshtml) 
  
  ***Having an introduction as usual with highlighted javascript functionality demo to be replaced later, the announcments secetions which includes trending news related to the industry, notice here I have an HTML Table that is set to Display:none; howoever it's data is inflated with all users returned from our local database returned as an IEnumerable in our action method after getting the DataTable from DAL and then converting it to a List through our Index.cs Model ***
  
## Authentication Page (Authentication.cshtml)
**Verify whether the user is already registered or not by validating our local database with Username attribute from Authentication.cs Model, server and client revalidation is being applied with unobtrusive library, our overrided Action Method is noted with [HttpPost] to recieve requests and an Authentication.cs Model Object is passed over with inflated data from User Input***


## Registeration Page (Registeration.cshtml)
**Very Similar to Authentication by revalidating with server and client revalidation however, we check that the user is not registered and the ModelState.IsValid and if both conditions are met a new user is inserted into our database***


## Contact Page (Contact.cshtml)  
**After validating Input any user can submit a query which goes into local database***

## About Page (About.cshtml)
**Super Simple, no backend stuff going on here just the baisc About.Us page***


## Products Page (Products.cshtml)
**Having about twleve rows in our database where each row contains four columns ID, SampleTitle, SampleDescription, Image. the image column is stored as varbinary(max) notice here I've managed to bulk insert twleve entries using SQL SERVER POWERSHELL where all images are stored within a folder so by storing all file names within $files looping through with predifened variables it Worked!. At this point in our Product.cs Model having four attributes that correspond with our table's columns headers and notice Image attribute datatype is byte[], After using DAL which references Stored procedure that selects all data then a DataTable is returned and after converting with Utility.tools  an IEnumerable<> looper with objects where each one matches with a row is returned to our Model stored as "var products in our action method", Notice here we convert varbinary image to Base64 and then we inflate the Products.cshtml with data***


## ProductDetails Page (ProductDetails.cshtml)
***using the same var products IEnumerable without having to refer to DAL all over again, I simply pass over the ID which matches with indices within products list I use .ElementAt(ID) which returns the underlying item and then data is inflated with an extra entry which is A link to A video that overviews the current tech gadget with a title and description***


DAL (Data Access Layer as a sperate project within solution )

## DAL (Data Access Layer as a sperate project within solution )
***Basically the work with our local database is done here, using the path from a manually created file .UDL used from it and stored within var path, now most of the method used are referencing stored procedures and all data are returned to models as per request***


## __Layout.cshtml
***COntains the navbar and footer which is shared accross all views.***

# To-Do-List : 
- Need to add a functionality where each user is associated with favourite set of items
- Inflate proper data by replacing the sample data 
- Improvising more of the design so that it matches with industry's atmosphere 
- Implement proper Tests



  
  
