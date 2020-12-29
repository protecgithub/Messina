using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace TheSite
{
    public partial class LoginCallCenter : System.Web.UI.Page
    {

		protected S_Controls.S_TextBox txtsUserName;
		protected S_Controls.S_TextBox txtsPasword;
		protected Csy.WebControls.MessagePanel PanelMess;

		string user;
		string password;
        protected void Page_Load(object sender, EventArgs e)
        {
			user = Request.Params["u"];
			password = Request.Params["p"];
			Login();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Login()
		{
			Classi.Sicurezza _Sic = new Classi.Sicurezza();
			Classi.Utente _Utente = new TheSite.Classi.Utente();

			txtsPasword.Text = _Sic.EncryptMD5(txtsPasword.Text);
			txtsUserName.Text = user;
			try
			{

				int i_IdUtente = _Utente.Login(this);

				if (i_IdUtente > 0)
				{
					string url = FormsAuthentication.GetRedirectUrl(user, false);
					//					FormsAuthentication.SetAuthCookie(txtsUserName.Text,false);
					//			
					//					Response.Redirect(url);
					string[] a_roles = _Utente.GetRuoli(user);

					string roleStr = "";
					double ore = 8;
					foreach (String role in a_roles)
					{
						//if(role.ToUpper()=="CALLCENTER")
						//	ore=8;
						roleStr += role;
						roleStr += ";";
					}

					FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
						1,
						user,
						DateTime.Now,                   // issue time
						DateTime.Now.AddHours(ore),       // expires every hour
						false,                          // don't persist cookie
						roleStr,                        // roles
						FormsAuthentication.FormsCookiePath);

					// Encrypt the ticket.
					string encTicket = FormsAuthentication.Encrypt(ticket);

					// Create the cookie.
					Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

					// Redirect back to original URL.
					Response.Redirect(url);

				}
				else
				{
					PanelMess.ShowError("Utenza o Password errati", true);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				//PanelMess.ShowError("Errore interno al Data Base.", true);
				PanelMess.ShowError(ex.Message.ToString(), true);

			}
		}
	}
}