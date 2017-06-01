<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Aua2505_EF_Model_First.Views.Categorias.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvCategorias" runat="server"></asp:GridView>

    <asp:TextBox ID="txtId" runat="server"></asp:TextBox><br />
    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
    <asp:Button ID="btnLocalizar" runat="server" Text="Localizar" OnClick="btnLocalizar_Click" />
    <asp:Button ID="btnListar" runat="server" Text="Listar" />
    </asp:Content>
