//
//  CodegeneratorContract.cs
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

namespace ZincOxide.Codegen.Abstract.Result {

	/// <summary>
	/// A contract class for <see cref="ICodegenerator"/> instances.
	/// </summary>
	[ContractClassFor(typeof(ICodegenerator))]
	public abstract class CodegeneratorContract : ICodegenerator {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CodegeneratorContract"/> class.
		/// </summary>
		protected CodegeneratorContract () {
		}
		#endregion
		#region ICodegenerator implementation
		/// <summary>
		/// Alter the given <paramref name="result"/> by generating or modifying code.
		/// </summary>
		/// <param name="result">The <see cref="ICodegenResult"/> instance that stores the genrated code.</param>
		/// <remarks>
		/// <para>One can assume the <paramref name="result"/> is always effective.</para>
		/// </remarks>
		public void GenerateCode (ICodegenResult result) {
			Contract.Requires (result != null);
		}
		#endregion
	}
}

