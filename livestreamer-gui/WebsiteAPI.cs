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

namespace livestreamer_gui
{
 struct MainFormInfo
 {
  // typy
  public delegate void GenerateRunEventType();
  public delegate string GetLivestreamerPathType();
  public delegate void GenerateUpdateEventType(string id);

  // pola
  public System.Windows.Forms.TabControl tabControl;
  public GenerateRunEventType generateRunEvent;
  public GetLivestreamerPathType getLivestreamerPath;
  public GenerateUpdateEventType generateUpdateEvent;
 }

 interface WebsiteAPI
 {
  bool isMyUri(System.Uri url);

  string getStreamTitle();
  string getStreamAuthor();
  string getCanonicalUrl();
  void queryAdditionalData();

  string[] getQuality();

  string getPluginId();

  void setUpTab(MainFormInfo mfi);
 }
}