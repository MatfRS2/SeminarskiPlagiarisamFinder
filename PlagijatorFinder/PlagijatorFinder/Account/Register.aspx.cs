using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PlagijatorFinder.Account
{
    public partial class Register : System.Web.UI.Page
    {
        
        //protected global::System.Web.UI.WebControls.CreateUserWizardStep RegisterUserWizardStep;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(_Default.GetConnectionString());
            conn.Open();
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }
        /*
        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie );
        
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }*/

        protected void RegisterUser_CreatingUser(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(_Default.GetConnectionString());
            conn.Open();
            
            
            //Label l = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("RegisterUserValidationSummary") as Label;
            
            TextBox user = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("UserName") as TextBox;
            TextBox passw = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Password") as TextBox;
            TextBox email = RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("Email") as TextBox;

            SqlCommand q = new SqlCommand("Select count(1) from Korisnik where userName = @userName", conn);
            q.CommandType = System.Data.CommandType.Text;
            q.Parameters.AddWithValue("@userName", user.Text);
            int count = (int)q.ExecuteScalar();
            if (count == 0)            
            {
                string passHash = FormsAuthentication.HashPasswordForStoringInConfigFile(passw.Text, "SHA1");

                SqlCommand query = new SqlCommand("Insert into Korisnik (userName, password, email) values (@userName, @password, @email)", conn);
                query.CommandType = System.Data.CommandType.Text;

                query.Parameters.AddWithValue("@userName", user.Text);
                query.Parameters.AddWithValue("@password", passHash);
                query.Parameters.AddWithValue("@email", email.Text);

                int insertSuccess = query.ExecuteNonQuery();
                Response.Redirect("~\\Account\\Login.aspx");
                if (insertSuccess != 0)
                {
                    Response.Redirect("~\\Account\\Login.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registration failed!')", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username is taken!')", true);
                return;
            }

            
                
            conn.Close();            
        }
    }
}
