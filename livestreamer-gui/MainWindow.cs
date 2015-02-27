﻿using System;
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
 public partial class MainWindow : Form
 {
  public MainWindow()
  {
   InitializeComponent();
  }

  WebsiteAPI[] webApi;
  string currentWebApi;

  private void MainWindow_Load(object sender, EventArgs e)
  {
   // ładowanie konfiguracji
   try {
    ConfigurationClass cfgClass = new ConfigurationClass();

    XmlReader xreader = XmlReader.Create("livestreamer-gui.xml");
    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(cfgClass.GetType());
    cfgClass = (ConfigurationClass)serializer.Deserialize(xreader);

    tbLivestreamerPath.Text = cfgClass.livestreamerPath;
    cbLogLevel.SelectedIndex = cfgClass.livestreamerLogLevel;
    cbTryRetry.Checked = cfgClass.retry;
    nupAttempts.Value = cfgClass.retryCount;
    nupDelay.Value = cfgClass.retryDelay;
    cbDontShowConsoleWindow.Checked = cfgClass.dontShowConsole;
    cbGenerateMetadataForVLC.Checked = cfgClass.generateVlcMetadata;

    xreader.Close();
   } catch (Exception)
   {  }
   // koniec ładowania konfiguracji

   // ładowanie naszych ukochanych form
   webApi = new WebsiteAPI[]{
    new plugins.TwitchTv(),
    new plugins.YouTubeCom(),
    new plugins.GenericPage(),
   };

   MainFormInfo mfi = new MainFormInfo();
   mfi.tabControl = tcMainTabControl;
   mfi.getLivestreamerPath = apiGetLivestreamerPath;
   mfi.generateRunEvent = apiGenerateRunEvent;
   mfi.generateUpdateEvent = apiGenerateUpdateEvent;

   foreach (WebsiteAPI it in webApi)
    it.setUpTab(mfi);

   // koniec ładowania
  }

  private void apiGenerateUpdateEvent(string id)
  {
   currentWebApi = id;
   updateUrl();
  }

  private void apiGenerateRunEvent()
  {
   updateUrl();
   runUrl();
  }

  private void updateUrl()
  {
   // sprawdzamy która klasa jest aktualnie wybrana
   foreach (WebsiteAPI it in webApi)
   {
    if ( it.getPluginId() == currentWebApi )
    {
     tbOutputUrl.Text = it.getCanonicalUrl();

     cbQuality.Items.Clear();
     cbQuality.Items.AddRange(it.getQuality());

     return;
    }
   }

   tbOutputUrl.Text = "";
  }

  private void runUrl()
  {
   if (tbOutputUrl.Text == "")
    return;

   Process prc = new Process();
   WebsiteAPI currentWebsite = getCurrentWebsite();

   if (cbDontShowConsoleWindow.Checked)
    prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

   prc.StartInfo.FileName = tbLivestreamerPath.Text;
   prc.StartInfo.Arguments = "--loglevel " + cbLogLevel.Text + " ";

   if ( cbTryRetry.Checked )
   {
    if (nupAttempts.Value > 1)
     prc.StartInfo.Arguments += "--retry-open " + nupAttempts.Value.ToString() + " ";

    if ( nupDelay.Value > 1 )
     prc.StartInfo.Arguments += "--retry-streams " + nupDelay.Value.ToString() + " ";
   }

   if ( cbGenerateMetadataForVLC.Checked )
   {
    string append = "";

    append += "--meta-title=\"" + currentWebsite.getStreamTitle() + "\" ";
    append += "--meta-author=\"" + currentWebsite.getStreamAuthor() + "\" ";
    append += "--meta-artist=\"" + currentWebsite.getStreamAuthor() + "\" ";

    append += "{filename}";

    append = escapeString(append);

    prc.StartInfo.Arguments += "--player-args \"" + append + "\" ";
   }

   prc.StartInfo.Arguments += tbOutputUrl.Text + " ";
   if (cbQuality.Text == "")
   {
    StringBuilder sb = new StringBuilder();
    foreach (string it in cbQuality.Items)
    {
     sb.Append(it);
     sb.Append(",");
    }
    prc.StartInfo.Arguments += sb.ToString().Trim(',') + " ";
   } else
    prc.StartInfo.Arguments += cbQuality.Text + " ";

   prc.Start();

   tbOutput.Text = prc.StartInfo.FileName + " " + prc.StartInfo.Arguments;
  }

  private string escapeString(string append)
  {
   append = append.Replace(@"\", @"\\");
   append = append.Replace("\"", "\\\"");
   return append;
  }

  private WebsiteAPI getCurrentWebsite()
  {
   foreach (WebsiteAPI it in webApi)
    if (it.getPluginId() == currentWebApi)
     return it;

   return null;
  }

  private string apiGetLivestreamerPath()
  {
   return tbLivestreamerPath.Text;
  }

  private void button1_Click(object sender, EventArgs e)
  {
   updateUrl();
   runUrl();
  }

  private void tbInput_TextChanged(object sender, EventArgs e)
  {
   System.Uri myuri;

   try
   {
    myuri = new Uri(tbInput.Text);
   } catch (UriFormatException)
   {
    try
    {
     myuri = new Uri("http://" + tbInput.Text);
    } catch (UriFormatException)
    {
     return;
    }
   }

   // sprawdzamy do którego to pasuje
   foreach (WebsiteAPI it in webApi)
   {
    if ( it.isMyUri(myuri) )
    {
     currentWebApi = it.getPluginId();
     tbOutputUrl.Text = it.getCanonicalUrl();
     return;
    }
   }
  }

  private void btnChooseLivestreamerPath_Click(object sender, EventArgs e)
  {
   OpenFileDialog ofd = new OpenFileDialog();

   ofd.Filter = "Livestreamer|livestreamer.exe|All Files|*.*";
   ofd.CheckFileExists = true;

   if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
    return;

   tbLivestreamerPath.Text = ofd.FileName;
  }

  private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
  {
   ConfigurationClass cfgClass = new ConfigurationClass();
   cfgClass.livestreamerPath = tbLivestreamerPath.Text;
   cfgClass.livestreamerLogLevel = cbLogLevel.SelectedIndex;
   cfgClass.retry = cbTryRetry.Checked;
   cfgClass.retryCount = Decimal.ToInt32(nupAttempts.Value);
   cfgClass.retryDelay = Decimal.ToInt32(nupDelay.Value);
   cfgClass.dontShowConsole = cbDontShowConsoleWindow.Checked;
   cfgClass.generateVlcMetadata = cbGenerateMetadataForVLC.Checked;
   cfgClass.usedUrls = null;

   System.Xml.Serialization.XmlSerializer xmlSerialiser = new System.Xml.Serialization.XmlSerializer(cfgClass.GetType());

   XmlWriterSettings xws = new XmlWriterSettings();
   xws.Indent = true;
   xws.IndentChars = " ";
   xws.Encoding = Encoding.UTF8;

   XmlWriter xmlWriter = XmlWriter.Create("livestreamer-gui.xml", xws);
   xmlSerialiser.Serialize(xmlWriter, cfgClass);

   xmlWriter.Close();
  }
 }
}
