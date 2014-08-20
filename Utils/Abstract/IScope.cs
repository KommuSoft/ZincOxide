//
//  IScope.cs
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
using System.Collections.Generic;

namespace ZincOxide.Utils.Abstract {

	/// <summary>
	/// An interface that describes that the object contains a hierachy of scopes.
	/// </summary>
	/// <remarks>
	/// <para>Scopes contain a certain context, depending of the scope, the meaning of a certain identifer
	/// can be overridden.</para>
	/// </remarks>
	public interface IScope<T> : ICollection<T> {

		/// <summary>
		/// Gets the parent scope of this scope.
		/// </summary>
		/// <value>
		/// The parent scope of this scope.
		/// </value>
		/// <remarks>
		/// <para>If no parent scope is available, <c>null</c> is returned.</para>
		/// </remarks>
		IScope<T> Parent {
			get;
		}

	}
}

