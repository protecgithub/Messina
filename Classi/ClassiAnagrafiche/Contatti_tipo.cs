using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;
using S_Controls;
using S_Controls.Collections;
using ApplicationDataLayer;
using ApplicationDataLayer.DBType;

namespace TheSite.Classi.ClassiAnagrafiche
{
	/// <summary>
	/// Descrizione di riepilogo per Richiedenti_tipo.
	/// </summary>
	public class Contatti_tipo : AbstractBase
	{
		public Contatti_tipo()
		{
			//
			// TODO: aggiungere qui la logica del costruttore
			//
		}
	
	
		#region Metodi Pubblici
		public override DataSet GetData()
		{
			return null;
		}
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;
			//S_ControlsCollections CollezioneControlli=new S_ControlsCollection(); 

			S_Controls.Collections.S_Object S_Cursor=new S_Object();
			S_Cursor.ParameterName ="IO_CURSOR";
			S_Cursor.DbType=CustomDBType.Cursor;
			S_Cursor.Direction=ParameterDirection.Output;
			S_Cursor.Index = CollezioneControlli.Count;
		
			CollezioneControlli.Add(S_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_RICHIEDENTI_TIPO.SP_GETCONTATTI_TIPO";
			_Ds=_OraDL.GetRows(CollezioneControlli,s_StrSql).Copy();
			return _Ds;
		}

		public DataSet GetAllData()
		{
			DataSet _Ds;
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection(); 

			S_Controls.Collections.S_Object S_Cursor=new S_Object();
			S_Cursor.ParameterName ="IO_CURSOR";
			S_Cursor.DbType=CustomDBType.Cursor;
			S_Cursor.Direction=ParameterDirection.Output;
			S_Cursor.Index = 1;
		
			CollezioneControlli.Add(S_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDL=new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CONTATTI_TIPO.SP_GETALLCONTATTI_TIPO";
			_Ds=_OraDL.GetRows(CollezioneControlli,s_StrSql).Copy();
			return _Ds;
		}

		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_id";
			s_Id.DbType = CustomDBType.Integer;
			s_Id.Direction = ParameterDirection.Input;
			s_Id.Index = 0;
			s_Id.Value = itemId;
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SColl.Add(s_Id);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_CONTATTI_TIPO.SP_GETSINGLECONTATTI_TIPO";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;	
		}

		#endregion

		#region ProprietÓ Pubbliche
		#endregion

		#region Metodi privati
		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_MaxParametri = CollezioneControlli.Count + 1;			

			// Id
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;
						
			//			// UTENTE

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			i_MaxParametri ++;
			
			// TIPO OPERAZIONE

			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();

			i_MaxParametri ++;

			// OUT

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;
				
			CollezioneControlli.Add(s_IdIn);	
			CollezioneControlli.Add(s_CurrentUser);	
			CollezioneControlli.Add(s_Operazione);
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_CONTATTI_TIPO.SP_EXECUTERICHIEDENTI_TIPO");
				
			return i_Result;
		
		}


		#endregion
	
	}
}
