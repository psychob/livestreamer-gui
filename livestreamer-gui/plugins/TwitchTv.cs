//
// livestreamer-gui
// (c) 2014 Andrzej Budzanowski <psychob.pl@gmail.com>
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;

namespace livestreamer_gui.plugins
{
 class TwitchTv : WebsiteAPI
 {
  public bool isMyUri(System.Uri url)
  {
   if ( url.Host == "www.twitch.tv" || url.Host == "twitch.tv" )
   {
    if (url.Segments.Length < 2)
     return false;

    layout_boxChannel.Text = url.Segments[1].Trim('/').Trim();
    layout_checkhightligh.Checked = false;
    layout_boxVOD.Text = "";
    layout_numHour.Value = 0;
    layout_numMinute.Value = 0;
    layout_numSecond.Value = 0;

    if (url.Segments.Length != 4)
     return true;

    if (url.Segments[2].Trim('/').Trim() == "c")
     layout_checkhightligh.Checked = true;

    layout_boxVOD.Text = url.Segments[3].Trim('/').Trim();

    return true;
   }

   return false;
  }

  public string getStreamTitle()
  {
   return stream_title == "" ? getName() : stream_title;
  }

  public string getStreamAuthor()
  {
   return stream_author == "" ? getName() : stream_author;
  }

  string getName( )
  {
   return layout_boxChannel.Text.Trim();
  }

  public string getCanonicalUrl()
  {
   if (layout_boxVOD.Text == "")
    return "http://www.twitch.tv/" + getName();
   else
   {
    string append = "";

    if (layout_numHour.Value > 0 || layout_numMinute.Value > 0 || layout_numSecond.Value > 0)
    {
     append = "?t=";
     if (layout_numHour.Value > 0)
      append += layout_numHour.Value.ToString() + "h";
     if (layout_numMinute.Value > 0)
      append += layout_numMinute.Value.ToString() + "m";
     if (layout_numSecond.Value > 0)
      append += layout_numSecond.Value.ToString() + "s";
    }

    if (layout_checkhightligh.Checked)
     return "http://www.twitch.tv/" + getName() + "/c/" + layout_boxVOD.Text + append;
    else
     return "http://www.twitch.tv/" + getName() + "/b/" + layout_boxVOD.Text + append;
   }
  }

  public string[] getQuality()
  {
   return new string[]{
    "best",
    "high",
    "medium",
    "low",
    "worst"
   };
  }

  public string getPluginId()
  {
   return "stock::twitchtv";
  }

  MainFormInfo local_mfi;

  TabPage layout_mtp;
  Label layout_labelChannel,
          layout_labelVOD,
          layout_labelTime,
          layout_labelIsHighlight,
          layout_labelh,
          layout_labelm,
          layout_labels;
  TextBox layout_boxChannel,
          layout_boxVOD;
  NumericUpDown layout_numHour,
                layout_numMinute,
                layout_numSecond;
  CheckBox layout_checkhightligh;

  public void setUpTab(MainFormInfo mfi)
  {
   local_mfi = mfi;

   // tworzenie
   layout_mtp = new TabPage("twitch.tv");
   layout_labelChannel = new Label();
   layout_boxChannel = new TextBox();
   layout_labelVOD = new Label();
   layout_boxVOD = new TextBox();
   layout_labelTime = new Label();
   layout_labelIsHighlight = new Label();
   layout_numHour = new NumericUpDown();
   layout_numMinute = new NumericUpDown();
   layout_numSecond = new NumericUpDown();
   layout_labelh = new Label();
   layout_labelm = new Label();
   layout_labels = new Label();
   layout_checkhightligh = new CheckBox();

   // inicjalizacja
   layout_labelChannel.Text = "Channel Name:";
   layout_labelChannel.Location = new System.Drawing.Point(3, 10);
   layout_labelChannel.Size = new System.Drawing.Size(81, 20);

   layout_boxChannel.Location = new System.Drawing.Point(85, 7);
   layout_boxChannel.Size = new System.Drawing.Size(295, 20);
   layout_boxChannel.TextChanged += evenChanger;

   layout_labelVOD.Text = "VOD:";
   layout_labelVOD.Location = new System.Drawing.Point(3, 40);
   layout_labelVOD.Size = new System.Drawing.Size(81, 20);

   layout_boxVOD.Location = new System.Drawing.Point(85, 37);
   layout_boxVOD.Size = new System.Drawing.Size(295, 20);
   layout_boxVOD.TextChanged += evenChanger;

   layout_labelTime.Text = "Start Time:";
   layout_labelTime.Location = new System.Drawing.Point(3, 63);
   layout_labelTime.Size = new System.Drawing.Size(81, 20);

   layout_numHour.Minimum = 0;
   layout_numHour.Maximum = 24 * 5;
   layout_numHour.Location = new System.Drawing.Point(85, 60);
   layout_numHour.Size = new System.Drawing.Size(50, 20);
   layout_numHour.ValueChanged += evenChanger;

   layout_labelh.Text = "h";
   layout_labelh.Location = new System.Drawing.Point(140, 63);
   layout_labelh.Size = new System.Drawing.Size(10, 20);

   layout_numMinute.Minimum = 0;
   layout_numMinute.Maximum = 60;
   layout_numMinute.Location = new System.Drawing.Point(155, 60);
   layout_numMinute.Size = new System.Drawing.Size(50, 20);
   layout_numMinute.ValueChanged += evenChanger;

   layout_labelm.Text = "m";
   layout_labelm.Location = new System.Drawing.Point(210, 63);
   layout_labelm.Size = new System.Drawing.Size(10, 20);

   layout_numSecond.Minimum = 0;
   layout_numSecond.Maximum = 60;
   layout_numSecond.Location = new System.Drawing.Point(225, 60);
   layout_numSecond.Size = new System.Drawing.Size(50, 20);
   layout_numSecond.ValueChanged += evenChanger;

   layout_labels.Text = "s";
   layout_labels.Location = new System.Drawing.Point(280, 63);
   layout_labels.Size = new System.Drawing.Size(10, 20);

   layout_labelIsHighlight.Text = "Is Highlight:";
   layout_labelIsHighlight.Location = new System.Drawing.Point(3, 86);
   layout_labelIsHighlight.Size = new System.Drawing.Size(81, 20);

   layout_checkhightligh.Location = new System.Drawing.Point(85, 83);
   layout_checkhightligh.CheckedChanged += evenChanger;

   // dodawanie do komponentów
   layout_mtp.Controls.AddRange(
    new Control[]{layout_labelChannel, layout_boxChannel, layout_labelVOD,
                  layout_boxVOD, layout_labelTime, layout_labelIsHighlight,
                  layout_numHour, layout_numMinute, layout_numSecond,
                  layout_labelh, layout_labelm, layout_labels,
                  layout_checkhightligh}
   );

   // dodwanie taba
   mfi.tabControl.TabPages.Add(layout_mtp);
  }

  private void evenChanger(object sender, System.EventArgs e)
  {
   local_mfi.generateUpdateEvent(getPluginId());
  }

  string stream_title = "";
  string stream_author = "";

  public void queryAdditionalData()
  {
   string apiSite = "https://api.twitch.tv/kraken/channels/" + getName();

   WebRequest wr = WebRequest.Create(apiSite);
   WebResponse wre = wr.GetResponse();
   Stream data = wre.GetResponseStream();

   string html = string.Empty;
   using ( StreamReader sr = new StreamReader(data))
   {
    html = sr.ReadToEnd();
   }
   data.Close();

   JavaScriptSerializer jss = new JavaScriptSerializer();
   var dict = jss.Deserialize<Dictionary<string, object>>(html);

   stream_author = (string)dict["display_name"];
   stream_title = "Playing: " + (string)dict["game"] + " " + (string)dict["status"];
  }
 }
}
