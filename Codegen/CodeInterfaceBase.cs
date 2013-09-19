//
//  CodeInterfaceBase.cs
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

    public class CodeInterfaceBase : NameBase {

        private ICodePackage package;
        private readonly List<ICodeInterface> superInterfaces = new List<ICodeInterface> ();

        public ICodePackage Package {
            get {
                return this.package;
            }
        }

        public List<ICodeInterface> SuperInterfaces {
            get {
                return this.superInterfaces;
            }
        }

        public CodeInterfaceBase (string name, ICodePackage package = null, params ICodeInterface[] interfaces) : this(name,package,(IEnumerable<ICodeInterface>) interfaces) {
        }

        public CodeInterfaceBase (string name, ICodePackage package, IEnumerable<ICodeInterface> interfaces) : base(name) {
            this.package = package;
            this.superInterfaces.AddRange (interfaces);
        }

    }
}

