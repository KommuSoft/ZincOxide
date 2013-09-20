//
//  CodeFileBase.cs
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
using System;
using ZincOxide.Utils;

namespace ZincOxide.Codegen.Base {

    public abstract class CodeFileBase : NameBase, ICodeFile {

        protected CodeFileBase (string name) : base(name) {
        }

        #region ICodeFile implementation
        public abstract void Write (Stream stream);

        public string GetText () {
            string result;
            using (MemoryStream ms = new MemoryStream ()) {
                this.Write (ms);
                using (MemoryStream ms2 = new MemoryStream (ms.ToArray ())) {
                    using (StreamReader tr = new StreamReader (ms2)) {
                        result = tr.ReadToEnd ();
                    }
                }
            }
            return result;
        }
        #endregion

        public override string ToString () {
            return this.GetText ();
        }

    }
}

