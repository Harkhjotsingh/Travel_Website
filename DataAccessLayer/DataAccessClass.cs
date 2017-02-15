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
                SqlCommand cmd = new SqlCommand("proc_addBus", conn);                         // proc_AddBus is a stored procedure that inserts values to Bus table.
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
            catch (Exception excep)                                                              // Catch Exception and Log data to Log file.
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
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
        #region EditBusDetails
        public int EditBusDetails(BussinessObjectsClass bussinessObject)                                // Edit is similar to add, insted of "insert" we have to "update" the values.
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_editBus", conn);                                      // proc_EditBus is a stored procedure that updates values in Bus table.
            cmd.CommandType = CommandType.StoredProcedure;
            // Assigning Data to Bus Details properties. 
            cmd.Parameters.AddWithValue("@BusNumber", bussinessObject.BusNumber);
            cmd.Parameters.AddWithValue("@StartPoint", bussinessObject.StartPoint);
            cmd.Parameters.AddWithValue("@Destination", bussinessObject.Destination);
            cmd.Parameters.AddWithValue("@capacity", bussinessObject.Capacity);
            cmd.Parameters.AddWithValue("@DepartureTime", bussinessObject.DepartureTime);
            cmd.Parameters.AddWithValue("@ArrivalTime", bussinessObject.ArrivalTime);
            cmd.Parameters.AddWithValue("@CompanyName", bussinessObject.CompanyName);
            cmd.Parameters.AddWithValue("@BusType", bussinessObject.BusType);
            int isquerySuccessful = cmd.ExecuteNonQuery();
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
        #region AutoGeneratePickupIds
        public string AutoGenPickupIDs()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_autoGenPickupIDs", conn);                                      // proc_autoGenPickupIDs is a stored procedure that auto-generates Bus Pickup IDs.
            cmd.CommandType = CommandType.StoredProcedure;
            string isquerySuccessful = cmd.ExecuteScalar().ToString();                                           // ExcecuteScalar() will last pp_id from pickupPoint table.
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
        #region AddBusPickupInfo
        public int AddBusPickupInfo(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_addBusPickupInfo", conn);                                      // proc_addBusPickupInfo is a stored procedure that adds values in Bus table.
            cmd.CommandType = CommandType.StoredProcedure;
            // Assigning Data to Bus Details properties. 
            cmd.Parameters.AddWithValue("@pp_id", bussinessObject.PickupId);                                     // inserting values to the table.  
            cmd.Parameters.AddWithValue("@pp_station", bussinessObject.PickupLocation);
            int isquerySuccessful = cmd.ExecuteNonQuery();
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
        #region ViewPickupPointsAdmin
        public DataSet ViewPickupPointsInfo()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_viewPickupPointsInfo", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);                                        // DataADapter object 
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();                                                         // DataSet object to store data locally.
            da.Fill(ds);                                                        // Fill data from DataAdapter DataSet object.     
            conn.Close();
            return ds;                                                                          // return DataSet.    
        }
        #endregion
        #region DeletePickupPoints
        public int DeletePickupPoints(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_deletePickupPoint", conn);
            cmd.CommandType = CommandType.StoredProcedure;                                                             // Stored Procedure to delete Pickup Point details by PickupId(pp_id)
            cmd.Parameters.AddWithValue("@pp_id", bussinessObject.PickupId);
            int isquerySuccessful = cmd.ExecuteNonQuery();
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
        #region GetBusNumber,StartPoint and Destination for BusPickup Point
        public SqlDataReader BusInfoForBusPickupPoint()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_BusNumToAndFromPlace", conn);                                      // Retrives BusNumber, starting point and Destination.
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            //conn.Close();                                                                                          // Need to find a way to close connection, as if its closed here SqlDataReader cannot be used. 
            return dr;
        }
        #endregion
        #region AddBusSpecificPickupPoint
        public int AddBusSpecificPickupPoint(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_addBusSpecificPickupPoint", conn);                                      // proc_addBusSpecificPickupPoint is a stored procedure that updates values in BusPickupPoints table.
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BusNumber", bussinessObject.BusNumber);                                         // inserting values to the table.  
            cmd.Parameters.AddWithValue("@pp_id", bussinessObject.PickupId);
            int isquerySuccessful = cmd.ExecuteNonQuery();
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
        #region AutoGenerateDestinationIds
        public string AutoGenDestinationIDs()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_autoGenDestinationIDs", conn);                                 // proc_autoGenDestinationIDs is a stored procedure that auto-generates Destination IDs.
            cmd.CommandType = CommandType.StoredProcedure;
            string previousID = cmd.ExecuteScalar().ToString();                                                  // ExcecuteScalar() will return last d_id from Destination table.
            conn.Close();
            return previousID;
        }
        #endregion
        #region AddBusDestinationInfo
        public int AddBusDestinationInfo(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_addBusDestinationInfo", conn);                                  // proc_addBusDestinationInfo is a stored procedure that add Destination Id and Locations in Bus table.
            cmd.CommandType = CommandType.StoredProcedure;
            // Assigning Data to Bus Details properties. 
            cmd.Parameters.AddWithValue("@d_id", bussinessObject.DestinationId);
            cmd.Parameters.AddWithValue("@d_station", bussinessObject.DestinationLocation);
            int isquerySuccessful = cmd.ExecuteNonQuery();
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
        #region ViewDestinationPointsAdmin
        public DataSet ViewDestinationPointsInfo()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_viewDestinationPointsInfo", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);                                        // DataADapter object 
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();                                                         // DataSet object to store data locally.
            da.Fill(ds);                                                                        // Fill data from DataAdapter DataSet object.     
            conn.Close();
            return ds;
        }
        #endregion
        #region DeleteDestinationPoints
        public int DeleteDestinationPoints(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_deleteDestinationPoint", conn);
            cmd.CommandType = CommandType.StoredProcedure;                                                             // Stored Procedure to delete Destination Point details by DestinationId(d_id)
            cmd.Parameters.AddWithValue("@d_id", bussinessObject.DestinationId);
            int isquerySuccessful = cmd.ExecuteNonQuery();
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
        #region UpdateDestinationPoints
        public int UpdateDestinationPoints(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_updateDestinationPoints", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@d_id", bussinessObject.DestinationId);
            cmd.Parameters.AddWithValue("@d_station", bussinessObject.DestinationLocation);
            int isQuerySuccessfull = cmd.ExecuteNonQuery();
            return isQuerySuccessfull;
        }
        #endregion
        #region AddBusSpecificDestinationPoints
        public int AddBusSpecificDestinationPoints(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_addBusSpecificDestinationPoints", conn);                                      // proc_addBusSpecificDestinationPoints is a stored procedure that updates values in BusDestination table.
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BusNumber", bussinessObject.BusNumber);                                           
            cmd.Parameters.AddWithValue("@d_id", bussinessObject.DestinationId);
            int isquerySuccessful = cmd.ExecuteNonQuery();
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
        #region DestinationPointsBasedOnBusNumber
        public DataSet DestinationPointsBasedOnBusNumber(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_getDestinationPointsBasedOnBusNumber", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);                                                             // DataADapter object 
            cmd.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();                                                                              // DataSet object to store data locally.
            cmd.Parameters.AddWithValue("@BusNumber", bussinessObject.BusNumber);
            da.Fill(ds);                                                                                             // Fill data from DataAdapter DataSet object.     
            conn.Close();
            return ds;                                                                                               // return DataSet.    
        }
        #endregion
        #region AddFare
        public int AddFare(BussinessObjectsClass bussinessObject)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_str"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("proc_addFare", conn);                                      
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BusNumber", bussinessObject.BusNumber);                                    
            cmd.Parameters.AddWithValue("@Start_id", bussinessObject.FromDepartureID);
            cmd.Parameters.AddWithValue("@From_depTime", bussinessObject.FromDepartureTime);
            cmd.Parameters.AddWithValue("@Destination_id", bussinessObject.ToDestinationID);
            cmd.Parameters.AddWithValue("@To_depTime", bussinessObject.ToDepartureTime);
            cmd.Parameters.AddWithValue("@Fare", bussinessObject.Fare);
            int isquerySuccessful = cmd.ExecuteNonQuery();
            conn.Close();
            return isquerySuccessful;
        }
        #endregion
    }
}
