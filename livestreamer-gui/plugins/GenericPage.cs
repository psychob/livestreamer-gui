using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace livestreamer_gui.plugins
{
    class GenericPage : PluginAPI
    {
        string currentUrl
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

        public string[] GetCanonicalQuality()
        {
            return new string[]
            {
                "best",
                "worst",
            };
        }

        public string GetCanonicalUrl()
        {
            return currentUrl;
        }

        public string GetPluginId()
        {
            return "generic";
        }

        public StreamInfo GetVideoMedatada()
        {
            StreamInfo sinfo = new StreamInfo();

            sinfo.Author = currentUrl;
            sinfo.Title = currentUrl;

            return sinfo;
        }

        public void InitTab(InitData data)
        {
            localInitData = data;

            layoutTabPage = new TabPage("Generic Page");
            layoutLabelVideoId = new Label();
            layoutTextBoxVideoId = new TextBox();

            layoutLabelVideoId.Text = "Url:";
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
            currentUrl = url.ToString();
            return true;
        }

        public void ShutDown()
        {
        }

        public void StreamStarted()
        {
        }
    }
}
