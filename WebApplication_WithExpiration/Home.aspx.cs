using System;
using System.Globalization;

namespace WebApplication_WithExpiration
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string expiredDate = System.Configuration.ConfigurationManager.AppSettings["ExpiredDate"].ToString();
            DateTime date = DateTime.ParseExact(expiredDate, "yyyy-MM-dd HH:mm:ss tt", CultureInfo.InvariantCulture);

            if (date <= DateTime.Now)
            {                
                Response.Redirect("Expiration.aspx");
            }
        }    
    }
}