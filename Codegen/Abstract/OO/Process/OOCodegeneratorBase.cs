//
//  OOCodegeneratorBase.cs
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

namespace ZincOxide.Codegen.Abstract.OO.Process {

	/// <summary>
	/// A basic implementation of the <see cref="IOOCodegenerator"/>, used for
	/// programming convenience in the object-oriented programming paradigm.
	/// </summary>
	public abstract class OOCodegeneratorBase : CodegeneratorBase, IOOCodegenerator {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="OOCodegeneratorBase"/> class.
		/// </summary>
		protected OOCodegeneratorBase () {
		}
		#endregion
		#region IOOCodegenerator implementation
		/// <summary>
		/// Generate code in the object-oriented programming paradigm using the given <see cref="IOOCodegenResult"/>
		/// and alter it.
		/// </summary>
		/// <param name="result">The instance that must be modified.</param>
		public abstract void GenerateCode (IOOCodegenResult result);
		#endregion
		#region ICodegenerator implementation
		/// <summary>
		/// Alter the given <paramref name="result"/> by generating or modifying code.
		/// </summary>
		/// <param name="result">The <see cref="ICodegenResult"/> instance that stores the genrated code.</param>
		/// <exception cref="ZincOxideBugException">If the given <see cref="ICodegenResult"/> uses the wrong
		/// programming paradigm.</exception>
		public override void GenerateCode (ICodegenResult result) {
			IOOCodegenResult roo = result as IOOCodegenResult;
			if (roo != null) {
				GenerateCode (roo);
			} else {
				throw new ZincOxideBugException ("The program has mixed up the provided programming paradigms.");
			}
		}
		#endregion
	}
}

