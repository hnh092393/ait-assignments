<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AITR.Views.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Register"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="First Name"></asp:Label>
            <br />
            <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="This field is required." ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>

            <br />

            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Last Name"></asp:Label>
            <br />
            <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="This field is required." ControlToValidate="txtLastName"></asp:RequiredFieldValidator>

            <br />

            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Email Address"></asp:Label>
            <br />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="This field is required." ControlToValidate="txtEmail"></asp:RequiredFieldValidator>

            <br />

            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Phone Number"></asp:Label>
            <br />
            <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="This field is required." ControlToValidate="txtPhone"></asp:RequiredFieldValidator>

            <br />

            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Text="Date of Birth"></asp:Label>

            <br />

            <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ErrorMessage="This field is required." ControlToValidate="txtDOB"></asp:RequiredFieldValidator>

            <br />

            <asp:TextBox ID="txtDOB" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:ImageButton ID="btnCalendar" runat="server" Height="64px" ImageUrl="~/Images/calendar.png" Width="64px" CausesValidation="False" OnClick="btnCalendar_Click" />

            <br />
            <br />
            <asp:Calendar ID="calendar" runat="server" OnSelectionChanged="calendar_SelectionChanged"></asp:Calendar>

            <br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <br />
        </div>

    </div>
</asp:Content>
