<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ImageID.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="fu" runat="server" />
            <asp:Button Text="Upload" ID="btnUpload"  runat="server" OnClick="btnUpload_Click" />
            <asp:PlaceHolder runat="server" ID="ph" />
            <asp:Label Text="Please Upload An Image" ID="lblStatus" runat="server" />
        </div>
    </form>
</body>
</html>