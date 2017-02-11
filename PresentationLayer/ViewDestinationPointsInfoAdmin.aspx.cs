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
    }
}