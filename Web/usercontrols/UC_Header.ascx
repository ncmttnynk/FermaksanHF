<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Header.ascx.cs" Inherits="usercontrols_UC_Header" %>


<%@ Register Src="UC_AnaMenu.ascx" TagName="UC_AnaMenu" TagPrefix="uc1" %>


<header id="header" data-plugin-options="{'stickyEnabled': true, 'stickyEnableOnBoxed': true, 'stickyEnableOnMobile': true, 'stickyStartAt': 58, 'stickySetTop': '-58px', 'stickyChangeLogo': true}">
    <div class="header-body">
        <div class="header-top header-top-colored header-top-primary">
            <div class="container">
                <div class="header-row py-2">
                    <div class="header-column justify-content-start">
                        <div class="header-row">
                            <p>
                                <asp:Literal ID="ltlIletisimBaslik" runat="server" />
                                <span class="ml-1"><i class="fas fa-phone"></i>
                                    <asp:Literal ID="ltlIletisimTelefon" runat="server" /></span><span class="d-none d-sm-inline-block pl-1"> | <a href="javascript:void(0)">
                                        <asp:Literal ID="ltlIletisimEposta" runat="server" /></a></span>
                            </p>
                        </div>
                    </div>
                    <div class="header-column justify-content-end">
                        <div class="header-row">
                            <nav class="header-nav-top">
                                <ul class="nav nav-pills">
                                    <asp:Literal ID="ltlUstMenu" runat="server" />
                                    <li class="nav-item dropdown">
                                        <a class="nav-link" href="javascript:void(0)" role="button" id="dropdownLanguage" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                            <asp:Literal ID="ltlSeciliDil" runat="server" />
                                        </a>
                                        <div class="dropdown-menu" aria-labelledby="dropdownLanguage">
                                            <asp:Literal ID="ltlMenuDil" runat="server" />
                                        </div>
                                    </li>
                                </ul>
                            </nav>
                            <ul class="header-social-icons social-icons d-none d-sm-block">
                                <li class="social-icons-facebook">
                                    <asp:HyperLink ID="hlFacebook" runat="server" Target="_blank" ToolTip="Facebook" Visible="false"><i class="fab fa-facebook-f"></i></asp:HyperLink></li>
                                <li class="social-icons-youtube">
                                    <asp:HyperLink ID="hlYoutube" runat="server" Target="_blank" ToolTip="YouTube" Visible="false"><i class="fab fa-youtube"></i></asp:HyperLink></li>

                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="header-container container">
            <div class="header-row">
                <div class="header-column">
                    <div class="header-row">
                        <div class="header-logo">
                            <a href="/">
                                <img alt="Fermaksan" width="111" height="54" data-sticky-width="100" data-sticky-height="50" data-sticky-top="4" src="/img/logo.jpg" style="top: 0px; width: 111px; height: 54px;">
                            </a>
                        </div>
                    </div>
                </div>
                <uc1:UC_AnaMenu ID="UC_AnaMenu1" runat="server" />
            </div>
        </div>
    </div>
</header>
