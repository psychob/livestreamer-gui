//
// livestreamer-gui
// (c) 2016 Andrzej Budzanowski <psychob.pl@gmail.com>
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

		public string LivestreamerPath
		{
			get
			{
				return tbLivestreamerPath.Text;
			}
		}

		public string PlayerPath
		{
			get
			{
				return tbPlayerPath.Text;
			}
		}

		public string CurrentUrl
		{
			get
			{
				return tbOutputUrl.Text;
			}
		}

		public bool GenerateVLC
		{
			get
			{
				return cbxVlcMetadata.Checked;
			}
		}

		public string CurrentQuality
		{
			get
			{
				if (cbQualityBox.SelectedIndex == -1)
					return "best,worst";
				else
					return (string)cbQualityBox.Items[cbQualityBox.SelectedIndex];
			}
		}

		public string[] Qualitys
		{
			get
			{
				return cbQualityBox.Items.Cast<string>().ToArray();
			}

			set
			{
				if (cbQualityBox.SelectedIndex == -1)
				{
					cbQualityBox.Items.Clear();
					cbQualityBox.Items.AddRange(value);
				}
				else
				{
					string current_quality = (string)cbQualityBox.Items[cbQualityBox.SelectedIndex];
					int index = value.IndexOf(current_quality);

					cbQualityBox.Items.Clear();
					cbQualityBox.Items.AddRange(value);

					cbQualityBox.SelectedIndex = index;
				}
			}
		}

		public bool RetryStream
		{
			get
			{
				return cbxRetryStream.Checked;
			}
		}

		public int NumberOfAttempts
		{
			get
			{
				return Convert.ToInt32(nudRetryAttempts.Value);
			}
		}

		public int DelayBetween
		{
			get
			{
				return Convert.ToInt32(nudRetryDelay.Value);
			}
		}

		public bool HideConsole
		{
			get
			{
				return cbxHideConsole.Checked;
			}
		}

		public MainWindow()
		{
			InitializeComponent();

			cfgDatabase.LoadConfiguration(Path.Combine(ExtenstionMethods.GetUserPath(),
				"livestreamer.xml"));

			apis = new PluginAPI[]
			{
				new plugins.TwitchTv(),
				new plugins.YouTubeCom(),
				new plugins.GenericPage(),
			};

			foreach (var it in apis)
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

			cfgDatabase.SaveConfiguration(Path.Combine(ExtenstionMethods.GetUserPath(),
				"livestreamer.xml"));
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

			RunLivestreamer(metadata);

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

		private void RunLivestreamer(StreamInfo metadata)
		{
			string outputCommand = "", arguments = "";
			Process processToRun = new Process();

			processToRun.StartInfo.FileName = LivestreamerPath;
			outputCommand += LivestreamerPath.Escape();

			if (HideConsole)
				processToRun.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

			if (PlayerPath.Length > 0) // customowy player
				arguments += "--player " + PlayerPath.Escape() + " ";

			if (cbLogLevel.SelectedIndex != -1)
				arguments += "--loglevel=" + (string)cbLogLevel.SelectedItem + ' ';

			if (GenerateVLC)
			{
				string playeropts = "";

				playeropts += "--meta-title=" + metadata.Title.Escape() + ' ';
				playeropts += "--meta-author=" + metadata.Author.Escape() + ' ';
				playeropts += "--meta-artist=" + metadata.Author.Escape() + ' ';
				playeropts += "{filename}";

				arguments += "--player-args=" + playeropts.Escape() + ' ';

				//arguments += "--player-passthrough=hls ";
			}

			if (RetryStream)
			{
				// --retry-open 1000 --retry-streams 2
				arguments += "--retry-open " + NumberOfAttempts.ToString() + ' ';
				arguments += "--retry-streams " + DelayBetween.ToString() + ' ';
			}

			if (!metadata.OptionsPassedToLivestreamer.IsEmpty())
				arguments += metadata.OptionsPassedToLivestreamer + ' ';

			// na końcu link + jakość
			arguments += metadata.CanonicalUrl.Escape() + " " + CurrentQuality.Escape();

			processToRun.StartInfo.Arguments = arguments;
			tbOutputCommand.Text = outputCommand + " " + arguments;

			processToRun.Start();
		}

		private void apiUpdatedTab(string id)
		{
			currentPlugin = id;
			PluginAPI curr = GetCurrentPlugin();

			tbOutputUrl.Text = curr.GetCanonicalUrl();
			Qualitys = curr.GetCanonicalQuality();
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

				foreach (var it in apis)
				{
					if (it.Owns(uri))
					{
						apiUpdatedTab(it.GetPluginId());
						break;
					}
				}
			}
			catch (UriFormatException)
			{
				// zły adres, nic nie możemy zrobić.
			}
		}
	}
}
