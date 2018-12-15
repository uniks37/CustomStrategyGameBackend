<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoggedOutPage.aspx.cs" Inherits="CustomStrategyGameBackend.LoggedOutPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Confirmation Page</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1 class="display-4">You have been succesfully logged out!</h1>
            <p class="lead">Please
                <asp:HyperLink ID="loginLink" runat="server" NavigateUrl="~/Login.aspx">Click Here</asp:HyperLink>
                to reach at login page.</p>
            <hr class="my-4">
            <p>It uses utility classes for typography and spacing to space content out within the larger container.</p>
            <p class="lead">
                <a class="btn btn-primary btn-lg" href="#" role="button">Learn more</a>
            </p>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</body>
</html>
