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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            BussinessLogicClass bussinessLogic = new BussinessLogicClass();             // Business logic class object. This allows Presentation Layer to interact with Bussiness logic layer.
            BussinessObjectsClass bussinessObject = new BussinessObjectsClass();        // Bussiness Objects class object. This allows Presentation Layer to interact with Bussiness Objects layer.
            bussinessObject.UserName = UserName.Text;                                   // Accessing properties defined in Bussiness Object class for username and password.
            bussinessObject.Password = Password.Text;
            int loginAttempt = bussinessLogic.AdminLogin(bussinessObject);              // Call AdminLogin() method fo admin login
            if (loginAttempt == 1)                                                      // Redirect to AdminHime.aspx page if return value = 1. 
            {
                Response.Redirect("AdminHome.aspx");
            }
            else
            {
                FailureText.Text = "Either the username or password is incorrect.";
            }
        }
    }
}