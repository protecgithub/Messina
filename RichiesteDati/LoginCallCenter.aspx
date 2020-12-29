<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginCallCenter.aspx.cs" Inherits="TheSite.LoginCallCenter" %>

<%@ Register TagPrefix="cc1" Namespace="S_Controls" Assembly="S_Controls" %>
<%@ Register TagPrefix="MessPanel" Namespace="Csy.WebControls" Assembly="CsyWebControls" %>


<form id="Form1" method="post" runat="server">
    <MessPanel:MessagePanel ID="PanelMess" runat="server" MessageIconUrl="~/Images/ico_info.gif" ErrorIconUrl="~/Images/ico_critical.gif"
        HorizontalAlign="Center" Wrap="False">
    </MessPanel:MessagePanel>

    <cc1:S_TextBox ID="txtsUserName" runat="server" DBDirection="Input" DBSize="50" DBParameterName="p_UserName"
        Width="130px"></cc1:S_TextBox>
    <cc1:S_TextBox ID="txtsPasword" runat="server" DBDirection="Input" DBSize="50" DBParameterName="p_Password"
        Width="130px" DBIndex="1" TextMode="Password"></cc1:S_TextBox>
</form>
