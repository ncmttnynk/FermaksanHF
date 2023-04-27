<%@ Page Title="" Language="C#" MasterPageFile="~/MP_SolSutun.master" AutoEventWireup="true" CodeFile="CMS.aspx.cs" Inherits="CMS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_Sol" runat="Server">
    <aside class="sidebar mt-3">
        <h4>
         
        <asp:Literal ID="ltlCmsMenu" runat="server" />
             </h4>
    </aside>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_Sag" runat="Server">
    <asp:Literal ID="ltlIcerik" runat="server" />
</asp:Content>

