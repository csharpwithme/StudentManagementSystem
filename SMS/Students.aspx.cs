using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.BLL;

namespace SMS
{
    public partial class Students : System.Web.UI.Page
    {
        // Use your BLL class
        StudentBLL bll = new StudentBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        // Bind GridView with all students
        private void BindGrid()
        {
            DataTable dt = bll.GetAllStudents();

            // Sort ascending by Name
            DataView dv = dt.DefaultView;
            dv.Sort = "Name ASC"; // or "StudentID ASC" for ID order

            GridView1.DataSource = dv;
            GridView1.DataBind();
        }

        // Add or Update student
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                int age = int.Parse(txtAge.Text.Trim());
                string course = txtClass.Text.Trim();

                // Check if editing or adding
                if (btnAdd.Text == "Add Student")
                {
                    bll.CreateStudent(name, age, course);
                }
                else if (btnAdd.Text == "Update Student")
                {
                    int id = int.Parse(hfStudentID.Value); // HiddenField to store StudentID
                    bll.UpdateStudent(id, name, age, course);
                    btnAdd.Text = "Add Student"; // Change button text back
                }

                ClearFields();
                BindGrid();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        // Load selected row into textboxes for editing
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.NewEditIndex].Value);
            DataTable dt = bll.GetStudentById(id);

            if (dt.Rows.Count > 0)
            {
                hfStudentID.Value = dt.Rows[0]["StudentID"].ToString(); // store id in HiddenField
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtAge.Text = dt.Rows[0]["Age"].ToString();
                txtClass.Text = dt.Rows[0]["Class"].ToString();
                btnAdd.Text = "Update Student"; // change button text
            }

            e.Cancel = true; // prevent GridView inline editing
        }

        // Delete student
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            bll.DeleteStudent(id);
            BindGrid();
        }

        // Optional: clear textboxes
        private void ClearFields()
        {
            txtName.Text = "";
            txtAge.Text = "";
            txtClass.Text = "";
            hfStudentID.Value = "";
        }
    }
}
