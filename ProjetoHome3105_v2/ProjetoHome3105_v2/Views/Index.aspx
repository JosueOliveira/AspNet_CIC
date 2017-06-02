<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProjetoHome3105_v2.Views.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Livros Cadastrados</h1>
    <div class="row">
        <div class="panel panel-primary">
    <asp:GridView ID="grdLivros" runat="server" OnRowCommand="grdLivros_RowCommand">
        <Columns>
            <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="Excluir" ImageUrl="~/Images/delete20.png" Text="Excluir" />
            <asp:ButtonField ButtonType="Image" CommandName="Editar" HeaderText="Editar" ImageUrl="~/Images/alterar20.png" Text="Editar" />
        </Columns>
            </asp:GridView>
            </div>
    </div>
    <br />
    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnNewBook" class="btn btn-primary" runat="server" Text="Novo Livro" OnClick="btnNewBook_Click" />
    <asp:Button ID="btnLocalizar" class="btn btn-primary" runat="server" Text="Localizar" OnClick="btnLocalizar_Click" />
    <asp:Button ID="btnListar" class="btn btn-primary" runat="server" Text="Listar" OnClick="btnListar_Click" Width="105px" />
</asp:Content>
