using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace personal_page_info
{
    public partial class Admin1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsersData();
            }
        }
        private void LoadUsersData()
        {
            using (userE context = new userE())
            {
                var users = context.users.Select(u => new
                {
                    u.code,
                    u.Id,
                    u.Name,
                    u.Email,
                    u.Phone,
                }).ToList();
                GridViewUsers.DataSource = users;
                GridViewUsers.DataBind();
            }
            SetSelectedPaidValueForGrid();
        }
        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DeleteRow")
            {
                // Lấy code của bản ghi để xóa từ GridView
                GridViewRow row = GridViewUsers.Rows[rowIndex];
                int code = Convert.ToInt32(row.Cells[0].Text);

                // Xóa bản ghi từ cơ sở dữ liệu
                using (userE context = new userE())
                {
                    var userToDelete = context.users.FirstOrDefault(u => u.code == code);
                    if (userToDelete != null)
                    {
                        context.users.Remove(userToDelete);
                        context.SaveChanges();
                    }
                }
            }
            //BindGridView();
            LoadUsersData();
        }

        private void SetSelectedPaidValueForGrid()
        {
            foreach (GridViewRow row in GridViewUsers.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList Paid_Check = (DropDownList)row.FindControl("Paid_Check");
                    if (Paid_Check != null)
                    {
                        int code = Convert.ToInt32(row.Cells[0].Text);
                        using (userE context = new userE())
                        {
                            var user = context.users.FirstOrDefault(u => u.code == code);
                            if (user != null)
                            {
                                Paid_Check.SelectedIndex = (int)user.Paid;
                            }
                        }
                    }
                }
            }
        }
        protected void AddNewUser_Click(object sender, EventArgs e)
        {
            bool isCodeExists = false;
            int randomCode = GenerateUniqueRandomCode();

            // create new user
            user newUser = new user();
            newUser.code = randomCode;
            newUser.Paid = 0;

            // Add new user to database if Regrister Code not Exists
            using (userE context = new userE())
            {
                isCodeExists = context.users.Any(u => u.code == randomCode);
                while (isCodeExists)
                {
                    randomCode = GenerateUniqueRandomCode();
                    newUser.code = randomCode;
                    isCodeExists = context.users.Any(u => u.code == randomCode);
                }

                context.users.Add(newUser);

                context.SaveChanges();
            }
            LoadUsersData();
        }
        private int GenerateUniqueRandomCode()
        {
            Random rand = new Random();
            int randomCode = rand.Next(3000, 5000);
            return randomCode;
        }

        protected void updatePaidStatus(object sender, EventArgs e)
        {
            DropDownList Paid_Check = (DropDownList)sender;
            GridViewRow row = (GridViewRow)Paid_Check.NamingContainer;
            int code = Convert.ToInt32(row.Cells[0].Text);

            using (userE context = new userE())
            {
                var userToUpdate = context.users.FirstOrDefault(u => u.code == code);
                userToUpdate.Paid = Convert.ToInt16(Paid_Check.SelectedIndex);
                context.SaveChanges();
                Debug.WriteLine(userToUpdate.Paid);
            }
            LoadUsersData();
        }
    }
}
