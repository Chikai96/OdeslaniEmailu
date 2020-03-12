<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Odeslani_emailu._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
    <asp:Button ID="Button1" runat="server" Text="Odeslat email" />
</asp:Content>
