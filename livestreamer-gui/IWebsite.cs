//
// livestreamer-gui
// (c) 2014 Andrzej Budzanowski
//
using System;
using System.Windows.Forms;

namespace livestreamer_gui
{
 public delegate void UpdateCallBack( string id );

 interface IWebsite
 {
  // czy ta klasa odpowiada za taki url
  bool Is(Uri url);

  // pobranie Nazwy Streamu
  string getName();

  // pobieranie Adresu Stremu
  string getUrl();

  // pobieranie jakości
  string[] getQuality();

  // pobranie autora
  string getAuthor();

  void setUpClass(TabControl tb, UpdateCallBack ucb );

  string id();
 }
}
