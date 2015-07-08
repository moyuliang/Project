<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserSign.aspx.cs" Inherits="WebBlog.UserSign" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>用户注册</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../dist/css/login.css" rel="stylesheet"/>

</head>
<body class="font-size bg-info">
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
           <li><a href="UserLog.aspx">登录</a></li>
           <li class="active"><a>注册</a></li>
          </ul>
        </div>
      </div>
    </nav>
    <form id="form1" runat="server">
    <div class="container containerborder">
        <div class="row-fluid">
                <div class="col-md-3"></div>
                <div class="col-md-6" id="col-md-border">
                    <div>
                        <h3 class="text-center">用户注册</h3>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:Label ID="Label1" runat="server" Text="用户名:" Width="20%" CssClass="text-center"></asp:Label><asp:TextBox ID="TextBox1" runat="server" TextMode="Email" placeholder="请输入电子邮件" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="用户名不能为空"></asp:RequiredFieldValidator><br />
                        <asp:Label ID="Label2" runat="server" Text="密码:" Width="20%" CssClass="text-center"></asp:Label><asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="密码" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="密码不能为空"></asp:RequiredFieldValidator><br />
                        <asp:Label ID="Label3" runat="server" Text="确认密码:" Width="20%" CssClass="text-center"></asp:Label><asp:TextBox ID="TextBox3" runat="server" TextMode="Password" placeholder="与上述密码保持一致" Width="80%"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="与上述密码不一致" Operator="Equal" Type="String"></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="确认密码不能为空"></asp:RequiredFieldValidator>       
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="昵称:" Width="20%" CssClass="text-center"></asp:Label><asp:TextBox ID="TextBox4" runat="server" Width="80%"></asp:TextBox><br /><br />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">  
                            <ContentTemplate>     
                                <asp:Label ID="Label7" runat="server" Text="居住地:" Width="20%" CssClass="text-center"></asp:Label><asp:DropDownList ID="DropDownListProvince" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListProvince_SelectedIndexChanged" Width="40%"></asp:DropDownList><asp:DropDownList ID="DropDownListCity" runat="server" Width="40%"></asp:DropDownList><br /><br />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:Label ID="Label5" runat="server" Text="性别:" Width="20%" CssClass="text-center"></asp:Label><asp:RadioButton ID="RadioButton1" runat="server" GroupName="SexGroup" Text="男"/>&nbsp;
                             <asp:RadioButton ID="RadioButton2" runat="server" GroupName="SexGroup" Text="女"/>&nbsp;
                             <asp:RadioButton ID="RadioButton3" runat="server" GroupName="SexGroup" Text="保密"/>&nbsp;<br /><br />
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">  
                            <ContentTemplate>    
                                <asp:Label ID="Label6" runat="server" Text="头像:" Width="20%" CssClass="text-center"></asp:Label><div class="row">
                                <div class="col-md-3"></div>
                                 <div class="col-md-7"><asp:FileUpload ID="pic_upload" runat="server"/></div><br />                                
                                <div class="col-md-2"></div> 
                            </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="个性签名:" Width="20%" CssClass="text-center"></asp:Label><asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" placeholder="用几句签名表达自己的个性吧>_<" Width="80%"></asp:TextBox><br /> 
                        </div>
                        <div class="text-center">
                            <asp:Button ID="Button1" runat="server" Text="注册" OnClick="Button1_Click" class="btn btn-default" />
                            <input id="Reset1" type="reset" value="重置" class="btn btn-default" />                           
                        </div>
                    <br />
                </div>
                <div class="col-md-3"></div>
            </div>
    </div>
    </form>
        <script src="../dist/css/bootstrap.min.js"></script>
</body>
</html>
