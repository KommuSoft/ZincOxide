//
//  CSharpCodegenResult.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2014 Willem Van Onsem
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
using System.CodeDom;
using System.Diagnostics.Contracts;
using System.IO;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using ZincOxide.Codegen.Abstract.OO.Process;

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// A code generator for the C# language.
	/// </summary>
	/// <remarks>
	/// <para>C# enables several classes to be written all in the same file.</para>
	/// </remarks>
	public class CSharpCodegenResult : OOCodegenResultBase {

		#region Fields
		private readonly CodeCompileUnit ccu = new CodeCompileUnit ();
		private readonly CodeNamespace cn;
		#endregion
		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="CSharpCodegenResult"/> class where the result
		/// of a code generator process can be stored and emitted.
		/// </summary>
		/// <param name='environment'>The environment that describes how the code should be written.</param>
		/// <exception cref="ArgumentNullException">If the given environment is not effective.</exception>
		public CSharpCodegenResult (ICodegenEnvironment environment) : base(environment) {
			this.cn = new CodeNamespace (environment.Namespace);
			this.ccu.Namespaces.Add (this.cn);
		}
		#endregion
		#region implemented abstract members of OOCodegenResultBase
		/// <summary>
		/// Generate a class with the given name.
		/// </summary>
		/// <param name="name">The name of the class that must be generated/returned.</param>
		/// <returns>A <see cref="IClass"/> instance that represents the generated class.</returns>
		/// <remarks>
		/// <para>The name is prefixed with the <see cref="P:ICodegenEnvironment.ClassPrefix"/> name automatically.</para>
		/// </remarks>
		public override IClass GenerateClass (string name) {
			Contract.Requires (name != null);
			Contract.Requires (name != string.Empty);
			Contract.Ensures (Contract.Result<IClass> () != null);
			Contract.Ensures (Contract.Result<IClass> ().Name != null);
			Contract.Ensures (Contract.Result<IClass> ().Name == this.Environment.ClassPrefix + name);
			CodeTypeDeclaration ctd = new CodeTypeDeclaration (this.Environment.ClassPrefix + name);
			this.cn.Types.Add (ctd);
			return new Class (ctd);
		}

		/// <summary>
		/// Get the type that corresponds with the given integer representation (abstract) type for the specific language.
		/// </summary>
		/// <returns>A <see cref="IType"/> that corresponds to the given integer representation type.</returns>
		/// <param name="pir">The given integer representation type, optional, by default a 32-bit integer.</param>
		public override IType GetIntegerType (ZincOxide.Environment.ProgramIntegerRepresentation pir = (ZincOxide.Environment.ProgramIntegerRepresentation)2L) {
			throw new NotImplementedException ();
		}

		/// <summary>
		/// Get the type that corresponds with the given float representation (abstract) type for the specific language.
		/// </summary>
		/// <returns>A <see cref="IType"/> that corresponds to the given float representation type.</returns>
		/// <param name="pfr">The given float representation type, optional, by default a 64-bit float.</param>
		public override IType GetFloatType (ProgramFloatRepresentation pfr = (ProgramFloatRepresentation)32) {
			throw new NotImplementedException ();
		}
		#endregion
		#region implemented abstract members of CodegenResultBase
		/// <summary>
		/// Emit the generated code to file, the standard output or print the appropriate errors.
		/// </summary>
		public override void Emit () {
			using (CSharpCodeProvider cscp = new CSharpCodeProvider()) {
				using (StreamWriter sw = new StreamWriter(this.Environment.FileName,false)) {
					using (IndentedTextWriter itw = new IndentedTextWriter(sw)) {
						cscp.GenerateCodeFromCompileUnit (this.ccu, itw, new CodeGeneratorOptions ());
					}
				}
			}
		}
		#endregion
	}
}

