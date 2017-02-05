using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinessObjectsNamespace;
using BussinessLogicNamespace;

namespace PresentationLayer
{
    public partial class AddBus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddBus_Click(object sender, EventArgs e)
        {
            // Assigning data Entered by user to Bussiness Object properties for Bus Details. 
            BussinessObjectsClass bussinessObject = new BussinessObjectsClass();
            bussinessObject.BusNumber = TxtBusNumber.Text;
            bussinessObject.StartPoint = TxtStratingPoint.Text;
            bussinessObject.Destination = TxtDestination.Text;
            bussinessObject.Capacity = int.Parse(TxtCapacity.Text);                         // since Capacity is int-type, user string is parsed back to int.
            bussinessObject.DepartureTime = TxtDepartureTime.Text;
            bussinessObject.ArrivalTime = TxtArrivalTime.Text;
            bussinessObject.CompanyName = TxtCompanyName.Text;
            bussinessObject.BusType = ListBusType.SelectedItem.Text;

            BussinessLogicClass bussinessLogicObject = new BussinessLogicClass();
            int isProcessSucessful = bussinessLogicObject.AddBus(bussinessObject);     // Addbus() method from Bussiness logic layer called and return value stored in variable isProcessSuccessful.
            if (isProcessSucessful == 1)                                               // If return value is 1, display "Bus added Successfully." else display apprpriate error messages.
            {
                Response.Write("Bus added Successfully.");
            }
            else
            { 
                Response.Write("Cannot add bus details,please try again!");            // This could also be an actual exception/error message.
            }
        }
    }
}