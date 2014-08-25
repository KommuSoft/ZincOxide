//
//  CodegenEnvironment.cs
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
using System.Diagnostics.Contracts;
using ZincOxide.Utils.Abstract;

namespace ZincOxide.Codegen {

	/// <summary>
	/// A basic implementation of the <see cref="ICodegenEnvironment"/> interface. A class
	/// that stores parameters to generate code with.
	/// </summary>
	public class CodegenEnvironment : ICodegenEnvironment {

		#region Fields
		private string _namespace = "Sample";
		private string _classprefix = "Problem";
		#endregion
		#region ICodegenEnvironment implementation
		/// <summary>
		/// Get the namespace that should be used for code generation.
		/// </summary>
		/// <value>The namespace used in the code generation process.</value>
		public string Namespace {
			get {
				return _namespace;
			}
			protected set {
				Contract.Ensures (this._namespace != null);
				this._namespace = value.IfNull (string.Empty);
			}
		}

		/// <summary>
		/// Get the prefix that should be used in front of all classes, interfaces, etc. names.
		/// </summary>
		/// <value>The prefix used in from of all classes, interfaces, etc.</value>
		public string ClassPrefix {
			get {
				return _classprefix;
			}
			protected set {
				Contract.Ensures (this._namespace != null);
				this._classprefix = value.IfNull (string.Empty);
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CodegenEnvironment"/> class.
		/// </summary>
		public CodegenEnvironment () {
		}
		#endregion
	}
}

