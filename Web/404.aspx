<%@ Page Title="" Language="C#" MasterPageFile="~/MP_TekSutun.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_TekCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_TekSutun" runat="Server">
    <div class="container">
        <section class="page-not-found">
            <div class="row justify-content-center">
                <div class="col-lg-7 text-center">
                    <div class="page-not-found-main">
                        <h2>404 <i class="fas fa-file"></i></h2>
                        <p>
                            <asp:Literal ID="ltlBulunamadi" runat="server" />
                        </p>
                    </div>
                </div>
                <div class="col-lg-4">
                    <h4 class="heading-primary">
                        <asp:Literal ID="ltlLinkBaslik" runat="server" /></h4>
                    <ul class="nav nav-list flex-column">
                        <li class="nav-item"><a class="nav-link" href="Default"><%=(Dil.Equals("tr") ? "Anasayfa" : "Home") %></a></li>
                        <li class="nav-item"><a class="nav-link" href="Makineler"><%=(Dil.Equals("tr") ? "Makineler" : "Machines") %></a></li>
                        <li class="nav-item"><a class="nav-link" href="Sektorler"><%=(Dil.Equals("tr") ? "Sektörler" : "Endustries") %></a></li>
                        <li class="nav-item"><a class="nav-link" href="Servis"><%=(Dil.Equals("tr") ? "Servis Talepi" : "Service Request") %></a></li>
                        <li class="nav-item"><a class="nav-link" href="Iletisim"><%=(Dil.Equals("tr") ? "İletişim" : "Contact Us") %></a></li>
                    </ul>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

