<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CustomStrategyGameBackend.DefaultPage" %>

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
                        <p class="font-weight-bold" style="font-size: large">Sign In</p>
                        <hr/>
                        <div class="form-group form-row">
                            <label class="col-form-label col-md-3" for="unametxt">Username</label>
                            <div class="col-md-7">
                                <asp:TextBox ID="unametxt" runat="server" CssClass="form-control" ></asp:TextBox>                            
                                <asp:RequiredFieldValidator ID="unametxtVal" runat="server" ErrorMessage="Username is required." ControlToValidate="unametxt" CssClass="alert-danger"></asp:RequiredFieldValidator>                                                        
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                        <div class="form-group form-row">
                            <label class="col-form-label col-md-3" for="unamepass">Password</label>
                            <div class="col-md-7">
                                <asp:TextBox ID="passtxt" MaxLength="16" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></div>
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="passtxtVal" runat="server" ErrorMessage="Password is required." ControlToValidate="passtxt" CssClass="alert-danger"></asp:RequiredFieldValidator>                            
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="form-check">
                                <asp:CheckBox ID="remMe" runat="server" CssClass="form-check-input" OnCheckedChanged="remMe_CheckedChanged"/>
                                <asp:Label ID="remMeLbl" runat="server" Text="Label" CssClass="form-check-label" >Keep me posted</asp:Label>
                                
                            </div>
                        </div>
                        <hr>
                        <asp:Button ID="signinBtn" runat="server" Text="Sign In" CssClass="btn btn-primary" OnClick="signinBtn_Click" />
                        <div class="form-group">
                            <asp:HyperLink ID="fpassLink" runat="server" NavigateUrl="~/Register.aspx" CssClass="float-right">Forgot Password?</asp:HyperLink>                            
                            <br />
                            <asp:HyperLink ID="regLink" runat="server" NavigateUrl="~/Register.aspx" CssClass="float-right">Not yet registered?</asp:HyperLink>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
</body>
</html>
