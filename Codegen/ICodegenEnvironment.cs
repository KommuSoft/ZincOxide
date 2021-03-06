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

namespace ZincOxide.Codegen {

	/// <summary>
	/// An interface describing the environment in which code should be generated (like namespaces, class names, etc.).
	/// </summary>
	[ContractClass(typeof(CodegenEnvironmentContract))]
	public interface ICodegenEnvironment {

		/// <summary>
		/// Get the namespace that should be used for code generation.
		/// </summary>
		/// <value>The namespace used in the code generation process.</value>
		string Namespace {
			get;
		}

		/// <summary>
		/// Get the prefix that should be used in front of all classes, interfaces, etc. names.
		/// </summary>
		/// <value>The prefix used in from of all classes, interfaces, etc.</value>
		string ClassPrefix {
			get;
		}
	}
}

