using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//using statements that are required to connect to EF DB
using COMP2007_Lab3.Models;
using System.Web.ModelBinding;

namespace COMP2007_Lab3
{
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the student grid
            if (!IsPostBack)
            {
                // Get the student data
                this.GetDepartments();
            }
        }
        /**
         * <summary>
         * This method gets the student data from the DB
         * </summary>
         * 
         * @method GetStudents
         * @returns {void}
         */
        protected void GetDepartments()
        {
            // connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                // query the Students Table using EF and LINQ
                var Departments = (from allDepartments in db.Departments
                                   select allDepartments);

                // bind the result to the GridView
                DepartmentsGridView.DataSource = Departments.ToList();
                DepartmentsGridView.DataBind();
            }
        }
        /**
         * <summary>
         * this event handler deletes a student from the db using EF
         * </summary>
         * 
         * @method StudentsGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         **/

        protected void DepartmentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get selected StudentID using the Grid's DataKey Collection
            int DepartmentID = Convert.ToInt32(DepartmentsGridView.DataKeys[selectedRow].Values["DepartmentID"]);

            // use EF to find the selected student in the DB and remove it
            using (DefaultConnection db = new DefaultConnection())
            {
                //create object of the Student class and store the query string inside of it
                Department deletedDepartment = (from DepartmentRecords in db.Departments
                                                where DepartmentRecords.DepartmentID == DepartmentID
                                                select DepartmentRecords).FirstOrDefault();

                // remove the selected student from the db
                db.Departments.Remove(deletedDepartment);

                // save the changes
                db.SaveChanges();

                // refresh the grid
                this.GetDepartments();
            }
        }
        /**
         * <summary>
         * This event handler allows pagination to occur fo the students page
         * </summary>
         * @method StudentsGridView_PageIndexChanging
         * @param {object} sender
         * @param {GridViewPageEventArgs} e
         * @returns {void}
         **/

        protected void DepartmentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // set the new page number
            DepartmentsGridView.PageIndex = e.NewPageIndex;

            // refresh the grid
            this.GetDepartments();
        }

        /**
         * <summary>
         * Changes the amount of objects are on each grid view
         * </summary>
         * @method PageSizeDropDownList_SelectedIndexChanged
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         **/

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // set the new page size
            DepartmentsGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh the grid
            this.GetDepartments();
        }
    }
}