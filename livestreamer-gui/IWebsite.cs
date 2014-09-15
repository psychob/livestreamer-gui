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
