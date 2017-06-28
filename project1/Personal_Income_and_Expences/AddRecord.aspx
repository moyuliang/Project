<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRecord.aspx.cs" Inherits="Personal_Income_and_Expences.AddRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>添加——个人日常开支管理系统</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../dist/css/signin.css" rel="stylesheet" />
    <link href="../dist/css/bootstrap-datetimepicker.css" rel="stylesheet" />
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
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="修改后的昵称"></asp:TextBox>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        <asp:Button ID="Button30" runat="server" Text="保存" CssClass="btn btn-primary" OnClick="Button30_Click" />
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
                        <li class="active">
                            <a>添加</a></li>
                        <li>
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">管理</asp:LinkButton></li>
                    </ul>
                    <ul class="nav navbar-nav navbar-right">
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
                                <asp:Label ID="Label1" runat="server" Text="账户"></asp:Label><span class="caret"></span></a>
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
                                <h3 class="panel-title">费用</h3>
                            </div>
                            <div class="panel-body">
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="divtop">
                                            <div class="btn-group btn-group-justified" role="group" aria-label="...">
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button1" runat="server" Text="伙食费" CssClass="btn btn-default" OnClick="Button1_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button2" runat="server" Text="交通费" CssClass="btn btn-default" OnClick="Button2_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button3" runat="server" Text="生活费" CssClass="btn btn-default" OnClick="Button3_Click" />
                                                </div>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group">
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button4" runat="server" Text="交际费" CssClass="btn btn-default" OnClick="Button4_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button5" runat="server" Text="医疗费" CssClass="btn btn-default" OnClick="Button5_Click" />

                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button6" runat="server" Text="杂费" CssClass="btn btn-default" OnClick="Button6_Click" />
                                                </div>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group">
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button7" runat="server" Text="通讯费" CssClass="btn btn-default" OnClick="Button7_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button8" runat="server" Text="电费燃气费" CssClass="btn btn-default" OnClick="Button8_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button9" runat="server" Text="美容费" CssClass="btn btn-default" OnClick="Button9_Click" />
                                                </div>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group">
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button10" runat="server" Text="旅行费" CssClass="btn btn-default" OnClick="Button10_Click" />

                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button11" runat="server" Text="+收入" CssClass="btn btn-default" OnClick="Button11_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="divlartop">
                                            <div class="input-group">
                                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                                <span class="input-group-btn">
                                                    <asp:Button ID="Button32" runat="server" Text="x" CssClass="btn btn-default" OnClick="Button32_Click" />
                                                </span>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group">
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button12" runat="server" Text="7" CssClass="btn btn-default" OnClick="Button12_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button13" runat="server" Text="8" CssClass="btn btn-default" OnClick="Button13_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button14" runat="server" Text="9" CssClass="btn btn-default" OnClick="Button14_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button15" runat="server" Text="/" CssClass="btn btn-default" OnClick="Button15_Click" />
                                                </div>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group">
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button16" runat="server" Text="4" CssClass="btn btn-default" OnClick="Button16_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button17" runat="server" Text="5" CssClass="btn btn-default" OnClick="Button17_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button18" runat="server" Text="6" CssClass="btn btn-default" OnClick="Button18_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button19" runat="server" Text="*" CssClass="btn btn-default" OnClick="Button19_Click" />
                                                </div>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group">
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button20" runat="server" Text="1" CssClass="btn btn-default" OnClick="Button20_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button21" runat="server" Text="2" CssClass="btn btn-default" OnClick="Button21_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button22" runat="server" Text="3" CssClass="btn btn-default" OnClick="Button22_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button23" runat="server" Text="-" CssClass="btn btn-default" OnClick="Button23_Click" />

                                                </div>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group">
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button24" runat="server" Text="." CssClass="btn btn-default" OnClick="Button24_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button25" runat="server" Text="0" CssClass="btn btn-default" OnClick="Button25_Click" />

                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button26" runat="server" Text="00" CssClass="btn btn-default" OnClick="Button26_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button27" runat="server" Text="+" CssClass="btn btn-default" OnClick="Button27_Click" />

                                                </div>
                                            </div>
                                            <div class="btn-group btn-group-justified" role="group">
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button28" runat="server" Text="=" CssClass="btn btn-default" OnClick="Button28_Click" />
                                                </div>
                                                <div class="btn-group" role="group">
                                                    <asp:Button ID="Button29" runat="server" Text="填写" CssClass="btn btn-default" OnClick="Button29_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group">
                                    <label for="dtp_input2" class="control-label">Date Picking</label>
                                    <div class="input-group date form_date" data-date="" data-date-format="yyyymmdd" data-link-field="dtp_input2">
                                        <asp:TextBox ID="TextBox2" runat="server" class="form-control" size="16" placeholder="请选择日期" Text="" ></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                                        <span class="input-group-addon"><span id="calendar" class="glyphicon glyphicon-calendar"></span></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-8">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">日历</h3>
                            </div>
                            <div class="panel-body">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender"
                                            TodayDayStyle-CssClass="todaystyle" TodayDayStyle-ForeColor="#74B174"
                                            DayHeaderStyle-CssClass="dayheader" DayStyle-CssClass="daystyle" DayStyle-ForeColor="#B2B2B2" CssClass="table table-bordered"
                                            WeekendDayStyle-ForeColor="#C58080" OtherMonthDayStyle-ForeColor="#EEEEEE"
                                            TitleStyle-CssClass="titlestyle" TitleStyle-BackColor="White">
                                            <DayHeaderStyle CssClass="dayheader" />
                                            <DayStyle CssClass="daystyle" />
                                        </asp:Calendar>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../dist/js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="./dist/js/bootstrap-datetimepicker.js" charset="UTF-8"></script>
<script type="text/javascript" src="./dist/js/locales/bootstrap-datetimepicker.zh-CN.js" charset="UTF-8"></script>
<script type="text/javascript">

    $('.form_date').datetimepicker({
        language: 'zh-CN',
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 0
    });

</script>
</body>
</html>
