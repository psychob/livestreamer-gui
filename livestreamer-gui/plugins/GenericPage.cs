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
using System.Windows.Forms;

namespace livestreamer_gui.plugins
{
 class GenericPage : WebsiteAPI
 {
  public bool isMyUri(System.Uri url)
  {
   layout_tbPageUrl.Text = url.ToString();
   return true;
  }

  public string getStreamTitle()
  {
   return "not supported!";
  }

  public string getStreamAuthor()
  {
   return "not supported!";
  }

  public string getCanonicalUrl()
  {
   return layout_tbPageUrl.Text;
  }

  public string[] getQuality()
  {
   return new string[]{
    "best",
    "worst"
   };
  }

  public string getPluginId()
  {
   return "stock::generic";
  }

  MainFormInfo local_mfi;

  TabPage layout_ctp;
  TextBox layout_tbPageUrl;
  Label   layout_lbPage;

  public void setUpTab(MainFormInfo mfi)
  {
   local_mfi = mfi;
   layout_ctp = new TabPage("Any Page");

   layout_tbPageUrl = new TextBox();
   layout_lbPage = new Label();

   layout_lbPage.Text = "Site with stream url:";
   layout_lbPage.Location = new System.Drawing.Point(3, 10);

   layout_tbPageUrl.Location = new System.Drawing.Point(115, 6);
   layout_tbPageUrl.Size = new System.Drawing.Size(246, 20);
   layout_tbPageUrl.TextChanged += layout_tbPageUrl_TextChanged;
   layout_tbPageUrl.KeyDown += layout_tbPageUrl_KeyDown;

   layout_ctp.Controls.AddRange(new Control[]{ layout_lbPage, layout_tbPageUrl});

   mfi.tabControl.TabPages.Add(layout_ctp);
  }

  void layout_tbPageUrl_KeyDown(object sender, KeyEventArgs e)
  {
   if (e.KeyCode == Keys.Return)
    local_mfi.generateRunEvent();
  }

  void layout_tbPageUrl_TextChanged(object sender, System.EventArgs e)
  {
   local_mfi.generateUpdateEvent(getPluginId());
  }

  public void queryAdditionalData()
  { // nic
  }
 }
}
