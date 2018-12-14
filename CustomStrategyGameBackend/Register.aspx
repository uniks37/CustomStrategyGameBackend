<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CustomStrategyGameBackend.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <a class="navbar-brand" href="#">StrategyGame</a>
        </nav>
        <div class="row" style="padding-top: 5%">
            <div class="col-md-1"></div>
            <div class="col-md-4 roundborder">
                <div class="jumbotron">
                    <p>We will soon be having a beautiful tutorial video for this game. Please, stay tuned.</p>
                </div>
            </div>
            <div class="col-md-1 border-right border-light border-1"></div>
            <div class="col-md-1"></div>
            <div class="col-md-4 roundborder">
                <div class="jumbotron">
                    <div class="clearfix">
                        <p class="font-weight-bold" style="font-size: large">Register</p>
                        <hr/>
                        <div class="form-group form-row">
                            <label class="col-form-label col-md-3" for="emailtxt">Email-Id</label>
                            <div class="col-md-7">
                                <asp:TextBox ID="emailtxt" runat="server" CssClass="form-control" TextMode="Email" AutoCompleteType="Email"></asp:TextBox>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                        <div class="form-group form-row">
                            <label class="col-form-label col-md-3" for="unametxt">Username</label>
                            <div class="col-md-7">
                                <asp:TextBox ID="unametxt" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                        <div class="form-group form-row">
                            <asp:Label ID="passtxtLbl" runat="server" Text="Password" CssClass="col-form-label col-md-3"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox ID="passtxt" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>                            
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                        <div class="form-group form-row">
                            <asp:Label ID="passLbl" runat="server" Text="Verify Password" CssClass="col-form-label col-md-3"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox ID="passverifytxt" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                        <hr/>
                        <asp:Button ID="regBtn" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="regBtn_Click"/>
                        <div class="form-group">
                            <asp:HyperLink ID="loginLink" runat="server" CssClass="float-md-right" NavigateUrl="~/Login.aspx">Recalled Password</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</body>
</html>
