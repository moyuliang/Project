<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="image.aspx.cs" Inherits="图片管理.image" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        请输入图片序号<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="删除" />
        <br />
        <br />
        图片名<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        图片来源<asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <%--用户名<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>--%>
        <br />
        <%--上传时间<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>--%>
        <br />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="上传" />
    </div>
    </form>
</body>
</html>
