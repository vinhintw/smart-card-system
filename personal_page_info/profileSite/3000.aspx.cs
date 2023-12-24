﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace personal_page_info.profileSite
{
    public partial class _3000 : System.Web.UI.Page
    {
        String code = "3000";
        protected void Page_Load(object sender, EventArgs e)
        {
            // CONNECT TO DATABASE AND GET USER INFORMATION
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\personal_page_info\\personal_page_info\\App_Data\\user.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework"; // Thay thế bằng chuỗi kết nối thực của bạn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Avatar, Name, Phone, Website, Facebook, Line, Youtube FROM [user] WHERE code = @code"; // Thay thế Users và các cột dữ liệu thực của bạn
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@code", code); // Thay thế bằng ID người dùng của bạn

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    //GET AVATAR DATA IN DATABASE
                    object avatarData = reader["Avatar"];
                    try
                    {
                        //SHOW IMAGE
                        byte[] imageData = (byte[])avatarData;
                        string imageSource = GetImageSource(imageData);
                        avatar.ImageUrl = imageSource;
                    }
                    catch (Exception)
                    {

                    }
                    //GET INFORMATION
                    string name = reader["Name"].ToString();
                    //string description = "This is my BIO";
                    string phone = reader["Phone"].ToString();
                    string website = reader["Website"].ToString();
                    string facebook = reader["Facebook"].ToString();
                    string line = reader["Line"].ToString();
                    string youtube = reader["Youtube"].ToString();

                    //SHOW INFORMATION
                    txtname.Text = name; 
                    phonenumber.Text = phone;
                    websitelink.NavigateUrl = website; 
                    linelink.NavigateUrl = line; 
                    facebooklink.NavigateUrl = facebook; 
                    linelink.NavigateUrl = line;
                    youtubelink.NavigateUrl = youtube;
                    //Debug.WriteLine(linelink.NavigateUrl);

                    //INVISIBLE IF ""
                    if (websitelink.NavigateUrl == "")
                    {
                        websitelink.Visible = false;
                    }
                    if (facebooklink.NavigateUrl == "")
                    {
                        facebooklink.Visible = false;
                    }
                    if (linelink.NavigateUrl == "")
                    {
                        linelink.Visible = false;
                    }
                    if (youtubelink.NavigateUrl == "")
                    {
                        youtubelink.Visible = false;
                    }
                    if (txtname.Text == "")
                    {
                        txtname.Visible = false;
                    }
                    if (avatar.ImageUrl == "")
                    {
                        avatar.Visible = false;
                    }

                }
                reader.Close();
            }
        }
        protected string GetImageSource(byte[] imageData)
        {
            if (imageData != null)
            {
                // CONVERT TO TYPE base64
                string base64String = Convert.ToBase64String(imageData, 0, imageData.Length);
                return "data:image/png;base64," + base64String; // Thay đổi kiểu hình ảnh tùy thuộc vào định dạng thực tế của hình ảnh trong dữ liệu
            }
            return string.Empty;
        }
    }
}