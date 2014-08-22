//
//  ZincRelationAttribute.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
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

namespace ZincOxide.MiniZinc.Builtins {

	/// <summary>
	/// An attribute to register builtin predicates, functions and other identifiers.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class ZincBuiltinRelationAttribute : Attribute {
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincBuiltinRelationAttribute"/> class. This attribute should
		/// only be initialized on classes to register builtin relations.
		/// </summary>
		public ZincBuiltinRelationAttribute () {
		}
		#endregion
	}
}

