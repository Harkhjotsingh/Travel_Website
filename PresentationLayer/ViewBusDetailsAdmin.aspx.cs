using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BussinessLogicNamespace;
using BussinessObjectsNamespace;


namespace PresentationLayer
{
    public partial class ViewBusDetailsAdmin : System.Web.UI.Page
    {
        private void GetBusDetails()                                                // Gets the data from BussinessLogic Layer and binds it with Grid view control(gridBusDetails).
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            DataSet ds = bussinessLogicObject.ViewBus();                            // Call view Bus function from Bussiness logic Layer.     
            gridBusDetails.DataSource = ds;                                         // Define the above created dataset as DataSource of the gridBusDetails.   
            gridBusDetails.DataBind();                                              // Bind data.
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)                                                              // Load Bus details when the page loads.
            {
                GetBusDetails();
            }
        }

        protected void gridBusDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
            string busNumber = gridBusDetails.DataKeys[e.RowIndex].Value.ToString();
            bussinessObject.BusNumber = busNumber;
            int isDeleteSuccessful = bussinessLogicObject.DeleteBus(bussinessObject);
            if(isDeleteSuccessful == 1)
            {
                Response.Write("Bus entry is Deleted");
                GetBusDetails();
            }
            else
            {
                Response.Write("Could not delete Bus entry. Please try again");
            }
        }
    }
}