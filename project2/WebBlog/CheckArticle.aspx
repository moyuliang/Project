<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckArticle.aspx.cs" Inherits="WebBlog.CheckArticle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>查询文章</title>
    <link href="../dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../dist/css/login.css" rel="stylesheet"/>

</head>
<body class="font-size bg-info" >
    
    <form id="form1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" CssClass="navbar-brand">主页</asp:LinkButton>
        </div>
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li>
                <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">个人主页</asp:LinkButton></li>              
            <li class="dropdown">
              <a class="dropdown-toggle active" data-toggle="dropdown" aria-labelledby="dropdownMenu4" aria-haspopup="true" aria-expanded="false">文章管理<span class="caret"></span></a>
              <ul class="dropdown-menu">
                <li>
                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">文章类型</asp:LinkButton></li>
                  <li>
                      <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">添加文章</asp:LinkButton></li>
                <li role="separator" class="divider"></li>
                <li><a>查看文章</a></li>
              </ul>
           </li>
            <li><a href="image.aspx">图片管理</a></li>
            <li>
                <asp:LinkButton ID="LinkButton7" runat="server">博客管理</asp:LinkButton></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
              <li class="dropdown">
                  <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                      <asp:Label ID="Label1" runat="server" Text="请登录"></asp:Label><span class="caret"></span></a>
                  <ul class="dropdown-menu">
                    <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">个人设置</asp:LinkButton>>
                    <li role="separator" class="divider"></li>
                    <li><a href="Homepage.aspx">退出</a></li>
                </ul>
            </li>
          </ul>
        </div>
          
      </div>
    </nav>
        <div class="container" id="container_border">
            <div class="row-fluid">
                <div class="col-md-3"></div>
                <div class="col-md-6 divborder">
                    <div><h3 class="text-center">管理文章</h3></div>
                    <div>
                        <div><asp:Button ID="Button5" runat="server" Text="刷 新" OnClick="Button5_Click1" class="btn btn-default"/><br /></div>             
                        <div>
                        <table>
                        <td>
                         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID"
                        PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                            <asp:BoundField DataField="now" HeaderText="now" SortExpression="now" />
                            <asp:BoundField DataField="name" HeaderText="type" SortExpression="name" />
                            <asp:CommandField DeleteText="阅读" ShowDeleteButton="True" />
                        </Columns>
                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" CssClass="pageapart" />
                    </asp:GridView>
                         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT Artical.id,Artical.title,Artical.now,ArticalType.name FROM [Artical],[ArticalType]"></asp:SqlDataSource>
                        </td>
                      </table>
                        </div>
                        <br />
                        <div>文章ID：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
                        <div>文章内容：</div>
                        <div><asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Width="100%" Height="350px"></asp:TextBox></div>
                        <div class="text-center">
                            <asp:Button ID="Button2" runat="server" Text="修 改" OnClick="Button2_Click" class="btn btn-default" />
                            <asp:Button ID="Button3" runat="server" Text="删 除" OnClick="Button3_Click" class="btn btn-default"/>
                            <asp:Button ID="Button4" runat="server" Text="清 空" OnClick="Button4_Click" class="btn btn-default" />      
                        </div>
                        <div>
                            <table style="width: 510px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:DataList ID="DataList1" runat="server" OnDeleteCommand="DataList1_DeleteCommand"
                                            Width="383px" OnItemDataBound="DataList1_ItemDataBound" CellPadding="4" ForeColor="#333333">
                                            <AlternatingItemStyle BackColor="White" />
                                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                            <ItemStyle BackColor="#EFF3FB" />
                                            <ItemTemplate>
                                                <table style="width: 600px" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td colspan="2">评论id:
                   <asp:Label ID="id" runat="server" Text='<%# Eval("id") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>评论主题:
                <asp:Label ID="title" runat="server" Text='<%# Eval("title") %>' />
                                                        </td>
                                                        <td>评论时间:
                <asp:Label ID="comment_time" runat="server" Text='<%# Eval("comment_time") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>评论内容:
                <asp:Label ID="comment_detail" runat="server" Text='<%# Eval("comment_detail") %>' />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: right">评论人：
                <asp:Label ID="comment_username" runat="server" Text='<%# Eval("comment_username") %>' />&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete">删除评论</asp:LinkButton>
                                                            <asp:LinkButton ID="LinkButton2" runat="server">评论回复</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </ItemTemplate>
                                            <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        </asp:DataList>
                                    </td>
                                </tr>
                                <br />
                                <tr>
                                    <td colspan="3" style="width: 4249px; text-align: right">
                                        <asp:LinkButton ID="update" runat="server" OnClick="update_Click" ForeColor="Blue">【刷新】</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lnkbtnfirst" runat="server" 
                        Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick"  >首页</asp:LinkButton>
                                        &nbsp;
                    <asp:LinkButton ID="lnkbtnUp" runat="server"  Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick" >上一页</asp:LinkButton>
                                        <asp:LinkButton ID="lnkbtnNext" runat="server"  Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick" >下一页</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lnkbtnlast" runat="server" 
                        Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick" >尾页</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                     </div>
                <div class="col-md-3"></div>
            </div>
                </div>
            </div>
    </form>
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
</body>
</html>
