<%@ Page Title="" Language="C#" MasterPageFile="~/MP_TekSutun.master" AutoEventWireup="true" CodeFile="Sektorler.aspx.cs" Inherits="Sektorler" %>

<%@ Register Src="/usercontrols/UC_Sektorler.ascx" TagName="UC_Sektorler" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_TekCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_TekSutun" runat="Server">
    <div class="container mt-3">
        <asp:Panel ID="pnlSektor" runat="server" Visible="false">
            <div class="row">
                <div class="col">
                    <div class="portfolio-title">
                        <div class="row">
                            <div class="portfolio-nav-all col-lg-1">
                                <asp:HyperLink ID="hlTumSol" runat="server"><i class="fas fa-th"></i></asp:HyperLink>
                            </div>
                            <div class="col-lg-10 text-center">
                                <h2 class="mb-0">
                                    <asp:Literal ID="ltlSektorUstBaslik" runat="server" /></h2>
                            </div>
                            <div class="portfolio-nav col-lg-1">
                                <asp:HyperLink ID="hlTumSag" runat="server"><i class="fas fa-th"></i></asp:HyperLink>
                            </div>
                        </div>
                    </div>
                    <hr class="tall">
                </div>
            </div>
            <div class="row" runat="server">
                <div class="col mb-5">
                    <div class="show-nav-hover mt-0">
                        <div>
                            <span class="img-thumbnail d-block center">
                                <ny:MyImage ID="img" runat="server" MaxHeight="500" CssClass="img-fluid" Quality="100" Scaled="false" Thumbnail="false" EmptyImageUrl="/img/projects/project-short.jpg" />
                            </span>
                        </div>
                        <%--  <div>
                            <span class="img-thumbnail d-block">
                                <img src="/img/projects/project-short-2.jpg" class="img-fluid" alt="">
                            </span>
                        </div>
                        <div>
                            <span class="img-thumbnail d-block">
                                <img src="/img/projects/project-short-3.jpg" class="img-fluid" alt="">
                            </span>
                        </div>--%>
                    </div>
                </div>
            </div>
            <hr class="tall">
        </asp:Panel>
        <uc1:UC_Sektorler ID="UC_Sektorler1" runat="server" Visible="false" />
        <div class="container">
            <div class="row">
                <div class="col">
                    <%--<h2 class="mt-3 mb-2">
                        <asp:Literal ID="ltlSektorAltBaslik" runat="server" /></h2>--%>
                    <asp:Literal ID="ltlSektorAciklama" runat="server" />
                </div>
            </div>

        </div>
        <div class="row mb-5" id="divIlgiliMakineler" runat="server" visible="false">
            <div class="col">
                <hr class="tall mt-4">
                <h4 class="mb-3"><strong><% if (Dil.Equals("tr")) Response.Write("İlgili Makineler"); else Response.Write("Dedicated Machines");  %></strong></h4>
                <asp:Repeater ID="rptSektorMakineler" runat="server">
                    <HeaderTemplate>
                        <div class="masonry-loader masonry-loader-showing">
                            <div class="masonry" data-plugin-masonry data-plugin-options="{'itemSelector': '.masonry-item'}">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="masonry-item">
                            <a href='<%#string.Format("/"+Dil+"/MakineDetay/{0}/{1}/{2}",Eval("Id"),Eval("Baslik").ToString().ToURL(),Eval("Kod").ToString().ToURL()) %>'>

                                <span class="thumb-info thumb-info-centered-info thumb-info-no-borders">
                                    <span class="thumb-info-wrapper">
                                        <asp:Image ID="MyImage1" runat="server" ImageUrl='<%#Eval("Fotograf") %>' EmptyImageUrl="/img/projects/project.jpg" CssClass="img-fluid" AlternateText='<%#Eval("Baslik") %>' />
                                        <span class="thumb-info-title">
                                            <span class="thumb-info-inner" style="text-transform: none !important;"><%#Eval("Baslik") %></span>
                                            <span class="thumb-info-type"><%#Eval("Kod") %></span>
                                        </span>
                                        <span class="thumb-info-action">
                                            <span class="thumb-info-action-icon"><i class="fas fa-link"></i></span>
                                        </span></span>
                                </span>
                            </a>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <%--<section class="call-to-action call-to-action-default with-button-arrow content-align-center call-to-action-in-footer">
        <div class="container">
            <div class="row">
                <div class="col-md-9 col-lg-9">
                    <div class="call-to-action-content">
                        <h3>Porto is <strong>everything</strong> you need to create an <strong>awesome</strong> website!</h3>
                        <p class="mb-0">The <strong>#1 Selling</strong> HTML Site Template on ThemeForest</p>
                    </div>
                </div>
                <div class="col-md-3 col-lg-3">
                    <div class="call-to-action-btn">
                        <a href="http://themeforest.net/item/porto-responsive-html5-template/4106987" target="_blank" class="btn btn-lg btn-primary">Buy Now!</a><span class="arrow hlb d-none d-md-block" data-appear-animation="rotateInUpLeft" style="top: -40px; left: 70%;"></span>
                    </div>
                </div>
            </div>
        </div>
    </section>--%>
</asp:Content>

