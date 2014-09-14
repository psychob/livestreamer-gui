//
// livestreamer-gui
// (c) 2014 Andrzej Budzanowski
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
    prc.StartInfo.Arguments += "best,high,medium,low,worst";

   prc.Start();

   tb_log.Text = prc.StartInfo.FileName + " " + prc.StartInfo.Arguments;
  }
 }
}
