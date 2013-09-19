//
//  CodeBuilderBase.cs
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
using System.Collections.Generic;

namespace ZincOxide.Codegen {

    public abstract class CodeBuilderBase : ICodeBuilder {

        private readonly List<ICodeInterface> interfaces = new List<ICodeInterface> ();

        public CodeBuilderBase () {
        }

        public IEnumerable<T> Interfaces<T> () where T : ICodeInterface {
            foreach (ICodeInterface iface in this.interfaces) {
                if (iface is T) {
                    yield return (T)iface;
                }
            }
        }

        #region ICodeBuilder implementation
        public abstract ICodePackage NewPackage (string name);

        public abstract ICodeInterface NewInterface (ICodePackage package, string name, params ICodeInterface[] iface);

        public abstract IEnumerable<ICodeFile> Generate ();
        #endregion

    }

}

