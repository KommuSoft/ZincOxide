//
//  CSharpTypeContract.cs
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
using System.CodeDom;
using ZincOxide.Codegen.Abstract.Typed;

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// A contract class for <see cref="ICSharpType"/> instances.
	/// </summary>
	[ContractClassFor(typeof(ICSharpType))]
	public abstract class CSharpTypeContract : TypeContract, ICSharpType {
		#region ICSharpType implementation
		/// <summary>
		/// Get a reference to this type, used for implementation and the creation of code members.
		/// </summary>
		/// <value>A <see cref="CodeTypeReference"/> that refers to this type.</value>
		/// <remarks>
		/// <para>The reference is guaranteed to be effective.</para>
		/// </remarks>
		public CodeTypeReference Reference {
			get {
				Contract.Ensures (Contract.Result<CodeTypeReference> () != null);
				return default(CodeTypeReference);
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CSharpTypeContract"/> class.
		/// </summary>
		protected CSharpTypeContract () {
		}
		#endregion
	}
}