//
//  CodePackageCSharp.cs
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
using ZincOxide.Utils;
using ZincOxide.Codegen.Base;

namespace ZincOxide.Codegen.CSharp {

    public class CodePackageCSharp : CodePackageBase {

        public override string Name {
            get {
                return base.Name;
            }
            protected set {
                if (CSharpUtils.ValidPackage (value)) {
                    base.Name = value;
                } else {
                    throw new ZincOxideCodeGenException ("Invalid package name for C#.");
                }
            }
        }

        #region implemented abstract members of ZincOxide.Codegen.CodePackageBase
        public override string Path {
            get {
                return string.Format ("{0}/", this.Name.Replace ('.', '/'));
            }
        }
        #endregion

        public CodePackageCSharp (string name) : base(name) {
        }

    }
}

