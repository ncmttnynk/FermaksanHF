<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Mansetler.ascx.cs" Inherits="usercontrols_UC_Slider" %>

<asp:Repeater ID="rptSlider" runat="server">
    <HeaderTemplate>
        <div class="nivo-slider theme-dark">
            <div class="slider-wrapper">
                <div id="nivoSlider" class="nivoSlider">
    </HeaderTemplate>
    <ItemTemplate>
        <a href='<%#Eval("Url") %>' target='<%# Convert.ToBoolean(Eval("Yeni")) ? "_blank" : "" %>'>
            <ny:MyImage ID="nyImg" runat="server" ImageUrl='<%#Eval("Fotograf") %>' Scaled="false" Thumbnail="false" Quality="100" AlternateText='<%#Eval("Baslik") %>' MaxWidth="1110" ToolTip='<%#Eval("Baslik") %>' />
        </a>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </div>
</div>
    </FooterTemplate>
</asp:Repeater>



<%-- <div id="htmlcaption_0" class="nivo-html-caption">
                    <h1 class="slide-h1">Title</h1>
                    <h2 class="slide-h2">Description</h2>
                    <h3 class="slide-h3">
                        <a href="#" title="">Learn More &raquo;</a>
                    </h3>
                </div>
                   Eğer fotoğrafın tooltip'inin başına # eklenirse buradaki id'si o olan içeriği gösteriyor.
--%>