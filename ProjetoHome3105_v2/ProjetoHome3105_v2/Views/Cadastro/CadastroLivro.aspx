<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroLivro.aspx.cs" Inherits="ProjetoHome3105_v2.Views.Cadastro.CadastroLivro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cadastro De livros</h1>
    <asp:Label ID="lblNome" runat="server" Text="Nome"></asp:Label>
    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblAutor" runat="server" Text="Autor"></asp:Label>
    <asp:TextBox ID="txtAutor" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblDescricao" runat="server" Text="Descricao"></asp:Label>
    <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="btnAdicionar" class="btn btn-primary" runat="server" Text="Salvar" OnClick="btnAdicionar_Click" />
    <asp:Button ID="btnEditar" class="btn btn-primary" runat="server" Text="Alterar" OnClick="btnEditar_Click" />
    
</asp:Content>
