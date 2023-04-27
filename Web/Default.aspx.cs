using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DA.MetaTagGenerator;

public partial class _Default : IPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        base.MP_Main.Buradasiniz = new List<Info.BuradasinizInfo>
             {
                 new Info.BuradasinizInfo {Title=(Dil.Equals("tr") ? "Anasayfa" : "Home") ,Url="/"}
             };
        base.MP_Main.Title = (Dil.Equals("tr") ? "Anasayfa" : "Home");
        base.MP_Main.H1 = (Dil.Equals("tr") ? "Anasayfa" : "Home");
        DateTime date = new DateTime(2010, 4, 7);
        MetaTagGenerator gen = MetaTagGenerator.CreateInstance(this);
        //gen.FBMetaTags = new Tags.FBTagsInfo
        //{
        //    AdminId = 12345,
        //    AdminIds = new long[] { 12345, 67890 },
        //    AppId = 12345,
        //    Pages = new long[] { 12345, 67890 },
        //    ProfileId = 12345
        //};
        //gen.MetaTags = new Tags.MetaTagsInfo
        //{
        //    Abstract = "xxx",
        //    Author = "xxx",
        //    Category = "xxx",
        //    Charset = Constants.UTF8,
        //    Classification = "xxx",
        //    ContentType = Constants.UTF8_httpeqiv,
        //    Copyright = "xxx",
        //    CopyrightUrl = "http://example.com/copyright.html",
        //    Coverage = "xxx",
        //    Date = date.ToISO8601DateString(),
        //    Description = "xxx",
        //    Designer = "xxx",
        //    Directory = "xxx",
        //    Distribution = "xxx",
        //    Generator = "xxx",
        //    HandheldFriendly = HandheldFriendlyTypes.True,
        //    IdentifierUrl = "xxx.html",
        //    //KeywordArray=new string["keyword1","keyword2"],
        //    Keywords = "keywords1, keywords2",
        //    Language = "en",
        //    Medium = "xxx",
        //    MobileOptimized = "320",
        //    OriginalSource = "xxx",
        //    Owner = "xxx",
        //    PageKey = "xxx",
        //    PageName = "xxx",
        //    Rating = "xxx",
        //    //Refresh="",
        //    ReplyTo = "xxx@example.com",
        //    RevisitAfter = "7 days",
        //    SearchDate = date.ToISO8601DateString(),
        //    Robots = RobotsTypes.INDEX | RobotsTypes.NOFOLLOW,
        //    Subject = "xxx",
        //    Subtitle = "xxx",
        //    Summary = "xxx",
        //    SyndicationSource = "http://example.com/copyright.html",
        //    //Target="",
        //    Title = (DilKod == 1) ? "Anasayfa" : "Home",
        //    Topic = "xxx",
        //    Url = "http://example.com/example.aspx"
        //};
        //gen.MetaTags.LinkTags.Add(new Tags.LinkTagInfo
        //{
        //    Rel = LinkTagDefs.Alternate,
        //    Type = FileTypeDefs.Atom,
        //    Href = "example.html",
        //    Title = "title"
        //});
        //gen.MetaTags.LinkTags.Add(new Tags.LinkTagInfo
        //{
        //    Rel = LinkTagDefs.Favicon,
        //    Type = FileTypeDefs.Image_ico,
        //    Href = "/favicon.ico"
        //});
        //gen.OGMetaTags = new Tags.OGTagsInfo
        //{
        //    AlternateLocales = new string[] { "fr", "jp" },
        //    ArticleInfo = new Tags.OGArticleInfo
        //    {
        //        Authors = new Tags.OGProfileInfo[] { new Tags.OGProfileInfo { FirstName = "Devrim", LastName = "Altınkurt", Gender = GenderTypes.Male, Username = "daltinkurt" } },
        //        ExpirationTime = date.ToISO8601DateString(),
        //        ModifiedTime = date.ToISO8601DateString(),
        //        PublishedTime = date.ToISO8601DateString(),
        //        Section = "xxx",
        //        Tags = new string[] { "tag1", "tag2" }
        //    },
        //    Description = "xxx",
        //    Url = "xxx.html",
        //    Type = OGTypes.Article,
        //    Title = "title",
        //    Site_Name = "daltinkurt",
        //    Locale = "en",
        //    //AudioInfo=
        //    //ImageInfo=
        //    //VideoInfo=
        //};
        //gen.TwitterTags = new Tags.TwitterCardInfo
        //{
        //    Card = TwitterCardTypes.App,
        //    Site = "twitter",
        //    Description = "Cannonball is the fun way to create and share stories and poems on your phone.",
        //    App = new Tags.TwitterAppInfo
        //    {
        //        Country = "US",
        //        GooglePlayId = "io.fabric.samples.cannonball",
        //        GooglePlayName = "Cannonball",
        //        GooglePlayUrl = "http://cannonball.fabric.io/poem/5149e249222f9e600a7540ef",
        //        IpadId = "929750075",
        //        IpadName = "Cannonball",
        //        IpadUrl = "cannonball://poem/5149e249222f9e600a7540ef",
        //        IphoneId = "929750075",
        //        IphoneName = "Cannonball",
        //        IphoneUrl = "cannonball://poem/5149e249222f9e600a7540ef"
        //    }
        //};
        //gen.RichSnippetsTags.Article = new Tags.RichSnippetArticleInfo
        //{
        //    Author = "Devrim Altınkurt",
        //    DateModified = date.ToISO8601DateString(),
        //    DatePublished = date.ToISO8601DateString(),
        //    Decription = "Meta Generator for ASP.NET Description",
        //    Image = new Tags.RichSnippetImageInfo
        //    {
        //        Height = 148,
        //        Url = "http://metataggenerator.daltinkurt.com/assets/img/logo-main.png",
        //        Width = 150
        //    },
        //    Publisher = "Devrim Altınkurt",
        //    PublisherLogo = new Tags.RichSnippetImageInfo
        //    {
        //        Height = 148,
        //        Url = "http://metataggenerator.daltinkurt.com/assets/img/logo-main.png",
        //        Width = 150
        //    },
        //    Title = "Meta Generator for ASP.NET",
        //    Url = "http://metataggenerator.daltinkurt.com"
        //};
        //gen.GenerateTags();
        if (!IsPostBack)
        {
            SabitlerDB sDB = new SabitlerDB();
            ltlGirisUst.Text = (DilKod == 1) ? sDB.TurkceIcerikGetir(Enums.Sabitler.GirisUstAciklama) : sDB.IngilizceIcerikGetir(Enums.Sabitler.GirisUstAciklama);
            ltlGirisOrta.Text = (DilKod == 1) ? sDB.TurkceIcerikGetir(Enums.Sabitler.GirisOrtaAciklama) : sDB.IngilizceIcerikGetir(Enums.Sabitler.GirisOrtaAciklama);
            ltlGirisAlt.Text = (DilKod == 1) ? sDB.TurkceIcerikGetir(Enums.Sabitler.GirisAltAciklama) : sDB.IngilizceIcerikGetir(Enums.Sabitler.GirisAltAciklama);
            ltlAltMesaj.Text = (DilKod == 1) ? @"
                        En ileri teknolojileri kullanarak geliştirdiğimiz <em>makineler</em>
                        <span>işinize kalite katacaktır!</span>" : @"
                        Machines which we developed using the most advanced technologies <em>will add</em>
                        <span>quality to your business!</span>";
        }
    }
}