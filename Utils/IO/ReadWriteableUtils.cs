//
//  WritableUtils.cs
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
using System.IO;

namespace ZincOxide.Utils {

    public static class ReadWriteableUtils {

        public static void Write (this IWriteable writeable, Stream stream) {
            using (StreamWriter sw = new StreamWriter (stream)) {
                writeable.Write (sw);
            }
        }

        public static void Write (this IWriteable writeable, string filename, FileMode mode = FileMode.OpenOrCreate) {
            using (FileStream fs = File.Open (filename, mode, FileAccess.Write)) {
                writeable.Write (fs);
            }
        }

        public static void Read (this IReadable readable, Stream stream) {
            using (StreamReader sr = new StreamReader (stream)) {
                readable.Read (sr);
            }
        }

        public static void Read (this IReadable readable, string filename, FileMode mode = FileMode.OpenOrCreate) {
            using (FileStream fs = File.Open (filename, mode, FileAccess.Read)) {
                readable.Read (fs);
            }
        }

        public static string WriteString (this IWriteable writeable) {
            string result;
            using (MemoryStream ms = new MemoryStream ()) {
                writeable.Write (ms);
                using (MemoryStream ms2 = new MemoryStream (ms.ToArray ())) {
                    using (StreamReader tr = new StreamReader (ms2)) {
                        result = tr.ReadToEnd ();
                    }
                }
            }
            return result;
        }

    }

}

