//
//  CodeInterfaceCSharp.cs
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
using ZincOxide.Utils;
using ZincOxide.Codegen.Base;

namespace ZincOxide.Codegen.CSharp {

    public class CodeInterfaceCSharp : CodeInterfaceBase, IContextWriteable {

        public override string Name {
            get {
                return base.Name;
            }
            protected set {
                if (CSharpUtils.ValidIdentifier (value)) {
                    base.Name = value;
                } else {
                    throw new ZincOxideCodeGenException ("The name of the interface is not a valid C# name.");
                }
            }
        }

        public CodeInterfaceCSharp (string name, ICodePackage package = null, params ICodeInterface[] interfaces) : base(name,package,interfaces) {
        }

        #region IWriteable implementation
        public void Write (ContextStreamWriter writer) {
            if (this.Package != null) {
                writer.WriteLine ("namespace {0} {", this.Package.Name);
                writer.WriteLine ();
            }
            writer.Write ("\tpublic interface {0}", this.Name);
            if (this.SuperInterfaces.Count > 0x00) {
                writer.Write (" : {0}", string.Join (", ", this.SuperInterfaces));
            }
            writer.WriteLine (" {");
            writer.WriteLine ("\t}");
            writer.WriteLine ("}");
        }
        #endregion


    }

}

