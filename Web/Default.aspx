<%@ Page Title="" Language="C#" MasterPageFile="~/MP_TekSutun.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="/usercontrols/UC_Mansetler.ascx" TagName="UC_Mansetler" TagPrefix="uc1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="CPH_TekCSS" runat="Server">
    <link rel="stylesheet" href="/Compress.ashx?css=/vendor/nivo-slider/nivo-slider.css">
    <link rel="stylesheet" href="/vendor/nivo-slider/dark/dark.css">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_TekSutun" runat="Server">

    <uc1:UC_Mansetler ID="UC_Mansetler1" runat="server" />
    <section class="section section-primary mb-0">
        <div class="container">
            <div class="row counters counters-text-light">
                <div class="col-sm-6 col-lg-3 mb-5 mb-lg-0">
                    <div class="counter">
                        <strong data-to="30">30</strong>
                        <label><%=(DilKod == 1) ? "Yıllık Tecrübe" : "Years in Business" %></label>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-3 mb-5 mb-sm-0">
                    <div class="counter">
                        <strong data-to="40" data-append="+">40+</strong>
                        <label><%=(DilKod == 1) ? "Ülke" : "Countries" %></label>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-3 mb-5 mb-sm-0">
                    <div class="counter">
                        <strong data-to="1000" data-append="+">1000+</strong>
                        <label><%=(DilKod == 1) ? "Fazla Makine" : "Thousands of Machines" %></label>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-3 mb-5 mb-lg-0">
                    <div class="counter">
                        <strong data-to="1000" data-append="+">10000+</strong>
                        <label><%=(DilKod == 1) ? "Mutlu Müşteri" : "Happy Client" %></label>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="section section-secondary text-center text-lg-left pb-0 pb-lg-5 pb-xl-0 mb-0">
        <div class="container">
            <div class="row">
                <asp:Literal ID="ltlGirisUst" runat="server" />
            </div>
        </div>
    </section>
    <div class="container">
        <div class="row mt-5">
            <asp:Literal ID="ltlGirisOrta" runat="server" />
        </div>
    </div>
    <section class="section m-0">
        <div class="container">
            <asp:Literal ID="ltlGirisAlt" runat="server" />
        </div>
    </section>
    <div class="home-intro mb-0" id="home-intro">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-lg-8">
                    <p>
                        <asp:Literal ID="ltlAltMesaj" runat="server" />
                    </p>
                </div>
                <div class="col-lg-4">
                    <asp:UpdatePanel ID="up" runat="server">
                        <ContentTemplate>
                            <div class="get-started text-left text-lg-right">
                                <a href="https://www.youtube.com/watch?v=Y1ROTlNakZI" class="btn btn-primary lightbox" data-plugin-options="{'type': 'iframe'}"><%=(DilKod==1)?"Videomuzu izlemek için tıklayın!":"See our video!" %></a>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

