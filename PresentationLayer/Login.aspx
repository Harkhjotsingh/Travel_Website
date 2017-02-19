<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentationLayer.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style-Sheets/StyleSheetMainMaster.css" rel="stylesheet" type="text/css" />
    <link href="Style-Sheets/StyleSheetLogin.css" rel="stylesheet" type="text/css" />
    <div id="loginpage">
        <img id="busImage" src="Images/bus1.jpg" />
        <div id="userlogin">
            <p>Welcome Admin</p>
            <br />
            <asp:TextBox placeholder="User Name" runat="server" ID="UserName"></asp:TextBox>            
            <br />
            <asp:TextBox type="password" placeholder="Password" runat="server" ID="Password"></asp:TextBox>
            <br />
            <asp:Button  text="Log In" ID="btnLogin" runat="server" OnClick="LoginButton_Click" />
            <br />
            <br />
            <asp:Label ID="lblErrMsg" Text="" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>

