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
            DataSet ds = bussinessLogicObject.DestinationPointsBasedOnBusNumber(bussinessObject);
            ddlFromPlace.DataSource = ds;
            ddlFromPlace.DataValueField = "d_station";
            ddlFromPlace.DataBind();
            ddlToPlace.DataSource = ds;
            ddlToPlace.DataValueField = "d_station";
            ddlToPlace.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindBusInfo();
            }
        }

        protected void ddlBusNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDestinationsPointsBasedOnBusNumber();
        }
    }
}