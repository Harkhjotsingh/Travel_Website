using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessLogicNamespace;
using BussinessObjectsNamespace;

namespace PresentationLayer
{
    public partial class AddDestinationIDs : System.Web.UI.Page
    {
        public void AutoGenDestinationIDs()
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            string DestinationID = bussinessLogicObject.AutoGenDestinationIDs();
            txtDestinationID.Text = DestinationID;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AutoGenDestinationIDs();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtDestinationLocation.Text == "")                                                        // TextBox validation. Make sure user enters a Pickup Location.      
            {
                lblDestinationLocation.Text = "*Please enter a Pickup Location";
                txtDestinationLocation.Focus();
                lblMessage.Text = "";
            }
            else
            {
                lblDestinationLocation.Text = "";
                BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
                BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
                bussinessObject.DestinationId = txtDestinationID.Text;                                 // Pass Destination-Id from front-end to DestinationId Property in BussinessObjects. 
                bussinessObject.DestinationLocation = txtDestinationLocation.Text;                           // Passing user entered Destination Location DestinationLocation Property in BussinessObjects. 
                int isDestinationInfoAdded = bussinessLogicObject.AddBusDestinationInfo(bussinessObject);    // Send values to Logic layer. From there to DataAccess layer and from there to Database. Return 1 if process succeeded.
                if (isDestinationInfoAdded == 1)
                {
                    lblMessage.Text = "Destination Point added Successfully.";                               // Show message. 
                    txtDestinationLocation.Text = "";                                                        // Clear TextBox
                    AutoGenDestinationIDs();                                                                 // Generate new Destination Id.
                    txtDestinationLocation.Focus();                                                          // Focus cursor to Destination Location to enter Another location.        
                }
                else
                {
                    lblMessage.Text = "Failed to add Destination point info. Please try again.";
                }
            }
        }
    }
}