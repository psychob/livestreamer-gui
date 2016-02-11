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
    static class ExtenstionMethods
    {
        public static int Update<T>(this List<T> lst, Predicate<T> pred,
            Func<T, T> updater)
        {
            int count = 0;

            for (int it = 0; it < lst.Count; ++it)
            {
                if (pred(lst[it]))
                {
                    lst[it] = updater(lst[it]);
                    count++;
                }
            }

            return count;
        }

        public static int RemoveIf<T>(this List<T> lst, Predicate<T> pred)
        {
            int ret = 0;

            for (int it = 0; it < lst.Count; ++it)
            {
                if (pred(lst[it]))
                {
                    lst.RemoveAt(it);
                    ret++;
                    it--;
                }
            }

            return ret;
        }

        public static T[] Rewrite<T,U>(this List<U> lst, Func<U, T> rewriter)
        {
            if (lst.Count == 0)
                return null;

            T[] rarr = new T[lst.Count];

            for (int it = 0; it < lst.Count; ++it)
                rarr[it] = rewriter(lst[it]);

            return rarr;
        }

        public static void WriteTag(this XmlWriter xml, string tagname,
            string value, Dictionary<string, string> attributes = null)
        {
            xml.WriteStartElement(tagname);

            if ( attributes != null)
            {
                foreach (var it in attributes)
                    xml.WriteAttributeString(it.Key, it.Value);
            }

            xml.WriteString(value);

            xml.WriteEndElement();
        }

        public static void StartTag(this XmlWriter xml, string name,
            Dictionary<string, string> attributes = null)
        {
            xml.WriteStartElement(name);

            if (attributes != null)
            {
                foreach (var it in attributes)
                    xml.WriteAttributeString(it.Key, it.Value);
            }
        }

        public static void EndTag(this XmlWriter xml)
        {
            xml.WriteEndElement();
        }

        public static string GetUserPath()
        {
            return System.IO.Directory.GetParent(System.Windows.Forms.Application.UserAppDataPath).FullName;
        }

        public static string Escape(this string str)
        {
            return '"' + str.EscapeWithout() + '"';
        }

        public static string EscapeWithout(this string str)
        {
            return str.Replace("\"", "\\\"");
        }

        public static int IndexOf<T>(this T[] val, T item)
        {
            for (int it = 0; it < val.Length; ++it)
                if (val[it].Equals(item))
                    return it;

            return -1;
        }
    }
}
