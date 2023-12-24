using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace personal_page_info
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["IsLoggedIn"] != null && (bool)Session["IsLoggedIn"])
                {
                    // Nếu đã đăng nhập, ẩn liên kết "Login"
                    loginLink.Visible = false;
                    // Hiển thị liên kết "Logout"
                    logoutLink.Visible = true;
                    managerlink.Visible = true;
                    profilelink.Visible = true;
                    profilelink.HRef = "~/profileSite/" + Convert.ToString(Session["UserCode"]);
                    Debug.WriteLine(Session["UserCode"]);
                    int admincode = (int)Session["UserCode"];
                    // Kiểm tra xem người dùng có phải là admin hay không
                    if (admincode == 3000)
                    {
                        adminpage.Visible = true;
                    }
                    else
                    {
                        adminpage.Visible = false;
                        Debug.WriteLine(Session["UserID"]);

                    }

                }
                else
                {
                    loginLink.Visible = true;
                    logoutLink.Visible = false;
                    managerlink.Visible = false;
                    profilelink.Visible = false;
                    adminpage.Visible = false;
                }
            }
        }
        protected void logout_click(object sender, EventArgs e)
        {
            Debug.WriteLine(Session["IsLoggedIn"]);
            loginLink.Visible = true;
            // Ẩn liên kết "Logout"
            logoutLink.Visible = false;
            Session["IsLoggedIn"] = null;
            Session.Abandon();
        }
    }
}