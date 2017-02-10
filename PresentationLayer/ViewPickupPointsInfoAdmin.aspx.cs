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
    public partial class ViewPickupPointsInfoAdmin : System.Web.UI.Page
    {
        private void GetPickupPointDetails()                                                // Gets the data from BussinessLogic Layer and binds it with Grid view control(gridViewPickupPoints).
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            DataSet ds = bussinessLogicObject.ViewPickupPoints();                            // Call ViewPickupPoints() function from Bussiness logic Layer.     
            gridViewPickupPoints.DataSource = ds;                                            // Define the above created dataset as DataSource of the gridViewPickupPoints.   
            gridViewPickupPoints.DataBind();                                                 // Bind data.
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)                                                                // Load Pickup Point details when the page loads.
            {
                GetPickupPointDetails();
            }
        }

        protected void gridViewPickupPoints_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
            string pickupID = gridViewPickupPoints.DataKeys[e.RowIndex].Value.ToString();             // getting pickup ID
            bussinessObject.PickupId = pickupID;
            int isDeleteSuccessful = bussinessLogicObject.DelPickupPoint(bussinessObject);            // passing the pickup ID via bussinessObject's object.
            if (isDeleteSuccessful == 1)                                                              // if deletetion successful
            {
                Response.Write("PickupPoint entry is Deleted");                                       
                GetPickupPointDetails();                                                              // Update gridViewPickupPoints on page for user to see. 
            }
            else
            {
                Response.Write("Could not delete PickupPoint entry. Please try again");                
            }
        }
    }
}
