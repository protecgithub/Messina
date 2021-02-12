<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>

<%@ Page Language="c#" CodeBehind="Login.aspx.cs" AutoEventWireup="false" Inherits="TheSite.Login" %>

<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Login</title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <style type="text/css">
        BODY {
            MARGIN: 0px
        }

        INPUT {
            BORDER-RIGHT: #464a50 1px solid;
            PADDING-RIGHT: 2px;
            BORDER-TOP: #464a50 1px solid;
            PADDING-LEFT: 2px;
            FONT-WEIGHT: normal;
            FONT-SIZE: 11px;
            PADDING-BOTTOM: 2px;
            BORDER-LEFT: #464a50 1px solid;
            COLOR: #0a305c;
            PADDING-TOP: 2px;
            BORDER-BOTTOM: #464a50 1px solid;
            FONT-FAMILY: Tahoma
        }
    </style>
    <!--<LINK href="Styles/MenuStyle.css" type="text/css" rel="stylesheet">-->
    <link href="Css/MainSheet.css" type="text/css" rel="stylesheet">
    <script language="javascript">		 
        if (typeof (parent.left) != "undefined") {
            top.document.location.href = 'Default.aspx'
        }
    </script>
</head>
<body ms_positioning="GridLayout">
    <form id="Form1" method="post" runat="server">
        <table height="100%" cellspacing="0" cellpadding="0" align="center" border="0" runat="server" id="tableLogin" visible="true">
            <tr>
                <td style="height: 0.24%">&nbsp;</td>
            </tr>
            <tr>
                <td valign="middle">
                    <div align="center">
                        <table style="border-right: slategray 1px outset; border-top: slategray 1px outset; border-left: slategray 1px outset; width: 430px; border-bottom: slategray 1px outset; height: 300px"
                            cellspacing="1" cellpadding="2" align="center" bgcolor="#9bbec2" border="0">
                            <tr>
                                <td style="height: 35px" valign="middle" colspan="2" class="TitleSearch" align="center">
                                    <b>
                                        <%= System.Configuration.ConfigurationSettings.AppSettings["ApplicationName"]%>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px; height: 95px" valign="middle"></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="height: 18px" valign="middle" align="right">
                                    <span class="TestoNormale" style="color: white">USER</span></td>
                                <td style="height: 18px">
                                    <cc1:S_TextBox ID="txtsUserName" runat="server" DBDirection="Input" DBSize="50" DBParameterName="p_UserName"
                                        Width="130px"></cc1:S_TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" CssClass="LabelErrore" ControlToValidate="txtsUserName"
                                        ErrorMessage="Inserire l'utenza" ForeColor="White"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="height: 13px" valign="middle" align="right">
                                    <span class="TestoNormale" style="color: white">PASSWORD</span></td>
                                <td style="height: 13px">
                                    <cc1:S_TextBox ID="txtsPasword" runat="server" DBDirection="Input" DBSize="50" DBParameterName="p_Password"
                                        Width="130px" DBIndex="1" TextMode="Password"></cc1:S_TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server" CssClass="LabelErrore" ControlToValidate="txtsPasword"
                                            ErrorMessage="Inserire la password" ForeColor="White"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="height: 43px" colspan="2" align="center">
                                    <asp:Button ID="BttConferma" runat="server" Text="Conferma" CssClass="btn"></asp:Button></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">Inserisci la username e la password relativa al sistema informativo:
                                    <br />
                                    <b>SIR Martino</b></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <p align="center">
                                        <MessPanel:MessagePanel ID="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"
                                            HorizontalAlign="Center" Wrap="False">
                                        </MessPanel:MessagePanel>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>

        <!-- inserimento dati mancanti-->
        <table height="100%" cellspacing="0" cellpadding="0" align="center" border="0" runat="server" id="tableDati" visible="false">
            <tr>
                <td style="height: 0.24%">&nbsp;</td>
            </tr>
            <tr>
                <td valign="middle">
                    <div align="center">
                        <table style="border-right: slategray 1px outset; border-top: slategray 1px outset; border-left: slategray 1px outset; width: 430px; border-bottom: slategray 1px outset; height: 300px"
                            cellspacing="1" cellpadding="2" align="center" bgcolor="#9bbec2" border="0">
                            <tr>
                                <td style="height: 35px" valign="middle" colspan="2" class="TitleSearch" align="center">
                                    <b>
                                        <%= System.Configuration.ConfigurationSettings.AppSettings["ApplicationName"]%>
                                        <p>Ai sensi delle normative sui dati personali si prega di inserire i dati richiesti, altrimenti non è possibile procedere</p>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 130px; height: 95px" valign="middle"></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="height: 18px" valign="middle" align="right">
                                    <span class="TestoNormale" style="color: white">NOME</span></td>
                                <td style="height: 18px">
                                    <cc1:S_TextBox ID="S_TextBoxNome" runat="server" DBDirection="Input" DBSize="50" DBParameterName="p_UserName"
                                        Width="130px"></cc1:S_TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNome" runat="server" CssClass="LabelErrore" ControlToValidate="S_TextBoxNome"
                                        ErrorMessage="Inserire il nome" ForeColor="White"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="height: 13px" valign="middle" align="right">
                                    <span class="TestoNormale" style="color: white">COGNOME</span></td>
                                <td style="height: 13px">
                                    <cc1:S_TextBox ID="S_TextBoxCognome" runat="server" DBDirection="Input" DBSize="50" DBParameterName="p_Password"
                                        Width="130px" DBIndex="1"></cc1:S_TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="LabelErrore" ControlToValidate="S_TextBoxCognome"
                                            ErrorMessage="Inserire il cognome" ForeColor="White"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td style="height: 13px" valign="middle" align="right">
                                    <span class="TestoNormale" style="color: white">EMAIL</span></td>
                                <td style="height: 13px">
                                    <cc1:S_TextBox ID="S_TextBoxEmail" runat="server" DBDirection="Input" DBSize="50" DBParameterName="p_Password"
                                        Width="130px" DBIndex="2"></cc1:S_TextBox>
                                    <asp:RegularExpressionValidator ID="EmailValidator" runat="server" CssClass="LabelErrore" ControlToValidate="S_TextBoxEmail"
                                        ForeColor="White" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
                                        ErrorMessage="Email non valida" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="LabelErrore" ControlToValidate="S_TextBoxEmail"
                                        ErrorMessage="Inserire l'email" ForeColor="White"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td style="height: 43px" colspan="2" align="center">
                                    <asp:Button ID="ButtonAggiornaDati" runat="server" Text="Conferma" CssClass="btn"></asp:Button></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">Inserisci la username e la password relativa al sistema informativo:
                                    <br />
                                    <b>SIR Martino</b></td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <p align="center">
                                        <MessPanel:MessagePanel ID="MessagePanel1" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"
                                            HorizontalAlign="Center" Wrap="False">
                                        </MessPanel:MessagePanel>
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>


    </form>
</body>
</html>
