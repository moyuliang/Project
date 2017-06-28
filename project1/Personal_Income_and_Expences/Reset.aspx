<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset.aspx.cs" Inherits="Personal_Income_and_Expences.Reset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>管理——个人日常开支管理系统</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../dist/css/signin.css" rel="stylesheet" />
    <link href="../dist/css/bootstrap-modal.js" rel="stylesheet" />
    <style>
        .panelcol {
            background-color: #f8f8f8;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">修改昵称</h4>
                    </div>
                    <div class="modal-body">
                        <p>请输入更改后的昵称</p>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="修改后的昵称"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        <asp:Button ID="Button2" runat="server" Text="保存" CssClass="btn btn-primary" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </div>
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand">个人日常开支管理系统</a>
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>

                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">主页</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">添加</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">管理</asp:LinkButton></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                <asp:Label ID="Label1" runat="server" Text="账户"></asp:Label><span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <a href="#myModal" data-toggle="modal">修改昵称</a>
                                </li>
                                <li class="active"><a>修改密码</a></li>
                                <li role="separator" class="divider"></li>
                                <li><a href="Login.aspx">退出</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="container">
            <div class="divpad">

                <div class="panel">
                    <div class="panel-heading">
                        <h3 class="panel-title">个人基本资料</h3>
                    </div>
                    <div class="panel-body panelcol">
                        <div class="form-signin">
                            <h2 class="form-signin-heading">重置密码</h2>
                            <asp:TextBox ID="TextBox1" runat="server" type="email" class="form-control" placeholder="电子邮件" ReadOnly="true"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox2" runat="server" type="password" class="form-control" placeholder="旧密码"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox3" runat="server" type="password" class="form-control" placeholder="新密码"></asp:TextBox><br />
                            <asp:TextBox ID="TextBox4" runat="server" type="password" class="form-control" placeholder="确认新密码"></asp:TextBox><br />
                            <asp:Button ID="Button1" runat="server" Text="重置密码" CssClass="btn btn-lg btn-primary btn-block"/>
                        </div>
                    </div>

                </div>

            </div>

        </div>
    </form>
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
    <script src="../dist/js/bootstrap-modal.js"></script>
</body>
</html>
