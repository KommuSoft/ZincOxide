//
//  CodegeneratorBase.cs
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
using ZincOxide.Exceptions;

namespace ZincOxide.Codegen.Abstract.Result {

	/// <summary>
	/// A basic implementation of the <see cref="ICodegenerator"/> interface, used for programming convenience.
	/// </summary>
	public abstract class CodegeneratorBase : ICodegenerator {

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the <see cref="CodegeneratorBase"/> class, an abstract
		/// code generator used.
		/// </summary>
		protected CodegeneratorBase () {
		}
		#endregion
		#region ICodegenerator implementation
		/// <summary>
		/// Alter the given <paramref name="result"/> by generating or modifying code.
		/// </summary>
		/// <param name="result">The <see cref="ICodegenResult"/> instance that stores the genrated code.</param>
		/// <exception cref="ZincOxideBugException">If the given <see cref="ICodegenResult"/> uses the wrong
		/// programming paradigm.</exception>
		public abstract void GenerateCode (ICodegenResult result);
		#endregion
	}
}

