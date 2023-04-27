<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MP_Admin.master" AutoEventWireup="true" CodeFile="MakineDetay.aspx.cs" Inherits="admin_MakineDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_Sag" runat="Server">
    <asp:UpdatePanel ID="up" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnKaydet" EventName="" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="fotouploading" runat="server" Style="display: none;">
                <div class="popupbox" style="padding: 10px; height: 550px; width: 550px; overflow: auto;">
                    <div style="padding-top: 0px; text-align: center;">
                        <img src="/img/bekle.gif" alt="" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlMakineKategori" runat="server" DefaultButton="btnKaydet">
                <div class="row">
                    <div class="col">
                        <section class="card card-admin">
                            <header class="card-header">
                                <h2 class="card-title">
                                    <asp:Literal ID="ltlFormBaslik" runat="server" /></h2>
                            </header>
                            <div class="card-body">
                                <div class="form-horizontal form-bordered">
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Kod:</label>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="txtMakineKod" runat="server" CssClass="form-control" placeholder="Kod" ValidationGroup="makine" />
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtMakineKod" Display="Dynamic" SetFocusOnError="true" ValidationGroup="makine">
                                    <span class="alert-danger"><i class="fa fa-exclamation"></i> Boş geçemezsiniz</span>    
                                            </asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Başlık:</label>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="txtMakineBaslik" runat="server" CssClass="form-control" placeholder="Başlık" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Öncelik:</label>
                                        <div class="col-lg-6">
                                            <asp:TextBox ID="txtMakineOncelik" runat="server" CssClass="form-control" placeholder="Öncelik (0-9999)" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Sektörler:</label>
                                        <div class="col-lg-3">
                                            <asp:ListBox ID="lbSektorler" runat="server" CssClass="form-control" Rows="5" SelectionMode="Multiple" />
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Button ID="btnSektorEkle" runat="server" Text="Ekle" CssClass="btn btn-primary btn-xs mt-3" OnClick="btnSektorEkle_Click" />
                                            <asp:Button ID="btnSektorCikar" runat="server" Text="Çıkar" CssClass="btn btn-warning btn-xs mt-2" OnClick="btnSektorCikar_Click" />
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:ListBox ID="lbSeciliSektorler" runat="server" CssClass="form-control" Rows="5" SelectionMode="Multiple" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Kategoriler:</label>
                                        <div class="col-lg-3">
                                            <asp:ListBox ID="lbKategoriler" runat="server" CssClass="form-control" Rows="5" SelectionMode="Multiple" />
                                        </div>
                                        <div class="col-md-1">
                                            <asp:Button ID="btnKategoriEkle" runat="server" Text="Ekle" CssClass="btn btn-primary btn-xs mt-3" OnClick="btnKategoriEkle_Click" />
                                            <asp:Button ID="btnKategoriCikar" runat="server" Text="Çıkar" CssClass="btn btn-warning btn-xs mt-2" OnClick="btnKategoriCikar_Click" />
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:ListBox ID="lbSeciliKategoriler" runat="server" CssClass="form-control" Rows="5" SelectionMode="Multiple" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Fotoğraflar:</label>
                                        <div class="col-lg-6">
                                            <asp:Button ID="btnFotografUpload" runat="server" OnClick="btnFotografUpload_Click" Style="visibility: hidden; display: none;" Text="xxx" />
                                            <ajaxToolkit:AsyncFileUpload ID="fuMakineFotograf" ThrobberID="fotouploading" OnClientUploadComplete="btnFotografClick" OnUploadedComplete="fuMakineFotograf_UploadedComplete" runat="server" CssClass="background-color-white form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <asp:Repeater ID="rptMakineFotograflar" runat="server" OnItemCommand="rptMakineFotograflar_ItemCommand">
                                            <HeaderTemplate>
                                                <label class="col-lg-2 control-label text-lg-right pt-2"></label>
                                                <div class="col-lg-10">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="col-md-3 pull-left">
                                                    <asp:HyperLink ID="lbFotograf" runat="server" NavigateUrl='<%#Eval("Fotograf") %>' CssClass=" lightbox img-thumbnail d-inline-block" data-plugin-options="{'type':'image'}" ToolTip='<%#Eval("Fotograf") %>'>
                                                        <ny:MyImage ID="imgMakineFotograf" runat="server" CssClass="img-fluid" ImageUrl='<%#Eval("Fotograf") %>' MaxWidth="200" MaxHeight="200" />
                                                    </asp:HyperLink>
                                                    <asp:LinkButton ID="lbFotografSil" runat="server" ToolTip="Sil" CommandArgument='<%#Eval("Id") %>' CommandName="Sil" CssClass=" ml-1">
                                                      <i class="fas fa-trash-alt"></i>
                                                    </asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </div>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Açıklama:</label>
                                        <div class="col-lg-9">
                                            <CKEditor:CKEditorControl ID="ceMakineAciklama" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Detaylar:</label>
                                        <div class="col-lg-9">
                                            <CKEditor:CKEditorControl ID="ceMakineDetaylar" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                   <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Kullanıldığı Üretim Alanları:</label>
                                        <div class="col-lg-9">
                                            <CKEditor:CKEditorControl ID="ceMakineOzellikler" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Katalog:</label>
                                        <div class="col-lg-7" id="divKatalog" runat="server">
                                            <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Style="visibility: hidden; display: none;" Text="xxx" />
                                            <ajaxToolkit:AsyncFileUpload ID="fuMakineKatalog" ThrobberID="fotouploading" OnClientUploadComplete="btnClick" OnUploadedComplete="fu_UploadedComplete" runat="server" CssClass="background-color-white form-control" />
                                        </div>
                                        <div class="col-lg-1 mt-2" id="divKatalogGoster" runat="server" visible="false">
                                            <asp:HyperLink ID="hlKatalogGit" runat="server" CssClass="mr-2" Style="text-decoration: none !important;" Target="_blank" ToolTip="Göster">
                                        <i class="fas fa-external-link-alt"></i>
                                            </asp:HyperLink>
                                            <asp:LinkButton ID="lbKatalogSil" runat="server" ToolTip="Sil" OnClick="lbKatalogSil_Click">
                                            <i class="fas fa-trash-alt"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Video Link:</label>
                                        <div class="col-lg-7">
                                            <asp:TextBox ID="txtMakineVideo" runat="server" CssClass="form-control" placeholder="Video Link" />
                                            <span>Video görüntülensin istiyorsanız linki YouTube'dan kopyalayıp buraya yapıştırın!</span>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <label class="col-lg-2 control-label text-lg-right pt-2">Göster:</label>
                                        <div class="col-lg-2 mt-2">
                                            <asp:CheckBox ID="cbMakineGoster" runat="server" Checked="true" CssClass="input-group-lg" />
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-lg-9"></div>
                                        <div class="col-lg-3">
                                            <asp:HyperLink ID="hlVazgec" runat="server" Text="Vazgeç" CssClass="btn btn-warning btn-m" NavigateUrl="../admin/Makineler.aspx" />
                                            <asp:Button ID="btnKaydet" runat="server" Text="Kaydet" CssClass="btn btn-success btn-m" OnClick="btnKaydet_Click" ValidationGroup="makine" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </section>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

