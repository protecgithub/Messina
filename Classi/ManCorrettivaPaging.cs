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

using System.Data.OracleClient;


namespace TheSite.Classi.ManStraordinaria
{
	/// <summary>
	/// Descrizione di riepilogo per Richiesta.
	/// Crazione di una richiesta di lavoro da manutenzione straordinaria
	/// </summary>
	public class ManCorrettivaPaging : AbstractBase
	{
		public ManCorrettivaPaging()
		{
			
		}

		public ManCorrettivaPaging(int Id) 
		{
			this.Id = Id;			
		}

		#region Metodi Pubblici

		/// <summary>
		/// DataSet con tutti i record
		/// </summary>
		/// <returns></returns>
		public override DataSet GetData()
		{
			return null;		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="CollezioneControlli"></param>
		/// <returns></returns>
		public override DataSet GetData(S_ControlsCollection CollezioneControlli)
		{
			return null;		
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public override DataSet GetSingleData(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_Wr_Id";
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
			string s_StrSql = "PACK_MAN_STRA.SP_GETSINGLERICHIESTA";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;				
		}

		
		public int Crea(S_ControlsCollection CollezioneControlli)
		{
			int i_Result = 0;

			int i_MaxParametri = CollezioneControlli.Count + 1;

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			i_MaxParametri ++;

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;

			CollezioneControlli.Add(s_CurrentUser);	
			CollezioneControlli.Add(s_IdOut);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_CREA";	
			i_Result = _OraDl.GetRowsAffected(CollezioneControlli, s_StrSql);			

			return i_Result;		
		}

		public bool IsValidBlId(string BlId)
		{	
			string s_User = System.Web.HttpContext.Current.User.Identity.Name;

			Classi.ClassiDettaglio.Edificio _Edificio = new 
				TheSite.Classi.ClassiDettaglio.Edificio(s_User);

			S_Controls.Collections.S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_BlId = new S_Object();
			s_BlId.ParameterName = "p_Bl_Id";
			s_BlId.DbType = CustomDBType.VarChar;
			s_BlId.Direction = ParameterDirection.Input;
			s_BlId.Size = 8;
			s_BlId.Index = 0;
			s_BlId.Value = BlId;

			S_Controls.Collections.S_Object s_UserName = new S_Object();
			s_UserName.ParameterName = "p_UserName";
			s_UserName.DbType = CustomDBType.VarChar;
			s_UserName.Direction = ParameterDirection.Input;
			s_UserName.Size = 50;
			s_UserName.Index = 1;
			s_UserName.Value = s_User;

			S_Controls.Collections.S_Object s_Campus = new S_Object();
			s_Campus.ParameterName = "p_Campus";
			s_Campus.DbType = CustomDBType.VarChar;
			s_Campus.Direction = ParameterDirection.Input;
			s_Campus.Index = 2;
			s_Campus.Size = 128;
			s_Campus.Value = "";
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 3;

			_SColl.Add(s_BlId);
			_SColl.Add(s_UserName);
			_SColl.Add(s_Campus);
			_SColl.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_EDIFICI.SP_GETEDIFICI";	
			if (_OraDl.GetRows(_SColl, s_StrSql).Tables[0].Rows.Count == 1)
				return true;
			else
				return false;

		}

		public  DataSet GetListaRDL(S_ControlsCollection CollezioneControlli,string utente)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = utente;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetListaRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public  DataSet GetStatusRdl(int wr_id)
		{	
			DataSet _Ds;	

			S_ControlsCollection CollezioneControlli = new S_ControlsCollection();
			
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Wr_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = wr_id;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GETSTATUSRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}


		public DataSet GetAllTipoTrasmissione()
		{
			DataSet _Ds;
			
			S_Controls.Collections.S_ControlsCollection CollezioneControlli = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_GETALLTIPOTRASMISSIONE";	
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();
			return _Ds;		
		}

		public DataSet GetSingleRdl(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_Wr_Id";
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
			string s_StrSql = "PACK_MAN_STRA.SP_GETSINGLERDL";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;				
		}
		
		//****************************//
		public DataSet GetSingleRdlLabel(int itemId)
		{
			DataSet _Ds;

			S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_Id = new S_Object();
			s_Id.ParameterName = "p_Wr_Id";
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
			string s_StrSql = "PACK_ELIMINA_RDL.SP_GETSINGLERDL";	
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			this.Id = itemId;
			return _Ds;				
		}


		//******************************//

		public  DataSet GetRDLNonEmesse(string bl_id)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_bl_id = new S_Object();
			s_bl_id.ParameterName = "p_Bl_id";
			s_bl_id.DbType = CustomDBType.VarChar;
			s_bl_id.Direction = ParameterDirection.Input;
			s_bl_id.Index = 0;
			s_bl_id.Value = bl_id;

			_SColl.Add(s_bl_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;
			_SColl.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetRDLNonEmesse";
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			return _Ds;	

		}
		public  DataSet GetRDLApprovate(string bl_id)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_ControlsCollection _SColl = new S_ControlsCollection();

			S_Controls.Collections.S_Object s_bl_id = new S_Object();
			s_bl_id.ParameterName = "p_Bl_id";
			s_bl_id.DbType = CustomDBType.VarChar;
			s_bl_id.Direction = ParameterDirection.Input;
			s_bl_id.Index = 0;
			s_bl_id.Value = bl_id;

			_SColl.Add(s_bl_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 0;
			_SColl.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetRDLApprovate";
			_Ds = _OraDl.GetRows(_SColl, s_StrSql).Copy();			

			return _Ds;	

		}

		public DataSet GetStatus()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = "Select id_status as ID, status_desc as DESCRIZIONE from wr_status where in_ord=1";
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		
		public DataSet GetStatusAccorpa()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = "Select id_status as ID, status_desc as DESCRIZIONE from wr_status where in_gest=1";
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetStatusAnalisi()
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_sql = new S_Controls.Collections.S_Object();
			s_p_sql.ParameterName = "p_sql";
			s_p_sql.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_sql.Direction = ParameterDirection.Input;
			s_p_sql.Size =2000;
			s_p_sql.Index = 0;
			s_p_sql.Value = "Select id_status as ID, status_desc as DESCRIZIONE from wr_status where in_str=1";
			_SCollection.Add(s_p_sql);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);

			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_COMMON.SP_DYNAMIC_SELECT";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetAddetti(string NomeCompleto, string BL_ID)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_NomeCompleto = new S_Controls.Collections.S_Object();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size =50;
			s_p_NomeCompleto.Index = 0;
			s_p_NomeCompleto.Value = NomeCompleto;
			_SCollection.Add(s_p_NomeCompleto);			

			S_Controls.Collections.S_Object s_p_BL_ID = new S_Controls.Collections.S_Object();
			s_p_BL_ID.ParameterName = "p_bl_id";
			s_p_BL_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Size =50;
			s_p_BL_ID.Index = 1;
			s_p_BL_ID.Value = BL_ID;
			_SCollection.Add(s_p_BL_ID);			

			S_Controls.Collections.S_Object s_p_UserName = new S_Controls.Collections.S_Object();
			s_p_UserName.ParameterName = "p_UserName";
			s_p_UserName.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_UserName.Direction = ParameterDirection.Input;
			s_p_UserName.Size =50;
			s_p_UserName.Index = 2;
			s_p_UserName.Value = System.Web.HttpContext.Current.User.Identity.Name;
			_SCollection.Add(s_p_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 3;

			_SCollection.Add(s_Cursor);
			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetAddetti";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}

		public DataSet GetAddetti(string NomeCompleto, string BL_ID,int ditta_id)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_NomeCompleto = new S_Controls.Collections.S_Object();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size =50;	
			s_p_NomeCompleto.Index = 0;
			s_p_NomeCompleto.Value = NomeCompleto;	
			_SCollection.Add(s_p_NomeCompleto);			

			S_Controls.Collections.S_Object s_p_BL_ID = new S_Controls.Collections.S_Object();
			s_p_BL_ID.ParameterName = "p_bl_id";
			s_p_BL_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_BL_ID.Direction = ParameterDirection.Input;
			s_p_BL_ID.Size =50;
			s_p_BL_ID.Index = 1;
			s_p_BL_ID.Value = BL_ID;
			_SCollection.Add(s_p_BL_ID);			

			S_Controls.Collections.S_Object s_p_DITTA_ID = new S_Controls.Collections.S_Object();
			s_p_DITTA_ID.ParameterName = "p_ditta_id";
			s_p_DITTA_ID.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_DITTA_ID.Direction = ParameterDirection.Input;
			s_p_DITTA_ID.Size =50;
			s_p_DITTA_ID.Index = 2;
			s_p_DITTA_ID.Value = ditta_id;
			_SCollection.Add(s_p_DITTA_ID);			

			S_Controls.Collections.S_Object s_p_UserName = new S_Controls.Collections.S_Object();
			s_p_UserName.ParameterName = "p_UserName";
			s_p_UserName.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_UserName.Direction = ParameterDirection.Input;
			s_p_UserName.Size =50;
			s_p_UserName.Index = 3;
			s_p_UserName.Value = System.Web.HttpContext.Current.User.Identity.Name;
			_SCollection.Add(s_p_UserName);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 4;

			_SCollection.Add(s_Cursor);
			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			//string s_StrSql = "PACK_MAN_STRA.SP_GetAddetti";	
			string s_StrSql = "PACK_ADDETTI.SP_GETADDETTORUOLO";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}
		

		public DataSet GetRichiedenti(string NomeCompleto)
		{
			S_ControlsCollection _SCollection = new S_ControlsCollection();			
		
			S_Controls.Collections.S_Object s_p_NomeCompleto = new S_Controls.Collections.S_Object();
			s_p_NomeCompleto.ParameterName = "p_NomeCompleto";
			s_p_NomeCompleto.DbType = ApplicationDataLayer.DBType.CustomDBType.VarChar;
			s_p_NomeCompleto.Direction = ParameterDirection.Input;
			s_p_NomeCompleto.Size =50;
			s_p_NomeCompleto.Index = 0;
			s_p_NomeCompleto.Value = NomeCompleto;
			_SCollection.Add(s_p_NomeCompleto);			

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;

			_SCollection.Add(s_Cursor);
			
			DataSet _Ds;											

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetRichiedenti";	
			_Ds = _OraDl.GetRows(_SCollection, s_StrSql).Copy();			

			return _Ds;		
		}
		public  DataSet GetSfogliaRDL(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetSfogliaRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}
		public  DataSet GetSfogliaRDLExcel(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetSfogliaRDLExcel1";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public  DataSet GetSfogliaRDLExcel1(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetSfogliaRDLExcel2";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}
		public  DataSet GetSfogliaRDLExcel2(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetSfogliaRDLExcel3";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}




		public  DataSet GetSfogliaRDLPaging(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetSfogliaRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public  DataSet GetSfogliaRDLPaging4(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetSfogliaRDL4";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}
		public int GetCount(S_ControlsCollection CollezioneControlli)
		{
		
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetSfogliaRDLCount";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();


			return	int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}
		public int GetCount4(S_ControlsCollection CollezioneControlli)
		{
		
			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GetSfogliaRDLCount4";	
			DataSet _Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();


			return	int.Parse(_Ds.Tables[0].Rows[0][0].ToString());
		}
		public  DataSet GetSfogliaRDLDaEliminare(S_ControlsCollection CollezioneControlli)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_utente";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = System.Web.HttpContext.Current.User.Identity.Name;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_ELIMINA_RDL.SP_GetSfogliaRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public int EmettiRdl(ParamRichiesta parametri)
		{	
			
			S_ControlsCollection _SColl = new S_ControlsCollection();

			// WR_ID
			S_Controls.Collections.S_Object s_IdWR = new S_Object();
			s_IdWR.ParameterName = "p_Wr_Id";
			s_IdWR.DbType = CustomDBType.Integer;
			s_IdWR.Direction = ParameterDirection.Input;
			s_IdWR.Index = 0;
			s_IdWR.Value = parametri.wr_id;

			// STATUS_ID
			S_Controls.Collections.S_Object s_IdStatus = new S_Object();
			s_IdStatus.ParameterName = "p_stato";
			s_IdStatus.DbType = CustomDBType.Integer;
			s_IdStatus.Direction = ParameterDirection.Input;
			s_IdStatus.Index = 1;
			s_IdStatus.Value = (int)parametri.status_id;			
			
			// UTENTE

			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = 2;
			s_CurrentUser.Value =parametri.utente;

			// URGENZA

			S_Controls.Collections.S_Object s_Urgenza = new S_Object();
			s_Urgenza.ParameterName = "p_urgenza";
			s_Urgenza.DbType = CustomDBType.Integer;
			s_Urgenza.Direction = ParameterDirection.Input;
			s_Urgenza.Index = 3;
			s_Urgenza.Value = parametri.urgenza_id;	

			// RICHIEDENTE

			S_Controls.Collections.S_Object s_Richiedente = new S_Object();
			s_Richiedente.ParameterName = "p_richiedente";
			s_Richiedente.DbType = CustomDBType.VarChar;
			s_Richiedente.Direction = ParameterDirection.Input;
			s_Richiedente.Index = 4;
			s_Richiedente.Value = parametri.richiedente;

			// DESCRIZIONE

			S_Controls.Collections.S_Object s_Descrizione = new S_Object();
			s_Descrizione.ParameterName = "p_descrizione";
			s_Descrizione.DbType = CustomDBType.VarChar;
			s_Descrizione.Direction = ParameterDirection.Input;
			s_Descrizione.Index = 5;
			s_Descrizione.Size=4000;
			s_Descrizione.Value = parametri.descrizione;

			// DATAPIANIFICATA

			S_Controls.Collections.S_Object s_DataP = new S_Object();
			s_DataP.ParameterName = "p_datapianificata";
			s_DataP.DbType = CustomDBType.VarChar;
			s_DataP.Direction = ParameterDirection.Input;
			s_DataP.Index = 6;			
			s_DataP.Size=30;
			s_DataP.Value = parametri.data_pianificata;

			// SERVIZIO

			S_Controls.Collections.S_Object s_Servizio = new S_Object();
			s_Servizio.ParameterName = "p_servizio_id";
			s_Servizio.DbType = CustomDBType.Integer;
			s_Servizio.Direction = ParameterDirection.Input;
			s_Servizio.Index = 7;
			s_Servizio.Value = parametri.servizio_id;

			// TRASMISSIONE

			S_Controls.Collections.S_Object s_Trasmissione = new S_Object();
			s_Trasmissione.ParameterName = "p_trasmissione_id";
			s_Trasmissione.DbType = CustomDBType.Integer;
			s_Trasmissione.Direction = ParameterDirection.Input;
			s_Trasmissione.Index = 8;
			s_Trasmissione.Value = parametri.trasmissione_id;

			// MANUTENZIONE

			S_Controls.Collections.S_Object s_Manutenzione = new S_Object();
			s_Manutenzione.ParameterName = "p_manutenzione_id";
			s_Manutenzione.DbType = CustomDBType.Integer;
			s_Manutenzione.Direction = ParameterDirection.Input;
			s_Manutenzione.Index = 9;
			s_Manutenzione.Value = parametri.tipo_mautenzione_id;

			// BL_ID

			S_Controls.Collections.S_Object s_BL = new S_Object();
			s_BL.ParameterName = "p_bl_id";
			s_BL.DbType = CustomDBType.Integer;
			s_BL.Direction = ParameterDirection.Input;
			s_BL.Index = 10;
			s_BL.Value = parametri.bl_id;

			// ADDETTO_ID

			S_Controls.Collections.S_Object s_Addetto = new S_Object();
			s_Addetto.ParameterName = "p_addetto_id";
			s_Addetto.DbType = CustomDBType.Integer;
			s_Addetto.Direction = ParameterDirection.Input;
			s_Addetto.Index = 11;
			s_Addetto.Value = parametri.addetto_id;
			
			// ID_DITTA
			S_Controls.Collections.S_Object p_id_ditta = new S_Object();
			p_id_ditta.ParameterName = "p_id_ditta";
			p_id_ditta.DbType = CustomDBType.Integer;
			p_id_ditta.Direction = ParameterDirection.Input;
			p_id_ditta.Index = 12;
			p_id_ditta.Value = parametri.id_ditta;

			// STD APPARECCHIATURA
			S_Controls.Collections.S_Object p_stdApparecchiatura_id = new S_Object();
			p_stdApparecchiatura_id.ParameterName = "p_stdApparecchiatura_id";
			p_stdApparecchiatura_id.DbType = CustomDBType.Integer;
			p_stdApparecchiatura_id.Direction = ParameterDirection.Input;
			p_stdApparecchiatura_id.Index = 13;
			p_stdApparecchiatura_id.Value = parametri.stdApparecchiatura_id;

			// APPARECCHIATURA
			S_Controls.Collections.S_Object p_eq_id = new S_Object();
			p_eq_id.ParameterName = "p_eq_id";
			p_eq_id.DbType = CustomDBType.Integer;
			p_eq_id.Direction = ParameterDirection.Input;
			p_eq_id.Index = 14;
			p_eq_id.Value = parametri.eq_id;

			//TODO: nuovi parametri
			//          p_tipointervento in number,
			//          p_numeropreventivo in varchar2,
			//          p_importopreventivo in number,
			//          p_pdfpreventivo in varchar2,

			//Tipo intervento ATER
			S_Controls.Collections.S_Object p_tipointervento = new S_Object();
			p_tipointervento.ParameterName = "p_tipointervento";
			p_tipointervento.DbType = CustomDBType.Integer;
			p_tipointervento.Direction = ParameterDirection.Input;
			p_tipointervento.Index = 15;
			p_tipointervento.Value = parametri.tipoInterventoAter;
			
			//Numero preventivo
			S_Controls.Collections.S_Object p_numeropreventivo = new S_Object();
			p_numeropreventivo.ParameterName = "p_numeropreventivo";
			p_numeropreventivo.DbType = CustomDBType.VarChar;
			p_numeropreventivo.Direction = ParameterDirection.Input;
			p_numeropreventivo.Index = 16;
			p_numeropreventivo.Size =8;
			p_numeropreventivo.Value = parametri.numero_preventivo;
			
			//importo preventivo
			S_Controls.Collections.S_Object p_importopreventivo = new S_Object();
			p_importopreventivo.ParameterName = "p_importopreventivo";
			p_importopreventivo.DbType = CustomDBType.Double;
			p_importopreventivo.Direction = ParameterDirection.Input;
			p_importopreventivo.Index = 17;
			p_importopreventivo.Value =double.Parse(parametri.importo_preventivo); 
			
			//Nome del file pdf
			S_Controls.Collections.S_Object p_pdfpreventivo = new S_Object();
			p_pdfpreventivo.ParameterName = "p_pdfpreventivo";
			p_pdfpreventivo.DbType = CustomDBType.VarChar;
			p_pdfpreventivo.Direction = ParameterDirection.Input;
			p_pdfpreventivo.Index = 18;
			p_pdfpreventivo.Size =250;
			p_pdfpreventivo.Value = parametri.PdfPreventivo;
			
			// OUT
			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_IdOut";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = 19;
				
			_SColl.Add(s_IdWR);	
			_SColl.Add(s_IdStatus);	
			_SColl.Add(s_CurrentUser);
			_SColl.Add(s_Urgenza);
			_SColl.Add(s_Richiedente);
			_SColl.Add(s_Descrizione);
			_SColl.Add(s_DataP);
			_SColl.Add(s_Servizio);
			_SColl.Add(s_Trasmissione);
			_SColl.Add(s_Manutenzione);
			_SColl.Add(s_BL);			
			_SColl.Add(s_Addetto);
			_SColl.Add(p_id_ditta);
			_SColl.Add(p_stdApparecchiatura_id);
			_SColl.Add(p_eq_id);

			_SColl.Add(p_tipointervento);	
			_SColl.Add(p_numeropreventivo);	
			_SColl.Add(p_importopreventivo);	
			_SColl.Add(p_pdfpreventivo);	

			_SColl.Add(s_IdOut);			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			
			int i_Result=0;
			
			switch(parametri.status_id)
			{
				case Classi.StateType.EmessaInLavorazione:										
					i_Result = _OraDl.GetRowsAffected(_SColl, "PACK_EMETTI_RDL_STR.SP_EMETTI");
					break;
				case Classi.StateType.RichiestaRifiutata:	
					i_Result = _OraDl.GetRowsAffected(_SColl, "PACK_EMETTI_RDL_STR.SP_RIFIUTA");
					break;
				case Classi.StateType.RichiestaSospesa:
					i_Result = _OraDl.GetRowsAffected(_SColl, "PACK_EMETTI_RDL_STR.SP_SOSPENDI");
					break;	
			}
				
			return i_Result;
		}




		public  DataSet GetAnalisiRDL(S_ControlsCollection CollezioneControlli,string utente)
		{
			DataSet _Ds;	

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_CurrentUser";
			s_IdIn.DbType = CustomDBType.VarChar;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = CollezioneControlli.Count + 1;
			s_IdIn.Value = utente;

			CollezioneControlli.Add(s_IdIn);
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GETANALISIRDL";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}

		public  DataSet GetHWR(S_ControlsCollection CollezioneControlli,string utente)
		{
			DataSet _Ds;	
	
			
			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = CollezioneControlli.Count + 1;
			CollezioneControlli.Add(s_Cursor);
			
			


			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GETHWR";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}		
		/// <summary>
		/// recupera i dati per ilRapporto della richiesta visualizzato nella pagina RapportoRichiestaRdl.aspx
		/// </summary>
		/// <param name="wr_id">il wr_id della richiesta appena creata</param>
		/// <returns>Ritorna un data set con tutti i dati</returns>
		public  DataSet GetRapportino(int wr_id)
		{
			DataSet _Ds;	
	        
			S_ControlsCollection CollezioneControlli=new S_ControlsCollection ();

			
			S_Controls.Collections.S_Object p_wr_id = new S_Object();
			p_wr_id.ParameterName = "p_wr_id";
			p_wr_id.DbType = CustomDBType.Integer;
			p_wr_id.Direction = ParameterDirection.Input;
			p_wr_id.Index = 0;
			p_wr_id.Value =wr_id;
			CollezioneControlli.Add(p_wr_id);

			S_Controls.Collections.S_Object s_Cursor = new S_Object();
			s_Cursor.ParameterName = "IO_CURSOR";
			s_Cursor.DbType = CustomDBType.Cursor;
			s_Cursor.Direction = ParameterDirection.Output;
			s_Cursor.Index = 1;
			CollezioneControlli.Add(s_Cursor);
			
			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);
			string s_StrSql = "PACK_MAN_STRA.SP_GETRAPPORTINO";
			_Ds = _OraDl.GetRows(CollezioneControlli, s_StrSql).Copy();			

			return _Ds;	

		}	
		
		public int DeleteRdL(S_ControlsCollection CollezioneControlli)
		{
			int i_MaxParametri = CollezioneControlli.Count ;			

			S_Controls.Collections.S_Object s_IdOut = new S_Object();
			s_IdOut.ParameterName = "p_Id_Out";
			s_IdOut.DbType = CustomDBType.Integer;
			s_IdOut.Direction = ParameterDirection.Output;
			s_IdOut.Index = i_MaxParametri;
			//s_IdIn.Value = itemId;		
			
			
			CollezioneControlli.Add(s_IdOut);	
			

			ApplicationDataLayer.OracleDataLayer _OraDl = new OracleDataLayer(s_ConnStr);

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_ELIMINA_RDL.SP_DELETERDL");

			return i_Result;
		}

		public  string UpdateStatusAut(int P_ID_STATO_AUTORIZ,int P_wr_id)
		{

			
		    string Result="";
			string ConnectionString=ConfigurationSettings.AppSettings.Get("ConnectionString");
			string s_StrSql = "PACK_MANCORRETIVA.SP_UPD_WR_STAUTORIZ";
			using(OracleConnection connection = new OracleConnection(ConnectionString))
			{
				try
				{
					connection.Open();

					using(OracleCommand command = new OracleCommand(s_StrSql,connection))
					{
						command.CommandType = System.Data.CommandType.StoredProcedure;
					
						OracleParameter p1 = new OracleParameter("P_ID_STATO_AUTORIZ",OracleType.Number);
						p1.Value     = P_ID_STATO_AUTORIZ;
						p1.Direction = System.Data.ParameterDirection.Input;
						command.Parameters.Add(p1);

						OracleParameter p2 = new OracleParameter("p_CurrentUser",OracleType.VarChar,50);
						p2.Value     = System.Web.HttpContext.Current.User.Identity.Name;
						p2.Direction = System.Data.ParameterDirection.Input;
						command.Parameters.Add(p2);

						OracleParameter p3 = new OracleParameter("P_wr_id",OracleType.Number);
						p3.Value     = P_wr_id;
						p3.Direction = System.Data.ParameterDirection.Input;
						command.Parameters.Add(p3);

						OracleParameter p4 = new OracleParameter("MSG_OUT",OracleType.VarChar,100);
						p4.Value     = "";
						p4.Direction = System.Data.ParameterDirection.InputOutput;
						command.Parameters.Add(p4);

						command.ExecuteNonQuery();

						Result=p4.Value.ToString();
					}
				}
				finally
				{
					if(connection.State == ConnectionState.Open)
					{
						connection.Dispose();
					}
				}
				return Result;
			}

			

		}

		#endregion
		#region ProprietÓ Private

		protected override int ExecuteUpdate(S_ControlsCollection CollezioneControlli, ExecuteType Operazione, int itemId)
		{
			int i_MaxParametri = CollezioneControlli.Count + 1;			

			S_Controls.Collections.S_Object s_IdIn = new S_Object();
			s_IdIn.ParameterName = "p_Id";
			s_IdIn.DbType = CustomDBType.Integer;
			s_IdIn.Direction = ParameterDirection.Input;
			s_IdIn.Index = i_MaxParametri;
			s_IdIn.Value = itemId;		
			
			i_MaxParametri ++;
			
			S_Controls.Collections.S_Object s_CurrentUser = new S_Object();
			s_CurrentUser.ParameterName = "p_CurrentUser";
			s_CurrentUser.DbType = CustomDBType.VarChar;
			s_CurrentUser.Direction = ParameterDirection.Input;
			s_CurrentUser.Index = i_MaxParametri;
			s_CurrentUser.Value = System.Web.HttpContext.Current.User.Identity.Name;

			i_MaxParametri ++;
			
			S_Controls.Collections.S_Object s_Operazione = new S_Object();
			s_Operazione.ParameterName = "p_Operazione";
			s_Operazione.DbType = CustomDBType.VarChar;
			s_Operazione.Direction = ParameterDirection.Input;
			s_Operazione.Index = i_MaxParametri;
			s_Operazione.Value = Operazione.ToString();

			i_MaxParametri ++;

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

			int i_Result = _OraDl.GetRowsAffected(CollezioneControlli, "PACK_FUNZIONI.SP_EXECUTEFUNZIONI");

			return i_Result;
		}

		#endregion
		
	
	}

}
