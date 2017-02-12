<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="UpdateDestinationPoints.aspx.cs" Inherits="PresentationLayer.UpdateDestinationPoints" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            margin-left: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Destination ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtDestinationID" runat="server" ReadOnly="True"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Destination ID cannot be edited"></asp:Label>
    </p>
    <p>
        Destination Location:&nbsp;&nbsp;
        <asp:TextBox ID="txtDestinationLocation" runat="server" Width="125px"></asp:TextBox>
        <asp:Label ID="lblDestinationLocation" runat="server" ForeColor="Red">*</asp:Label>
    </p>
    <p class="auto-style6">
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
    </p>
    <p class="auto-style6">
        <strong><em>
        <asp:Label ID="lblMessage" runat="server" ForeColor="#009900"></asp:Label>
        </em></strong>
    </p>
</asp:Content>
