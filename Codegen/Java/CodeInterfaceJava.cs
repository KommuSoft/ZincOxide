//
//  CodeInterfaceJava.cs
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

namespace ZincOxide.Codegen.Java {

    public class CodeInterfaceJava : CodeInterfaceBase, IContextWriteable {

        public override string Name {
            get {
                return base.Name;
            }
            protected set {
                if (JavaUtils.ValidIdentifier (value)) {
                    base.Name = value;
                } else {
                    throw new ZincOxideCodeGenException ("The name of the interface is not a valid Java name.");
                }
            }
        }

        public CodeInterfaceJava (string name, ICodePackage package = null, params ICodeInterface[] interfaces) : base(name,package,interfaces) {
        }

        #region IWriteable implementation
        public void Write (ContextStreamWriter writer) {
            if (this.Package != null) {
                writer.WriteLine ("package {0};", this.Package.Name);
                writer.WriteLine ();
            }
            writer.Write ("public interface {0}", this.Name);
            if (this.SuperInterfaces.Count > 0x00) {
                writer.Write (" extends {0}", string.Join (", ", this.SuperInterfaces));
            }
            writer.WriteLine (" {");
            writer.WriteLine ("}");
        }
        #endregion


    }

}

