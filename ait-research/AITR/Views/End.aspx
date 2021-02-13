<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="End.aspx.cs" Inherits="AITR.Views.End" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>

    <div>
        <asp:Button ID="btnLogInPage" runat="server" Text="Log In" OnClick="btnLogInPage_Click" />

        <br />
        <br />

        <asp:Button ID="btnRegisterPage" runat="server" Text="Register" OnClick="btnRegisterPage_Click"/>

        <br />
        <br />

        <asp:Button ID="btnAnswerPage" runat="server" Text="Answer Page" OnClick="btnAnswerPage_Click"/>
    </div>
</asp:Content>
