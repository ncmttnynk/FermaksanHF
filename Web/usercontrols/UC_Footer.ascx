<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Footer.ascx.cs" Inherits="usercontrols_UC_Footer" %>


<footer class="color color-secondary short mt-0" id="footer">
    <div class="container">
        <div class="row">
            <div class="col-lg-8">
                <asp:Literal ID="ltlFooterSol" runat="server" />
            </div>
            <div class="col-lg-3 col-lg-offset-1">
                <asp:Literal ID="ltlFooterSag" runat="server" />
            </div>
        </div>
    </div>
    <div class="footer-copyright">
        <div class="container">
            <div class="row">
                <asp:Literal ID="ltlFooterAlt" runat="server" />
            </div>
        </div>
    </div>
</footer>
