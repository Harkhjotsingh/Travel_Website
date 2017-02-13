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
    public partial class AddBusPickupPoints : System.Web.UI.Page
    {
        private void AutoGenPickupIDs()                                                              // Pass auto generated values to PickupID TextBox.
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            string pickupId = bussinessLogicObject.AutoGenPickupIDs();
            txtPickupId.Text = pickupId;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPickupLocation.Text = "*";
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                AutoGenPickupIDs();                                                                  // Show auto generated pickup id on page load 
                txtPickupLocation.Focus();
            }
        }

        protected void btnAddBus_Click(object sender, EventArgs e)
        {
            if(txtPickupLocation.Text == "")                                                        // TextBox validation. Make sure user enters a Pickup Location.      
            {
                lblPickupLocation.Text = "*Please enter a Pickup Location";
                txtPickupLocation.Focus();
            }
            else
            {
                lblPickupLocation.Text = "";
                BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
                BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
                bussinessObject.PickupId = txtPickupId.Text;                                            // Pass pickup-Id from front-end to PickupId Property in BussinessObjects. 
                bussinessObject.PickupLocation = txtPickupLocation.Text;                                // Passing user entered pickup Location PickupLocation Property in BussinessObjects. 
                int isBusPickupInfoAdded = bussinessLogicObject.AddBusPickupPointInfo(bussinessObject); // Send values to Logic layer. From there to DataAccess layer and from there to Database. Return 1 if process succeeded.
                if (isBusPickupInfoAdded == 1)
                {
                   lblMessage.Text = txtPickupLocation.Text+" is added to Pickup Points successfully."; // Show message. 
                    txtPickupLocation.Text = "";                                                        // Clear TextBox
                    AutoGenPickupIDs();                                                                 // Generate new Pickup Id.
                    txtPickupLocation.Focus();                                                          // Focus cursor to Pickup Location to enter Another location.        
                }
                else
                {
                    lblMessage.Text = "Failed to add Pickup point info. Please try again";
                }
            }
        }
    }
}