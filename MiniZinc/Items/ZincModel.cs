//
//  ZincModel.cs
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
using System.Linq;
using System.IO;
using System.Collections.Generic;
using ZincOxide.Environment;
using ZincOxide.MiniZinc.Structures;
using ZincOxide.Utils;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// A class representing a ZincModel (see <see cref="IZincModel"/>). A model does not assign values to
	/// parameter variables directly: only relations between the parameters are expressed.
	/// </summary>
	public class  ZincModel : ZincFileBase, IZincModel {

		private readonly List<IZincItem> items = new List<IZincItem> ();

		/// <summary>
		/// Gets a value indicating whether this instance is valid zinc data file.
		/// </summary>
		/// <value><c>true</c> if this instance is valid zinc data; otherwise, <c>false</c>.</value>
		public bool IsValidZincData {
			get {
				return this.Items.All (x => x is ZincVarDeclItem);
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is valid zinc model.
		/// </summary>
		/// <value><c>true</c> if this instance is valid zinc model; otherwise, <c>false</c>.</value>
		public bool IsValidZincModel {
			get {
				return true;//TODO: checks on VarDecl-Assign,...
			}
		}
		#region IZincFile implementation
		/// <summary>
		/// Enumerate all the <see cref="IZincItem"/> instances that are stored in this <see cref="IZincModel"/>.
		/// </summary>
		/// <value>A <see cref="T:IEnumerable`1"/> that enumerates all the items of the <see cref="IZincModel"/>.</value>
		public override IEnumerable<IZincItem> Items {
			get {
				return this.items;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincModel"/> class with no items to initialize.
		/// </summary>
		/// <remarks>
		/// <para>In other words, the model file is empty (and is in fact not valid at all).</para>
		/// <para>This constructor is merely used to parse data into.</para>
		/// </remarks>
		public ZincModel () {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincModel"/> class with a given list of <see cref="IZincItem"/>
		/// instances that must be stored in the file.
		/// </summary>
		/// <param name="items">An <see cref="T:IEnumerable`1"/> containing the <see cref="IZincItem"/> instances
		/// that should be stored in the <see cref="IZincModel"/>.</param>
		public ZincModel (IEnumerable<IZincItem> items) : this() {
			this.AddItems (items);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincModel"/> class with a given list of <see cref="IZincItem"/>
		/// instances that must be stored in the file.
		/// </summary>
		/// <param name="items">An array containing the <see cref="IZincItem"/> instances
		/// that should be stored in the <see cref="IZincModel"/>.</param>
		public ZincModel (params IZincItem[] items) : this((IEnumerable<IZincItem>) items) {
		}
		#endregion
		#region IZincFile implementation
		/// <summary>
		/// Adds the given <see cref="T:IEnumerable`1"/> of <see cref="IZincItem"/> instances to this <see cref="IZincModel"/>.
		/// </summary>
		/// <param name="items">The given list of <see cref="IZincItem"/> instances to be added.</param>
		/// <remarks>
		/// <para>Invalid itemS in the list are not added, but a warning will be printed for these items.</para>
		/// </remarks>
		public override void AddItems (IEnumerable<IZincItem> items) {
			if (items != null) {
				foreach (IZincItem item in items) {
					this.AddItem (item);
				}
			}
		}

		/// <summary>
		/// Add the given <see cref="IZincItem"/> to this <see cref="IZincModel"/>, but only if it is valid in MiniZinc.
		/// </summary>
		/// <param name="item">The given <see cref="IZincItem"/> to be added.</param>
		/// <remarks>
		/// <para>If an invalid item is added, nothing happens, but a warning is printed.</para>
		/// </remarks>
		public override void AddItem (IZincItem item) {
			if (item != null) {
				switch (item.Type) {
				case ZincItemType.Include:
				case ZincItemType.VarDecl:
				case ZincItemType.Assign:
				case ZincItemType.Constraint:
				case ZincItemType.Solve:
				case ZincItemType.Output:
				case ZincItemType.Predicate:
				case ZincItemType.Function:
					this.items.Add (item);
					break;
				case ZincItemType.TypeInstanceSynonym:
				case ZincItemType.Enum:
				case ZincItemType.Test:
					Interaction.Warning ("Items of type \"{0}\" are part of Zinc but not of MiniZinc.", item.Type);
					break;
				default :
					Interaction.Warning ("A ZincItem was found with an type that cannot be added to a ZincModel. Probably you are running an outdated version of ZincOxide.");
					break;
				}
			}
		}
		#endregion
		#region IWritable implementation
		/// <summary>
		/// Writes the textual representation of the Zinc model to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="writer">The given writer to write the textual representation to.</param>
		public override void Write (TextWriter writer) {
			foreach (IZincItem item in this.Items) {
				item.Write (writer);
				writer.WriteLine (";");
			}
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="T:IDictionary`2"/>
		/// stored as keys to the corresponding values and returns this instance, possibly if this is an
		/// <see cref="IZincIdent"/> itself another <see cref="IZincIdent"/>.
		/// </summary>
		/// <returns>
		/// If this instance is a compound type, a reference to itself. Otherwise a <see cref="IZincIdent"/> if
		/// this instance is a <see cref="IZincIdent"/> itself.
		/// </returns>
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			//TODO implement
			return this;
		}
		#endregion
		/// <summary>
		/// Convert the given parameter assignments to a returned <see cref="ZincData"/> instance.
		/// </summary>
		/// <returns>A <see cref="ZincData"/> instance that contains all the raw parameter value assignments, this can
		/// be used to separate the data from the model.</returns>
		public ZincData ConvertToZincData () {
			return new ZincData (this.Items);
		}

		/// <summary>
		/// Reduces this <see cref="IZincModel"/> to a <see cref="IZincDataFile"/> instance. Only the parameter assignment
		/// items are kept.
		/// </summary>
		/// <returns>A <see cref="IZincDataFile"/> contaning the parameter value assignments of this
		/// <see cref="IZincModel"/>.</returns>
		public ZincData ReduceToZincData () {
			return new ZincData (this.Items.Where (x => x.Type == ZincItemType.Assign).Cast<ZincAssignItem> ());//TODO: only par items
		}

		/// <summary>
		/// Converts this <see cref="IZincModel"/> into a <see cref="IZincDataFile"/> containing the parameter
		/// assignment items.
		/// </summary>
		/// <param name="model">The given model to convert.</param>
		/// <returns>A <see cref="ZincData"/> instance that contains all the raw parameter value assignments, this can
		/// be used to separate the data from the model.</returns>
		public static explicit operator ZincData (ZincModel model) {
			if (model != null) {
				return new ZincData (model.Items);
			} else {
				return null;
			}
		}

		/// <summary>
		/// Reduces this <see cref="IZincModel"/> to a <see cref="IZincDataFile"/> instance. Only the parameter assignment
		/// items are kept.
		/// </summary>
		/// <param name="model">The given model to convert.</param>
		/// <returns>A <see cref="IZincDataFile"/> contaning the parameter value assignments of this
		/// <see cref="IZincModel"/>.</returns>
		public static ZincData operator ~ (ZincModel model) {
			if (model != null) {
				return model.ReduceToZincData ();
			} else {
				return null;
			}
		}
		#region implemented abstract members of ZincScopeElementBase
		/// <summary>
		/// Generates a number of error messages that specify what is wrong with this instance.
		/// </summary>
		/// <returns>A <see cref="T:IEumerable`1"/> that contains a list of error messages describing why the instance is invalid.</returns>
		/// <remarks>
		/// <para>If no error messages are generated, the instance is valid, otherwise the instance is invalid.</para>
		/// </remarks>
		public override IEnumerable<string> InnerSoftValidate () {
			if (this.items.Where (x => x.Type == ZincItemType.Solve).Count () != 0x01) {
				yield return "A Zinc model always contains exactly one solve item.";
			}
			//TODO
		}
		#endregion
	}
}