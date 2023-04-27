<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Sektorler.ascx.cs" Inherits="usercontrols_UC_Sektorler" %>



<asp:Panel ID="pnlSektorler" runat="server">
    <h2 class="mt-2">
        <asp:Literal ID="ltlBaslik" runat="server" /></h2>
    <asp:Repeater ID="rptSektorler" runat="server">
        <HeaderTemplate>
            <div class="masonry-loader masonry-loader-showing">
                <div class="masonry" data-plugin-masonry data-plugin-options="{'itemSelector': '.masonry-item'}">
        </HeaderTemplate>
        <ItemTemplate>
            <div class="masonry-item">
                <a href='<%#string.Format("/" + Session["dil"] + "/Sektorler/{0}/{1}",Eval("Id"),Eval("Baslik").ToString().ToURL()) %>'>
                    <span class="thumb-info thumb-info-centered-info thumb-info-no-borders">
                        <span class="thumb-info-wrapper">
                            <ny:MyImage ID="img" runat="server" ImageUrl='<%#Eval("Fotograf") %>' EmptyImageUrl="/img/projects/project.jpg" CssClass="img-fluid" AlternateText='<%#Eval("Baslik") %>' Thumbnail="false" Quality="100" MaxHeight="500" />
                            <span class="thumb-info-title">
                                <span class="thumb-info-inner" style="text-transform: none !important;"><%#Eval("Baslik") %></span>
                                <%--<span class="thumb-info-type">Brand</span>--%>
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
</asp:Panel>
