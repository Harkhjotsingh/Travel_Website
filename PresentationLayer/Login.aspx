<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentationLayer.Login" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="Style-Sheets/StyleSheetMainMaster.css" rel="stylesheet" type="text/css" />
    <link href="Style-Sheets/StyleSheetLogin.css" rel="stylesheet" type="text/css" />
    <div id="loginpage">
        <div id="userlogin">
            Log In 
            <br />
            <br />
            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
            <br />
            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="userLogin">*</asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
            <br />
            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="userLogin">*</asp:RequiredFieldValidator>
            <br />
            <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
            <br />
            <br />
            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="userLogin" OnClick="LoginButton_Click" />

            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
        </div>
    </div>
</asp:Content>

