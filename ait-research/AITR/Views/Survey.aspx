<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="AITR.Views.Survey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <asp:Label ID="lblQuestion" runat="server" Text="Question"></asp:Label>
            :<br />
        </div>
        <div>

            <asp:PlaceHolder ID="phQuestion" runat="server"></asp:PlaceHolder>

            <br />
            <br />
            <asp:Button ID="btnSkip" runat="server" Text="Skip" />
&nbsp;&nbsp;&nbsp;

            <asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click"/>
        </div>
    </div>
</asp:Content>
