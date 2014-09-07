//
//  CodegenResultAttribute.cs
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

namespace ZincOxide.Codegen.Abstract {

	/// <summary>
	/// An attribute that specifies the programming language and attributes of a <see cref="ICodegenResult"/> implementation.
	/// </summary>
	/// <remarks>
	/// <para>The attributes are used to make code generation more generic.</para>
	/// </remarks>
	[AttributeUsage(AttributeTargets.Class)]
	public class CodegenResultAttribute : Attribute {

		#region Properties
		/// <summary>
		/// Get the name of the programming language.
		/// </summary>
		/// <value>A <see cref="string"/> that stores the name of the programming language.</value>
		public string ProgrammingLanguage {
			get;
			private set;
		}

		/// <summary>
		/// Get the paradigms supported by the programming language described by the
		/// <see cref="ICodegenResult"/>.
		/// </summary>
		/// <value>A <see cref="ProgrammingLanguageParadigm"/> value that enumerates
		/// the supported programming language paradigms.</value>
		public ProgrammingLanguageParadigm SupportedParadigms {
			get;
			private set;
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CodegenResultAttribute"/> class with the given programming language
		/// name and its supported paradigms.
		/// </summary>
		/// <param name="programmingLanguage">The name of the programming language.</param>
		/// <param name="paradigms">The programming languages supported by the programming language.</param>
		public CodegenResultAttribute (string programmingLanguage, ProgrammingLanguageParadigm paradigms) {
			this.ProgrammingLanguage = programmingLanguage;
			this.SupportedParadigms = paradigms;
		}
		#endregion
	}
}

