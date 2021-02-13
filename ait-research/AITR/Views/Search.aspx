<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="AITR.Views.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="First Name"></asp:Label>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field is required!" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Postcode"></asp:Label>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This field is required!" ControlToValidate="txtPostcode"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtPostcode" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Bank Used"></asp:Label>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="This field is required!" ControlToValidate="txtBankUsed"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtBankUsed" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Bank Service"></asp:Label>
    <br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="This field is required!" ControlToValidate="txtBankService"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtBankService" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnSearch" runat="server" Text="Search" />
    <br />
    <br />
    <br />
    <br />


    <asp:Table ID="tblRespondent" runat="server" GridLines="Both">
        <asp:TableRow>
            <asp:TableCell>
                Respondent
            </asp:TableCell>
            <asp:TableCell>
                IP
            </asp:TableCell>
            <asp:TableCell>
                First Name
            </asp:TableCell>
            <asp:TableCell>
                Last Name
            </asp:TableCell>
            <asp:TableCell>
                Date of Birth
            </asp:TableCell>
            <asp:TableCell>
                Phone
            </asp:TableCell>
        </asp:TableRow>

    </asp:Table>
</asp:Content>
