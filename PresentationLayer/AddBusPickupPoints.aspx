<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddBusPickupPoints.aspx.cs" Inherits="PresentationLayer.AddBusPickupPoints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style6 {
        margin-left: 160px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Pickup ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPickupId" runat="server"></asp:TextBox>
</p>
<p>
    Pickup Location:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPickupLocation" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lblPickupLocation" runat="server" ForeColor="Red"></asp:Label>
</p>
<p class="auto-style6">
    <asp:Button ID="btnAddBus" runat="server" OnClick="btnAddBus_Click" Text="Add" />
&nbsp;&nbsp;
</p>
</asp:Content>
