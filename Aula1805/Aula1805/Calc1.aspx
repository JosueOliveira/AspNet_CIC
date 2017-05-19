<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calc1.aspx.cs" Inherits="Aula1805.Calc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtValor1" runat="server"></asp:TextBox><asp:TextBox ID="txtValor2" runat="server"></asp:TextBox>
    </div>
        <p>
        <asp:TextBox ID="txtResultado" runat="server"></asp:TextBox>
        <asp:Button ID="btnSoma" runat="server" Text="+" Height="26px" OnClick="btnSoma_Click" Width="58px" />
            <asp:Button ID="btnIgual" runat="server" Text="=" style="margin-top: 0px" Width="56px" OnClick="btnIgual_Click" />
            <asp:Button ID="btnLimpar" runat="server" Text="Limpar" OnClick="btnLimpar_Click" />
        </p>
        <p>
            <asp:LinkButton ID="linkBtnigual" runat="server" href="Calc2">=</asp:LinkButton>
            </p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
