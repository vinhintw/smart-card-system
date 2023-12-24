using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Security;
using System.Web.UI;

namespace personal_page_info
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ giao diện người dùng
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Thực hiện kiểm tra đăng nhập
            if (ValidateUser(username, password))
            {
                // Nếu đăng nhập thành công, lưu thông tin người dùng vào Session và chuyển hướng
                Session["UserID"] = GetUserID(username);
                Session["UserCode"] = GetUserCode(username);
                FormsAuthentication.SetAuthCookie(txtUsername.Text, false);
                Session["IsLoggedIn"] = true;
                Response.Redirect("~/Manager.aspx");
            }
            else
            {
                // Hiển thị thông báo lỗi nếu đăng nhập không thành công
                lblError.Text = "Invalid username or password.";
            }
        }

        private bool ValidateUser(string username, string password)
        {
            // Sử dụng YourDbContext
            using (userE context = new userE())
            {
                // Thực hiện kiểm tra đăng nhập với cơ sở dữ liệu
                var user = context.users.FirstOrDefault(u => u.Id.Equals(username) && u.Password.Equals(password));

                // In ra thông tin người dùng đã đăng nhập để kiểm tra
                if (user != null)
                {
                    // In ra thông tin để kiểm tra
                    Console.WriteLine($"Logged in user: {user.Id}");
                }

                return user != null;
            }
        }

        private string GetUserID(string username)
        {
            using (userE context = new userE())
            {
                var user = context.users.FirstOrDefault(u => u.Id == username);

                // Kiểm tra nếu người dùng tồn tại
                if (user != null)
                {
                    return user.Id;
                }
                else
                {
                    // Trường hợp người dùng không tồn tại, trả về giá trị mặc định hoặc null tùy theo yêu cầu của bạn
                    return null; // hoặc trả về một giá trị mặc định khác
                }
            }
        }
        private int GetUserCode(string username)
        {
            using (userE context = new userE())
            {
                var user = context.users.FirstOrDefault(u => u.Id == username);

                // Kiểm tra nếu người dùng tồn tại
                if (user != null)
                {
                    return user.code;
                }
                else
                {
                    // Trường hợp người dùng không tồn tại, trả về giá trị mặc định hoặc null tùy theo yêu cầu của bạn
                    return 0; // hoặc trả về một giá trị mặc định khác
                }
            }
        }
    }
}
