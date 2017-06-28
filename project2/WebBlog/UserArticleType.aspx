<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserArticleType.aspx.cs" Inherits="WebBlog.UserArticleType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>文章类型管理</title>
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
            <li class="active">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">个人主页</asp:LinkButton></li>              
            <li class="dropdown">
              <a class="dropdown-toggle" data-toggle="dropdown" aria-labelledby="dropdownMenu4" aria-haspopup="true" aria-expanded="false">文章管理<span class="caret"></span></a>
              <ul class="dropdown-menu">
                <li><a>文章类型</a></li>
                  <li><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">添加文章</asp:LinkButton></li>
                <li role="separator" class="divider"></li>
                <li><asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">查看文章</asp:LinkButton></li>
              </ul>
           </li>
            <li><a href="image.aspx">图片管理</a></li>
            <li>
                <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">博客管理</asp:LinkButton></li>
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
    
    <div id="container_border">
        <table  width="100%">
        <tr align="center">
            <td>
                <table border="1">
            <td>
            <table align="center">
                <tr align="center">
                    <td>
                        <h3> 个人文章类型管理</h3>
                    </td>
                </tr>   
            </table>
        <br />
         <table>
            <tr>
        <table width="180px"  bgcolor="FFFFFF" align="left">
            <td>
                <asp:ListBox ID="ListBox1" runat="server" Height="318px" Width="176px"></asp:ListBox>
            </td> 
        </table>         
        <table width="600px"  align="right">
            <td>
            <table  width="600px" align="center">
                <tr align="center">
            <td>                
                选文章类型名称：<asp:DropDownList ID="DropDownList1" runat="server" Height="31px" Width="155px"></asp:DropDownList>               
                <br />
                <br />              
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="新 添" class="btn btn-default"/>
            </td></tr>            
        </table> 
        <br />
        <br />
        <table width="600px" align="center">
            <tr align="center">
            <td>
               <%--<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                修改为：
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <br />
                <br />
              <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="修 改" class="btn btn-default"/> 
            </td></tr>
        </table>  
        <br />
        <br />
        <table width="600px" align="center">
            <tr align="center">
            <td>
               需删除的类型：<%--<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>--%>
                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList>
            <br />
            <br />
                <div class="text-center">
            <asp:Button ID="Button3" runat="server" Text="删 除" OnClick="Button3_Click" class="btn btn-default"/>
            </div>
                    </td></tr>           
        </table> 
                </td>        
        </table> 
        </tr>
        </table>
            </td>
            </table> 
            </td>
            </tr>
            </table>     
    </div>
    </form>
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
</body>
</html>
