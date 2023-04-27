<%@ Page Title="" Language="C#" MasterPageFile="~/MP_TekSutun.master" AutoEventWireup="true" CodeFile="Makineler.aspx.cs" Inherits="Makineler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_TekCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_TekSutun" runat="Server">
    <div class="container mt-3">
        <div class="container">
            <h2><%=(DilKod==1) ? "Makineler" : "Machines" %></h2>
            <asp:Repeater ID="rptKategoriler" runat="server" OnItemDataBound="rptKategoriler_ItemDataBound">
                <HeaderTemplate>
                    <ul class="nav nav-pills sort-source" data-sort-id="kategoriMakineleri" data-option-key="filter" data-plugin-options="{'layoutMode': 'masonry', 'filter': '*'}">
                        <li class="nav-item" id="liHepsi" runat="server" data-option-value="*">
                            <a id="aHepsi" runat="server" class="nav-link"><% if (Dil.Equals("tr")) Response.Write("Hepsi"); else Response.Write("All"); %></a></li>
                </HeaderTemplate>
                <ItemTemplate>
                    <li class="nav-item" id="liKat" runat="server" data-option-value='<%#string.Format(".{0}",Eval("Baslik").ToString().ToURL()) %>'><a class="nav-link" id="aKat" runat="server" href="#"><%#Eval("Baslik") %></a></li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
            <asp:Repeater ID="rptMakineler" runat="server">
                <HeaderTemplate>
                    <div class="sort-destination-loader sort-destination-loader-showing mt-4 pt-2">
                        <div class="row portfolio-list sort-destination" data-sort-id="kategoriMakineleri">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col-lg-4 isotope-item <%#string.Format("{0}",Eval("Kategori").ToString().ToURL()) %>">
                        <div class="portfolio-item">
                            <a href='<%#string.Format("MakineDetay/{0}/{1}/{2},product",Eval("Id"),Eval("Baslik").ToString().ToURL(),Eval("Kod").ToString().ToURL()) %>'>
                                <span class="thumb-info thumb-info-centered-info thumb-info-no-borders">
                                    <span class="thumb-info-wrapper">
                                        <asp:Image ID="img" runat="server" ImageUrl='<%#Eval("Fotograf") %>' AlternateText='<%#string.Format("{0} - {1}",Eval("Baslik"),Eval("Kod")) %>' ToolTip='<%#string.Format("{0} - {1}",Eval("Baslik"),Eval("Kod")) %>' CssClass="img-fluid" />
                                        <span class="thumb-info-title">
                                            <span class="thumb-info-inner" style="text-transform: none !important;"><%#Eval("Baslik") %></span>
                                            <span class="thumb-info-type"><%#Eval("Kod") %></span>
                                        </span>
                                        <span class="thumb-info-action">
                                            <span class="thumb-info-action-icon"><i class="fas fa-link"></i></span>
                                        </span>
                                    </span>
                                </span>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                        </div>
                </FooterTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>

