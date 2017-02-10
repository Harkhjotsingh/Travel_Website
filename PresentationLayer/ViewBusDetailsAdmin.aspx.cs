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
            string busNumber = gridBusDetails.DataKeys[e.RowIndex].Value.ToString();            // getting bus number 
            bussinessObject.BusNumber = busNumber;
            int isDeleteSuccessful = bussinessLogicObject.DeleteBus(bussinessObject);           // passing the bus number via bussinessObject's object.
            if(isDeleteSuccessful == 1)                                                         // if deletes successfull
            {
                Response.Write("Bus entry is Deleted");                                         // Show user message
                GetBusDetails();                                                                // Update gridBusDetails on page for user to see. 
            }
            else
            {
                Response.Write("Could not delete Bus entry. Please try again");                    // else show error message.
            }
        }

        protected void gridBusDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)    // Page index change event. Each page can display upto 4 records.
        {
            gridBusDetails.PageIndex = e.NewPageIndex;
            GetBusDetails();
        }

        protected void gridBusDetails_RowEditing(object sender, GridViewEditEventArgs e)         // Change to dynamic editing-view once the user clicks edit button.  
        {
            gridBusDetails.EditIndex = e.NewEditIndex;                                           // Change index value, its "-1" by default which is for static view.
            GetBusDetails();
        }

        protected void gridBusDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)  // If user hit cancel, change back to static view, i.e EditIndex = -1
        {
            gridBusDetails.EditIndex = -1;
            GetBusDetails();
        }

        protected void gridBusDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
            GridViewRow row = (GridViewRow)gridBusDetails.Rows[e.RowIndex];                         // Get the number of rows in the gridview and the index where user clicked edit.
            TextBox bNum = (TextBox)row.FindControl("txt_bNumber");                                 // Find the control in which the user has edited the value.
            bussinessObject.BusNumber = bNum.Text;                                                  // Assign the properties in the business-object layer with te user entered values.  
            TextBox sPoint = (TextBox)row.FindControl("txt_sPoint");
            bussinessObject.StartPoint = sPoint.Text;
            TextBox dest = (TextBox)row.FindControl("txt_dest");
            bussinessObject.Destination = dest.Text;
            TextBox cap = (TextBox)row.FindControl("txt_cap");
            bussinessObject.Capacity = int.Parse(cap.Text);
            TextBox dTime = (TextBox)row.FindControl("txt_dTime");
            bussinessObject.DepartureTime = dTime.Text;
            TextBox aTime = (TextBox)row.FindControl("txt_aTime");
            bussinessObject.ArrivalTime = aTime.Text;
            TextBox cName = (TextBox)row.FindControl("txt_cName");
            bussinessObject.CompanyName = cName.Text;
            TextBox bType = (TextBox)row.FindControl("txt_bType");
            bussinessObject.BusType = bType.Text;
            int isEditProcessSuccessfull = bussinessLogicObject.EditBus(bussinessObject);            // Passing above values to Edit bus function. 
            if(isEditProcessSuccessfull == 1)                                                        // If query execution returns 1, update records and switch back to static view with updated data.   
            {
                Response.Write("Bus details Edited Successfully");
                gridBusDetails.EditIndex = -1;
                GetBusDetails();

            }
            else
            {
                Response.Write("Unable to Edit bus details.Please try again");
                GetBusDetails();
            }
        }
    }
}
