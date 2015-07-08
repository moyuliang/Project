<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Picture.aspx.cs" Inherits="WebBlog.Picture" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>博客管理</title>

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
            <li>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">个人主页</asp:LinkButton>
            </li>              
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
            <li><a  class="active">博客管理</a></li>
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

    <div class="container">
        <div class="row-fluid" id="divcenter">
            <div class="col-md-1"></div>
            <div class="col-md-4">
                <asp:Image ID="Image1" runat="server" Width="100%" Height="500px" CssClass="text-center"/>
            </div>
            <div class="col-md-4 text-center">
                <div>
                    <asp:FileUpload ID="FileUpload1" runat="server" /><br /><asp:Button ID="Button1" runat="server" Text="上传图片" CssClass="btn btn-default" OnClick="Button1_Click" />
                </div>
                <br />
                <div><asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdown" Width="80%"></asp:DropDownList></div>
                <br />
                <div><asp:Button ID="Button3" runat="server" Text="查看图片" CssClass="btn btn-default" OnClick="Button3_Click" /><asp:Button ID="Button2" runat="server" Text="删除图片" CssClass="btn btn-default" OnClick="Button2_Click" /></div>
            </div>
            <div class="col-md-3 text-center">
                <asp:Calendar ID="Calendar1" runat="server" TodayDayStyle-ForeColor="#CC6600" Width="90%"></asp:Calendar>
            </div>
        </div>
    </div>
    </form>
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
</body>
</html>
