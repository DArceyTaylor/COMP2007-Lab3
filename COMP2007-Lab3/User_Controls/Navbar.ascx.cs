using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * @author: D'Arcey Taylor
 * @date: June 02, 2015
 * @version: 0.0.2 added SetActivePage method to include new links
**/
namespace COMP2007_Lab3
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetActivePage();
        }
        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
        **/
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Home Page":
                    Home.Attributes.Add("class", "active");
                    break;
                case "Students":
                    Students.Attributes.Add("class", "active");
                break;
                case "Courses":
                    Courses.Attributes.Add("class", "active");
                break;
                case "Departments":
                    Departments.Attributes.Add("class", "active");
                break;
                case "Contact":
                    Contact.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}