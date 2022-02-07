using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
 

namespace DAL
{
    public class DB
    {
        public DataTable getProducts ()
        {
            String path = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MainProject;Data Source=PC;";

            String procedure = "GetProducts";

            SqlConnection database = new SqlConnection(path);

            if (database.State == ConnectionState.Closed)
            {
                database.Open();
            }

            SqlCommand sqlCommand = new SqlCommand(procedure, database);

            SqlDataReader reader =  sqlCommand.ExecuteReader();
            
            DataTable datatable = new DataTable();

            datatable.Load(reader);

            if (database.State == ConnectionState.Open)
            {
                database.Close();
            }

            return datatable;   


        }
        public DataTable getUsersDataTable()
        {

            String path = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MainProject;Data Source=PC;";

            SqlConnection database = new SqlConnection(path);

            String query = @"SELECT [ID]
                       ,[Username]
                       ,[Password]
                       ,[Email]
                        FROM[dbo].[Table_1]";


            SqlCommand command = new SqlCommand(query, database);

            if (database.State == ConnectionState.Closed) { database.Open(); }
            SqlDataReader reader = command.ExecuteReader();  // SqlDataReader for online database, SqlDataAdapter for offline database

            DataTable dataTable = new DataTable();
            dataTable.Load(reader); // after ExecuteReader() which performs query on database Load the reader into datatable which convert to rows and coulmns


            if (database.State == ConnectionState.Open) { database.Close(); }

            return dataTable;

        }


        // Check if user is already registered returns true if it is, otherwise false.
        public Boolean IsRegistered(string Username, string Password)
        {


            String procedure = "AuthUser";

            String path = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MainProject;Data Source=PC;";
            SqlConnection database = new SqlConnection(path);

            SqlCommand sqlCommand = new SqlCommand(procedure, database);

            if (database.State == ConnectionState.Closed)
            {
                database.Open();

            }

            sqlCommand.CommandType = CommandType.StoredProcedure; // CommandType is an enum {} 

            sqlCommand.Parameters.Add("@Username", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Username"].Value = Username;

            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Password"].Value = Password;



            SqlDataReader dr = sqlCommand.ExecuteReader();// at this point dr is a cursor which points to data only and nothin more.
            dr.Read(); // now it reads data by passing keys 

            if (Convert.ToInt32(dr["Records"]) == 1)
            {

                if (database.State == ConnectionState.Open)
                {
                    database.Close();

                }
                return true;
            }
            else
            {

                if (database.State == ConnectionState.Open)
                {
                    database.Close();

                }
                return false;
            }

        }


        //                  OVERLOAD
        public Boolean IsRegistered(string Username)
        {


            String procedure = "AuthUserByName"; // Different procude where it checks for avaialbe username only without password.

            String path = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MainProject;Data Source=PC;";
            SqlConnection database = new SqlConnection(path);

            SqlCommand sqlCommand = new SqlCommand(procedure, database);

            if (database.State == ConnectionState.Closed)
            {
                database.Open();

            }

            sqlCommand.CommandType = CommandType.StoredProcedure; // CommandType is an enum {} 

            sqlCommand.Parameters.Add("@Username", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Username"].Value = Username;

            
            SqlDataReader dr = sqlCommand.ExecuteReader();// at this point dr is a cursor which points to data only and nothin more.
            dr.Read(); // now it reads data by passing keys 

            if (Convert.ToInt32(dr["Records"]) == 1)
            {

                if (database.State == ConnectionState.Open)
                {
                    database.Close();

                }
                return true;
            }
            else
            {

                if (database.State == ConnectionState.Open)
                {
                    database.Close();

                }
                return false;
            }

        }


        public static Boolean  InsertUser (String Username, String Password, String Email, int Phone)

        {

            String procedure = "addUser";

            String path = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MainProject;Data Source=PC;";

            try
            {


            
            SqlConnection database = new SqlConnection(path);

            SqlCommand sqlCommand = new SqlCommand(procedure, database);

            if (database.State == ConnectionState.Closed)
            {
                database.Open();

            }

            sqlCommand.CommandType = CommandType.StoredProcedure; // CommandType is an enum {} 

            sqlCommand.Parameters.Add("@Username", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Username"].Value = Username;

            sqlCommand.Parameters.Add("@Password", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Password"].Value = Password;

            sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Email"].Value = Email;

            sqlCommand.Parameters.Add("@Phone", SqlDbType.NVarChar);
            sqlCommand.Parameters["@Phone"].Value = Phone;



            int rows = sqlCommand.ExecuteNonQuery(); // this return an int as for the numbers of rows that have been inserted
                // at this point dr is a cursor which points to data only and nothin more.
                                                    //Don't need SqlDataReader and don't need dr.Read() cuz ExecuteNonQuery(); only writes to the Database 

                if (rows > 0)
                {
                    if (database.State == ConnectionState.Open)
                    {
                        database.Close();


                    }
                    
                    return true; 
                }
                else
                {
                    if (database.State == ConnectionState.Open)
                    {
                        database.Close();


                    }
                    return false; 
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
           

        }


        public static Boolean insertContactSubmission(string FullName, string Email, string Description )
        {


            String path = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MainProject;Data Source=PC;";

            string Proc = "InsertContact";

            try {

                SqlConnection database = new SqlConnection(path);

                if (database.State == ConnectionState.Closed )
                {
                    database.Open();
                }


                SqlCommand sqlCommand = new SqlCommand(Proc, database);

                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add("@FullName", SqlDbType.NVarChar );
                sqlCommand.Parameters["@FullName"].Value = FullName;
                
                sqlCommand.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCommand.Parameters["@Email"].Value = Email;

                sqlCommand.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCommand.Parameters["@Description"].Value =   Description;

               int rows =  sqlCommand.ExecuteNonQuery();


 
               if (rows > 0 )
                {
                    if (database.State == ConnectionState.Open)
                    {
                        database.Close();
                    }
                    return true;

                }
               else
                {
                    if (database.State == ConnectionState.Open)
                    {
                        database.Close();

                    }
                    return false;

                }

            } catch (Exception ex) {

                throw ex;
            }
        }
    }
}

/* First  : create project within solution : DAL
 * right click DAL - properties - signing - check on assembly - pick new from down below - uncheck password - pick algoritihm and ok.
 * 
 * Second : go SQL management software, right click green icon , get database server name by copy paste
 * 
 * Third : create file on desktop : connection.UDL  - double click - proprties or somethin - pick native server sql client 10.0 - paste the name - pick Windows NT
 * pick table - test the connection - then close
 * 
 * Four : Edit connecntion.UDL with any editor then copy   @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MainProject;Data Source=PC;"; 
 * 
 * DELETE Provider=SQLNCLI10.1;   Initial File Name="";Server SPN = ""  User ID = ""; 
 * 
 * using System.Data.SqlClient;
 * 
 * Five : don't forget to add reference
 * 
 * always delete these from path   Provider = SQLNCLI10.1; Initial File Name=""; Server SPN = "" 
 * SSPI security support provider interface
 * 
 */