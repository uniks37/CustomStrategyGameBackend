﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CustomStrategyGameBackend.Register" %>

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
                        <hr />
                        <div class="form-group form-row">
                            <label class="col-form-label col-md-3" for="emailtxt">Email-Id</label>
                            <div class="col-md-7">
                                <asp:TextBox ID="emailtxt" runat="server" CssClass="form-control" TextMode="Email" AutoCompleteType="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="emailReq" runat="server" ErrorMessage="Email is required." ControlToValidate="emailtxt" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                        <div class="form-group form-row">
                            <label class="col-form-label col-md-3" for="unametxt">Username</label>
                            <div class="col-md-7">
                                <asp:TextBox ID="unametxt" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="unameReq" runat="server" ErrorMessage="Username is required." ControlToValidate="unametxt" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                        <div class="form-group form-row">
                            <asp:Label ID="passtxtLbl" runat="server" Text="Password" CssClass="col-form-label col-md-3"></asp:Label>
                            <div class="col-md-7">
                                <asp:TextBox ID="passtxt" MaxLength="16" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="passtxtReg" runat="server" ErrorMessage="Password must be 8-16 characters long" ControlToValidate="passtxt" CssClass="alert-danger" ValidationExpression="\s*\S.{8,16}\S\s*"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-2">
                                <asp:RequiredFieldValidator ID="passtxtReq" runat="server" ErrorMessage="Password is required." ControlToValidate="passtxt" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group form-row">
                            <asp:Label ID="passLbl" runat="server" Text="Verify Password" CssClass="col-form-label col-md-3"></asp:Label>

                            <div class="col-md-7">
                                <asp:TextBox ID="passverifytxt" MaxLength="16" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="passverifytxtReq" runat="server" ErrorMessage="Verification Password is required." ControlToValidate="passverifytxt" CssClass="alert-danger"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2">
                                <asp:CompareValidator ID="passverifytxtCmp" runat="server" ErrorMessage="Passwords Do Not Match" CssClass="alert-warning" ControlToCompare="passtxt" ControlToValidate="passverifytxt" Operator="Equal" Type="String"></asp:CompareValidator>
                            </div>
                        </div>
                        <hr />
                        <asp:Button ID="regBtn" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="regBtn_Click" />
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
