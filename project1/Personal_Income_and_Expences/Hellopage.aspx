<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hellopage.aspx.cs" Inherits="Personal_Income_and_Expences.Hellopage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>欢迎——个人日常开支管理系统</title>

    <link href="../dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../dist/css/signin.css" rel="stylesheet" />
    <style>

    </style>
</head>
<body>
    <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
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
                        <a>首页</a></li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="Login.aspx">登录</a></li>
                    <li>
                        <a href="SignOut.aspx">注册</a></li>
                </ul>
            </div>
        </div>
    </nav>
    <form>
        <div class="container">
            <div class="jumbotron divpad">
                <h1>Hello!</h1>
                <h3>欢迎进入个人日常收支管理系统，通过将越简单越好作为设计理念，本系统能简单方便地记录您的日常开支并自动统计月消费，帮助您更好地管理开支。快来登录系统试试吧！！</h3>
                <p class="pull-right"><a class="btn btn-primary btn-lg" href="Login.aspx" role="button">登录</a></p>
                <div class="row divimgcen">
                    <div class="col-lg-3 divpcen">
                        <h2>折线图</h2>
                         <p>通过折线图清晰得表示出每个月的总花费，使您的每个月消费情况一目了然</p>
                    </div>
                    <div class="col-lg-9">
                        <img src="image/月消费.png" class="img-rounded" />
                    </div>
                </div>
                <div class="row divimgcen">
                    <div class="col-lg-9">
                        <img src="image/日消费明细.png" class="img-rounded" />
                    </div>
                    <div class="col-lg-3 divpcen">
                        <h2>表格</h2>
                        <p>通过表格显示每一笔消费，让您更仔细地了解消费情况</p>
                    </div>
                </div>
                <div class="row divimgcen">
                    <div class="col-lg-3 divpcen">
                        <h2>分类</h2>
                        <p>区分费用类型，使您能更加了解自己当天在哪些方面花费更多</p>
                    </div>
                    <div class="col-lg-9">
                        <img src="image/日消费.png" class="img-rounded" />
                    </div>
                </div>
                <div class="row divimgcen">
                    <div class="col-lg-9">
                        <img src="image/费用类型明细.png" class="img-rounded" />
                    </div>
                    <div class="col-lg-3 divpcen">
                        <h2>费用分类</h2>
                        <p>区分费用类型，使您能更加了解自己在哪些方面花费更多</p>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <footer>
        <p class="pull-right"><a href="#top">回到顶部</a></p>
        <p>@吴雨潜 王小飘 周彧 唐依莎</p>
    </footer>
    <script src="../dist/js/jquery-2.1.1.min.js"></script>
    <script src="../dist/js/bootstrap.min.js"></script>
</body>
</html>
