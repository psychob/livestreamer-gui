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
    class ConfigurationDatabase
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

        private Dictionary<string, ConfigValue> values;

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

        public void UpdateAutocomplete(string key, string url)
        {
            if (values.ContainsKey(key))
            {
                var obj = values[key];

                if (obj.boxedType == ConfigValue.Type.AutocompleteList)
                {
                    var acl = (List<AutocompleteData>)obj.boxedValue;
                    acl.Update(p => p.url == url,
                        upd => new AutocompleteData(upd.url, upd.count));
                }
                else
                    throw new Exception("bad type");
            }
            else
            {
                List<AutocompleteData> lst = new List<AutocompleteData>();
                lst.Add(new AutocompleteData(url));
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

            throw new KeyNotFoundException();
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
    }

    class ConfigurationDatabaseProxy
    {
        private ConfigurationDatabase innerDatabase;
        private string prefix;

        public ConfigurationDatabaseProxy( ConfigurationDatabase cdb, string prefix )
        {
            innerDatabase = cdb;
            this.prefix = prefix;
        }

        public void SetString(string key, string value)
        {
            innerDatabase.SetString(prefix + "." + key, value);
        }

        public string GetString(string key, string def = "")
        {
            return innerDatabase.GetString(prefix + "." + key, def);
        }

        public void SetInt(string key, int value)
        {
            innerDatabase.SetInt(prefix + "." + key, value);
        }

        public int GetInt(string key, int def = 0)
        {
            return innerDatabase.GetInt(prefix + "." + key);
        }

        public void SetBoolean(string key, bool b)
        {
            innerDatabase.SetBoolean(prefix + "." + key, b);
        }

        public bool GetBoolean(string key, bool def = false)
        {
            return innerDatabase.GetBoolean(prefix + "." + key, def);
        }

        public void UpdateAutocomplete(string key, string url)
        {
            innerDatabase.UpdateAutocomplete(prefix + "." + key, url);
        }

        public bool RemoveAutocomplete(string key, string url)
        {
            return innerDatabase.RemoveAutocomplete(prefix + "." + key, url);
        }

        public List<ConfigurationDatabase.AutocompleteData> GetAutocomplete(string key)
        {
            return innerDatabase.GetAutocomplete(prefix + "." + key);
        }

        public void SetListOfStrings(string key, List<string> list)
        {
            innerDatabase.SetListOfStrings(prefix + "." + key, list);
        }

        public List<string> GetListOfStrings(string key)
        {
            return innerDatabase.GetListOfStrings(prefix + "." + key);
        }
    }
}
