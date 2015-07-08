<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="WebBlog.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>博客管理系统</title>
    <link href="../dist/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../dist/css/login.css" rel="stylesheet"/>

</head>
<body class="font-size bg-info" >
    <form id="form1" runat="server">
    <nav class="navbar navbar-inverse navbar-fixed-top">
      <div class="container-fluid">
        <div class="navbar-header">
          <a class="navbar-brand">女汉子博客</a>
        </div>

        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
          <ul class="nav navbar-nav">
            <li class="active"><a>主页 <span class="sr-only">(current)</span></a></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
           <li><a href="UserLog.aspx">登录</a></li>
           <li><a href="UserSign.aspx">注册</a></li>
          </ul>
        </div>
      </div>
    </nav>

    <div class="container" id="container_border">
        
            <div><h1 class="text-center">博客主页</h1></div><br />
            <div class="row">
                <div class="col-md-1"></div>
                <div class="col-md-2 text-center">
                        <div><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">所有文章</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">随笔/感悟</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">生活记录</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">娱乐/八卦</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">明星动态</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">影评/乐评</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton8" runat="server">体育/竞技</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton9" runat="server">精彩球评</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton10" runat="server">人文/历史</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton11" runat="server">文学/原创</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton12" runat="server">艺术赏析</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton13" runat="server">知识/探索</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton14" runat="server">视觉/图片</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton15" runat="server">时尚/名品</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton16" runat="server">情感故事</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton17" runat="server">两性话题</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton18" runat="server">同行/同志</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton19" runat="server">教育杂谈</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton20" runat="server">学习公社</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton21" runat="server">校园生活</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton22" runat="server">产经/公司</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton23" runat="server">证券/理财</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton24" runat="server">时事评论</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton25" runat="server">军事/谈兵</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton26" runat="server">IT/科技</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton27" runat="server">房产/置业</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton28" runat="server">家居/装修</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton29" runat="server">汽车/试驾</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton30" runat="server">社会/纪实</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton31" runat="server">职场/励志</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton32" runat="server">奇闻/逸事</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton33" runat="server">趣味/幽默</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton34" runat="server">恐怖/怪谈</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton35" runat="server">健康/保健</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton36" runat="server">游戏部落</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton37" runat="server">卡通/动漫</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton38" runat="server">旅行/见闻</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton39" runat="server">美食/厨艺</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton40" runat="server">宠物阵营</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton41" runat="server">育儿/亲子</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton42" runat="server">星座/测试</asp:LinkButton><br />
                        <asp:LinkButton ID="LinkButton43" runat="server">其他频道</asp:LinkButton><br />
                        </div>
                </div>
                <div class="col-md-8">
                    <table width="100%" bgcolor="#FFFFFF" align="center">
                        <tr align="center">
                        <td >

                     <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                    BorderColor="#FFE4E1" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ID"
                    PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging"  OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" >
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                        <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
                        <asp:CommandField DeleteText="阅读" ShowDeleteButton="True" />                             
                    </Columns>
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />

                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT id,title,author FROM [Artical]"></asp:SqlDataSource>
                            <br />
                        </td>                         
                        </tr>
                        </table>
                </div>
                <div class="col-md-1"></div>
            </div>

    </div>
        </form>
    
</body>
</html>
