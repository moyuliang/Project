<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal_Homepage.aspx.cs" Inherits="WebBlog.SuccessLog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>个人主页</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../dist/css/login.css" rel="stylesheet"/>
</head>
<body class="font-size bg-info">
    
    <form id="form1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="navbar-brand">主页</asp:LinkButton>
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li class="active">
                <a class="active">个人主页</a></li>              
            <li class="dropdown">
              <a class="dropdown-toggle" data-toggle="dropdown" aria-labelledby="dropdownMenu4" aria-haspopup="true" aria-expanded="false">文章管理<span class="caret"></span></a>
              <ul class="dropdown-menu">
                <li>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">文章类型</asp:LinkButton>
                </li>
                <li>
                      <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">添加文章</asp:LinkButton>
                </li>
                <li role="separator" class="divider"></li>
                <li>
                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">查看文章</asp:LinkButton>
                </li>
              </ul>
           </li>
            <li><a href="image.aspx">图片管理</a></li>
            <li>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">博客管理</asp:LinkButton></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
              <li class="dropdown">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                      <asp:Label ID="Label1" runat="server" Text="请登录"></asp:Label><span class="caret"></span></a>
                  <ul class="dropdown-menu">
                    <li>
                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">个人设置</asp:LinkButton>
                    </li>
                    <li role="separator" class="divider"></li>
                    <li>
                        <a href="Homepage.aspx">退出</a>
                    </li>
                </ul>
            </li>
          </ul>
        </div>
          
      </div>
    </nav>
    <div id="container_border">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-2">
                <div id="imgborder">
                    <asp:Image ID="Image1" runat="server" Width="200px" Height="200px" />
                </div>
                <br />
                <div>
                    昵&nbsp;&nbsp;称:&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text=""></asp:Label><br /><br />
                    性&nbsp;&nbsp;别:&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text=""></asp:Label><br /><br />
                    城&nbsp;&nbsp;市:&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text=""></asp:Label><br /><br />
                    个性签名:&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="100%" Height="600px" BackColor="#d9edf7"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Calendar ID="Calendar1" runat="server" TodayDayStyle-ForeColor="#CC6600" Width="100%"></asp:Calendar>
            </div>
            <div class="col-md-1"></div>
        </div>
    </div>
    </form>
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
</body>
</html>
