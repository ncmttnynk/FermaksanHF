<%@ Page Title="" Language="C#" MasterPageFile="~/MP_TekSutun.master" AutoEventWireup="true" CodeFile="Iletisim.aspx.cs" Inherits="Iletisim" %>

<%@ Register Src="/includes/GoogleMap/GoogleMapForASPNet.ascx" TagName="GoogleMapForASPNet"
    TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_TekCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_TekSutun" runat="Server">
    <div class="mt-0">
        <uc2:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
    </div>
    <section class="section section-default section-default-scale-2">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-12" style="margin-top: 10px;">
                <div class="container">
                    <div class="row" id="iletisim">
                        <asp:Panel ID="pnlIletisim" runat="server" DefaultButton="btnIletisimKaydet" CssClass="col-lg-6">
                            <h2 class="mb-3 mt-2"><strong><%=(DilKod == 1) ? "Bize Ulaşın!" : "Contact Us" %></strong> </h2>
                            <div class="form-row">
                                <div class="form-group col-lg-6">
                                    <label class="text-primary"><%=(DilKod == 1) ? "Ad ve Soyad:" : "Name and Surname:" %></label>
                                    <asp:TextBox ID="txtAdSoyad" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtAdSoyad"
                                        ValidationGroup="iletisim" SetFocusOnError="true" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group col-lg-6">
                                    <label class="text-primary"><%=(DilKod == 1) ? "E-Posta:" : "E-Mail:" %></label>
                                    <asp:TextBox ID="txtPosta" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPosta"
                                        ValidationGroup="iletisim" SetFocusOnError="true" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEPosta" runat="server"
                                        ControlToValidate="txtPosta" ValidationGroup="iletisim" SetFocusOnError="true"
                                        Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                           <label><%=(DilKod == 1) ? "Geçersiz e-posta adresi!" : "Invalid e-mail adress!" %></label>
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col">
                                    <label class="text-primary"><%=(DilKod == 1) ? "Konu:" : "Subject:" %></label>
                                    <asp:TextBox ID="txtKonu" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtKonu"
                                        ValidationGroup="iletisim" SetFocusOnError="true" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col">
                                    <label class="text-primary"><%=(DilKod == 1) ? "Açıklama:" : "Information:" %></label>
                                    <asp:TextBox ID="txtAciklama" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="10" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAciklama"
                                        ValidationGroup="iletisim" SetFocusOnError="true" Display="Dynamic">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col">
                                    <asp:Button ID="btnIletisimKaydet" runat="server" Text="Gönder" CssClass="btn btn-primary btn-lg pull-right" OnClick="btnServisKaydet_Click" ValidationGroup="iletisim" />
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="col-lg-6">
                            <h4 class="heading-primary mt-4"><strong><%=Config.Title %></strong></h4>
                            <asp:Literal ID="ltlIletisimAciklama" runat="server" />
                            <hr>
                            <h4 class="heading-primary">Of<strong><%=(DilKod == 1) ? "is" : "icce" %></strong></h4>
                            <ul class="list list-icons list-icons-style-3 mt-4 text-color-primary">
                                <li><i class="fas fa-map-marker-alt"></i><strong class="text-light"><%=(DilKod == 1) ? "Adres:" : "Adress:" %></strong>
                                    <asp:Literal ID="ltlAdres" runat="server" /></li>
                                <li><i class="fas fa-phone"></i><strong class="text-light"><%=(DilKod == 1) ? "Telefon:" : "Telephone:" %></strong>
                                    <asp:Literal ID="ltlTelefon" runat="server" /></li>
                                <li><i class="far fa-envelope"></i><strong class="text-light"><%=(DilKod == 1) ? "E-Posta:" : "E-Mail:" %></strong>
                                    <asp:Literal ID="hlMail" runat="server" /></li>
                            </ul>
                            <hr>
                            <h4 class="heading-primary"><%=(DilKod == 1) ? "Çalışma" : "Business" %> <strong><%=(DilKod == 1) ? "Saatleri" : "Hour" %></strong></h4>
                            <asp:Literal ID="ltlCalismaSaatleri" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </section>
</asp:Content>

