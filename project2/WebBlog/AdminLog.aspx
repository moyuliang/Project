<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLog.aspx.cs" Inherits="WebBlog.AdminLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>后台管理员登录</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../dist/css/login.css" rel="stylesheet"/>

</head>
<body class="font-size bg-info">
    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
          <a class="navbar-brand">女汉子博客后台管理</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li><a href="Manage.aspx">用户管理 <span class="sr-only">(current)</span></a></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
           <li class="active"><a>登录</a></li>
          </ul>
        </div>
          
      </div>
    </nav>
    <form id="form1" runat="server">
    <div class="container" id="divcenter">
            <div class="row-fluid">
                <div class="col-md-4"></div>
                <div class="col-md-4" id="col-md-border">
                    <div>
                        <h3 class="text-center">后台管理员登录</h3>
                        <asp:Label ID="Label1" runat="server" Text="用户名:" ></asp:Label><asp:TextBox ID="TextBox1" runat="server" TextMode="Email" placeholder="请输入电子邮件" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="密&nbsp;&nbsp;&nbsp;码:"></asp:Label><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="请输入密码" Width="100%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
                        <br />
                    </div>
                    <div class="text-center">
                        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" class="btn btn-primary"/>
                    </div>
                    <br />
                </div>
                <div class="col-md-4"></div>
            </div>
    </div>
    </form>
    
    <script src="../dist/css/bootstrap.min.js"></script>
</body>
</html>
