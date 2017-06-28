<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageRecord.aspx.cs" Inherits="Personal_Income_and_Expences.ManageRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>管理——个人日常开支管理系统</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../dist/css/signin.css" rel="stylesheet" />
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
                        <asp:Button ID="Button1" runat="server" Text="保存" CssClass="btn btn-primary" OnClick="Button1_Click"/>
                    </div>
                </div>
            </div>
        </div>
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
                        <li>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">主页</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">添加</asp:LinkButton></li>
                        <li class="active">
                            <a>管理</a></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                <asp:Label ID="Label1" runat="server" Text="账户"></asp:Label><span class="caret"></span></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <a href="#myModal" data-toggle="modal">修改昵称</a>
                                </li>
                               <li>
                                   <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">修改密码</asp:LinkButton></li>
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

                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">管理日消费明细</h3>
                    </div>
                    <div class="panel-body">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" OnSorting="GridView1_Sorting" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="id" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound" Width="100%" GridLines="None" CssClass="table table-hover">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="id" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                <asp:BoundField DataField="name" HeaderText="类型" SortExpression="name" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                <asp:BoundField DataField="day_cost" HeaderText="金额" SortExpression="day_cost" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                <asp:BoundField DataField="date" HeaderText="日期" SortExpression="date" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                <asp:CommandField HeaderText="编辑" ShowEditButton="True" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" Font-Size="Larger" />
                        </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">费用类型明细</h3>
                    </div>
                    <div class="panel-body">
                        <canvas id="myChart" width="900" height="400"></canvas>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
    <script src="../dist/js/Chart.js"></script>
    <script type="text/javascript">
        var ctx = document.getElementById("myChart").getContext("2d");
        var data = {
            labels: ["伙食费", "电费燃气费", "生活费", "交际费", "交通费", "通讯费", "美容费", "旅行费", "杂费", "医疗费", "收入"],
            datasets: [
                {
                    fillColor: "rgba(220,220,220,0.5)",
                    strokeColor: "rgba(220,220,220,1)",
                    data: [<%=dataChart()%>]
                }
            ]
        }
        var myNewChart = new Chart(ctx).Bar(data);
    </script>
</body>
</html>
