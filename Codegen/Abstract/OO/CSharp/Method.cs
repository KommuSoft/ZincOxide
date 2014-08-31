//
//  Method.cs
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

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// The representation of a <see cref="IMethod"/> in C#.
	/// </summary>
	public class Method : MethodBase {

		#region Fields
		private readonly CodeMemberMethod data;
		#endregion
		#region implemented abstract members of NameShadow
		/// <summary>
		/// Gets the name of this instance.
		/// </summary>
		/// <value>The name of this instance.</value>
		public override string Name {
			get {
				return data.Name;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Method"/> class with the given data specifying the
		/// method.
		/// </summary>
		/// <param name="data">The given <see cref="CodeMemberMethod"/> that specifies the method.</param>
		internal Method (CodeMemberMethod data) {
			this.data = data;
		}
		#endregion
	}
}

