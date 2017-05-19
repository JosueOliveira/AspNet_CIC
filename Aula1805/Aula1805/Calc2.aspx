<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calc2.aspx.cs" Inherits="Aula1805.Calc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtValor1soma2" runat="server"></asp:TextBox>
        <asp:Label ID="soma" runat="server" Text="+"></asp:Label>
        <asp:TextBox ID="txtValor2soma2" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtResultadoSoma" runat="server"></asp:TextBox>
        <br />
        
        <asp:TextBox ID="txtValor1subtrai2" runat="server"></asp:TextBox>
        <asp:Label ID="Subtrai" runat="server" Text="-"></asp:Label>
        <asp:TextBox ID="txtValor2subtrai2" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtResultadoSubtrai" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtValor1mult2" runat="server"></asp:TextBox>
        <asp:Label ID="Mult" runat="server" Text="*"></asp:Label>
        <asp:TextBox ID="txtValor2mult2" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtResultadoMultiplica" runat="server"></asp:TextBox>
        <br />
        <asp:TextBox ID="txtValor1div2" runat="server"></asp:TextBox>
        <asp:Label ID="Divisao" runat="server" Text="/"></asp:Label>
        <asp:TextBox ID="txtValor2div2" runat="server"></asp:TextBox>
        <asp:TextBox ID="txtResultadoDivisao" runat="server"></asp:TextBox>
    </div>
    </form>
</body>
</html>
