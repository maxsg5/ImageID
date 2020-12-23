<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="ImageID.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1>Image Recognition App</h1>
        <div class = "output">
            <asp:FileUpload ID="fu" runat="server" />
            <asp:Button Text="Upload" ID="btnUpload" runat="server" OnClick="btnUpload_Click" />
        </div>
        <div class = "output">
            <asp:PlaceHolder runat="server" ID="ph" />
            
        </div>
        <div class="output">
            <asp:Label Text="Please Upload An Image..." ID="lblStatus" runat="server" />

        </div>
    </form>
</body>
</html>