<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProjetoHome3105_v1.Views.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cadastro de Livros</h1>


    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="btnNewBook" runat="server" Text="Adicionar Livro" OnClick="btnNewBook_Click" />
    <asp:Button ID="btnNewCategory" runat="server" Text="Nova Categoria" />
    <asp:Button ID="btnListar" runat="server" Text="Livros Cadastrados" />
</asp:Content>
