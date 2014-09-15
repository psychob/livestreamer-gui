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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace livestreamer_gui
{
 public partial class Form1 : Form
 {
  List<IWebsite> allwebs = new List<IWebsite>();
  string current = "";

  public Form1()
  {
   InitializeComponent();

   cb_livestreamer_loglevel.SelectedIndex = 4;

   // inicjalizacja
   allwebs.Add(new Twitch());
   allwebs.Add(new YouTube());

   foreach ( IWebsite it in allwebs )
    it.setUpClass( this.tabs, updateCurrent );
  }

  private void tb_userUrl_TextChanged(object sender, EventArgs e)
  {
   Uri uri = null;
   try
   {
    uri = new Uri(tb_userUrl.Text);
   }
   catch (Exception)
   {
    try
    {
     uri = new Uri("http://" + tb_userUrl.Text);
    }
    catch (Exception)
    { }
   }

   if (uri == null)
    return;

   foreach (IWebsite it in allwebs)
    if (it.Is(uri))
    {
     current = it.id();
     tb_genUrl.Text = it.getUrl();
     {
      cb_quality.Items.Clear();
      foreach (var jt in it.getQuality())
       cb_quality.Items.Add(jt);
     }
     break;
    }
  }

  private void updateCurrent( string id )
  {
   foreach ( IWebsite web in allwebs )
    if ( web.id() == id )
    {
     current = web.id();
     tb_genUrl.Text = web.getUrl();
     {
      cb_quality.Items.Clear();
      foreach (var jt in web.getQuality())
       cb_quality.Items.Add(jt);
     }

     break;
    }
  }

  private void button1_Click(object sender, EventArgs e)
  {
   if (tb_genUrl.Text == "")
    return;

   Process prc = new Process();

   if ( cbxDontShowConsoleWindow.Checked ) 
    prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

   prc.StartInfo.FileName = tb_livestreamer_path.Text;
   prc.StartInfo.Arguments = "--loglevel " + cb_livestreamer_loglevel.Text + " ";
   if (cbx_livestreamer_retry.Checked)
   {
    if ( num_livestreamer_attempts.Value > 1 )
     prc.StartInfo.Arguments += "--retry-open " + num_livestreamer_attempts.Value.ToString() + " ";
    if ( num_livestreamer_delay.Value > 0 )
     prc.StartInfo.Arguments += "--retry-streams " + num_livestreamer_delay.Value.ToString() + " ";
   }
   prc.StartInfo.Arguments += tb_genUrl.Text + " " + cb_quality.Text;

   if (cb_quality.Text == "")
   {
    StringBuilder sb = new StringBuilder();
    foreach (var it in cb_quality.Items)
    {
     sb.Append(it);
     sb.Append(",");
    }

    prc.StartInfo.Arguments += sb.ToString().Trim(',');
   } else
    prc.StartInfo.Arguments += cb_quality.Text;

   prc.Start();

   tb_log.Text = prc.StartInfo.FileName + " " + prc.StartInfo.Arguments;
  }

  private void btnSearchForLivestreamer_Click(object sender, EventArgs e)
  {
   OpenFileDialog ofd = new OpenFileDialog();

   ofd.CheckFileExists = true;
   ofd.CheckPathExists = true;
   ofd.Filter = "livestreamer.exe|livestreamer.exe";
   ofd.FilterIndex = 0;
   ofd.Title = "Search for livestreamer.exe file";
   if ( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK )
    tb_livestreamer_path.Text = ofd.FileName;
  }

  private void Form1_Load(object sender, EventArgs e)
  {
   // loading config from file
   try
   {
    XmlReaderSettings xrs = new XmlReaderSettings();
    xrs.IgnoreWhitespace = true;
    XmlReader xr = XmlReader.Create("config.xml", xrs);
    xr.ReadStartElement("gui");

    xr.ReadStartElement("livestreamer-path");
    tb_livestreamer_path.Text = xr.Value;
    xr.Skip();
    xr.ReadEndElement();

    xr.ReadStartElement("log-level");
    cb_livestreamer_loglevel.Text = xr.Value;
    xr.Skip();
    xr.ReadEndElement();

    xr.ReadStartElement("retry");
    xr.MoveToFirstAttribute();
    if (xr.Value == "true")
     cbx_livestreamer_retry.Checked = true;
    else
     cbx_livestreamer_retry.Checked = false;
    xr.MoveToContent();

    xr.ReadStartElement("attempts");
    num_livestreamer_attempts.Value = int.Parse(xr.Value);
    xr.Skip();
    xr.ReadEndElement();

    xr.ReadStartElement("delay");
    num_livestreamer_delay.Value = int.Parse(xr.Value);
    xr.Skip();
    xr.ReadEndElement();

    xr.ReadEndElement();

    xr.ReadStartElement("hide-console");
    if (xr.Value == "true")
     cbxDontShowConsoleWindow.Checked = true;
    else
     cbxDontShowConsoleWindow.Checked = false;
    xr.Skip();
    xr.ReadEndElement();

    xr.ReadEndElement();
    xr.Close();
   } catch ( Exception )
   {
    // catch'em all!
   }
  }

  private void Form1_FormClosed(object sender, FormClosedEventArgs e)
  {
   // saving config file
   XmlWriterSettings xws = new XmlWriterSettings();
   xws.Indent = true;
   xws.IndentChars = " ";
   xws.Encoding = Encoding.UTF8;

   XmlWriter xw = XmlWriter.Create("config.xml", xws);

   xw.WriteStartDocument(true);
   xw.WriteStartElement("gui");
   
   // path
   xw.WriteStartElement("livestreamer-path");
   xw.WriteString(tb_livestreamer_path.Text);
   xw.WriteEndElement();

   // log level
   xw.WriteStartElement("log-level");
   xw.WriteString(cb_livestreamer_loglevel.Text);
   xw.WriteEndElement();

   // retry
   xw.WriteStartElement("retry");
   xw.WriteAttributeString("enabled", cbx_livestreamer_retry.Checked ? "true" : "false");

   xw.WriteStartElement("attempts");
   xw.WriteString(num_livestreamer_attempts.Value.ToString());
   xw.WriteEndElement();

   xw.WriteStartElement("delay");
   xw.WriteString(num_livestreamer_delay.Value.ToString());
   xw.WriteEndElement();

   xw.WriteEndElement();

   // hide console
   xw.WriteStartElement("hide-console");
   xw.WriteString(cbxDontShowConsoleWindow.Checked ? "true" : "false");
   xw.WriteEndElement();

   xw.WriteEndDocument();

   // retarded xml...
   xw.Close();
  }
 }
}
