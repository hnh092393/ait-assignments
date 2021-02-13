<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="AITR.Views.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In Page</title>
</head>
<body>
    <%-- navigation bar --%>
    <nav>
        <a>
            <asp:Image ID="imgLogo" runat="server" Height="64px" ImageUrl="~/Images/logo.png" Width="64px" />
        </a>
    </nav>

    <%-- form including username and password fields --%>
    <form id="form1" runat="server">
        <div>

            <h2>Log In</h2>

            <%-- username field --%>
            <div>
                <asp:Label runat="server" for="txtUsername" Text="Username"></asp:Label>
                <br />
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ErrorMessage="This field can not be empty!" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox runat="server" ID="txtUsername" placeholder="your username" name="txtUsername" />
                    <br />
                </div>
            </div>

            <br />

            <%-- password field --%>
            <div>
                <asp:Label runat="server" for="txtPassword" Text="Password"></asp:Label>
                <br />
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="This field can not be empty!" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                <div>
                    <asp:TextBox runat="server" ID="txtPassword" placeholder="your password" name="txtPassword" />
                </div>
            </div>

            <div>
                <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
            &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
            </div>
        </div>
    </form>
</body>
</html>
