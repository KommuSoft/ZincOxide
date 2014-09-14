//
//  Namespace.cs
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
using ZincOxide.Utils.Abstract;
using System.Diagnostics.Contracts;
using ZincOxide.Codegen.Abstract.OO;

namespace ZincOxide.Codegen.Languages.CSharp {

	/// <summary>
	/// The implementation of a namespace for the C# programming language.
	/// </summary>
	public class Namespace : NameShadow, INamespace {

		#region Field
		private readonly CodeNamespace data;
		#endregion
		#region IName implementation
		/// <summary>
		/// Gets the name of this C# namespace.
		/// </summary>
		/// <value>The name of this C# namespace.</value>
		public override string Name {
			get {
				return data.Name;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Namespace"/> class: a CSharp namespace.
		/// </summary>
		internal Namespace (CodeNamespace data) {
			Contract.Requires (data != null);
			Contract.Ensures (this.data != null);
			this.data = data;
		}
		#endregion
	}
}

