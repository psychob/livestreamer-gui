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
    static class ExtenstionMethods
    {
        public static void Update<T>(this List<T> lst, Predicate<T> pred,
            Func<T, T> updater)
        {
            for (int it = 0; it < lst.Count; ++it)
            {
                if (pred(lst[it]))
                    lst[it] = updater(lst[it]);
            }
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
    }
}
