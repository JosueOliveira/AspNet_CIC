﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ProjetoHome3105_v2.Views.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>livros Cadastrados</h1>
    <div class="row">
        <div class="panel panel-primary">
    <asp:GridView ID="grdLivros" runat="server"></asp:GridView>
            </div>
    </div>
    <br />
    <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnNewBook" runat="server" Text="Novo Livro" OnClick="btnNewBook_Click" />
    <asp:Button ID="btnLocalizar" runat="server" Text="Localizar" OnClick="btnLocalizar_Click" />
</asp:Content>
