using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace personal_page_info
{
    public partial class Register : System.Web.UI.Page
    {
        string username;
        string email;
        string password;
        string confirmPassword;
        int regcode;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các điều khiển nhập
            username = txtUserName.Text.Trim();
            email = txtEmail.Text.Trim();
            password = txtPassword.Text.Trim();
            confirmPassword = TextBox1.Text.Trim();
            
            // Kiểm tra xem regCode có đúng định dạng số hay không
            try
            {
                regcode = Convert.ToInt32(txtregcode.Text.Trim());
            }
            catch (Exception)
            {
                regnotify.Text = "Invalid Register Code"; // Thông báo lỗi khi Register Code không phải là số
                return;
            }

            // Kiểm tra mật khẩu và mật khẩu xác nhận có trùng khớp hay không
            if (password != confirmPassword)
            {
                regnotify.Text = "Passwords do not match"; // Thông báo lỗi khi mật khẩu không trùng khớp
                return;
            }

            // Kiểm tra xem đã có người dùng có cùng regcode trong cơ sở dữ liệu chưa
            using (userE context = new userE())
            {
                bool existingCode = context.users.Any(u => u.code == regcode);
                bool existingUser = context.users.Any(u => u.Id == username);
                if (!existingCode)
                {
                    regnotify.Text = "Register Code is incorrect"; // Thông báo lỗi khi regcode không đúng
                    return;
                }
                if (existingUser)
                {
                    regnotify.Text = "This UserName already exists, please use another UserName";
                    return;
                }
                user user = context.users.FirstOrDefault(u => u.code == regcode);
                // Cập nhật thông tin cho người dùng đã tồn tại
                user.Id = username;
                user.Password = password;
                user.Email = email;
                // Cập nhật các thông tin khác tương tự

                context.SaveChanges();
                regnotify.Text = "Registration Successful"; // Thông báo đăng ký thành công
            }
        }
    }
}