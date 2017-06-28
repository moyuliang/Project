<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLog.aspx.cs" Inherits="WebBlog.UserLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>用户登录</title>
    <link href="../dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../dist/css/login.css" rel="stylesheet"/>

</head>
<body class="font-size bg-info">
    
    <form id="form1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
          <a class="navbar-brand">女汉子博客</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li><a href="Homepage.aspx">主页 <span class="sr-only">(current)</span></a></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
           <li class="active"><a>登录</a></li>
           <li><a href="UserSign.aspx">注册</a></li>
          </ul>
        </div>
      </div>
    </nav>

    <div class="container">
            <div class="row-fluid" id="divcenter">
                <div class="col-md-4"></div>
                <div class="col-md-4" id="col-md-border">
                    <div>
                        <h3 class="text-center">用户登录</h3>
                        <asp:Label ID="Label1" runat="server" Text="用户名:" Width="20%"></asp:Label><asp:TextBox ID="TextBox1" runat="server" TextMode="Email" placeholder="请输入电子邮件" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="密&nbsp;&nbsp;&nbsp;码:" Width="20%"></asp:Label><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="请输入密码" Width="80%"></asp:TextBox>       
                        <br />
                        <asp:CheckBox ID="CheckBox1" runat="server"/>&nbsp;记住我<br />
                     </div>
                     <div>
                         <div class="text-center">
                            <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" class="btn btn-primary" />
                         </div>
                         <div class="text-right">
                             <span class="a-style"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">忘记密码??</asp:LinkButton></span>
                         </div>
                     </div>
                </div>
                <div class="col-md-4"></div>
            </div>
    </div>
    </form>
    <script src="../dist/css/bootstrap.min.js"></script>
</body>
</html>
