<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Personal_Income_and_Expences.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>登录——个人日常开支管理系统</title>

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
                    <li class="active">
                        <a>登录</a></li>
                    <li>
                        <a href="SignOut.aspx">注册</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container">
        <div class="divpad">
            <form id="form1" runat="server" class="form-signin">
                <h2 class="form-signin-heading">请登录</h2><%-- type="email"--%>
                <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="电子邮件"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox2" runat="server" type="password" class="form-control" placeholder="密码" CausesValidation="False"></asp:TextBox>
                <div class="checkbox">
                    <label>
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="记住我" />
                    </label>
                </div>
                <asp:Button ID="Button1" runat="server" Text="登录" CssClass="btn btn-lg btn-primary btn-block" OnClick="Button1_Click" />
            </form>
        </div>
    </div>
    
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
    <script src="../dist/js/jquery.validate.js"></script>
    <script type="text/javascript">
        <%--$("#TextBox1").blur(function () {
            alert("blur");
            <% getPassword(); %>
            alert("blur111");
        });--%>

        $(function () {

            $("#form1").validate({
                rules: {
                    TextBox1: {
                        required: true,
                        email: true
                    },
                    TextBox2: {
                        required: true,
                        rangelength: [2, 16]
                    }
                },
                messages: {
                    TextBox1: {
                        required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写邮件地址</font>",
                        email: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>E-Mail格式不正确</font>"
                    },
                    TextBox2: {
                        required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写密码</font>",
                        rangelength: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>密码长度必须在2-16之间</font>"
                    }

                }
            });
        });
    </script>
    
</body>
</html>
