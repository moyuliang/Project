<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignOut.aspx.cs" Inherits="Personal_Income_and_Expences.SignOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>注册——个人日常开支管理系统</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../dist/css/signin.css" rel="stylesheet" />
    <style type="text/css">
        img#error
        {
            width:17px;
            height:17px;
        }

    </style>
</head>
<body>
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
                        <a href="Hellopage.aspx">首页</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="Login.aspx">登录</a></li>
                    <li class="active"><a>注册</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container">
        <div class="divpad">
            <form id="form1" runat="server" class="form-signin">

                <asp:TextBox ID="TextBox1" runat="server" type="email" class="form-control" placeholder="电子邮件"></asp:TextBox><br />
                <asp:TextBox ID="TextBox2" runat="server" type="password" class="form-control" placeholder="密码"></asp:TextBox><br />
                <asp:TextBox ID="TextBox3" runat="server" type="password" class="form-control" placeholder="确认密码"></asp:TextBox><br />
                <asp:TextBox ID="TextBox4" runat="server" class="form-control" placeholder="昵称"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Text="注册" class="btn btn-lg btn-primary btn-block" OnClick="Button1_Click" />

            </form>
        </div>
    </div>
    
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
    <script src="../dist/js/jquery.validate.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#form1").validate({
                rules: {
                    TextBox1: {
                        required: true,
                        email: true
                    },
                    TextBox2: {
                        required: true,
                        rangelength: [6, 16]
                    },
                    TextBox3: {
                        required: true,
                        equalTo: "#TextBox2"
                    },
                    TextBox4: {
                        required: true
                    }
                },
                messages: {
                    TextBox1: {
                        required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写邮件地址</font>",
                        email: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>邮件格式不正确</font>"
                    },
                    TextBox2: {
                        required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写密码</font>",
                        rangelength: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>密码长度必须在6-16之间</font>"
                    },
                    TextBox3: {
                        required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写您的确认密码</font>",
                        equalTo: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>确认密码和密码不一致</font>"
                    },
                    TextBox4: {
                        required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写昵称</font>"
                    }

                }
            });
        });
    </script>
</body>
</html>
