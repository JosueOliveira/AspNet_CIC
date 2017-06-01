<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroDeLivros.aspx.cs" Inherits="ProjetoHome3105_v1.Views.Cadastro.CadastroDeLivros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Cadastrar Livro</h1>
    <div class="row">
    <asp:Label ID="lblnome" runat="server" Text="Nome"/>
    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblAutor" runat="server" Text="Autor"/>
    <asp:TextBox ID="txtAutor" runat="server"></asp:TextBox>
    <br />  
    <asp:Label ID="lblDescricao" runat="server" Text="Descrição"/>
    <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
    <br />  
    <asp:Label ID="lblCodigo" runat="server" Text="Codigo"></asp:Label>
    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblCategoria" runat="server" Text="Categoria"/>
    <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
    <br />  
        </div>
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    <asp:Button ID="btnEditar" runat="server" Text="Editar" />
    <asp:Button ID="btnexcluir" runat="server" Text="Excluir" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
</asp:Content>
