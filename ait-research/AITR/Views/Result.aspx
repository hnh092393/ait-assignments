<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="AITR.Views.Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Respondent Answer List"></asp:Label>

    <br />

    <asp:Table ID="tblAnswer" runat="server" GridLines="Both">
        <asp:TableRow>
            <asp:TableCell>
                Question
            </asp:TableCell>
            <asp:TableCell>
                Answer
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
</asp:Content>
