<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="AddBus.aspx.cs" Inherits="PresentationLayer.AddBus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            margin-top: 2px;
        }
        .auto-style8 {
            color: #009900;
            font-size: x-large;
        }
        p{
            margin:5px;        
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="auto-style8"><strong>ADD BUS</strong></span></p>
    <p>
        Enter Bus Number:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:TextBox ID="TxtBusNumber" runat="server" CssClass="auto-style1" Height="20px" Width="120px" ></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
    </p>
    <p>
        Starting Point:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TxtStratingPoint" runat="server" CssClass="auto-style1" Height="20px" Width="120px"></asp:TextBox>&nbsp;
    </p>
    <p>
        Destination:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TxtDestination" runat="server" Width="120px" CssClass="auto-style1" Height="20px"></asp:TextBox>
    </p>
    <p>
        Capacity:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TxtCapacity" runat="server" Height="20px" Width="119px" ></asp:TextBox>&nbsp;
    </p>
    <p>
        Departure Time:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TxtDepartureTime" runat="server" CssClass="auto-style1" Height="20px" Width="120px" ></asp:TextBox>
    </p>
    <p>
        &nbsp;Arr&nbsp;Arrival Time:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TxtArrivalTime" runat="server" CssClass="auto-style1" Height="20px" Width="120px" ></asp:TextBox>
    </p>
    <p>
        Company Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TxtCompanyName" runat="server" CssClass="auto-style1" Height="20px" Width="120px"></asp:TextBox>&nbsp;
    </p>
    <p>
        Bus Type:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:ListBox ID="ListBusType" runat="server" CssClass="auto-style1" Height="20px" Width="120px">
            <asp:ListItem>Single Deck</asp:ListItem>
            <asp:ListItem>Double Decker</asp:ListItem>
        </asp:ListBox>
    </p>
    <p>
        <asp:Button ID="btnAddBus" runat="server" Text="Add Bus" OnClick="btnAddBus_Click" />
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        &nbsp;
    </p>
</asp:Content>
