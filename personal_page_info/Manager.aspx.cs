using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace personal_page_info
{
    public partial class Admin : System.Web.UI.Page
    {
        String userId;
        protected void Page_Load(object sender, EventArgs e)
        {

            // Kiểm tra xem đã có người dùng đăng nhập hay chưa, nếu chưa thì chuyển hướng về trang đăng nhập
            userId = (String)Session["UserID"];
            if (!IsUserAuthorized(userId))
            {
                Response.Redirect("~/Account/Login.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                //Debug.WriteLine(Session["UserID"]);

            }
            Debug.WriteLine(Session["UserID"]);
            // Lấy thông tin người dùng từ Session hoặc từ cơ sở dữ liệu và kiểm tra quyền truy cập
            if (!IsPostBack)
            {
                LoadCurrentUserDetails(userId);
            }
        }
        private void LoadCurrentUserDetails(string userId)
        {
            DisableTextBoxes();
            notify.Text = " ";
            
            using (userE context = new userE())
            {
                var currentUser = context.users.FirstOrDefault(u => u.Id == userId);

                if (currentUser != null)
                {
                    // Gọi hàm GetImageSource để nhận URL của hình ảnh từ mảng byte
                    string imageSource = GetImageSource(currentUser.Avatar);
                    txtName.Text = currentUser.Name;
                    txtPhone.Text = Convert.ToString(currentUser.Phone);
                    txtWebsite.Text = currentUser.Website;
                    txtFacebook.Text = currentUser.Facebook;
                    txtLine.Text = currentUser.Line;
                    txtYoutube.Text = currentUser.Youtube;

                    preavatar.ImageUrl = imageSource;
                    prename.Text = txtName.Text;
                    prewebsitelink.NavigateUrl = txtWebsite.Text;
                    prefacebooklink.NavigateUrl = txtFacebook.Text;
                    prelinelink.NavigateUrl = txtLine.Text;
                    preyoutubelink.NavigateUrl = txtYoutube.Text;
                    prephone.Text = txtPhone.Text;

                    if (prewebsitelink.NavigateUrl == "")
                    {
                        prewebsitelink.Visible = false;
                    }
                    else
                    {
                        prewebsitelink.Visible = true;
                    }
                    if (prefacebooklink.NavigateUrl == "")
                    {
                        prefacebooklink.Visible = false;
                    }
                    else
                    {
                        prefacebooklink.Visible = true;
                    }
                    if (prelinelink.NavigateUrl == "")
                    {
                        prelinelink.Visible = false;
                    }
                    else
                    {
                        prelinelink.Visible = true;
                    }
                    if (preyoutubelink.NavigateUrl == "")
                    {
                        preyoutubelink.Visible = false;
                    }
                    else
                    {
                        preyoutubelink.Visible = true;
                    }
                    if (prename.Text == "")
                    {
                        prename.Visible = false;
                    }
                    else
                    {
                        prename.Visible = true;
                    }
                    if (preavatar.ImageUrl == "")
                    {
                        preavatar.Visible = false;
                    }
                    else
                    {
                        preavatar.Visible = true;
                    }

                }
            }
        }

        private bool IsUserAuthorized(string userId)
        {
            // Sử dụng context của Entity Framework
            using (userE context = new userE())
            {
                if (userId != null) {
                    // Tìm kiếm người dùng trong cơ sở dữ liệu dựa trên Id
                    var userFromDb = context.users.FirstOrDefault(u => u.Id == userId);
                    //Debug.WriteLine(userFromDb != null && userFromDb.Id == userId);
                    //Debug.WriteLine(userFromDb.Id);

                    return userFromDb != null && userFromDb.Id == userId;
                }
                else
                {
                    return false;
                }
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            EnableTextBoxes();
            notify.Text = " ";

        }
        private void DisableTextBoxes()
        {
            txtName.Enabled = false;
            txtPhone.Enabled = false;
            txtWebsite.Enabled = false;
            txtFacebook.Enabled = false;
            txtLine.Enabled = false;
            txtYoutube.Enabled = false;
        }
        private void EnableTextBoxes()
        {
            txtName.Enabled = true;
            txtPhone.Enabled = true;
            txtWebsite.Enabled = true;
            txtFacebook.Enabled = true;
            txtLine.Enabled = true;
            txtYoutube.Enabled = true;
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (imgfile.HasFile)
            {
                byte[] imageByteArray = null;

                using (BinaryReader reader = new BinaryReader(imgfile.PostedFile.InputStream))
                {
                    imageByteArray = reader.ReadBytes(imgfile.PostedFile.ContentLength);
                }
                using (userE context = new userE())
                {
                    var currentUser = context.users.FirstOrDefault(u => u.Id == userId);

                    if (currentUser != null)
                    {
                        currentUser.Avatar = imageByteArray;
                        context.SaveChanges();
                    }
                }
            }
            if (!String.IsNullOrEmpty(userId))
            {
                using (userE context = new userE())
                {
                    var currentUser = context.users.FirstOrDefault(u => u.Id == userId);
                    if (currentUser != null)
                    {
                        currentUser.Name = String.IsNullOrWhiteSpace(txtName.Text) ? null : txtName.Text.Trim();
                        try
                        {
                            currentUser.Phone = String.IsNullOrWhiteSpace(txtPhone.Text) ? null : txtPhone.Text;

                        }
                        catch (Exception)
                        {

                            notify.Text = "Invaild number";
                        }
                        
                        currentUser.Name = String.IsNullOrWhiteSpace(txtName.Text) ? null : txtName.Text.Trim();
                        currentUser.Website = String.IsNullOrWhiteSpace(txtWebsite.Text) ? null : txtWebsite.Text.Trim();
                        currentUser.Facebook = String.IsNullOrWhiteSpace(txtFacebook.Text) ? null : txtFacebook.Text.Trim();
                        currentUser.Line = String.IsNullOrWhiteSpace(txtLine.Text) ? null : txtLine.Text.Trim();
                        currentUser.Youtube = String.IsNullOrWhiteSpace(txtYoutube.Text) ? null : txtYoutube.Text.Trim();


                        context.SaveChanges();
                        // Hiển thị thông báo hoặc thực hiện các hành động khác sau khi cập nhật thành công
                        LoadCurrentUserDetails(userId);
                        notify.Text = "Updated successfully";
                    }
                }
                DisableTextBoxes();
            }
            else
            {
                Debug.WriteLine("error");
                // Xử lý trường hợp không có người dùng đăng nhập
            }
        }
        private byte[] GetImageAsByteArray(string imagePath)
        {
            byte[] imageData = null;

            // Kiểm tra xem đường dẫn hình ảnh có tồn tại không
            if (System.IO.File.Exists(imagePath))
            {
                // Đọc dữ liệu hình ảnh từ đường dẫn và chuyển đổi sang mảng byte
                using (System.IO.FileStream fs = new System.IO.FileStream(imagePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                }
            }

            return imageData;
        }

        protected string GetImageSource(byte[] imageData)
        {
            if (imageData != null)
            {
                // Chuyển đổi mảng byte sang dữ liệu base64
                string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
                return "data:image/jpg;base64," + base64String; // Thay đổi kiểu hình ảnh tùy thuộc vào định dạng thực tế của hình ảnh trong dữ liệu
            }
            return string.Empty;
        }

        
    }
}