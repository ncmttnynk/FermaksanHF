<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MP_Admin.master" AutoEventWireup="true" CodeFile="Kategoriler.aspx.cs" Inherits="admin_Kategoriler" %>

<%@ Register Src="../usercontrols/UC_Sayfalama.ascx" TagName="UC_Sayfalama" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_Sag" runat="Server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" CssClass="modal fade show" ID="pnlKayit" role="dialog" aria-labelledby="largeModalLabel" Style="display: none; padding-right: 17px;" DefaultButton="btnKayitKaydet">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="lblKayitBaslik" runat="server" /></h4>
                            <asp:LinkButton ID="btnKapatUst" runat="server" Text="x" CssClass="close" OnClick="btnKapatUst_Click" />
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-2">
                                    <blockquote class="blockquote-primary">
                                        <p>Kategori:</p>
                                    </blockquote>
                                </div>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtKayitBaslik" runat="server" CssClass="form-control" ValidationGroup="proje" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <blockquote class="blockquote-primary">
                                        <p>Öncelik:</p>
                                    </blockquote>
                                </div>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtKayitOncelik" runat="server" Text="1000" CssClass="form-control input-lg" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <blockquote class="blockquote-primary">
                                        <p>Göster:</p>
                                    </blockquote>
                                </div>
                                <div class="col-md-10 mt-3">
                                    <asp:CheckBox ID="cbKayitGoster" runat="server" Checked="true" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnKayitKaydet" CssClass="btn btn-success" Text="Kaydet" runat="server" OnClick="btnKayitKaydet_Click" />
                            <asp:Button ID="btnKayitKapat" CssClass="btn btn-danger" Text="Vazgeç" runat="server" OnClick="btnKayitKapat_Click" />

                        </div>
                    </div>
                </div>
            </asp:Panel>
            <asp:LinkButton ID="btnYeni" runat="server" CssClass="btn btn-success" OnClick="btnYeni_Click"><i class="fas fa-plus-square"></i> Yeni</asp:LinkButton>
            <uc1:UC_Sayfalama ID="UC_Sayfalama1" runat="server" ToplamGoster="true" ToplamMetin="{0} kayıt" />
            <asp:GridView ID="gvKayitlar" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered" GridLines="None" OnRowCommand="gvKayitlar_RowCommand" OnRowDataBound="gvKayitlar_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="İşlemler" HeaderStyle-Width="220" ItemStyle-Width="220" ItemStyle-CssClass="center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbSil" runat="server" Text="Sil" CssClass="btn btn-warning btn-xs" OnClientClick="return confirm('Emin misiniz?')" CommandName="Sil" CommandArgument='<%#Eval("Id") %>' />
                            <asp:LinkButton ID="lbGuncelle" runat="server" Text="Düzenle" CssClass="btn btn-primary btn-xs" CommandName="Guncelle" CommandArgument='<%#Eval("Id") %>' />
                            <asp:HyperLink ID="hlGit" runat="server" NavigateUrl='<%#string.Format("/{0}/Makineler/#{1}",Dil,Eval("Baslik").ToString().ToURL()) %>' ToolTip="Göster" Target="_blank"><i class="fa fa-link" aria-hidden="true"></i></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Başlık" DataField="Baslik" HeaderStyle-CssClass="center" ItemStyle-CssClass="center" HeaderStyle-Width="200" />
                    <asp:BoundField HeaderText="Öncelik" DataField="Oncelik" HeaderStyle-CssClass="center" ItemStyle-CssClass="center" HeaderStyle-Width="200" />
                    <asp:TemplateField HeaderText="Dil" HeaderStyle-Width="80" ItemStyle-Width="80" ItemStyle-CssClass="center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Literal ID="ltlDil" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Göster" HeaderStyle-Width="80" ItemStyle-Width="80" ItemStyle-CssClass="center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Literal ID="ltlGoster" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <uc1:UC_Sayfalama ID="UC_Sayfalama2" runat="server" ToplamGoster="true" ToplamMetin="{0} kayıt" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

