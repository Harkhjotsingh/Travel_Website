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
    public partial class AddBusSpecificDestinationPoints : System.Web.UI.Page
    {
        // Shows BusInfo in Select Bus dropdown-list. 
        private void BindBusInfo()                                                                        
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            SqlDataReader dr = bussinessLogicObject.BusInfoForBusPickupPoint();                           // Get data reader from Bussiness Logic Layer.
            if (dr.HasRows)                                                                               // if the table contain row(s)   
            {
                while (dr.Read())
                {
                    //get BusNumber, StartingPoint and Destination from each row.
                    string busNumber = dr[0].ToString();
                    string stratingPoint = dr[1].ToString();
                    string destination = dr[2].ToString();
                    string info = busNumber + " / " + stratingPoint + " to " + destination;               // Show info in form of <busNumber> / <stratingPoint> to <destination> 
                    ddlSelectBus.Items.Add(info);
                }

            }
        }
        //Displays all the Destination Points.
        private void GetDestinationInfo()
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            DataSet ds = bussinessLogicObject.ViewDestinationPoints();
            gridDestinationPoints.DataSource = ds;
            gridDestinationPoints.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBusInfo();
                GetDestinationInfo();
            }
        }

        protected void gridDestinationPoints_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDestinationPoints.PageIndex = e.NewPageIndex;
            GetDestinationInfo();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
            foreach (GridViewRow row in gridDestinationPoints.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("checkDestination");
                if (cb.Checked)
                {
                    Label destID = (Label)row.FindControl("lblDestinationID");
                    bussinessObject.DestinationId = destID.Text.ToString();
                    string selectedBus = ddlSelectBus.SelectedItem.ToString();
                    string[] busInfo = selectedBus.Split('/');                                                           // Split the string to extract BusNumber from the String.  
                    bussinessObject.BusNumber = busInfo[0].ToString();
                    int isProcessSuccessfull = bussinessLogicObject.AddBusSpecificDestinationPoint(bussinessObject);     // Add values to BusDestination table  
                    if (isProcessSuccessfull == 1)
                    {
                        lblMessage.Text = "Destination Points are added Successfully for " +busInfo[0].ToString();
                    }
                    else
                    {
                        lblMessage.Text = "Failed to add Bus Destination Points. Please try again.";
                    }
                }
            }
        }
    }
}