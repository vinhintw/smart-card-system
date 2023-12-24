using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace personal_page_info.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IsLoggedIn"] = false; // Đặt lại trạng thái đăng nhập
                                           // Xóa các thông tin đăng nhập khác trong Session nếu có
            Session.Remove("UserId"); // Ví dụ: Session lưu UserId
                                      // Chuyển hướng về trang chủ hoặc trang đăng nhập
            Response.Redirect("~/"); // Điều hướng về trang chủ
        }
    }
}