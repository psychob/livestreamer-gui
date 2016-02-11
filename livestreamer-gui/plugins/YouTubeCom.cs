//
// livestreamer-gui
// (c) 2014 - 2016 Andrzej Budzanowski <psychob.pl@gmail.com>
//

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace livestreamer_gui.plugins
{
    class YouTubeCom : PluginAPI
    {
        string currentVideoId
        {
            get
            {
                return layoutTextBoxVideoId.Text.Trim();
            }

            set
            {
                layoutTextBoxVideoId.Text = value.Trim();
            }
        }

        TabPage layoutTabPage;
        Label layoutLabelVideoId;
        TextBox layoutTextBoxVideoId;
        InitData localInitData;

        public string GetPluginId()
        {
            return "youtube";
        }

        public StreamInfo GetVideoMedatada()
        {
            StreamInfo sinfo = new StreamInfo();

            try
            {
                // pobieramy informacje o video
                string yt_url = GetCanonicalUrl();
                string oembed = "http://www.youtube.com/oembed";

                {
                    var qstr = HttpUtility.ParseQueryString(string.Empty);
                    qstr["url"] = yt_url;
                    qstr["format"] = "xml";

                    oembed += "?" + qstr.ToString();
                }

                WebRequest wr = WebRequest.Create(oembed);
                WebResponse wre = wr.GetResponse();
                Stream data = wre.GetResponseStream();

                System.Xml.XmlDocument xmldoc = new System.Xml.XmlDocument();
                xmldoc.Load(data);
                data.Close();

                sinfo.Author = xmldoc.GetElementsByTagName("author_name")[0].InnerText;
                sinfo.Title = xmldoc.GetElementsByTagName("title")[0].InnerText;
                sinfo.CanonicalUrl = GetCanonicalUrl();
            }
            catch (Exception)
            {
                sinfo.Author = "Unknown author";
                sinfo.Title = "Unknown title";
                sinfo.CanonicalUrl = GetCanonicalUrl();
            }

            return sinfo;
        }

        public string GetCanonicalUrl()
        {
            return "http://www.youtube.com/watch?v=" + currentVideoId;
        }

        public void InitTab(InitData data)
        {
            localInitData = data;

            layoutTabPage = new TabPage("youtube.com");
            layoutLabelVideoId = new Label();
            layoutTextBoxVideoId = new TextBox();

            layoutLabelVideoId.Text = "Video ID:";
            layoutLabelVideoId.Location = new System.Drawing.Point(8, 9);
            layoutLabelVideoId.Size = new System.Drawing.Size(81, 20);

            layoutTextBoxVideoId.Location = new System.Drawing.Point(152, 6);
            layoutTextBoxVideoId.Size = new System.Drawing.Size(243, 20);
            layoutTextBoxVideoId.TextChanged += evenChanger;

            layoutTabPage.Controls.AddRange(
              new Control[]{ layoutLabelVideoId,
                   layoutTextBoxVideoId,
              });

            // dodwanie taba
            localInitData.Control.TabPages.Add(layoutTabPage);
        }

        private void evenChanger(object sender, EventArgs e)
        {
            localInitData.TabUpdated(GetPluginId());
        }

        public bool Owns(Uri url)
        {
            if (url.Host == "youtube.com" || url.Host == "www.youtube.com")
            {
                var urlq = HttpUtility.ParseQueryString(url.Query);
                currentVideoId = urlq["v"];
                return true;
            }
            else if (url.Host == "youtu.be")
            {
                currentVideoId = url.Segments[1];
                return true;
            }

            return false;
        }

        public void StreamStarted()
        {
        }

        public void ShutDown()
        {
        }

        public string[] GetCanonicalQuality()
        {
            return new string[]
            {
                "best",
                "1080p",
                "720p",
                "480p",
                "360p",
                "260p",
                "worst"
            };
        }
    }
}
