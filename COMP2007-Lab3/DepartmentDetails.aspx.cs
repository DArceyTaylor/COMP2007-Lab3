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
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetDepartment();
            }
        }

        protected void GetDepartment()
        {
            // populate the form with existing data from the database
            int DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            //connect to the EF framework
            using (DefaultConnection db = new DefaultConnection())
            {
                //populate a student object instance with the StudentID from the URL paramerter
                Department updatedDepartment = (from department in db.Departments
                                                where department.DepartmentID == DepartmentID
                                                select department).FirstOrDefault();

                //map the student properties to the form controls
                if (updatedDepartment != null)
                {
                    DepartmentNameTextBox.Text = updatedDepartment.Name;
                    BudgetTextBox.Text = updatedDepartment.Budget.ToString();
                }
            }
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

                int DepartmentID = 0;

                if (Request.QueryString.Count > 0)// our URL contains a StudentID
                {
                    //get the ID from the URL
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    //get the current student from the EF db
                    newDepartment = (from department in db.Departments
                                     where department.DepartmentID == DepartmentID
                                     select department).FirstOrDefault();
                }

                // add data to the new student record
                newDepartment.Name = DepartmentNameTextBox.Text;
                if(BudgetTextBox.Text != "")
                {
                    newDepartment.Budget = Convert.ToDecimal(BudgetTextBox.Text);
                }

                // use LINQ to ADO.NET to add / insert new student to the db
                if (DepartmentID == 0)
                {
                    db.Departments.Add(newDepartment);
                }

                // save our changes
                db.SaveChanges();

                // redirect back to the updated students page
                Response.Redirect("~/Departments.aspx");
            }
        }
    }
}