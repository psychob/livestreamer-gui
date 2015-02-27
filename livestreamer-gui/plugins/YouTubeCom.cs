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

using System.Web;
using System.Windows.Forms;

namespace livestreamer_gui.plugins
{
 class YouTubeCom : WebsiteAPI
 {
  public bool isMyUri(System.Uri url)
  {
   if ( url.Host == "youtube.com" || url.Host == "www.youtube.com" )
   {
    var urlq = HttpUtility.ParseQueryString(url.Query);
    layout_boxVideo.Text = urlq["v"];
    return true;
   } else if ( url.Host == "youtu.be" )
   {
    layout_boxVideo.Text = url.Segments[1];
    return true;
   }

   return false;
  }

  public string getStreamTitle()
  {
   return "!not supported";
  }

  public string getStreamAuthor()
  {
   return "!not supported!";
  }

  public string getCanonicalUrl()
  {
   return "http://www.youtube.com/watch?v=" + layout_boxVideo.Text;
  }

  public string[] getQuality()
  {
   return new string[]{
    "best",
    "1080p",
    "720p",
    "480p",
    "360p",
    "260p",
    "worst"
   };
  }

  public string getPluginId()
  {
   return "stock::youtube";
  }

  MainFormInfo local_mfi;

  TabPage layout_tab;

  Label layout_labelVideo;
  TextBox layout_boxVideo;

  public void setUpTab(MainFormInfo mfi)
  {
   local_mfi = mfi;

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

   mfi.tabControl.TabPages.Add(layout_tab);
  }

  private void eventChanger(object sender, System.EventArgs e)
  {
   local_mfi.generateUpdateEvent(getPluginId());
  }

  public void queryAdditionalData()
  { // nic
  }
 }
}
