//
//  ZincAnnotations.cs
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

namespace ZincOxide.MiniZinc.Structures {

	/// <summary>
	/// A <see cref="IZincItem"/> that annotates the code. This is done by providing a sequence of zero or more
	/// <see cref="IZincAnnotation"/> instances.
	/// </summary>
	public class ZincAnnotations : LinkedList<IZincAnnotation>, IZincAnnotations {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAnnotations"/> class with the given list of annotations.
		/// </summary>
		/// <param name="annotations">The given list of annotations.</param>
		public ZincAnnotations (IEnumerable<IZincAnnotation> annotations) : base(annotations) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAnnotations"/> class with the given list of annotations.
		/// </summary>
		/// <param name="annotations">The given list of annotations.</param>
		public ZincAnnotations (params IZincAnnotation[] annotations) : base(annotations) {
		}
		#endregion
		/// <summary>
		/// Returns a <see cref="String"/> that represents the current <see cref="ZincAnnotations"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincAnnotations"/>.</returns>
		/// <remarks>
		/// <para>Annotations are formatted by a list of <see cref="IZincAnnotation"/> instances separated by <c>::</c>.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format (":: {0}", string.Join (" :: ", this));
		}
		#region IWriteable implementation
		public void Write (TextWriter writer) {
			writer.Write (this.ToString ());
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="T:IDictionary`1"/>
		/// stored as keys to the corresponding values and returns this instance, possibly if this is an
		/// <see cref="IZincIdent"/> itself another <see cref="IZincIdent"/>.
		/// </summary>
		/// <returns>
		/// If this instance is a compound type, a reference to itself. Otherwise a <see cref="IZincIdent"/> if
		/// this instance is a <see cref="IZincIdent"/> itself.
		/// </returns>
		public IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			LinkedListNode<IZincAnnotation> node = this.First;
			while (node != null) {
				node.Value = node.Value.Replace (identMap) as ZincAnnotation;
				node = node.Next;
			}
			return this;
		}
		#endregion
		#region IInnerSoftValidateable implementation
		public IEnumerable<string> InnerSoftValidate () {
			throw new System.NotImplementedException ();
		}
		#endregion
		#region IValidateable implementation
		public bool Validate () {
			throw new System.NotImplementedException ();
		}
		#endregion
		#region ISoftValidateable implementation
		public IEnumerable<string> SoftValidate () {
			throw new System.NotImplementedException ();
		}
		#endregion
		#region IComposition implementation
		public IEnumerable<IZincElement> Children () {
			return this;
		}
		#endregion
	}
}

