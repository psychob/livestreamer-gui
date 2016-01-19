//
// livestreamer-gui
// (c) 2016 Andrzej Budzanowski <psychob.pl@gmail.com>
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace livestreamer_gui.gui
{
    public partial class MainWindow : Form
    {
        ConfigurationDatabase cfgDatabase = new ConfigurationDatabase();
        PluginAPI[] apis;
        string currentPlugin;
        List<ConfigurationDatabase.AutocompleteData> ad;

        public MainWindow()
        {
            InitializeComponent();

            cfgDatabase.LoadConfiguration("./livestreamer-v3.xml");

            apis = new PluginAPI[]
            {
                new plugins.TwitchTv(),
                new plugins.YouTubeCom(),
                new plugins.GenericDotCom(),
            };

            foreach ( var it in apis )
            {
                InitData id = new InitData();

                id.Config = new ConfigurationDatabaseProxy(cfgDatabase,
                    it.GetPluginId());
                id.Control = tabControl1;
                id.RunLiveStreamer = apiRunLiveStreamer;
                id.TabUpdated = apiUpdatedTab;

                it.InitTab(id);
            }

            ad = cfgDatabase.GetAutocomplete(ConfigurationConstants.Autocomplete);

            if (ad == null)
                ad = new List<ConfigurationDatabase.AutocompleteData>();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            tbLivestreamerPath.Text = cfgDatabase.GetString(ConfigurationConstants.LivestreamerPath);
            cbLogLevel.SelectedIndex = cfgDatabase.GetInt(ConfigurationConstants.LivestreamerLogLevel, -1);
            tbPlayerPath.Text = cfgDatabase.GetString(ConfigurationConstants.PlayerPath);

            cbxRetryStream.Checked = cfgDatabase.GetBoolean(ConfigurationConstants.RetryStream);
            nudRetryAttempts.Value = Convert.ToDecimal(cfgDatabase.GetInt(ConfigurationConstants.RetryStreamAttempts, 1));
            nudRetryDelay.Value = Convert.ToDecimal(cfgDatabase.GetInt(ConfigurationConstants.RetryStreamDelay, 1));

            cbxHideConsole.Checked = cfgDatabase.GetBoolean(ConfigurationConstants.LivestreamerHideConsole);
            cbxVlcMetadata.Checked = cfgDatabase.GetBoolean(ConfigurationConstants.PlayerGenerateVLCMetadata);
            cbxAllowInternetApiAccess.Checked = cfgDatabase.GetBoolean(ConfigurationConstants.ApiInternetAccess);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            // zapisujemy dane
            cfgDatabase.SetString(ConfigurationConstants.LivestreamerPath,
                tbLivestreamerPath.Text);
            cfgDatabase.SetInt(ConfigurationConstants.LivestreamerLogLevel,
                cbLogLevel.SelectedIndex);
            cfgDatabase.SetString(ConfigurationConstants.PlayerPath,
                tbPlayerPath.Text);

            cfgDatabase.SetBoolean(ConfigurationConstants.RetryStream,
                cbxRetryStream.Checked);
            cfgDatabase.SetInt(ConfigurationConstants.RetryStreamAttempts,
                Convert.ToInt32(nudRetryAttempts.Value));
            cfgDatabase.SetInt(ConfigurationConstants.RetryStreamDelay,
                Convert.ToInt32(nudRetryDelay.Value));

            cfgDatabase.SetBoolean(ConfigurationConstants.LivestreamerHideConsole,
                cbxHideConsole.Checked);
            cfgDatabase.SetBoolean(ConfigurationConstants.PlayerGenerateVLCMetadata,
                cbxVlcMetadata.Checked);
            cfgDatabase.SetBoolean(ConfigurationConstants.ApiInternetAccess,
                cbxAllowInternetApiAccess.Checked);

            foreach (var it in apis)
                it.ShutDown();

            cfgDatabase.SetAutocomplete(ConfigurationConstants.Autocomplete, ad);

            cfgDatabase.SaveConfiguration("./livestreamer-v3.xml");
        }

        private void apiRunLiveStreamer()
        {
            PluginAPI current = GetCurrentPlugin();

            if (!Uri.IsWellFormedUriString(tbOutputUrl.Text, UriKind.Absolute))
                return;

            if (tbLivestreamerPath.Text == string.Empty)
            {
                MessageBox.Show("Livestreamer path is not set");
                return;
            }

            if (current == null)
                return;

            var metadata = current.GetVideoMedatada();

            current.StreamStarted();

            int io = ad.FindIndex(p => p.url == metadata.CanonicalUrl);

            if (io == -1)
                ad.Add(new ConfigurationDatabase.AutocompleteData(metadata.CanonicalUrl));
            else
            {
                var tmp = ad[io];
                ad[io] = new ConfigurationDatabase.AutocompleteData(tmp.url, tmp.count + 1);
            }

            tbInputUrl.AutoCompleteCustomSource.Clear();
            tbInputUrl.AutoCompleteCustomSource.AddRange(ad.Rewrite(r => r.url));
        }

        private void apiUpdatedTab(string id)
        {
            currentPlugin = id;

            tbOutputUrl.Text = GetCurrentPlugin().GetCanonicalUrl();
        }

        private PluginAPI GetCurrentPlugin()
        {
            foreach (var it in apis)
                if (it.GetPluginId() == currentPlugin)
                    return it;

            return null;
        }

        private void btnChooseLivestreamerPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.CheckFileExists = true;
            ofd.Title = "Search for livestreamer.exe";
            ofd.Filter = "Livestreamer Executable|livestreamer.exe|All files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
                tbLivestreamerPath.Text = ofd.FileName;
        }

        private void btnChoosePlayerPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.CheckFileExists = true;
            ofd.Title = "Search for video player";
            ofd.Filter = "All executable files|*.exe|All files|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.IndexOf("vlc.exe") > 0)
                    cbxVlcMetadata.Checked = true;
                else
                    cbxVlcMetadata.Checked = false;

                tbPlayerPath.Text = ofd.FileName;
            }
        }

        private void cbxAllowInternetApiAccess_CheckedChanged(object sender, EventArgs e)
        {
            cfgDatabase.SetBoolean(ConfigurationConstants.ApiInternetAccess,
                cbxAllowInternetApiAccess.Checked);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            apiRunLiveStreamer();
        }

        private void tbInputUrl_TextChanged(object sender, EventArgs e)
        {
            string url = tbInputUrl.Text;

            if (!url.StartsWith("http"))
                url = "http://" + url;

            try
            {
                Uri uri = new Uri(url);

                foreach ( var it in apis )
                {
                    if (it.Owns(uri))
                    {
                        apiUpdatedTab(it.GetPluginId());
                        break;
                    }
                }
            } catch( UriFormatException )
            {
                // zły adres, nic nie możemy zrobić.
            }
        }
    }
}
