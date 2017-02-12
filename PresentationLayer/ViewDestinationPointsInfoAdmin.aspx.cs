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
    public partial class ViewDestinationPointsInfoAdmin : System.Web.UI.Page
    {
        private void GetDestinationInfo()
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            DataSet ds = bussinessLogicObject.ViewDestinationPoints();
            gridViewDestinationPoints.DataSource = ds;
            gridViewDestinationPoints.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetDestinationInfo();
            }
        }

        protected void gridViewDestinationPoints_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName.ToString() == "cmdDelete")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument.ToString());
                GridViewRow row = (GridViewRow)gridViewDestinationPoints.Rows[rowIndex];
                Label destID = (Label)row.FindControl("lblDestinationId");
                BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
                bussinessObject.DestinationId = destID.Text;
                BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
                int isDestinationDeleted = bussinessLogicObject.DelDestinationPoint(bussinessObject);
                if(isDestinationDeleted == 1)
                {
                    Response.Write("Destination point deleted successfully");
                    GetDestinationInfo();
                }
                else
                {
                    Response.Write("Failed to delete the Destination Point");
                }
            }
            else if(e.CommandArgument.ToString() == "cmdUpdate")
            {

            }
        }
    }
}