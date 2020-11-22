<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Page language="c#" Codebehind="EditPmp.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditPmp" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditAddetti</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<script language="javascript">
	
	function Verifica(oggetto,max)
	{
	if (event.keyCode >=48	&& event.keyCode <= 57)
	{
		event.keyCode = 0;
	}
	
	
		if (oggetto.length>=max)
		{
				event.keyCode = 0;
		}
	}
	function Verifica1(oggetto,max)
	{
	if (event.keyCode <48	|| event.keyCode > 57)
	{
		event.keyCode = 0;
	}
	
	
		if (oggetto.length>=max)
		{
				event.keyCode = 0;
		}
	}
		</script>
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 100%; TOP: 0px; LEFT: 0px"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR vAlign="top" align="center" height="95%">
					<TD>
						<TABLE id="tblFormInput" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
							<TBODY>
								<TR>
									<TD style="WIDTH: 4.29%; HEIGHT: 5.31%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5.31%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" Width="504px" CssClass="TitleOperazione"></asp:label><cc2:messagepanel id="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"></cc2:messagepanel></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 83px; HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr noShade SIZE="1">
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 83px" vAlign="top" align="center"></TD>
									<TD vAlign="top" align="left" width="100%"><asp:panel id="PanelEdit" runat="server" Width="100%">
											<TABLE id="tblSearch100" border="0" cellSpacing="1" cellPadding="2" width="100%">
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Descrizione&nbsp;
														<asp:RequiredFieldValidator id="rfvcognome" runat="server" ErrorMessage="Inserire la descrizione" ControlToValidate="txtsdescrizione">*</asp:RequiredFieldValidator></TD>
													<TD>
														<cc1:S_TextBox id="txtsdescrizione" tabIndex="1" runat="server" Width="95%" MaxLength="250"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 25px" align="left">
														<P>Tempo Intervento espresso in minuti&nbsp;
														</P>
													</TD>
													<TD style="HEIGHT: 25px">
														<cc1:S_TextBox id="txtsunitshour" tabIndex="2" runat="server" MaxLength="7"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 20px" align="left">Servizio&nbsp;
														<asp:RangeValidator id="RfvServ" runat="server" ErrorMessage="Nessuno Servizio selezionato" ControlToValidate="cmbsServ"
															MinimumValue="1" MaximumValue="99999999999">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 20px">
														<asp:DropDownList id="cmbsServ" tabIndex="3" runat="server" Width="90%" AutoPostBack="True"></asp:DropDownList></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 20px" align="left">Standard Apparecchiatura
														<asp:RangeValidator id="RFVeqstd" runat="server" ErrorMessage="Nessuno Standard selezionato" ControlToValidate="cmbseq_std"
															MinimumValue="1" MaximumValue="99999999999">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 20px">
														<cc1:S_ComboBox id="cmbseq_std" tabIndex="4" runat="server" Width="90%" AutoPostBack="True" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 22px" align="left">Frequenza
														<asp:RangeValidator id="RfvPmpFreq" runat="server" ErrorMessage="Nessuna frequenza selezionata" ControlToValidate="cmbspmp"
															MinimumValue="1" MaximumValue="99999999999">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 22px">
														<cc1:S_ComboBox id="cmbspmp" tabIndex="5" runat="server" Width="90%" AutoPostBack="True" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 16px" align="left">Specializzazione
														<asp:RangeValidator id="Rfvtr" runat="server" ErrorMessage="Nessuna Specializzazione selezionata" ControlToValidate="cmbstr"
															MinimumValue="1" MaximumValue="99999999999">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 16px">
														<cc1:S_ComboBox id="cmbstr" tabIndex="6" runat="server" Width="90%" DBDataType="Integer"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px" align="left">Codice Procedura di Manutenzione</TD>
													<TD>
														<cc1:S_TextBox id="txtspmp_id" tabIndex="7" runat="server" Width="50%"></cc1:S_TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px">Dismesso:</TD>
													<TD>
														<cc1:s_checkbox id="ChekDismesso" tabIndex="8" runat="server"></cc1:s_checkbox></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="WIDTH: 83px; HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="8" runat="server" Text="Salva" CssClass="btn"></cc1:s_button>&nbsp;
										<cc1:s_button id="btnsElimina" tabIndex="9" runat="server" Text="Elimina" CommandType="Delete"
											CausesValidation="False" CssClass="btn"></cc1:s_button>&nbsp;
										<asp:button id="btnAnnulla" tabIndex="10" runat="server" Text="Annulla" CausesValidation="False"
											CssClass="btn"></asp:button></TD>
								</tr>
								<TR>
									<TD style="WIDTH: 83px; HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr noShade SIZE="1">
									</TD>
								</TR>
				</TR>
				<TR>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<asp:validationsummary id="vlsEdit" runat="server" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary></TD></TR></TBODY></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
