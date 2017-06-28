<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal_Setting.aspx.cs" Inherits="WebBlog.Personal_Setting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>个人设置</title>

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
                <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">个人主页</asp:LinkButton></li>              
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
            <li><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">博客管理</asp:LinkButton></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
               <li class="dropdown">
                  <a class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                      <asp:Label ID="Label1" runat="server" Text="请登录"></asp:Label><span class="caret"></span></a>
                  <ul class="dropdown-menu">
                    <li>
                        <a>个人设置</a>
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
        <div class="container containerborder">
            <div class="row-fluid">
                <div class="col-md-3"></div>
                <div class="col-md-6" id="col-md-border">
                    <div>
                        <h3 class="text-center">个人设置</h3>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Label ID="Label2" runat="server" Text="用户名:" Width="20%" CssClass="text-center"></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text="" Width="70%"></asp:Label><br /><br />
                        <asp:Label ID="Label4" runat="server" Text="昵称:" Width="20%" CssClass="text-center"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Width="70%"></asp:TextBox><br /><br />
                        <asp:Label ID="Label5" runat="server" Text="居住地:" Width="20%" CssClass="text-center"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" Width="70%"></asp:TextBox><br /><br />
                        <asp:Label ID="Label6" runat="server" Text="性别:" Width="20%" CssClass="text-center"></asp:Label>
                            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="SexGroup" Text="男" />&nbsp;
                             <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SexGroup" Text="女" />&nbsp;
                             <asp:RadioButton ID="RadioButton3" runat="server" GroupName="SexGroup" Text="保密" />&nbsp;<br /><br />
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Label ID="Label7" runat="server" Text="头像:" Width="20%" CssClass="text-center"></asp:Label>
                                <div class="row">
                                    <div class="col-md-3"></div>
                                    <div class="col-md-7">
                                        <asp:FileUpload ID="pic_upload" runat="server" />
                                    </div>
                                    <br />
                                    <div class="col-md-2"></div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="个性签名:" Width="20%" CssClass="text-center"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
                        <br /><br />
                        <div class="text-center">
                            <asp:Button ID="Button1" runat="server" Text="保存" OnClick="Button1_Click" CssClass="btn btn-default" />
                        </div>
                    <br />
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
