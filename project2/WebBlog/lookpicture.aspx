<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lookpicture.aspx.cs" Inherits="图片管理.lookpicture" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Image1" runat="server" width="200" Height="200" src="ImageService.aspx"/>
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="删除" />
    
    </div>
    </form>
</body>
</html>
