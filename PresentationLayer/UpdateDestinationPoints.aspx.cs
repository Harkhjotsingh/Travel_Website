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
    public partial class UpdateDestinationPoints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!IsPostBack)
            {
                txtDestinationID.Text = Session["d_id"].ToString();
                txtDestinationLocation.Text = Session["d_station"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDestinationLocation.Text == "")
            {
                lblDestinationLocation.Text = "*Please Enter a Destinatoin Location";
            }
            else
            {
                lblDestinationLocation.Text = "*";
                BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
                bussinessObject.DestinationId = txtDestinationID.Text;
                bussinessObject.DestinationLocation = txtDestinationLocation.Text;
                BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
                int isLocationUpdated = bussinessLogicObject.UpdateDestinationPoint(bussinessObject);
                if (isLocationUpdated == 1)
                {
                    lblMessage.Text = "Destination Lcation Updated Successfully. Click Back to go back to View Page";
                }
                else
                {
                    Response.Write("Failed to update Destination Location. Please try again");
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewDestinationPointsInfoAdmin.aspx");
        }
    }
}