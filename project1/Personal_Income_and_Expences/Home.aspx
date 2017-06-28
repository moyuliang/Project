<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Personal_Income_and_Expences.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>主页——个人日常开支管理系统</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../dist/css/signin.css" rel="stylesheet" />
    <style type="text/css">
        img#error {
            width: 17px;
            height: 17px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">修改昵称</h4>
                    </div>
                    <div class="modal-body">
                        <p>请输入更改后的昵称</p>
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="修改后的昵称"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        <asp:Button ID="Button1" runat="server" Text="保存" CssClass="btn btn-primary" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand">个人日常开支管理系统</a>
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                        <span class="sr-only"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                </div>

                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li class="active">
                            <a>主页</a></li>
                        <li>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">添加</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">管理</asp:LinkButton></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">

                                        <asp:Label ID="Label1" runat="server" Text="账户"></asp:Label>
                                <span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <a href="#myModal" data-toggle="modal">修改昵称</a>
                                </li>
                                <li><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">修改密码</asp:LinkButton></li>
                                <li role="separator" class="divider"></li>
                                <li><a href="Login.aspx">退出</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container">
            <div class="divpad">
                <div class="row">
                    <div class="col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">日总消费</h3>
                            </div>
                            <div class="panel-body">
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th>类型</th>
                                                    <th>金额</th>
                                                </tr>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblname" Text='<%# Eval("name") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="lblday_cost" Text='<%# Eval("sum") %>'></asp:Label></td>
                                        </tr>
                                    </ItemTemplate>
                                    <AlternatingItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label runat="server" ID="lblname" Text='<%# Eval("name") %>'></asp:Label></td>
                                            <td>
                                                <asp:Label runat="server" ID="lblday_cost" Text='<%# Eval("sum") %>'></asp:Label></td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-8">
                        <div class="row">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">月消费</h3>
                                </div>
                                <div class="panel-body">
                                    <canvas id="myChart" width="700" height="400"></canvas>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">日消费明细</h3>
                                </div>
                                <div class="panel-body">

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Repeater ID="Repeater2" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-striped table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th>#</th>
                                                                <th>类型</th>
                                                                <th>金额</th>
                                                                <th>日期</th>
                                                            </tr>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblid" Text='<%# Eval("id") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblname" Text='<%# Eval("name") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblday_cost" Text='<%# Eval("day_cost") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lbldate" Text='<%# Eval("date") %>'></asp:Label></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <AlternatingItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblid" Text='<%# Eval("id") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblname" Text='<%# Eval("name") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lblday_cost" Text='<%# Eval("day_cost") %>'></asp:Label></td>
                                                        <td>
                                                            <asp:Label runat="server" ID="lbldate" Text='<%# Eval("date") %>'></asp:Label></td>
                                                    </tr>
                                                </AlternatingItemTemplate>
                                                <FooterTemplate>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <div class="text-right">
                                                <asp:LinkButton ID="lnkbtnfirst" runat="server" CommandName="first" Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick">首页</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="lnkbtnUp" runat="server" CommandName="prev" Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick">上一页</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="lnkbtnNext" runat="server" CommandName="next" Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick">下一页</asp:LinkButton>&nbsp;
                                                <asp:LinkButton ID="lnkbtnlast" runat="server" CommandName="last" Font-Underline="False" ForeColor="Red" OnCommand="Page_OnClick">尾页</asp:LinkButton>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
    <script src="../dist/js/jquery.validate.js"></script>
    <script src="../dist/js/Chart.js"></script>
    <script type="text/javascript">
        var ctx = document.getElementById("myChart").getContext("2d");
        var data = {
            labels: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
            datasets: [
                {
                    fillColor: "rgba(220,220,220,0.5)",
                    strokeColor: "rgba(220,220,220,1)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    data: [<%=dataChart()%>]
                }
            ]
        }
            var defaults = {
                bezierCurveTension: 0,
                bezierCurve: false
            }
            var myNewChart = new Chart(ctx).Line(data, defaults);

            $(function () {
                $("#form1").validate({
                    rules: {
                        TextBox1: {
                            required: true
                        },
                        TextBox2: {
                            required: true,
                            rangelength: [2, 16]
                        },
                        TextBox3: {
                            required: true,
                            rangelength: [2, 16]
                        },
                        TextBox4: {
                            required: true,
                            equalTo: "#TextBox3"
                        }
                    },
                    messages: {
                        TextBox1: {
                            required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写昵称</font>"
                        },
                        TextBox2: {
                            required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写密码</font>",
                            rangelength: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>密码长度必须在2-16之间</font>"
                        },
                        TextBox3: {
                            required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写密码</font>",
                            rangelength: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>密码长度必须在2-16之间</font>"
                        },
                        TextBox4: {
                            required: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>请填写您的确认密码</font>",
                            equalTo: "<img src='/image/error.jpg' id='error'/> <font color='#CC1C1F'>确认密码和密码不一致</font>"
                        }

                    }
                });
            });
          
    </script>

</body>
</html>
