<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RankingsPage.aspx.cs" Inherits="CustomStrategyGameBackend.RankingsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CustomStrategy</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <a class="navbar-brand" href="#">Navbar</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavDropdown">
                <ul class="navbar-nav">
                    <li class="nav-item">
                        <a class="nav-link" href="MainPage.aspx">Home <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Rankings<span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="logoutBtn" runat="server" CssClass="nav-link">Logout</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="jumbotron">
            <h1>Hey <%= rankingPage.uname %>!</h1>
            <p>Welcome to our strategy game! It is custom and at a very primitive stage! But we are trying to improve it.</p>
        </div>

        <script src="Scripts/bootstrap.min.js"></script>
        <script src="Scripts/jquery-3.3.1.min.js"></script>
        <script src="Scripts/popper.min.js"></script>
    </form>
</body>
</html>

