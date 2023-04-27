<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_AnaMenu.ascx.cs" Inherits="usercontrols_UC_AnaMenu" %>


<div class="header-column justify-content-end">
    <div class="header-row">
        <div class="header-nav header-nav-stripe">
            <div class="header-nav-main header-nav-main-square header-nav-main-effect-1 header-nav-main-sub-effect-1">
                <asp:Literal ID="ltlAnaMenu" runat="server" />
            </div>
            <button class="btn header-btn-collapse-nav" data-toggle="collapse" data-target=".header-nav-main nav">
                <i class="fas fa-bars"></i>
            </button>
        </div>
    </div>
</div>
