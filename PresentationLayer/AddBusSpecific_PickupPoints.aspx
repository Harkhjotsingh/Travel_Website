<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddBusSpecific_PickupPoints.aspx.cs" Inherits="PresentationLayer.AddBusSpecific_PickupPoints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style6 {
        color: #996600;
    }
    .auto-style7 {
        width: 43px;
        margin-left: 120px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="auto-style6">
    <strong><em>Please select the Bus from the first list and Pickup Points from that Bus from Second list. </em></strong>
</p>
<p>
    Select Bus&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlSelectBus" runat="server">
    </asp:DropDownList>
</p>
<p>
    Select Pickup Point&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlSelectPickupPoint" runat="server">
    </asp:DropDownList>
</p>
<p class="auto-style7">
    <asp:Button ID="btnAdd" runat="server" CssClass="auto-style6" ForeColor="#000066" Height="32px" Text="Add" Width="45px" OnClick="btnAdd_Click" />
</p>
</asp:Content>
