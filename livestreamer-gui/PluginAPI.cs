//
// livestreamer-gui
// (c) 2016 Andrzej Budzanowski <psychob.pl@gmail.com>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livestreamer_gui
{
    public struct StreamInfo
    {
        public string Title;
        public string Author;
        public string CanonicalUrl;
        public string OptionsPassedToLivestreamer;
    }

    public struct InitData
    {
        public static class Event
        {
            public delegate void RunLiveStreamer();
            public delegate void TabUpdated(string id);
        }

        public ConfigurationDatabaseProxy Config;
        public System.Windows.Forms.TabControl Control;
        public Event.RunLiveStreamer RunLiveStreamer;
        public Event.TabUpdated TabUpdated;
    }

    interface PluginAPI
    {
        bool Owns(Uri url);

        string GetCanonicalUrl();

        string[] GetCanonicalQuality();

        StreamInfo GetVideoMedatada();

        string GetPluginId();

        void InitTab(InitData data);

        void StreamStarted();

        void ShutDown();
    }
}
