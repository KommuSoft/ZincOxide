//
//  OOCodegenResultContract.cs
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
using ZincOxide.Codegen.Abstract.OO;
using System.Diagnostics.Contracts;

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// A contract class that enables contracts for <see cref="IOOCodegenResult"/> inheritance.
	/// </summary>
	[ContractClassFor(typeof(IOOCodegenResult))]
	public abstract class OOCodegenResultContract : CodegenResultContract, IOOCodegenResult {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="OOCodegenResultContract"/> class used to bind contracts
		/// on the <see cref="IOOCodegenResult"/> instances.
		/// </summary>
		protected OOCodegenResultContract () {
		}
		#endregion
		#region IOOCodegenResult implementation
		/// <summary>
		/// Generate a class with the given name.
		/// </summary>
		/// <param name="name">The name of the class that must be generated/returned.</param>
		/// <exception cref="ArgumentNullException">If the given name is not effective.</exception>
		/// <returns>The class.</returns>
		public IClass GenerateClass (string name) {
			Contract.Requires (name != null);
			Contract.Requires (name != string.Empty);
			Contract.Ensures (Contract.Result<IClass> () != null);
			return default(IClass);
		}
		#endregion
	}
}

