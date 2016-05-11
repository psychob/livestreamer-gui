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
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace livestreamer_gui.plugins
{
	class TwitchTv : PluginAPI
	{
		TabPage layoutTabPage;
		Label layoutLabelChannelName, layoutLabelVOD, layoutLabelTime,
			layoutLabelH, layoutLabelM, layoutLabelS;
		TextBox layoutTextBoxChannel, layoutTextBoxVOD;
		NumericUpDown layoutNudHour, layoutNudMinute, layoutNudSecond;
		InitData localInitData;
		List<ConfigurationDatabase.AutocompleteData> ad;

		private string StreamName
		{
			get
			{
				return layoutTextBoxChannel.Text.Trim();
			}
		}

		private bool IsVod
		{
			get
			{
				return layoutTextBoxVOD.Text.Trim() != "";
			}
		}

		private string VodId
		{
			get
			{
				return layoutTextBoxVOD.Text.Trim();
			}
		}

		public string GetPluginId()
		{
			return "twitchtv";
		}

		public StreamInfo GetVideoMedatada()
		{
			StreamInfo retInfo = new StreamInfo();

			retInfo.Author = StreamName;
			retInfo.Title = "Stream of " + StreamName;
			retInfo.CanonicalUrl = GetCanonicalUrl();
			retInfo.OptionsPassedToLivestreamer = "";

			if (localInitData.Config.GetBoolean(ConfigurationConstants.ApiInternetAccess,
				true, false))
			{
				if (!IsVod)
				{
					string apiSite = "https://api.twitch.tv/kraken/channels/" + StreamName;

					WebRequest wr = WebRequest.Create(apiSite);
					WebResponse wre = wr.GetResponse();
					string html = string.Empty;

					using (Stream data = wre.GetResponseStream())
					{
						using (StreamReader sr = new StreamReader(data))
						{
							html = sr.ReadToEnd();
						}
					}

					JavaScriptSerializer jss = new JavaScriptSerializer();
					var dict = jss.Deserialize<Dictionary<string, object>>(html);

					retInfo.Author = (string)dict["display_name"];
					retInfo.Title = "Playing: " + (string)dict["game"] + " - " + (string)dict["status"];
					retInfo.CanonicalUrl = (string)dict["url"];
				}
				else
				{
					string apiSite = "https://api.twitch.tv/kraken/videos/v" + VodId;

					WebRequest wr = WebRequest.Create(apiSite);
					WebResponse wre = wr.GetResponse();
					string html = string.Empty;

					using (Stream data = wre.GetResponseStream())
					{
						using (StreamReader sr = new StreamReader(data))
						{
							html = sr.ReadToEnd();
						}
					}

					JavaScriptSerializer jss = new JavaScriptSerializer();
					var dict = jss.Deserialize<Dictionary<string, object>>(html);

					retInfo.Author = StreamName;
					retInfo.Title = "Playing: " + (string)dict["game"] + " - " + (string)dict["title"];
					retInfo.CanonicalUrl = GetCanonicalUrl();

				}
			}

			return retInfo;
		}


		public string[] GetCanonicalQuality()
		{
			return new string[]
			{
				"best",
				"high",
				"medium",
				"low",
				"worst",
			};
		}

		public string GetCanonicalUrl()
		{
			if (!IsVod)
				return "http://twitch.tv/" + StreamName;
			else
			{
				string ret = "http://twitch.tv/" + StreamName + "/v/" + VodId;

				if (layoutNudHour.Value != 0 || layoutNudMinute.Value != 0 || layoutNudSecond.Value != 0)
				{
					ret += "?t=";

					if (layoutNudHour.Value != 0)
						ret += layoutNudHour.Value + "h";

					if (layoutNudMinute.Value != 0)
						ret += layoutNudMinute.Value + "m";

					if (layoutNudSecond.Value != 0)
						ret += layoutNudSecond.Value + "s";
				}

				return ret;
			}
		}

		public void InitTab(InitData data)
		{
			localInitData = data;

			ad = localInitData.Config.GetAutocomplete("autocompletelist");
			if (ad == null)
				ad = new List<ConfigurationDatabase.AutocompleteData>();

			// tworzenie
			layoutTabPage = new TabPage("twitch.tv");
			layoutLabelChannelName = new Label();
			layoutTextBoxChannel = new TextBox();
			layoutLabelVOD = new Label();
			layoutTextBoxVOD = new TextBox();
			layoutLabelTime = new Label();
			layoutNudHour = new NumericUpDown();
			layoutNudMinute = new NumericUpDown();
			layoutNudSecond = new NumericUpDown();
			layoutLabelH = new Label();
			layoutLabelM = new Label();
			layoutLabelS = new Label();

			// inicjalizacja
			layoutLabelChannelName.Text = "Channel Name:";
			layoutLabelChannelName.Location = new System.Drawing.Point(8, 9);
			layoutLabelChannelName.Size = new System.Drawing.Size(81, 20);

			layoutTextBoxChannel.Location = new System.Drawing.Point(152, 6);
			layoutTextBoxChannel.Size = new System.Drawing.Size(243, 20);
			layoutTextBoxChannel.TextChanged += evenChanger;
			layoutTextBoxChannel.AutoCompleteMode = AutoCompleteMode.Suggest;
			layoutTextBoxChannel.AutoCompleteSource = AutoCompleteSource.CustomSource;
			layoutTextBoxChannel.AutoCompleteCustomSource = new AutoCompleteStringCollection();

			if (ad != null && ad.Count > 0)
				layoutTextBoxChannel.AutoCompleteCustomSource.AddRange(ad.Rewrite(r => r.url));

			layoutLabelVOD.Text = "VOD:";
			layoutLabelVOD.Location = new System.Drawing.Point(8, 35);
			layoutLabelVOD.Size = new System.Drawing.Size(81, 20);

			layoutTextBoxVOD.Location = new System.Drawing.Point(152, 32);
			layoutTextBoxVOD.Size = new System.Drawing.Size(243, 20);
			layoutTextBoxVOD.TextChanged += evenChanger;

			layoutLabelTime.Text = "Start Time:";
			layoutLabelTime.Location = new System.Drawing.Point(8, 62);
			layoutLabelTime.Size = new System.Drawing.Size(81, 20);

			layoutNudHour.Minimum = 0;
			layoutNudHour.Maximum = 24 * 24;
			layoutNudHour.Location = new System.Drawing.Point(152, 59);
			layoutNudHour.Size = new System.Drawing.Size(50, 20);
			layoutNudHour.ValueChanged += evenChanger;

			layoutLabelH.Text = "h";
			layoutLabelH.Location = new System.Drawing.Point(202, 63);
			layoutLabelH.Size = new System.Drawing.Size(10, 20);

			layoutNudMinute.Minimum = 0;
			layoutNudMinute.Maximum = 59;
			layoutNudMinute.Location = new System.Drawing.Point(217, 59);
			layoutNudMinute.Size = new System.Drawing.Size(50, 20);
			layoutNudMinute.ValueChanged += evenChanger;

			layoutLabelM.Text = "m";
			layoutLabelM.Location = new System.Drawing.Point(267, 63);
			layoutLabelM.Size = new System.Drawing.Size(10, 20);

			layoutNudSecond.Minimum = 0;
			layoutNudSecond.Maximum = 59;
			layoutNudSecond.Location = new System.Drawing.Point(282, 59);
			layoutNudSecond.Size = new System.Drawing.Size(50, 20);
			layoutNudSecond.ValueChanged += evenChanger;

			layoutLabelS.Text = "s";
			layoutLabelS.Location = new System.Drawing.Point(332, 63);
			layoutLabelS.Size = new System.Drawing.Size(10, 20);

			// dodawanie do komponentów
			layoutTabPage.Controls.AddRange(
			 new Control[]{ layoutLabelChannelName,
				   layoutTextBoxChannel,
				   layoutLabelVOD,
				   layoutTextBoxVOD,
				   layoutLabelTime,
				   layoutNudHour,
				   layoutNudMinute,
				   layoutNudSecond,
				   layoutLabelH,
				   layoutLabelM,
				   layoutLabelS,
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
			if (url.Host.ToLowerInvariant().IndexOf("twitch.tv") == -1)
				return false;

			string pq = url.PathAndQuery;
			int next_q = 0;

			if (pq.Length == 0 || pq == "/")
				return false;

			pq = pq.Substring(1);
			next_q = pq.IndexOf('/');

			layoutTextBoxChannel.Text = "";
			layoutTextBoxVOD.Text = "";
			layoutNudMinute.Value = 0;
			layoutNudHour.Value = 0;
			layoutNudSecond.Value = 0;

			// nie ma żadnej dodatkowej informacji
			if (next_q == -1)
			{
				layoutTextBoxChannel.Text = pq;
				layoutTextBoxVOD.Text = "";
				layoutNudMinute.Value = 0;
				layoutNudHour.Value = 0;
				layoutNudSecond.Value = 0;
			}
			else
			{
				layoutTextBoxChannel.Text = pq.Substring(0, next_q);

				pq = pq.Substring(next_q + 1);

				if (pq.Length <= 2)
					return true;

				pq = pq.Substring(2);

				next_q = pq.IndexOf('?');

				if (next_q == -1)
				{
					layoutTextBoxVOD.Text = pq;
				}
				else
				{
					layoutTextBoxVOD.Text = pq.Substring(0, next_q);

					pq = pq.Substring(next_q + 1);

					if (pq.Length <= 2)
						return true;

					pq = pq.Substring(2);

					int h = 0, m = 0, s = 0;
					int current = 0;

					foreach (var it in pq)
					{
						switch (it)
						{
							case 'h':
								h = current;
								current = 0;
								break;

							case 'm':
								m = current;
								current = 0;
								break;

							case 's':
								s = current;
								current = 0;
								break;

							default:
								current *= 10;
								current += Convert.ToInt32(it) - 0x30;
								break;
						}
					}

					layoutNudHour.Value = Convert.ToDecimal(h);
					layoutNudMinute.Value = Convert.ToDecimal(m);
					layoutNudSecond.Value = Convert.ToDecimal(s);
				}
			}

			return true;
		}

		public void StreamStarted()
		{
			int io = ad.FindIndex(p => p.url == StreamName);

			if (io == -1)
				ad.Add(new ConfigurationDatabase.AutocompleteData(StreamName));
			else
			{
				var tmp = ad[io];
				ad[io] = new ConfigurationDatabase.AutocompleteData(tmp.url, tmp.count + 1);
			}

			layoutTextBoxChannel.AutoCompleteCustomSource.Clear();
			layoutTextBoxChannel.AutoCompleteCustomSource.AddRange(ad.Rewrite(r => r.url));
		}

		public void ShutDown()
		{
			localInitData.Config.SetAutocomplete("autocompletelist", ad);
		}
	}
}
