<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddDestinationIDs.aspx.cs" Inherits="PresentationLayer.AddDestinationIDs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style6 {
        margin-left: 160px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Destination ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtDestinationID" runat="server"></asp:TextBox>
</p>
<p>
    Destination Location:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDestinationLocation" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lblDestinationLocation" runat="server" ForeColor="Red"></asp:Label>
</p>
<p class="auto-style6">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
</p>
<p class="auto-style6">
    <strong><em>
    <asp:Label ID="lblMessage" runat="server" ForeColor="#006600"></asp:Label>
    </em></strong>&nbsp;</p>
</asp:Content>
