<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="cc2" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="uc1" TagName="CalendarPicker" Src="../WebControls/CalendarPicker.ascx" %>
<%@ Register TagPrefix="uc1" TagName="VisualizzaReperibilita" Src="../WebControls/VisualizzaReperibilita.ascx" %>
<%@ Page language="c#" Codebehind="EditRepAddetti1.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.EditRepAddetti1" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EditRepAddetti1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Css/MainSheet.css">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" MS_POSITIONING="GridLayout">
		<script language="JavaScript">
		function Valorizza(val)
			{
				document.getElementById("txtHidden").value=val;
			}
			
		function SoloNumeri()
		{	
			if (event.keyCode < 48	|| event.keyCode > 57){
				event.keyCode = 0;
			}	
		}
		function Formatta(txt)
		{
			testo=document.getElementById(txt);
			if(testo.value.length==0)
				testo.value="00";
			if(testo.value.length==1)
				testo.value="0"+testo.value;		
		}
		function Controlla()
		{
			var ora=parseInt(document.getElementById("<%=txtsorain.ClientID%>").value);
			var minuti=parseInt(document.getElementById("<%=txtsorainmin.ClientID%>").value);
			var ore=(document.getElementById("<%=txtsorain.ClientID%>").value)+(document.getElementById("<%=txtsorainmin.ClientID%>").value)
			
						
			if(document.getElementById("txtHidden").value=="1")
			{
			
				if(ora<0 || ora>23)
				{ 

					alert("Attenzione l'ora deve essere compresa tra 00 e 23");		
					document.getElementById("<%=txtsorain.ClientID%>").focus()
					return false;
				}	
				if(minuti<0 || minuti>59)
				{
					alert("Attenzione i minuti deve essere compresa tra 00 e 59");		
					document.getElementById("<%=txtsorainmin.ClientID%>").focus();
					return false;
				}
				
				var ora1=parseInt(document.getElementById("<%=txtsoraout.ClientID%>").value);
				var minuti1=parseInt(document.getElementById("<%=txtsoraoutmin.ClientID%>").value);
				var ore1=(document.getElementById("<%=txtsoraout.ClientID%>").value) + document.getElementById("<%=txtsoraoutmin.ClientID%>").value;
							
				if(ora1<0 || ora1>23)
				{ 

					alert("Attenzione l'ora deve essere compresa tra 00 e 23");		
					document.getElementById("<%=txtsoraout.ClientID%>").focus()
					return false;
				}	
				if(minuti1<0 || minuti1>59)
				{
					alert("Attenzione i minuti deve essere compresa tra 00 e 59");		
					document.getElementById("<%=txtsoraoutmin.ClientID%>").focus();
					return false;
				}
				if(ore>ore1)
				{
					alert("Attenzione l'ora fine turno non pu� essere minore di quella di inizio");		
					document.getElementById("<%=txtsoraoutmin.ClientID%>").focus();
					return false;
				}
				return true;
			}
			else
			{
			    return true;
			}
		}
		</script>
		<form id="Form1" onsubmit="return Controlla();" method="post" runat="server">
			<TABLE style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; HEIGHT: 100%; TOP: 0px; LEFT: 0px"
				id="TableMain" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD style="HEIGHT: 50px" align="center"><uc1:pagetitle id="PageTitle1" runat="server"></uc1:pagetitle></TD>
				</TR>
				<TR height="95%" vAlign="top" align="center">
					<TD>
						<TABLE id="tblFormInput" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center">
							<TBODY>
								<TR>
									<INPUT id="txtHidden" type="hidden">
									<TD style="WIDTH: 5%; HEIGHT: 5%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblOperazione" runat="server" CssClass="TitleOperazione" Width="584px"></asp:label><cc2:messagepanel id="PanelMess" runat="server" ErrorIconUrl="~/Images/ico_critical.gif" MessageIconUrl="~/Images/ico_info.gif"></cc2:messagepanel></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr SIZE="1" noShade>
									</TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center"></TD>
									<TD vAlign="top" width="100%" align="left"><asp:panel id="PanelEdit" runat="server" Width="100%">
											<TABLE id="tblSearch100" border="0" cellSpacing="1" cellPadding="2" width="100%">
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 32px" align="left">Addetto
														<asp:RangeValidator id="RVraddetto" runat="server" ControlToValidate="cmbsadd" MaximumValue="999999999999999999"
															MinimumValue="1" ErrorMessage="Selezionare Addetto">*</asp:RangeValidator></TD>
													<TD style="HEIGHT: 32px">
														<cc1:S_ComboBox id="cmbsadd" tabIndex="4" runat="server" Width="60%" DBDataType="Integer" DBIndex="0"
															DBParameterName="p_addetto_id" DBSize="10" DBDirection="Input"></cc1:S_ComboBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Data Inizio Turno</TD>
													<TD style="HEIGHT: 24px">
														<asp:TextBox id="txtsorain" runat="server" Width="30px"></asp:TextBox>
														<DIV style="WIDTH: 24px; DISPLAY: inline; HEIGHT: 15px" ms_positioning="FlowLayout">&nbsp;&nbsp;:</DIV>
														<asp:TextBox id="txtsorainmin" runat="server" Width="30px"></asp:TextBox></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 181px; HEIGHT: 24px" align="left">Data Fine Turno</TD>
													<TD style="HEIGHT: 24px">
														<asp:TextBox id="txtsoraout" runat="server" Width="30px"></asp:TextBox>
														<DIV style="WIDTH: 24px; DISPLAY: inline; HEIGHT: 15px" ms_positioning="FlowLayout">&nbsp;&nbsp;:</DIV>
														<asp:TextBox id="txtsoraoutmin" runat="server" Width="30px"></asp:TextBox></TD>
												</TR>
											</TABLE>
											<TABLE>
												<TR>
													<TD align="center">
														<asp:listbox id="ListBoxLeft" tabIndex="7" runat="server" Width="280px" Rows="8"></asp:listbox></TD>
													<TD>
														<P align="center">
															<asp:button id="btnAssocia" tabIndex="14" runat="server" Width="110px" CssClass="btn" CausesValidation="False"
																Text="Aggiungi >>"></asp:button></P>
														<P align="center">
															<asp:button id="btnElimina" tabIndex="15" runat="server" Width="110px" CssClass="btn" CausesValidation="False"
																Text="<< Elimina"></asp:button></P>
													</TD>
													<TD align="center">
														<asp:listbox id="ListBoxRight" tabIndex="10" runat="server" Width="272px" Rows="8"></asp:listbox>
														<asp:RangeValidator style="Z-INDEX: 0" id="RangeValidator1" runat="server" ControlToValidate="ListBoxRight"
															MaximumValue="999999999999999999" MinimumValue="1" ErrorMessage="Nessun Giorno Associato">*</asp:RangeValidator></TD>
												</TR>
											</TABLE>
										</asp:panel></TD>
								</TR>
								<tr>
									<TD style="HEIGHT: 3.46%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 3.46%" vAlign="top" align="left"><cc1:s_button id="btnsSalva" tabIndex="7" runat="server" CssClass="btn" Text="Salva"></cc1:s_button>&nbsp;&nbsp;&nbsp;
										<asp:button id="btnAnnulla" tabIndex="9" runat="server" CssClass="btn" CausesValidation="False"
											Text="Annulla"></asp:button><uc1:visualizzareperibilita id="VisualizzaReperibilita1" runat="server"></uc1:visualizzareperibilita></TD>
								</tr>
								<TR>
									<TD style="HEIGHT: 1%" vAlign="top" align="left"></TD>
									<TD style="HEIGHT: 1%" vAlign="top" align="left">
										<hr SIZE="1" noShade>
									</TD>
								</TR>
				</TR>
				<TR>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"></TD>
					<TD style="HEIGHT: 5%" vAlign="top" align="left"><asp:label id="lblFirstAndLast" runat="server"></asp:label>&nbsp;
					</TD>
				</TR>
			</TABLE>
			<asp:validationsummary id="vlsEdit" runat="server" ShowMessageBox="True" ShowSummary="False"></asp:validationsummary></TD></TR></TBODY></TABLE></form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
