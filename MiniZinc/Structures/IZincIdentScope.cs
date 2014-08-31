//
//  IZincIdentScope.cs
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
using ZincOxide.Utils.Nameregister;

namespace ZincOxide.MiniZinc.Structures {

	/// <summary>
	/// An interface specifying that this instance is an object that scopes <see cref="IZincIdent"/> instances.
	/// A scope contains a name register (with fallback mechanism to the parent scope).
	/// </summary>
	public interface IZincIdentScope {

		/// <summary>
		/// Gets the name register associated with the scope. It stores the identifiers defined in the scope and is used
		/// to bind/cut identifiers.
		/// </summary>
		/// <value>The name register associated with the scope.</value>
		ZincIdentNameRegister NameRegister {
			get;
		}

		/// <summary>
		/// Closes the scope, used at the end of adding items to the scope.
		/// </summary>
		/// <param name="scope">The outer scope, used to attach a fallback mechanism to each
		/// scope, optionally, by default not effective.</param>
		/// <remarks>
		/// <para>When the scope closes, several operations are carried out: identifiers used in the scope
		/// that are defined in the scope as well are redirected to the assignment identifier.</para>
		/// </remarks>
		void CloseScope (IZincIdentScope scope = null);
	}
}