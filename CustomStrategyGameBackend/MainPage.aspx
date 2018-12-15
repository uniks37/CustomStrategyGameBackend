<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="CustomStrategyGameBackend.MainPage" %>

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
                    <li class="nav-item active">
                        <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="RankingsPage.aspx">Rankings</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="#">Global Standing</a>
                    </li>
                    <li class="nav-item">
                        <asp:LinkButton ID="logoutBtn" runat="server" CssClass="nav-link" OnClick="logoutBtn_Click">Logout</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </nav>
        <div class="jumbotron">
            <h1>Hey <%= mainPage.uname %>!</h1>
            <p>Welcome to our strategy game! It is custom and at a very primitive stage! But we are trying to improve it.</p>
        </div>
        
        <div class="row">
            <div class="col-3"></div>
            <div class="col-5">
                <div class="jumbotron">
                    <asp:Label ID="Label1" runat="server" Text="Search Your Opponent:"></asp:Label>
                    <asp:TextBox ID="unameSearchTxt" runat="server" CssClass="form-group"></asp:TextBox>
                    <asp:Button ID="seachBtn" runat="server" Text="Search" CssClass="btn btn-light"/>
                </div>
            </div>
            <div class="col-4">

            </div>
        </div>

        <script src="Scripts/bootstrap.min.js"></script>
        <script src="Scripts/jquery-3.3.1.min.js"></script>
        <script src="Scripts/popper.min.js"></script>
    </form>
</body>
</html>
