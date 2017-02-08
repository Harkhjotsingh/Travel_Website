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
        private void AutoGenPickupIDs()
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            string pickupId = bussinessLogicObject.AutoGenPickupIDs();
            txtPickupId.Text = pickupId;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AutoGenPickupIDs();
                txtPickupLocation.Focus();
            }
        }

        protected void btnAddBus_Click(object sender, EventArgs e)
        {
            if(txtPickupLocation.Text == "")
            {
                lblPickupLocation.Text = "*Please enter a Pickup Location";
                txtPickupLocation.Focus();
            }
            else
            {
                BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
                BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
                bussinessObject.PickupId = txtPickupId.Text;
                bussinessObject.PickupLocation = txtPickupLocation.Text;
                int isBusPickupInfoAdded = bussinessLogicObject.AddBusPickupPointInfo(bussinessObject);
                if(isBusPickupInfoAdded == 1)
                {
                    Response.Write("Pickup point info added Successfully");
                    txtPickupLocation.Text = "";
                    AutoGenPickupIDs();
                    txtPickupLocation.Focus();
                }
                else
                {
                    Response.Write("Failed to add Pickup point info. Please try again");
                }
            }
        }
    }
}