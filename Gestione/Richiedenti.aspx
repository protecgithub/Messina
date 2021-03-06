<%@ Register TagPrefix="Collapse" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Page language="c#" Codebehind="Richiedenti.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Gestione.Richiedenti" %>
<%@ Register TagPrefix="uc1" TagName="GridTitle" Src="../WebControls/GridTitle.ascx" %>
<%@ Register TagPrefix="uc1" TagName="PageTitle" Src="../WebControls/PageTitle.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Richiedenti_tipo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Css/MainSheet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onbeforeunload="parent.left.valorizza()" bottomMargin="0" leftMargin="5" topMargin="0"
		rightMargin="0" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="TableMain" style="Z-INDEX: 101; POSITION: absolute; WIDTH: 100%; TOP: 0px; LEFT: 0px"
				cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center">
						<uc1:PageTitle id="PageTitle1" runat="server"></uc1:PageTitle></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="tblForm" cellSpacing="1" cellPadding="1" align="center">
							<tbody>
								<TR>
									<TD Align="center">
										<Collapse:DataPanel id="PanelRicerca" runat="server" ExpandImageUrl="../Images/down.gif" CollapseImageUrl="../Images/up.gif"
											CollapseText="Riduci" ExpandText="Espandi" Collapsed="False" AllowTitleExpandCollapse="True" TitleText="Ricerca"
											CssClass="DataPanel75" TitleStyle-CssClass="TitleSearch">
											<TABLE id="tblSearch100" border="0" cellSpacing="1" cellPadding="2">
												<TR>
													<TD style="WIDTH: 8%" align="left"><B>Nome</B></TD>
													<TD>
														<cc1:S_TextBox id="txtsNome" runat="server" DBIndex="0" DBParameterName="p_nomecompleto" DBDirection="Input"
															width="100%" DBSize="128"></cc1:S_TextBox></TD>
													<TD align="right"><B>Progetto</B></TD>
													<TD colSpan="2">
														<CC1:S_COMBOBOX id="CmbProgetto" tabIndex="8" runat="server" dbdatatype="Integer" dbparametername="p_progetto"
															dbdirection="Input" dbsize="1" dbindex="5"></CC1:S_COMBOBOX></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 8%" align="left"><B>Cognome</B></TD>
													<TD>
														<cc1:S_TextBox id="txtsCognome" runat="server" DBIndex="1" DBParameterName="p_cognomecompleto"
															DBDirection="Input" width="100%" DBSize="255"></cc1:S_TextBox></TD>
													<TD align="right"><B>Gruppo</B></TD>
													<TD colSpan="2">
														<CC1:S_COMBOBOX style="Z-INDEX: 0" id="cmbTipRich" tabIndex="8" runat="server" dbdatatype="Integer"
															dbparametername="p_tipo_rich" dbdirection="Input" dbsize="1" dbindex="6"></CC1:S_COMBOBOX></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 4px" align="right"></TD>
													<TD></TD>
													<TD style="WIDTH: 8px" align="right"></TD>
													<TD style="WIDTH: 101px" align="right"></TD>
													<TD></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 339px" colSpan="3" align="left">&nbsp;
														<TABLE>
															<TR>
																<TD>
																	<cc1:S_Button id="btnsRicerca" runat="server" CssClass="btn" Text="Ricerca"></cc1:S_Button></TD>
																<TD>
																	<cc1:S_Button id="BtnReset" tabIndex="4" runat="server" CssClass="btn" Text="Reset"></cc1:S_Button></TD>
															</TR>
														</TABLE>
													</TD>
													<TD align="right"></TD>
													<TD align="right"><A class=GuidaLink href="<%= HelpLink %>" 
                  target=_blank>Guida</A></TD>
												</TR>
											</TABLE>
										</Collapse:DataPanel>
									</TD>
								</TR>
								<tr>
									<TD align="center">
										<uc1:GridTitle id="GridTitle1" runat="server"></uc1:GridTitle>
										<asp:DataGrid id="DataGridRicerca" runat="server" CssClass="DataGrid" BorderColor="Gray" BorderWidth="1px"
											GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True">
											<AlternatingItemStyle CssClass="DataGridAlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="DataGridItemStyle"></ItemStyle>
											<HeaderStyle CssClass="DataGridHeaderStyle"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton3" Runat=server CommandName="Dettaglio" ImageUrl="../images/Search16x16_bianca.jpg" CommandArgument='<%# "EditRichiedenti.aspx?ItemID=" + DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=read"%>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton1" Runat=server CommandName="Dettaglio" ImageUrl="../images/edit.gif" CommandArgument='<%# "EditRichiedenti.aspx?ItemID="+ DataBinder.Eval(Container.DataItem,"ID") + "&FunId=" + FunId + "&TipoOper=write"%>'>
														</asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="RichNome" HeaderText="Nome">
													<HeaderStyle Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="RichCognome" HeaderText="Cognome">
													<HeaderStyle Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="tipo_richiedente" HeaderText="Gruppo">
													<HeaderStyle Width="25%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Progetto" HeaderText="Progetto">
													<HeaderStyle Width="25%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Mode="NumericPages"></PagerStyle>
										</asp:DataGrid>
									</TD>
								</tr>
							</tbody>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">parent.left.calcola();</script>
	</body>
</HTML>
