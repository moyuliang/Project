<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="WebBlog.Manage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>用户管理</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../dist/css/login.css" rel="stylesheet"/>
</head>
<body class="font-size bg-info">
    <form id="form1" runat="server">
        <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
          <a class="navbar-brand">女汉子博客后台管理</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li class="active"><a>用户管理 <span class="sr-only">(current)</span></a></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
           <li><a href="AdminLog.aspx">退出</a></li>
          </ul>
        </div>
          
      </div>
    </nav>

    <div class="containerborder">
    
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="username" DataSourceID="SqlDataSource1" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" OnClick="DeleteButton_Click" CssClass="btn btn-default" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" CssClass="btn btn-default" />
                    </td>
                    <td>
                        <asp:Label ID="usernameLabel" runat="server" Text='<%# Eval("username") %>' />
                    </td>
                    <td>
                        <asp:Label ID="passwordLabel" runat="server" Text='<%# Eval("password") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="sexLabel" runat="server" Text='<%# Eval("sex") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cityLabel" runat="server" Text='<%# Eval("city") %>' />
                    </td>
                    <td>
                        <asp:Label ID="signLabel" runat="server" Text='<%# Eval("sign") %>' />
                    </td>
                    <td>
                        <asp:Label ID="signdateLabel" runat="server" Text='<%# Eval("signdate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="icoLabel" runat="server" Text='<%# Eval("ico") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" OnClick="UpdateButton_Click" CssClass="btn btn-default" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" CssClass="btn btn-default" />
                    </td>
                    <td>
                        <asp:Label ID="usernameLabel1" runat="server" Text='<%# Eval("username") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="sexTextBox" runat="server" Text='<%# Bind("sex") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="cityTextBox" runat="server" Text='<%# Bind("city") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="signTextBox" runat="server" Text='<%# Bind("sign") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="signdateTextBox" runat="server" Text='<%# Bind("signdate") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="icoTextBox" runat="server" Text='<%# Bind("ico") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>未返回数据。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" OnClick="InsertButton_Click" CssClass="btn btn-default" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" CssClass="btn btn-default" />
                    </td>
                    <td>
                        <asp:TextBox ID="usernameTextBox" runat="server" Text='<%# Bind("username") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="passwordTextBox" runat="server" Text='<%# Bind("password") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="nameTextBox" runat="server" Text='<%# Bind("name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="sexTextBox" runat="server" Text='<%# Bind("sex") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="cityTextBox" runat="server" Text='<%# Bind("city") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="signTextBox" runat="server" Text='<%# Bind("sign") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="signdateTextBox" runat="server" Text='<%# Bind("signdate") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="icoTextBox" runat="server" Text='<%# Bind("ico") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" OnClick="DeleteButton_Click" CssClass="btn btn-default" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" CssClass="btn btn-default" />
                    </td>
                    <td>
                        <asp:Label ID="usernameLabel" runat="server" Text='<%# Eval("username") %>' />
                    </td>
                    <td>
                        <asp:Label ID="passwordLabel" runat="server" Text='<%# Eval("password") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="sexLabel" runat="server" Text='<%# Eval("sex") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cityLabel" runat="server" Text='<%# Eval("city") %>' />
                    </td>
                    <td>
                        <asp:Label ID="signLabel" runat="server" Text='<%# Eval("sign") %>' />
                    </td>
                    <td>
                        <asp:Label ID="signdateLabel" runat="server" Text='<%# Eval("signdate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="icoLabel" runat="server" Text='<%# Eval("ico") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server"></th>
                                    <th runat="server">username</th>
                                    <th runat="server">password</th>
                                    <th runat="server">name</th>
                                    <th runat="server">sex</th>
                                    <th runat="server">city</th>
                                    <th runat="server">sign</th>
                                    <th runat="server">signdate</th>
                                    <th runat="server">ico</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"  />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="删除" OnClick="DeleteButton_Click" CssClass="btn btn-default" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="编辑" CssClass="btn btn-default" />
                    </td>
                    <td>
                        <asp:Label ID="usernameLabel" runat="server" Text='<%# Eval("username") %>' />
                    </td>
                    <td>
                        <asp:Label ID="passwordLabel" runat="server" Text='<%# Eval("password") %>' />
                    </td>
                    <td>
                        <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="sexLabel" runat="server" Text='<%# Eval("sex") %>' />
                    </td>
                    <td>
                        <asp:Label ID="cityLabel" runat="server" Text='<%# Eval("city") %>' />
                    </td>
                    <td>
                        <asp:Label ID="signLabel" runat="server" Text='<%# Eval("sign") %>' />
                    </td>
                    <td>
                        <asp:Label ID="signdateLabel" runat="server" Text='<%# Eval("signdate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="icoLabel" runat="server" Text='<%# Eval("ico") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BlogConnectionString %>" DeleteCommand="DELETE FROM [UserTable] WHERE [username] = @original_username" InsertCommand="INSERT INTO [UserTable] ([username], [password], [name], [sex], [city], [sign], [signdate], [ico]) VALUES (@username, @password, @name, @sex, @city, @sign, @signdate, NULL)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [username], [password], [name], [sex], [city], [sign], [signdate], [ico] FROM [UserTable]" UpdateCommand="UPDATE [UserTable] SET [password] = @password, [name] = @name, [sex] = @sex, [city] = @city, [sign] = @sign, [signdate] = @signdate WHERE [username] = @original_username">
            <DeleteParameters>
                <asp:Parameter Name="original_username" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="sex" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="sign" Type="String" />
                <asp:Parameter Name="signdate" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="sex" Type="String" />
                <asp:Parameter Name="city" Type="String" />
                <asp:Parameter Name="sign" Type="String" />
                <asp:Parameter Name="signdate" Type="String" />
                <asp:Parameter Name="original_username" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
        <script src="../dist/css/bootstrap.min.js"></script>
    </form>
</body>
</html>
