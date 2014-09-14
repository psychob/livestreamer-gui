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

using System;
using System.Windows.Forms;
using System.Web;

namespace livestreamer_gui
{
 class YouTube : IWebsite
 {
  public bool Is(Uri url)
  {
   if ( url.Host == "youtube.com" || url.Host == "www.youtube.com" )
   {
    var urlq = HttpUtility.ParseQueryString(url.Query);

    layout_boxVideo.Text = urlq["v"];

    return true;
   }

   return false;
  }

  public string getName()
  {
   return layout_boxVideo.Text;
  }

  public string getUrl()
  {
   if (getName() == "")
    return "";
   return "http://youtube.com/watch?v=" + getName();
  }

  public string[] getQuality()
  {
   var l = new System.Collections.Generic.List<string>()
   {
    "best",
    "1080p",
    "720p",
    "480p",
    "360p",
    "260p",
    "worst"
   };

   return l.ToArray();
  }

  public string getAuthor()
  {
   throw new NotImplementedException();
  }

  TabPage layout_tab;

  Label layout_labelVideo;
  TextBox layout_boxVideo;

  UpdateCallBack ucbf;

  public void setUpClass(TabControl tb, UpdateCallBack ucb )
  {
   layout_tab = new TabPage("youtube.com");

   layout_labelVideo = new Label();
   layout_boxVideo = new TextBox();

   layout_labelVideo.Text = "Video ID:";
   layout_labelVideo.Location = new System.Drawing.Point(3, 10);
   layout_labelVideo.Size = new System.Drawing.Size(81, 20);

   layout_boxVideo.Location = new System.Drawing.Point(85, 7);
   layout_boxVideo.Size = new System.Drawing.Size(295, 20);
   layout_boxVideo.TextChanged += eventChanger;

   layout_tab.Controls.Add(layout_labelVideo);
   layout_tab.Controls.Add(layout_boxVideo);

   tb.TabPages.Add(layout_tab);

   ucbf = ucb;
  }

  private void eventChanger(object sender, EventArgs e)
  {
   ucbf(id());
  }

  public string id()
  {
   return "youtube";
  }
 }
}
