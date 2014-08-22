//
//  ZincFileBase.cs
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ZincOxide.MiniZinc.Structures;
using ZincOxide.Utils.Designpatterns;
using ZincOxide.Utils.Functional;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// A basic implementation of a <see cref="IZincFile"/> a file contains a number of <see cref="IZincItem"/> instances.
	/// </summary>
	public abstract class ZincFileBase : ZincScopeElementBase, IZincFile {

		#region IZincFile implementation
		public abstract IEnumerable<IZincItem> Items {
			get;
		}
		#endregion
		#region Constructors
		protected ZincFileBase (ZincIdentNameRegister nameRegister = null) : base(nameRegister) {
		}
		#endregion
		#region IWriteable implementation
		public abstract void Write (TextWriter writer);
		#endregion
		#region IZincFile implementation
		public abstract void AddItem (IZincItem item);

		public abstract void AddItems (IEnumerable<IZincItem> items);
		#endregion
		#region implemented abstract members of ZincScopeElementBase
		/// <summary>
		/// Gets a list of involved <see cref="IZincElement"/> instances that are the children of
		/// this <see cref="IZincElement"/>.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> instance of
		/// <see cref="IZincElement"/> that are the childrens of this <see cref="IZincElement"/> instance.
		/// </returns>
		public override IEnumerable<IZincElement> Children () {
			return this.Items;
		}
		#endregion
		#region CloseScope override
		/// <summary>
		/// Closes the scope, used at the end of adding items to the scope.
		/// </summary>
		/// <param name="scope">The outer scope, used to attach a fallback mechanism to each
		/// scope, optionally, by default not effective.</param>
		public override void CloseScope (IZincIdentScope scope = null) {
			base.CloseScope (scope);
			Dictionary<IZincIdent,IZincIdent> replace = new Dictionary<IZincIdent, IZincIdent> ();
			/*foreach (Tuple<IZincIdentScope,IZincIdent> matcher in ICompositionUtils.DoubleBlanket<IZincElement,IZincIdentScope> (this,(Predicate<IZincIdentScope>)StandardFunctions.AllPredicate<IZincElement> (),x => x is IZincIdent,StandardFunctions.AllPredicate<IZincElement> ()).Cast<Tuple<IZincIdentScope,IZincIdent>> ()) {
				//replace.Add (matcher.Item2, matcher.Item1.NameRegister.Lookup ());
			}*/
			this.Replace (replace);
		}
		#endregion
	}
}

