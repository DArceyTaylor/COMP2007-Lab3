using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMP2007_Lab3.Models;
using System.Web.ModelBinding;

namespace COMP2007_Lab3
{
    public partial class DepartmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // redirect back to Departments page
            Response.Redirect("~/Departments.aspx");
        }


        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // use EF to connect to the server
            using (DefaultConnection db = new DefaultConnection())
            {
                // use the Student model to create a new student object and
                // save a new record
                Department newDepartment = new Department();

                // add data to the new student record
                newDepartment.Name = DepartmentNameTextBox.Text;
                newDepartment.Budget = Convert.ToDecimal(BudgetTextBox.Text);

                // use LINQ to ADO.NET to add / insert new student to the db
                db.Departments.Add(newDepartment);

                // save our changes
                db.SaveChanges();

                // redirect back to the updated students page
                Response.Redirect("~/Departments.aspx");
            }
        }
    }
}