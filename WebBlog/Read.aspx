<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="WebBlog.Read" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>阅读文章</title>

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
           <li><a href="UserSign.aspx">注册</a></li>
          </ul>
        </div>
      </div>
    </nav>

    <div class="container" id="container_border">
    <form id="form1" runat="server">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-8 divborder">
                <div class="text-center"><h3>阅读文章</h3></div>
                <div>
                    <div><asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="350px" Width="100%"></asp:TextBox></div>
                    <br />
                    <div class="text-center">评论区</div>            
                    <br />
                    <div>
                        写评论：<asp:TextBox ID="TextBox2" runat="server" Width="80%" ></asp:TextBox>
                             &nbsp;<asp:Button ID="Button1" runat="server" Text="评 论" CssClass="btn btn-default" OnClick="Button1_Click" />
                            <br /><br />
                            <div>
                                <asp:DataList ID="DataList1" runat="server" OnDeleteCommand="DataList1_DeleteCommand"
                                        OnItemDataBound="DataList1_ItemDataBound" CellPadding="4" ForeColor="#333333">
                                <AlternatingItemStyle BackColor="White" />
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <ItemStyle BackColor="#EFF3FB" />
                                <ItemTemplate>
                                <br />
                                <div>评论主题:&nbsp;<asp:Label ID="title" runat="server" Text='<%# Eval("title") %>'/>&nbsp;&nbsp;评论时间:&nbsp;<asp:Label ID="comment_time" runat="server" Text='<%# Eval("comment_time") %>' /></div><br />
                                <div>评论内容:&nbsp;<asp:Label ID="comment_detail" runat="server" Text='<%# Eval("comment_detail") %>'/></div><br />
                                <div class="text-right">评论人：<asp:Label ID="name" runat="server" Text='<%# Eval("name") %>'/>&nbsp;
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="delete">删除评论</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server">评论回复</asp:LinkButton>
                                </div> 
                                </ItemTemplate>
                                </asp:DataList>
                                <br />
                                <div class="text-right">
                                    <asp:LinkButton ID="update" runat="server" OnClick="update_Click" ForeColor="Blue">【刷新】</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="lnkbtnfirst" runat="server" CommandName="first" Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick">首页</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="lnkbtnUp" runat="server" CommandName="prev"  Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick">上一页</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="lnkbtnNext" runat="server" CommandName="next"  Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick">下一页</asp:LinkButton>&nbsp;
                                    <asp:LinkButton ID="lnkbtnlast" runat="server" CommandName="last" Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick">尾页</asp:LinkButton>
                                </div>
                            </div>
                            </div>
                 </div>
                 <br />
            </div>    
            <div class="col-md-2"></div>    
        </div>
    </form>
    </div>
</body>
</html>
