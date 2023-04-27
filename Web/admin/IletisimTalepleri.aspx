<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MP_Admin.master" AutoEventWireup="true" CodeFile="IletisimTalepleri.aspx.cs" Inherits="admin_IletisimTalepleri" %>

<%@ Register Src="../usercontrols/UC_Sayfalama.ascx" TagName="UC_Sayfalama" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_Sag" runat="Server">
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" CssClass="modal fade show" ID="pnlKayit" role="dialog" aria-labelledby="largeModalLabel" Style="display: none; height: auto; padding-right: 17px; overflow: scroll;" DefaultButton="btnServisCevapla">
                <div class="modal-dialog modal-lg">
                    <div class="modal-content" style="height: auto;">
                        <div class="modal-header">
                            <h4 class="modal-title">
                                <asp:Literal ID="lblKayitBaslik" runat="server" /></h4>
                            <asp:LinkButton ID="btnKapatUst" runat="server" Text="x" CssClass="close" OnClick="btnKapatUst_Click" />
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <blockquote class="blockquote-primary">
                                        <asp:Literal ID="ltlServisAdSoyad" runat="server" />
                                    </blockquote>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <blockquote class="blockquote-primary">
                                        <asp:Literal ID="ltlServisEposta" runat="server" />
                                    </blockquote>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <blockquote class="blockquote-primary">
                                        <asp:Literal ID="ltlServisTarih" runat="server" />
                                    </blockquote>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <blockquote class="blockquote-primary">
                                        <asp:Literal ID="ltlServisAciklama" runat="server" />
                                    </blockquote>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <blockquote class="blockquote-primary">
                                        <CKEditor:CKEditorControl ID="ceServisCevap" runat="server" />
                                    </blockquote>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="btnServisCevapla" CssClass="btn btn-success" Text="Cevapla" runat="server" OnClick="btnServisCevapla_Click"/>
                            <asp:Button ID="btnKayitKapat" CssClass="btn btn-danger" Text="Vazgeç" runat="server" OnClick="btnKayitKapat_Click" />

                        </div>
                    </div>
                </div>
            </asp:Panel>
            <uc1:UC_Sayfalama ID="UC_Sayfalama1" runat="server" ToplamGoster="true" ToplamMetin="{0} kayıt" />
            <asp:GridView ID="gvKayitlar" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-bordered" GridLines="None" OnRowCommand="gvKayitlar_RowCommand" OnRowDataBound="gvKayitlar_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="Ad Soyad" DataField="AdSoyad" HeaderStyle-CssClass="center" ItemStyle-CssClass="center" HeaderStyle-Width="200" />
                    <asp:BoundField HeaderText="E-Posta" DataField="Eposta" HeaderStyle-CssClass="center" ItemStyle-CssClass="center" HeaderStyle-Width="200" />
                    <asp:BoundField HeaderText="Açıklama" DataField="Aciklama" HeaderStyle-CssClass="center" ItemStyle-CssClass="center" HeaderStyle-Width="200" />
                    <asp:BoundField HeaderText="Tarih" DataField="Tarih" HeaderStyle-CssClass="center" ItemStyle-CssClass="center" HeaderStyle-Width="200" />
                    <asp:TemplateField HeaderText="Dil" HeaderStyle-Width="80" ItemStyle-Width="80" ItemStyle-CssClass="center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Literal ID="ltlDil" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cevaplandı" HeaderStyle-Width="80" ItemStyle-Width="80" ItemStyle-CssClass="center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:Literal ID="ltlCevaplandi" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="" HeaderStyle-Width="220" ItemStyle-Width="220" ItemStyle-CssClass="center" HeaderStyle-CssClass="center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbCevapla" runat="server" Text="Cevapla" CssClass="btn btn-primary btn-xs" CommandName="Cevapla" CommandArgument='<%#Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>


