//
//  EnumerableUtils.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;

namespace ZincOxide.Utils {

    public static class EnumerableUtils {

        public static IEnumerable<T> Empty<T> () {
            yield break;
        }

        public static IEnumerable<T> Append<T> (T value, params IEnumerable<T>[] lists) {
            yield return value;
            foreach (IEnumerable<T> list in lists) {
                foreach (T val in list) {
                    yield return val;
                }
            }
        }

        public static bool All<T,Q> (this IEnumerable<T> sourcex, IEnumerable<Q> sourcey, Func<T,Q,bool> function) {
            IEnumerator<T> enumx = sourcex.GetEnumerator ();
            IEnumerator<Q> enumy = sourcey.GetEnumerator ();
            bool movex = enumx.MoveNext ();
            bool movey = enumy.MoveNext ();
            while (movex && movey) {
                if (!function (enumx.Current, enumy.Current)) {
                    return false;
                }
                movex = enumx.MoveNext ();
                movey = enumy.MoveNext ();
            }
            return movex == movey;
        }

        public static IEnumerable<T> Append<T> (params IEnumerable<T>[] lists) {
            return Append (lists);
        }

        public static IEnumerable<T> Append<T> (IEnumerable<IEnumerable<T>> lists) {
            if (lists != null) {
                foreach (IEnumerable<T> list in lists) {
                    if (list != null) {
                        foreach (T t in list) {
                            yield return t;
                        }
                    }
                }
            }
        }

    }
}

