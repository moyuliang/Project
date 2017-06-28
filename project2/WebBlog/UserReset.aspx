<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserReset.aspx.cs" Inherits="WebBlog.UserReset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>重置密码</title>
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
           <li><a href="Homepage.aspx">登录</a></li>
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
                        <h3 class="text-center">重置密码</h3>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Label ID="Label1" runat="server" Text="用户名:" Width="30%" CssClass="text-center"></asp:Label><asp:TextBox ID="TextBox1" runat="server" TextMode="Email" placeholder="请输入电子邮件" Width="70%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="密码:" Width="30%" CssClass="text-center"></asp:Label><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="请输入更改之后的密码" Width="70%"></asp:TextBox>       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator>
                        <div><asp:Label ID="Label3" runat="server" Text="确认密码:" Width="30%" CssClass="text-center"></asp:Label><asp:TextBox ID="TextBox4" runat="server" TextMode="Password" placeholder="请输入更改之后的密码" Width="70%"></asp:TextBox>     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="确认密码不能为空"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox4" ErrorMessage="与密码保持一致"></asp:CompareValidator>
                        </div>
                        <div class="divright">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <a title="单击图片更换验证码"><img src="IdentifyingCode.aspx" style="vertical-align:bottom; margin-bottom:1px; cursor: pointer;" style="vertical-align:bottom; margin-bottom:1px; cursor: pointer;" alt="点击刷新" onclick="javascript:var time = new Date().getTime(); this.src=this.src + '?' + time;" /></a> 
                                        <asp:TextBox ID="TextBox3" runat="server" placeholder="请输入验证码" Width="70%" CssClass="divright"></asp:TextBox>      
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="验证码非空"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div> 
                         <div class="text-center">
                            <asp:Button ID="Button1" runat="server" Text="重置密码" OnClick="Button1_Click" class="btn btn-primary" />
                          </div><br />
                        </div>
                </div>
                <div class="col-md-4"></div>
            </div>
    </div>
    </form>
</body>
</html>
