using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using BussinessLogicNamespace;
using BussinessObjectsNamespace;

namespace PresentationLayer
{
    public partial class AddBusSpecific_PickupPoints : System.Web.UI.Page
    {
        private void BindBusInfo()                                                                       // Shows BusInfo in Select Bus dropdown-list. 
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            SqlDataReader dr = bussinessLogicObject.BusInfoForBusPickupPoint();                          // Get data reader from Bussiness Logic Layer.
            if(dr.HasRows)                                                                               // if the table contain row(s)   
            {
                while(dr.Read())
                {
                    //get BusNumber, StartingPoint and Destination from each row.
                    string busNumber = dr[0].ToString();
                    string stratingPoint = dr[1].ToString();
                    string destination= dr[2].ToString();
                    string info = busNumber + " / " + stratingPoint + " to " + destination;              // Show info in form of <busNumber> / <stratingPoint> to <destination> 
                    ddlSelectBus.Items.Add(info);
                }
                
            }
        }
        private void BindPickupPoints()                                                                  // Shows all PickupPoints in Select Pickup Point dropdown-list. 
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            // Using same method used for Admin to view Pickup Points.
            DataSet ds = bussinessLogicObject.ViewPickupPoints();                                        // Since return type of ViewPickupPoints() method is DataSet, save results in DataSet ds. 
            ddlSelectPickupPoint.DataSource = ds;                                                        // Set DataSource for Select PickupPoint List as ds.
            ddlSelectPickupPoint.DataTextField = "pp_station";                                           // Show Pickup Location in the list.
            ddlSelectPickupPoint.DataValueField = "pp_id";                                               // Save Pickup Id as value. This is used later to add values in BusPickupPoint table. 
            ddlSelectPickupPoint.DataBind();                                                             // DataBind   
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                // Load both dropdown list on page load
                BindBusInfo();
                BindPickupPoints();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
            bussinessObject.PickupId = ddlSelectPickupPoint.SelectedValue.ToString();                     // Get PickupId(pp_id) from the list.
            string selectedBus = ddlSelectBus.SelectedItem.ToString();                                    // Get Selected Bus from the list.  
            string[] busInfo = selectedBus.Split('/');                                                    // Split the string to extract BusNumber from the String.  
            bussinessObject.BusNumber = busInfo[0].ToString();
            int isProcessSuccessfull = bussinessLogicObject.AddBusSpecificPickupPoint(bussinessObject);   // Add values to table  
            if(isProcessSuccessfull == 1)
            {
                Response.Write("Bus pickup point added Successfully");
            }
            else
            {
                Response.Write("Could not add Bus Pickup Point. Please try again");
            }
        }
    }
}