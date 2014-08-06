//
//  ZincScopeElementBase.cs
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
using ZincOxide.Utils.Designpatterns;
using ZincOxide.Utils.Nameregister;
using System.Collections.Generic;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Structures {

	/// <summary>
	/// A basic implementation of the <see cref="IZincScopeElement"/> interface: a scope where identifiers are defined
	/// and where identifiers should be binded to the appropriate identifier.
	/// </summary>
	public abstract class ZincScopeElementBase : IZincScopeElement {

		#region Fields
		/// <summary>
		/// The name registers that stores the defined identifiers in the scope.
		/// </summary>
		private ZincIdentNameRegister nameRegister;
		#endregion
		#region IZincIdentScope implementation
		/// <summary>
		/// Gets the name register associated with the scope. It stores the identifiers defined in the scope and is used
		/// to bind/cut identifiers.
		/// </summary>
		/// <value>The name register associated with the scope.</value>
		public ZincIdentNameRegister NameRegister {
			get {
				return this.nameRegister;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincScopeElementBase"/> class with a given initial name register.
		/// </summary>
		/// <param name="nameRegister">The name register that will store the identifiers defined in this scope.</param>
		protected ZincScopeElementBase (ZincIdentNameRegister nameRegister = null) {
			this.nameRegister = nameRegister;
		}
		#endregion
		#region IZincIdentScope implementation
		/// <summary>
		/// Closes the scope, used at the end of adding items to the scope.
		/// </summary>
		/// <remarks>
		/// <para>When the scope closes, several operations are carried out: identifiers used in the scope
		/// that are defined in the scope as well are redirected to the assignment identifier.</para>
		/// </remarks>
		public virtual void CloseScope () {
			ICompositionUtils.UniqueDescendants (this);
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		public abstract IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap);
		#endregion
		#region IZincIdentContainer implementation
		public abstract IEnumerable<IZincIdent> InvolvedIdents ();
		#endregion
		#region IComposition implementation
		public abstract IEnumerable<IZincElement> Children ();
		#endregion
		#region ISoftValidateable implementation
		public abstract IEnumerable<string> SoftValidate ();
		#endregion
		#region IValidateable implementation
		/// <summary>
		/// Checks if the given instance is valid.
		/// </summary>
		/// <returns>True if the instance is valid, otherwise false.</returns>
		public bool Validate () {
			ValidateableUtils.Validate (this);
		}
		#endregion
		#region IInnerSoftValidateable implementation
		public abstract IEnumerable<string> InnerSoftValidate ();
		#endregion
	}
}

