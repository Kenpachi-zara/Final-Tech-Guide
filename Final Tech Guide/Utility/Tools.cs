using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;


namespace Final_Tech_Guide.Utility
{
    public class Tools
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> list = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(GetItem<T>(dr));
            }
            return list;
        }

        private static T GetItem<T>(DataRow dr)  // notice How T is type of function, and we cann pass it a value by GetItem<Employee>
        {
            Type temp = typeof(T); // amazing. getting original type passed to T  T is going to be HomeModel stored in Temp
            T obj = Activator.CreateInstance<T>(); // Activator.CreateInstance<T>() means to create an object of the generated type T 

            foreach (DataColumn dc in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties()) // temp.GetProperties() means get proprties of AuthenticationModel : ID, USername, Password, Email and loop them
                {
                    if (pro.Name == dc.ColumnName) // pro.Name gets the name of the current proeprty which at this point is ID, same for  dc.ColumnName
                    { 
                        pro.SetValue(obj, dr[dc.ColumnName], null); // set property value of obj to dr[dc.ColumnName]
                    } 
                    else
                    {
                        continue;
                    }
                }
            }
            return obj;
        }
    }
}