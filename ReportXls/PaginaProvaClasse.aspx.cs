using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TheSite.ReportXls
{
	/// <summary>
	/// Descrizione di riepilogo per PaginaProvaClasse.
	/// </summary>
	public class PaginaProvaClasse : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
//			ConsuntivoTrimestrale.ConsTrimst app = new ConsuntivoTrimestrale.ConsTrimst();
//			app.generaRptContableXls(2,2,2);
//			app = null;
//			GC.Collect();
		}

		#region Codice generato da Progettazione Web Form
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: questa chiamata � richiesta da Progettazione Web Form ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Metodo necessario per il supporto della finestra di progettazione. Non modificare
		/// il contenuto del metodo con l'editor di codice.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
