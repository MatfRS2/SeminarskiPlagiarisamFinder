using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Web.Security;
using System.Security.Cryptography;


namespace PlagijatorFinder.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx";//?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

            SqlConnection conn = new SqlConnection(_Default.GetConnectionString());
            conn.Open();
            
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(_Default.GetConnectionString());
            conn.Open();
            Label l = (Label) LoginUser.FindControl("loginFail");

            try
            {
                
                string user = ((TextBox)LoginUser.FindControl("UserName")).Text;
                string password = ((TextBox)LoginUser.FindControl("Password")).Text;
                
                
                String passHash = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                SqlCommand query = new SqlCommand("select password from Korisnik where userName = @userName", conn);
                query.CommandType = System.Data.CommandType.Text;
                query.Parameters.AddWithValue("@userName", user);
                //query.Parameters.AddWithValue("@password", password);
                
                string s = (string)query.ExecuteScalar();
                if (string.IsNullOrEmpty(s))
                {
                    Response.Redirect("~\\Account\\Login.aspx");                    
                }
                else
                {
                    SqlDataReader dr = query.ExecuteReader();
                    dr.Read();
                    if (passHash == dr.GetString(0))
                    {
                        FormsAuthentication.SetAuthCookie(user, true);
                        Response.Redirect("~\\Pocetna.aspx");
                    }
                    else
                    {
                        Response.Redirect("~\\Account\\Login.aspx");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                l.Text = ex.Message;
            }
        }
    }
}
