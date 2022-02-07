using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DAL;
using Final_Tech_Guide.Utility;


namespace Final_Tech_Guide.Models
{
    public class ProductsModel
    {

       
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public string Link { get; set; }


        public IEnumerable<ProductsModel> Products () {


           DB db = new DB();
           DataTable dt = db.getProducts(); // this returns a Datable

           var products = Tools.ConvertDataTable<ProductsModel>(dt);
            
           var allproducts = from u in products select u;
           return allproducts;


    }

    }
}