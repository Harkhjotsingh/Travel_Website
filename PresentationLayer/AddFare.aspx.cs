using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLogicNamespace;
using BussinessObjectsNamespace;
using System.Data.SqlClient;
using System.Data;

namespace PresentationLayer
{
    public partial class AddFare : System.Web.UI.Page
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
                    ddlBusNumber.Items.Add(info);
                }

            }
        }
        //Bind the Destination Points when user selects Bus from first DropDownList. 
        private void BindDestinationsPointsBasedOnBusNumber()
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
            string selectedBus = ddlBusNumber.SelectedItem.ToString();
            string[] busInfo = selectedBus.Split('/');
            bussinessObject.BusNumber = busInfo[0];
            ViewState["BusNumber"] = bussinessObject.BusNumber;                                                 // Save BusNumber for later use when Fare info is added to Fare table in DataBase
            DataSet ds = bussinessLogicObject.DestinationPointsBasedOnBusNumber(bussinessObject);
            ddlFromPlace.DataSource = ds;
            ddlFromPlace.DataTextField = "d_station";
            ddlFromPlace.DataValueField = "d_id";
            ddlFromPlace.DataBind();
            ddlToPlace.DataSource = ds;
            ddlToPlace.DataTextField = "d_station";
            ddlToPlace.DataValueField = "d_id";
            ddlToPlace.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFare.Text = lblStartTime.Text = lblArrivalTime.Text = "*";
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                BindBusInfo();
            }
        }

        protected void ddlBusNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDestinationsPointsBasedOnBusNumber();
        }

        protected void btnAddFare_Click(object sender, EventArgs e)
        {
            if(txtStartTime.Text=="")
            {
                lblStartTime.Text = "Please Enter Starting Time";
            }
            if (txtArrivalTime.Text == "")
            {
                lblArrivalTime.Text = "Please Enter Arrival Time";
            }
            if(txtFare.Text == "")
            {
                lblFare.Text = "Please enter Fare";
            }
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
            bussinessObject.BusNumber = ViewState["BusNumber"].ToString(); 
            bussinessObject.FromDepartureID = ddlFromPlace.SelectedValue.ToString();
            bussinessObject.ToDestinationID = ddlToPlace.SelectedValue.ToString();
            bussinessObject.FromDepartureTime = txtStartTime.Text.ToString();
            bussinessObject.ToDepartureTime = txtArrivalTime.Text.ToString();
            bussinessObject.Fare = Convert.ToDouble(txtFare.Text.ToString());
            int isFareAddedSuccessfully = bussinessLogicObject.AddFare(bussinessObject);
            if(isFareAddedSuccessfully == 1)
            {
                lblMessage.Text = "Fare added for Bus Number: " + ViewState["BusNumber"].ToString() + " from "+ddlFromPlace.SelectedItem.ToString() +" to " + ddlToPlace.SelectedItem.ToString() + " successfully";
            }
            else
            {
                lblMessage.Text = "Failed to add Fare info. Please try Again";
            }
        }
    }
}