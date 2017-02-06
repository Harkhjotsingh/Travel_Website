using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BussinessObjectsNamespace;


namespace DataAccessNamespace
{
    public class DataAccessClass                                                    // This Class interracts with dataBase and Bussiness Logic Layer.It contains ADO.NET code.
    {
        #region AddBus
        public int AddBus(BussinessObjectsNamespace.BussinessObjectsClass bussinessObject)
        {
            int isquerySuccessful = -9999999;                                                  // Its used to see if query got excecuted successdully. -9999999 is just an unreachable number used to be safe. 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            // try catch block to catch any runtime Exceptions.
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("proc_AddBus", conn);                         // proc_AddBus is a stored procedure that inserts values to Bus table.
                cmd.CommandType = CommandType.StoredProcedure;                                // Working with stored procedure.
                // Assigning Data to Bus Details properties. 
                cmd.Parameters.AddWithValue("@BusNumber", bussinessObject.BusNumber);
                cmd.Parameters.AddWithValue("@StartPoint", bussinessObject.StartPoint);
                cmd.Parameters.AddWithValue("@Destination", bussinessObject.Destination);
                cmd.Parameters.AddWithValue("@capacity", bussinessObject.Capacity);
                cmd.Parameters.AddWithValue("@DepartureTime", bussinessObject.DepartureTime);
                cmd.Parameters.AddWithValue("@ArrivalTime", bussinessObject.ArrivalTime);
                cmd.Parameters.AddWithValue("@CompanyName", bussinessObject.CompanyName);
                cmd.Parameters.AddWithValue("@BusType", bussinessObject.BusType);
                isquerySuccessful = cmd.ExecuteNonQuery();                                     // ExecuteNonQuery() returns value of how many queries got successfully executed.
            }
            catch(Exception excep)                                                              // Catch Exception and Log data to Log file.
            {
                string filePath = @"D:\_.NET\Projects\Travel_Website\ExceptionLogs.txt";
                StreamWriter sw = new StreamWriter(filePath);                                   // Stream writer object.
                sw.WriteLine("Type of Excpetion: " + excep.GetType().Name);                     // Logs the type of the exception.
                sw.WriteLine("Exception Message: " + excep.Message);                            // Logs the exception message thrown by the Exception class.
                sw.Write("Line of exception: " + excep.StackTrace);                             // Exactly on which solution/project/file/line the exception has occured.
                sw.Close();                                                                     // Free the resources.
            }
            conn.Close();                                                                       // Close the opened connection and return isquerySuccessful value(1 is successfull, 0 if not). 
            return isquerySuccessful;
        }
        #endregion
        #region ViewBusDetailsAdmin
        public DataSet ViewBusAdmin()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_viewBusDetailsAdmin", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);                                        // DataADapter object 
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();                                                         // DataSet object to store data locally.
            da.Fill(ds);                                                                        // Fill data from DataAdapter DataSet object.     
            conn.Close();
            return ds;                                                                          // return DataSet.    
        }
        #endregion
        #region DeleteBus
        public int DeleteBus(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString()); 
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_deleteBus", conn);
            cmd.CommandType = CommandType.StoredProcedure;                                                             // Stored Procedure to delete Bus details by BusNumber
            cmd.Parameters.AddWithValue("@BusNumber", bussinessObject.BusNumber);                                
            int isquerySuccessful = cmd.ExecuteNonQuery();                                                             // returns return value of ExecuteNonQuery() method i.e 1 for success and 0 for failure.
            return isquerySuccessful;
        }
        #endregion
    }
}
