<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AITR.Views.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="AIT Research Survey"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btnSurvey" runat="server" OnClick="btnSurvey_Click" Text="Enter the Survey" />
</asp:Content>




