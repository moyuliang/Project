<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="WebBlog.Article" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>添加文章</title>
    <link href="../dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../dist/css/login.css" rel="stylesheet"/>

</head>
<body class="font-size bg-info" >
    
<form id="form1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CssClass="navbar-brand">主页</asp:LinkButton>
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li class="active"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">个人主页</asp:LinkButton></li>              
            <li class="dropdown">
              <a class="dropdown-toggle" data-toggle="dropdown" aria-labelledby="dropdownMenu4" aria-haspopup="true" aria-expanded="false">文章管理<span class="caret"></span></a>
              <ul class="dropdown-menu">
                <li>
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">文章类型</asp:LinkButton></li>
                  <li><a>添加文章</a></li>
                <li role="separator" class="divider"></li>
                <li><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">查看文章</asp:LinkButton></li>
              </ul>
           </li>
            <li><a href="image.aspx">图片管理</a></li>
            <li><asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">博客管理</asp:LinkButton></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
              <li class="dropdown">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                      <asp:Label ID="Label1" runat="server" Text="请登录"></asp:Label><span class="caret"></span></a>
                  <ul class="dropdown-menu">
                    <li><asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">个人设置</asp:LinkButton></li>
                    <li role="separator" class="divider"></li>
                    <li><a href="Homepage.aspx">退出</a></li>
                </ul>
            </li>
          </ul>
        </div>
          
      </div>
    </nav>
    <div class="container" id="container_border">
        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6 divborder">
                <div><h3 class="text-center">添加文章</h3></div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Label ID="Label2" runat="server" Text="文章题目：" Width="40%" CssClass="text-center"></asp:Label><asp:TextBox ID="TextBox1" runat="server" Width="60%"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="Label3" runat="server" Text="文章类型：" Width="40%" CssClass="text-center"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" class="dropdown" Width="60%"></asp:DropDownList>
                    </div>
                </div>
                <div>
                   <div>文章内容：</div>
                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="100%" Height="300px"></asp:TextBox>  
                </div>
                <div class="text-center">    
                    <asp:Button ID="Button1" runat="server" Text="提 交" OnClick="Button1_Click" class="btn btn-default" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="重 置" class="btn btn-default" />
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>
    </div>
</form>
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
</body>
</html>
