//
// livestreamer-gui
// (c) 2016 Andrzej Budzanowski <psychob.pl@gmail.com>
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace livestreamer_gui
{
    public static class ConfigurationConstants
    {
        public const string LivestreamerPath = "core.livestreamer.path";
        public const string LivestreamerLogLevel = "core.livestreamer.log-level";
        public const string PlayerPath = "core.player.path";
        public const string RetryStream = "core.stream.retry";
        public const string RetryStreamAttempts = "core.stream.attempts";
        public const string RetryStreamDelay = "core.stream.delay";
        public const string LivestreamerHideConsole = "core.livestreamer.hide-console";
        public const string PlayerGenerateVLCMetadata = "core.player.vlc";
        public const string ApiInternetAccess = "core.api.internet";
        public const string Autocomplete = "core.autocomplete";
    }

    public class ConfigurationDatabase
    {
        public struct ConfigValue
        {
            public enum Type
            {
                String,
                Integer,
                Boolean,
                AutocompleteList,
                ListOfStrings,
            }

            public Type boxedType;
            public object boxedValue;

            public ConfigValue(string v)
            {
                boxedType = Type.String;
                boxedValue = v;
            }

            public ConfigValue(int v)
            {
                boxedType = Type.Integer;
                boxedValue = v;
            }

            public ConfigValue(bool b)
            {
                boxedType = Type.Boolean;
                boxedValue = b;
            }

            public ConfigValue(List<AutocompleteData> lst)
            {
                boxedType = Type.AutocompleteList;
                boxedValue = lst;
            }

            public ConfigValue(List<string> lst)
            {
                boxedType = Type.ListOfStrings;
                boxedValue = lst;
            }
        }

        public struct AutocompleteData
        {
            public string url;
            public int count;

            public AutocompleteData(string url)
            {
                this.url = url;
                count = 1;
            }

            public AutocompleteData(string url, int count)
            {
                this.url = url;
                this.count = count;
            }
        }

        private Dictionary<string, ConfigValue> values = new Dictionary<string, ConfigValue>();

        public void SetString(string key, string value)
        {
            values[key] = new ConfigValue(value);
        }

        public string GetString(string key, string def = "")
        {
            if (values.ContainsKey(key))
            {
                var obj = values[key];

                if (obj.boxedType == ConfigValue.Type.String)
                    return (string)obj.boxedValue;
                else
                    return Convert.ToString(obj.boxedValue);
            }
            else
                return def;
        }

        public void SetInt(string key, int value)
        {
            values[key] = new ConfigValue(value);
        }

        public int GetInt(string key, int def = 0)
        {
            if (values.ContainsKey(key))
            {
                var obj = values[key];

                if (obj.boxedType == ConfigValue.Type.Integer)
                    return (int)obj.boxedValue;
                else
                    return Convert.ToInt32(obj.boxedValue);
            }
            else
                return def;
        }

        public void SetBoolean(string key, bool b)
        {
            values[key] = new ConfigValue(b);
        }

        public bool GetBoolean(string key, bool def = false)
        {
            if (values.ContainsKey(key))
            {
                var obj = values[key];

                if (obj.boxedType == ConfigValue.Type.Boolean)
                    return (bool)obj.boxedValue;
                else
                    return Convert.ToBoolean(obj.boxedValue);
            }
            else
                return def;
        }

        public void UpdateAutocomplete(string key, string url, int count = -1)
        {
            if (values.ContainsKey(key))
            {
                var obj = values[key];

                if (obj.boxedType == ConfigValue.Type.AutocompleteList)
                {
                    var acl = (List<AutocompleteData>)obj.boxedValue;
                    int updated = acl.Update(p => p.url == url,
                        upd => new AutocompleteData(upd.url, count == -1 ? upd.count + 1 : count));

                    if (updated == 0)
                        acl.Add(new AutocompleteData(url, count == -1 ? 1 : count));
                }
                else
                    throw new Exception("bad type");
            }
            else
            {
                List<AutocompleteData> lst = new List<AutocompleteData>();
                lst.Add(new AutocompleteData(url, count == -1 ? 1 : count));
                values[key] = new ConfigValue(lst);
            }
        }

        public bool RemoveAutocomplete(string key, string url)
        {
            if (values.ContainsKey(key))
            {
                var obj = values[key];

                if (obj.boxedType == ConfigValue.Type.AutocompleteList)
                {
                    var acl = (List<AutocompleteData>)obj.boxedValue;
                    return acl.RemoveIf(p => p.url == url) > 0;
                }
                else
                    throw new InvalidCastException("internal config type is not List<AutocompleteData>");
            }
            else
                return false;
        }

        public List<AutocompleteData> GetAutocomplete(string key)
        {
            if (values.ContainsKey(key))
            {
                var obj = values[key];

                if (obj.boxedType == ConfigValue.Type.AutocompleteList)
                    return (List<AutocompleteData>)obj.boxedValue;
            }

            return null;
        }

        public void SetAutocomplete(string newKey, List<AutocompleteData> ad)
        {
            values[newKey] = new ConfigValue(ad);
        }

        public void SetListOfStrings(string key, List<string> list)
        {
            values[key] = new ConfigValue(list);
        }

        public List<string> GetListOfStrings(string key)
        {
            if (values.ContainsKey(key))
            {
                var obj = values[key];

                if (obj.boxedType == ConfigValue.Type.ListOfStrings)
                    return (List<string>)obj.boxedValue;
            }

            throw new KeyNotFoundException();
        }

        public void LoadConfiguration(string file)
        {
            if (!System.IO.File.Exists(file))
                return;

            XmlReaderSettings xrs = new XmlReaderSettings();
            xrs.CloseInput = true;

            using (XmlReader xmlr = XmlReader.Create(file, xrs))
            {
                while (xmlr.Read())
                {
                    if (xmlr.NodeType == XmlNodeType.Element)
                    {
                        string nodeName = xmlr.GetAttribute("name");

                        switch (xmlr.Name)
                        {
                            case "boolean":
                                SetBoolean(nodeName, xmlr.ReadString() == "y");
                                break;

                            case "integer":
                                SetInt(nodeName, int.Parse(xmlr.ReadString()));
                                break;

                            case "string":
                                SetString(nodeName, xmlr.ReadString());
                                break;

                            case "autocomplete":
                                xmlr.ReadToDescendant("entry");

                                do
                                {
                                    int c = int.Parse(xmlr.GetAttribute("count"));
                                    string url = xmlr.ReadString();

                                    UpdateAutocomplete(nodeName, url, c);
                                } while (xmlr.ReadToNextSibling("entry"));
                                break;

                            case "values":
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public void SaveConfiguration(string file)
        {
            XmlWriterSettings xmls = new XmlWriterSettings();
            xmls.CloseOutput = true;
            xmls.Encoding = Encoding.UTF8;
            xmls.Indent = true;
            xmls.IndentChars = "\t";

            using (XmlWriter xmlw = XmlWriter.Create(file, xmls))
            {
                xmlw.WriteStartDocument(true);
                xmlw.WriteStartElement("values");

                foreach (var it in values)
                {
                    switch (it.Value.boxedType)
                    {
                        case ConfigValue.Type.Boolean:
                            xmlw.WriteTag("boolean", ((bool)it.Value.boxedValue) ? "y" : "f",
                                new Dictionary<string, string>{
                                    { "name", it.Key }
                                });
                            break;

                        case ConfigValue.Type.Integer:
                            xmlw.WriteTag("integer", ((int)it.Value.boxedValue).ToString(),
                                new Dictionary<string, string>{
                                    { "name", it.Key }
                                });
                            break;

                        case ConfigValue.Type.String:
                            xmlw.WriteTag("string", (string)it.Value.boxedValue,
                                new Dictionary<string, string>{
                                    { "name", it.Key }
                                });
                            break;

                        case ConfigValue.Type.ListOfStrings:
                            xmlw.StartTag("stringlist",
                                new Dictionary<string, string>{
                                    { "name", it.Key }
                                });
                            List<string> lst = (List<string>)it.Value.boxedValue;

                            foreach (var jt in lst)
                                xmlw.WriteTag("string", jt);

                            xmlw.EndTag();
                            break;

                        case ConfigValue.Type.AutocompleteList:
                            xmlw.StartTag("autocomplete",
                                new Dictionary<string, string>{
                                    { "name", it.Key }
                                });
                            List<AutocompleteData> alst = (List<AutocompleteData>)it.Value.boxedValue;

                            foreach (var jt in alst)
                                xmlw.WriteTag("entry", jt.url,
                                    new Dictionary<string, string>{
                                        { "count", jt.count.ToString() }
                                    });

                            xmlw.EndTag();
                            break;
                    }
                }

                xmlw.WriteEndElement();
                xmlw.WriteEndDocument();
            }
        }
    }

    public class ConfigurationDatabaseProxy
    {
        private ConfigurationDatabase innerDatabase;
        private string prefix;

        public ConfigurationDatabaseProxy( ConfigurationDatabase cdb, string prefix )
        {
            innerDatabase = cdb;
            this.prefix = prefix;
        }

        public void SetString(string key, string value, bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;

            innerDatabase.SetString(newKey, value);
        }

        public string GetString(string key, string def = "",
            bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;

            return innerDatabase.GetString(newKey, def);
        }

        public void SetInt(string key, int value, bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            innerDatabase.SetInt(newKey, value);
        }

        public int GetInt(string key, int def = 0, bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            return innerDatabase.GetInt(newKey);
        }

        public void SetBoolean(string key, bool b, bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            innerDatabase.SetBoolean(newKey, b);
        }

        public bool GetBoolean(string key, bool def = false,
            bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            return innerDatabase.GetBoolean(newKey, def);
        }

        public void UpdateAutocomplete(string key, string url,
            bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            innerDatabase.UpdateAutocomplete(newKey, url);
        }

        public bool RemoveAutocomplete(string key, string url,
            bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            return innerDatabase.RemoveAutocomplete(newKey, url);
        }

        public List<ConfigurationDatabase.AutocompleteData>
            GetAutocomplete(string key, bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            return innerDatabase.GetAutocomplete(newKey);
        }

        public void SetListOfStrings(string key, List<string> list,
            bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            innerDatabase.SetListOfStrings(newKey, list);
        }

        public List<string> GetListOfStrings(string key, bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            return innerDatabase.GetListOfStrings(newKey);
        }

        public void SetAutocomplete(string key, List<ConfigurationDatabase.AutocompleteData> ad, bool withPrefix = true)
        {
            string newKey = withPrefix ? prefix + "." + key : key;
            innerDatabase.SetAutocomplete(newKey, ad);
        }
    }
}
