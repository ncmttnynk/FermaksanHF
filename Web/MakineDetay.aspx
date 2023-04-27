<%@ Page Title="" Language="C#" MasterPageFile="~/MP_TekSutun.master" AutoEventWireup="true" CodeFile="MakineDetay.aspx.cs" Inherits="MakineDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPH_TekCSS" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_TekSutun" runat="Server">
    <div class="container">
        <%--<div class="row mt-3">
            <div class="col">
                <div class="portfolio-title">
                    <div class="row">
                        <div class="portfolio-nav-all col-lg-1">
                            <asp:HyperLink ID="hlTumSol" runat="server"><i class="fas fa-th"></i></asp:HyperLink>
                        </div>
                        <div class="col-lg-10 text-center">
                            <h2 class="mb-0">
                                <asp:Literal ID="ltlMakineBaslik" runat="server" /></h2>
                        </div>
                        <div class="portfolio-nav col-lg-1">
                            <asp:HyperLink ID="hlTumSag" runat="server"><i class="fas fa-th"></i></asp:HyperLink>
                        </div>
                    </div>
                </div>
                <hr class="tall">
            </div>
        </div>--%>
        <div class="row mt-5">
            <div class="col-lg-6">
                <asp:Repeater ID="rptMakineFotograf" runat="server">
                    <HeaderTemplate>
                        <div class="owl-carousel owl-theme show-nav-hover" data-plugin-options="{'items': 1, 'autoHeight': true, 'nav': true, 'dots':false, 'autoplay':true, 'autoplayTimeout':3000}">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div>
                            <div class="thumbnail">
                                <%--<ny:MyImage ID="img" runat="server" ImageUrl='<%#Eval("Fotograf") %>' AlternateText='<%#string.Format("{0} - {1}",Eval("Baslik"),Eval("Kod")) %>' ToolTip='<%#string.Format("{0} - {1}",Eval("Baslik"),Eval("Kod")) %>' MaxHeight="1000" CssClass="img-fluid" Quality="100" Scaled="false" Thumbnail="false" EmptyImageUrl="/img/projects/project-short.jpg" />--%>
                                <asp:Image ID="img" runat="server" ImageUrl='<%#Eval("Fotograf") %>' AlternateText='<%#string.Format("{0} - {1}",Eval("Baslik"),Eval("Kod")) %>' ToolTip='<%#string.Format("{0} - {1}",Eval("Baslik"),Eval("Kod")) %>' CssClass="img-thumbnail" />
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </div>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="col-lg-6">
                <div class="summary entry-summary">
                    <h3 class="mb-3" style="text-transform: none !important;"><strong>
                        <asp:Literal ID="ltlMakineBaslik" runat="server" /></strong></h3>
                    <div class="review_num">
                        <span class="count" itemprop="ratingCount"></span>
                    </div>
                    <asp:Literal ID="ltlAciklama" runat="server" />
                    <asp:Literal ID="ltlMakineKod" runat="server" />
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="tabs tabs-bottom tabs-center tabs-simple">
                    <ul class="nav nav-tabs">
                        <%--<li class="nav-item active">
                                        <a class="nav-link show active" href="#tabsNavigationSimpleIcons1" data-toggle="tab">
                                            <span class="featured-boxes featured-boxes-style-6 p-0 m-0">
                                                <span class="featured-box featured-box-primary featured-box-effect-6 p-0 m-0" style="height: 100px;">
                                                    <span class="box-content p-0 m-0">
                                                        <i class="icon-featured fas fa-info"></i>
                                                    </span>
                                                </span>
                                            </span>
                                            <p class="mb-0 pb-0"><% if (Dil.Equals("tr")) Response.Write("Açıklama"); else Response.Write("Information"); %></p>
                                        </a>
                                    </li>--%>
                        <li class="nav-item active">
                            <a class="nav-link" href="#tabsNavigationSimpleIcons2" data-toggle="tab">
                                <span class="featured-boxes featured-boxes-style-6 p-0 m-0">
                                    <span class="featured-box featured-box-primary featured-box-effect-6 p-0 m-0" style="height: 100px;">
                                        <span class="box-content p-0 m-0">
                                            <i class="icon-featured fas fa-clipboard"></i>
                                        </span>
                                    </span>
                                </span>
                                <p class="mb-0 pb-0"><% if (Dil.Equals("tr")) Response.Write("Detaylar"); else Response.Write("Detail"); %></p>
                            </a>
                        </li>
                            <li class="nav-item" id="pnlKullanildigi" runat="server" Visible="false">
                                <a class="nav-link" href="#divKullanildigi" data-toggle="tab">
                                    <span class="featured-boxes featured-boxes-style-6 p-0 m-0">
                                        <span class="featured-box featured-box-primary featured-box-effect-6 p-0 m-0" style="height: 100px;">
                                            <span class="box-content p-0 m-0">
                                                <i class="icon-featured fas fa-eye"></i>
                                            </span>
                                        </span>
                                    </span>
                                    <p class="mb-0 pb-0"><% if (Dil.Equals("tr")) Response.Write("Kullanıldığı Üretim Alanları"); else Response.Write("Manufacturing Fields in Which it is Used"); %></p>
                                </a>
                            </li>
                        <li class="nav-item" id="liVideo" runat="server" visible="false">
                            <a class="nav-link" href="#divVideo" data-toggle="tab">
                                <span class="featured-boxes featured-boxes-style-6 p-0 m-0">
                                    <span class="featured-box featured-box-primary featured-box-effect-6 p-0 m-0" style="height: 100px;">
                                        <span class="box-content p-0 m-0">
                                            <i class="icon-featured fab fa-youtube"></i>
                                        </span>
                                    </span>
                                </span>
                                <p class="mb-0 pb-0">Video</p>
                            </a>
                        </li>
                        <li class="nav-item" id="liKatalog" runat="server" visible="false">
                            <asp:HyperLink ID="hlKatalog" runat="server" CssClass="nav-link" Target="_blank">
                                <span class="featured-boxes featured-boxes-style-6 p-0 m-0">
                                    <span class="featured-box featured-box-primary featured-box-effect-6 p-0 m-0" style="height: 100px;">
                                        <span class="box-content p-0 m-0">
                                            <i class="icon-featured fas fa-file-pdf"></i>
                                        </span>
                                    </span>
                                </span>
                                <p class="mb-0 pb-0"><% if (Dil.Equals("tr")) Response.Write("Katalog"); else Response.Write("Catalog"); %></p>
                            </asp:HyperLink>
                        </li>
                    </ul>
                    <div class="tab-content">
                        <%--  <div class="tab-pane active show" id="tabsNavigationSimpleIcons1">
                                        <div class="text-center">
                                            <h4><% if (Dil.Equals("tr")) Response.Write("Açıklama"); else Response.Write("Information"); %></h4>
                                            <asp:Literal ID="ltlAciklama" runat="server" />
                                        </div>
                                    </div>--%>
                        <div class="tab-pane active show" id="tabsNavigationSimpleIcons2">
                            <div class="text-center">
                                <asp:Literal ID="ltlDetay" runat="server" />
                            </div>
                        </div>
                        <div class="tab-pane" id="divKullanildigi">
                            <div class="text-center">
                                <asp:Literal ID="ltlOzellik" runat="server" />
                            </div>
                        </div>
                        <div class="tab-pane" id="divVideo">
                            <div class="row" id="divVideoContainer" runat="server" visible="false">
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <div class="embed-responsive embed-responsive-4by3 mb-none">
                                        <iframe id="video" runat="server" frameborder="0" allowfullscreen></iframe>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--  <div class="row">
            <div class="col">
                <div class="tabs tabs-product">
                    <ul class="nav nav-tabs">
                        <li class="nav-item active"><a class="nav-link" href="#productDescription" data-toggle="tab">Description</a></li>
                        <li class="nav-item"><a class="nav-link" href="#productInfo" data-toggle="tab">Aditional Information</a></li>
                        <li class="nav-item"><a class="nav-link" href="#productReviews" data-toggle="tab">Reviews (2)</a></li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="productDescription">
                            <p>Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce sagittis, massa fringilla consequat blandit, mauris ligula porta nisi, non tristique enim sapien vel nisl. Suspendisse vestibulum lobortis dapibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Praesent nec tempus nibh. Donec mollis commodo metus et fringilla. Etiam venenatis, diam id adipiscing convallis, nisi eros lobortis tellus, feugiat adipiscing ante ante sit amet dolor. Vestibulum vehicula scelerisque facilisis. Sed faucibus placerat bibendum. Maecenas sollicitudin commodo justo, quis hendrerit leo consequat ac. Proin sit amet risus sapien, eget interdum dui. Proin justo sapien, varius sit amet hendrerit id, egestas quis mauris.</p>
                        </div>
                        <div class="tab-pane" id="productInfo">
                            <table class="table table-striped mt-5">
                                <tbody>
                                    <tr>
                                        <th>Size:
                                        </th>
                                        <td>Unique
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Colors
                                        </th>
                                        <td>Red, Blue
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Material
                                        </th>
                                        <td>100% Leather
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="tab-pane" id="productReviews">
                            <ul class="comments">
                                <li>
                                    <div class="comment">
                                        <div class="img-thumbnail d-block">
                                            <img class="avatar" alt="" src="/img/avatars/avatar-2.jpg">
                                        </div>
                                        <div class="comment-block">
                                            <div class="comment-arrow"></div>
                                            <span class="comment-by">
                                                <strong>John Doe</strong>
                                                <span class="float-right">
                                                    <div title="Rated 5.00 out of 5" class="star-rating">
                                                        <span style="width: 100%"><strong class="rating">5.00</strong> out of 5</span>
                                                    </div>
                                                </span>
                                            </span>
                                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae, gravida pellentesque urna varius vitae. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam viverra euismod odio, gravida pellentesque urna varius vitae. Sed dui lorem, adipiscing in adipiscing et, interdum nec metus. Mauris ultricies, justo eu convallis placerat, felis enim ornare nisi, vitae mattis nulla ante id dui.</p>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                            <hr class="tall">
                            <h4 class="heading-primary">Add a review</h4>
                            <div class="row">
                                <div class="col">
                                    <div class="form-row">
                                        <div class="form-group col-lg-6">
                                            <label>Your name *</label>
                                            <input type="text" value="" data-msg-required="Please enter your name." maxlength="100" class="form-control" name="name" id="name">
                                        </div>
                                        <div class="form-group col-lg-6">
                                            <label>Your email address *</label>
                                            <input type="email" value="" data-msg-required="Please enter your email address." data-msg-email="Please enter a valid email address." maxlength="100" class="form-control" name="email" id="email">
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col">
                                            <label>Review *</label>
                                            <textarea maxlength="5000" data-msg-required="Please enter your message." rows="10" class="form-control" name="message" id="message"></textarea>
                                        </div>
                                    </div>
                                    <div class="form-row">
                                        <div class="form-group col">
                                            <input type="submit" value="Submit Review" class="btn btn-primary" data-loading-text="Loading...">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <hr class="tall">
                <h4 class="mb-3 text-uppercase">Related <strong>Products</strong></h4>
                <div class="row products product-thumb-info-list mt-4 pt-2">
                    <div class="col-sm-6 col-lg-3 product">
                        <a href="shop-product-sidebar.html">
                            <span class="onsale">Sale!</span>
                        </a>
                        <span class="product-thumb-info">
                            <a href="shop-cart.html" class="add-to-cart-product">
                                <span><i class="fas fa-shopping-cart"></i>Add to Cart</span>
                            </a>
                            <a href="shop-product-sidebar.html">
                                <span class="product-thumb-info-image">
                                    <span class="product-thumb-info-act">
                                        <span class="product-thumb-info-act-left"><em>View</em></span>
                                        <span class="product-thumb-info-act-right"><em><i class="fas fa-plus"></i>Details</em></span>
                                    </span>
                                    <img alt="" class="img-fluid" src="/img/products/product-1.jpg">
                                </span>
                            </a>
                            <span class="product-thumb-info-content">
                                <a href="shop-product-sidebar.html">
                                    <h4>Photo Camera</h4>
                                    <span class="price">
                                        <del><span class="amount">$325</span></del>
                                        <ins><span class="amount">$299</span></ins>
                                    </span>
                                </a>
                            </span>
                        </span>
                    </div>
                    <div class="col-sm-6 col-lg-3 product">
                        <span class="product-thumb-info">
                            <a href="shop-cart.html" class="add-to-cart-product">
                                <span><i class="fas fa-shopping-cart"></i>Add to Cart</span>
                            </a>
                            <a href="shop-product-sidebar.html">
                                <span class="product-thumb-info-image">
                                    <span class="product-thumb-info-act">
                                        <span class="product-thumb-info-act-left"><em>View</em></span>
                                        <span class="product-thumb-info-act-right"><em><i class="fas fa-plus"></i>Details</em></span>
                                    </span>
                                    <img alt="" class="img-fluid" src="/img/products/product-2.jpg">
                                </span>
                            </a>
                            <span class="product-thumb-info-content">
                                <a href="shop-product-sidebar.html">
                                    <h4>Golf Bag</h4>
                                    <span class="price">
                                        <span class="amount">$72</span>
                                    </span>
                                </a>
                            </span>
                        </span>
                    </div>
                    <div class="col-sm-6 col-lg-3 product">
                        <span class="product-thumb-info">
                            <a href="shop-cart.html" class="add-to-cart-product">
                                <span><i class="fas fa-shopping-cart"></i>Add to Cart</span>
                            </a>
                            <a href="shop-product-sidebar.html">
                                <span class="product-thumb-info-image">
                                    <span class="product-thumb-info-act">
                                        <span class="product-thumb-info-act-left"><em>View</em></span>
                                        <span class="product-thumb-info-act-right"><em><i class="fas fa-plus"></i>Details</em></span>
                                    </span>
                                    <img alt="" class="img-fluid" src="/img/products/product-3.jpg">
                                </span>
                            </a>
                            <span class="product-thumb-info-content">
                                <a href="shop-product-sidebar.html">
                                    <h4>Workout</h4>
                                    <span class="price">
                                        <span class="amount">$60</span>
                                    </span>
                                </a>
                            </span>
                        </span>
                    </div>
                    <div class="col-sm-6 col-lg-3 product">
                        <span class="product-thumb-info">
                            <a href="shop-cart.html" class="add-to-cart-product">
                                <span><i class="fas fa-shopping-cart"></i>Add to Cart</span>
                            </a>
                            <a href="shop-product-sidebar.html">
                                <span class="product-thumb-info-image">
                                    <span class="product-thumb-info-act">
                                        <span class="product-thumb-info-act-left"><em>View</em></span>
                                        <span class="product-thumb-info-act-right"><em><i class="fas fa-plus"></i>Details</em></span>
                                    </span>
                                    <img alt="" class="img-fluid" src="/img/products/product-4.jpg">
                                </span>
                            </a>
                            <span class="product-thumb-info-content">
                                <a href="shop-product-sidebar.html">
                                    <h4>Luxury bag</h4>
                                    <span class="price">
                                        <span class="amount">$199</span>
                                    </span>
                                </a>
                            </span>
                        </span>
                    </div>
                </div>
            </div>
        </div>--%>
    </div>
    <asp:Panel ID="pnlIlgılı" runat="server" Visible="false">
        <div class="container">
            <div class="row">
                <div class="col">
                    <hr class="tall mt-4">
                    <h4 class="mb-3">
                        <asp:Literal ID="ltlAltBaslik" runat="server" /></h4>
                    <asp:Repeater ID="rptIlgiliMakineler" runat="server">
                        <HeaderTemplate>
                            <div class="row">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="col-12 col-sm-6 col-lg-3 mb-4">
                                <div class="portfolio-item">
                                    <a href='<%#string.Format("/"+Dil+"/MakineDetay/{0}/{1}/{2}",Eval("Id"),Eval("Baslik").ToString().ToURL(),Eval("Kod").ToString().ToURL()) %>'>
                                        <span class="thumb-info thumb-info-lighten">
                                            <span class="thumb-info-wrapper">
                                                <asp:Image ID="img" runat="server" ImageUrl='<%#Eval("Fotograf") %>' AlternateText='<%#string.Format("{0} - {1}",Eval("Baslik"),Eval("Kod")) %>' ToolTip='<%#string.Format("{0} - {1}",Eval("Baslik"),Eval("Kod")) %>' CssClass="img-fluid" />
                                                <span class="thumb-info-title">
                                                    <span class="thumb-info-inner" style="text-transform: none !important;"><%#Eval("Baslik") %></span>
                                                    <span class="thumb-info-type"><%#Eval("Kod") %></span>
                                                </span>
                                                <span class="thumb-info-action">
                                                    <span class="thumb-info-action-icon"><i class="fas fa-link"></i></span>
                                                </span>
                                            </span>
                                        </span></a>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </asp:Panel>
    <%--<div class="container">
        <div class="row pb-4">
            <div class="col">
                <div class="row justify-content-center mt-4">
                    <div class="col-lg-4 mx-auto">
                        <div class="thumb-gallery">
                            <div class="owl-carousel owl-theme manual thumb-gallery-detail show-nav-hover owl-loaded owl-drag" id="thumbGalleryDetail">
                                <div class="owl-stage-outer">
                                    <div class="owl-stage" style="transform: translate3d(0px, 0px, 0px); transition: 0s; width: 2520px;">
                                        <div class="owl-item active" style="width: 350px; margin-right: 10px;">
                                            <div>
                                                <span class="img-thumbnail d-block">
                                                    <img alt="Project Image" src="/img//projects/project.jpg" class="img-fluid">
                                                </span>
                                            </div>
                                        </div>
                                   
                                    </div>
                                </div>
                                <div class="owl-nav">
                                    <button type="button" role="presentation" class="owl-prev disabled"></button>
                                    <button type="button" role="presentation" class="owl-next"></button>
                                </div>
                                <div class="owl-dots disabled"></div>
                            </div>
                            <div class="owl-carousel owl-theme manual thumb-gallery-thumbs mt owl-loaded owl-drag" id="thumbGalleryThumbs">
                                <div class="owl-stage-outer">
                                    <div class="owl-stage" style="transform: translate3d(0px, 0px, 0px); transition: 0s; width: 639px;">
                                        <div class="owl-item active" style="width: 76.25px; margin-right: 15px;">
                                            <div>
                                                <span class="img-thumbnail d-block cur-pointer">
                                                    <img alt="Project Image" src="/img//projects/project.jpg" class="img-fluid">
                                                </span>
                                            </div>
                                        </div>
                                        <div class="owl-item active" style="width: 76.25px; margin-right: 15px;">
                                            <div>
                                                <span class="img-thumbnail d-block cur-pointer">
                                                    <img alt="Project Image" src="/img//projects/project-2.jpg" class="img-fluid">
                                                </span>
                                            </div>
                                        </div>
                                        <div class="owl-item active" style="width: 76.25px; margin-right: 15px;">
                                            <div>
                                                <span class="img-thumbnail d-block cur-pointer">
                                                    <img alt="Project Image" src="/img//projects/project-4.jpg" class="img-fluid">
                                                </span>
                                            </div>
                                        </div>
                                        <div class="owl-item active" style="width: 76.25px; margin-right: 15px;">
                                            <div>
                                                <span class="img-thumbnail d-block cur-pointer">
                                                    <img alt="Project Image" src="/img//projects/project-5.jpg" class="img-fluid">
                                                </span>
                                            </div>
                                        </div>
                                        <div class="owl-item" style="width: 76.25px; margin-right: 15px;">
                                            <div>
                                                <span class="img-thumbnail d-block cur-pointer">
                                                    <img alt="Project Image" src="/img//projects/project-6.jpg" class="img-fluid">
                                                </span>
                                            </div>
                                        </div>
                                        <div class="owl-item" style="width: 76.25px; margin-right: 15px;">
                                            <div>
                                                <span class="img-thumbnail d-block cur-pointer">
                                                    <img alt="Project Image" src="/img//projects/project-2.jpg" class="img-fluid">
                                                </span>
                                            </div>
                                        </div>
                                        <div class="owl-item" style="width: 76.25px; margin-right: 15px;">
                                            <div>
                                                <span class="img-thumbnail d-block cur-pointer">
                                                    <img alt="Project Image" src="/img//projects/project-4.jpg" class="img-fluid">
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="owl-nav disabled">
                                    <button type="button" role="presentation" class="owl-prev"><span aria-label="Previous">‹</span></button>
                                    <button type="button" role="presentation" class="owl-next"><span aria-label="Next">›</span></button></div>
                                <div class="owl-dots disabled"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div> Belki version 2'de kullanılır--%>
</asp:Content>

