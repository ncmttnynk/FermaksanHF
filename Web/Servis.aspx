<%@ Page Title="" Language="C#" MasterPageFile="~/MP_TekSutun.master" AutoEventWireup="true" CodeFile="Servis.aspx.cs" Inherits="Servis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_TekCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_TekSutun" runat="Server">
    <asp:Panel ID="pnlServis" runat="server" DefaultButton="btnServisKaydet">
        <div class="container mt-2 mb-5">
            <div class="row">
                <div class="col">
                    <section class="card card-admin">
                        <header class="card-header">
                            <h2 class="card-title"><%=(DilKod == 1) ? "Online Servis Talebi" : "Online Service Request" %></h2>
                        </header>
                        <div class="card-body background-color-primary">
                            <div class="form-group row">
                                <label class="col-lg-3 control-label text-lg-right pt-2 text-color-light"><%=(DilKod == 1) ? "Ad ve Soyad:" : "Name and Surname:" %></label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtServisAdSoyad" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtServisAdSoyad" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servis">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 control-label text-lg-right pt-2 text-color-light"><%=(DilKod == 1) ? "Telefon:" : "Telephone Number:" %></label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtServisTelefon" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtServisTelefon" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servis">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtServisTelefon" ValidationGroup="servis" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$" >
                           <label class="mt-2 text-light"><%=(DilKod == 1) ? "Geçersiz telefon numarası!" : "Invalid telephone number!" %></label>

                                    </asp:RegularExpressionValidator> 

                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 control-label text-lg-right pt-2 text-color-light"><%=(DilKod == 1) ? "E-Posta:" : "E-Mail:" %></label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtServisEposta" runat="server" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtServisEposta" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servis">
                                    </asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="revEPosta" runat="server"
                                        ControlToValidate="txtServisEposta" ValidationGroup="servis" SetFocusOnError="true"
                                        Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                           <label class="mt-2 text-light"><%=(DilKod == 1) ? "Geçersiz e-posta adresi!" : "Invalid e-mail adress!" %></label>
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 control-label text-lg-right pt-2 text-color-light"><%=(DilKod == 1) ? "Açıklama:" : "Information:" %></label>
                                <div class="col-lg-6">
                                    <asp:TextBox ID="txtServisAciklama" runat="server" Rows="10" TextMode="MultiLine" CssClass="form-control" />
                                    <asp:RequiredFieldValidator ID="rfv22" runat="server" ControlToValidate="txtServisAciklama" Display="Dynamic" SetFocusOnError="true" ValidationGroup="servis">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 control-label text-lg-right pt-2 text-color-light"><%=(DilKod == 1) ? "Doğrulama Kodu:" : "Captcha:" %></label>
                                <div class="col-lg-3">
                                    <asp:Image ID="imgCaptcha" runat="server" ImageUrl="~/JpegImage.ashx" CssClass="" />
                                </div>
                                <div class="col-lg-3">
                                    <asp:TextBox ID="txtCaptcha" runat="server" AutoCompleteType="Disabled" CssClass="form-control input-lg" />
                                    <div class="alert alert-danger" id="divCaptcha" runat="server" visible="false">
                                        <strong><%=(DilKod == 1) ? "Hatalı kod!" : "Wrong Captcha!" %></strong>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row">
                                <label class="col-lg-3 control-label text-lg-right pt-2 text-color-light"></label>
                                <div class="col-lg-6">
                                    <asp:Button ID="btnServisKaydet" runat="server" CssClass="btn btn-3d btn-light btn-m fa-pull-right" ValidationGroup="servis" OnClick="btnServisKaydet_Click" />
                                </div>
                            </div>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

