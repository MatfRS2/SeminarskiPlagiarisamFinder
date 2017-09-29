using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PlagijatorFinder
{
    public partial class Pocetna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlDataSource1.SelectParameters.Add("userName", System.Data.DbType.AnsiString, System.Web.HttpContext.Current.User.Identity.Name.ToString());
            SqlDataSource1.SelectParameters["userName"].DefaultValue = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            this.Title = System.Web.HttpContext.Current.User.Identity.Name.ToString();
        }
    }
}