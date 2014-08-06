//
//  ICompositionUtils.cs
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
using System.Collections.Generic;

namespace ZincOxide.Utils.Designpatterns {

	/// <summary>
	/// A set of utility methods related to the composite pattern.
	/// </summary>
	public static class ICompositionUtils {

		/// <summary>
		/// Enumerate all the descendants of the given <paramref name="root"/> item of the composite pattern.
		/// </summary>
		/// <param name="root">The given root to generate the decendants from.</param>
		/// <typeparam name="TChildren">The type of the children and descendants of the <paramref name="root"/>.</typeparam>
		/// <remarks>
		/// <para>One is not considered to be a descendant from oneself. The given <paramref name="root"/> is not enumerated.</para>
		/// <para>Descendants are enumerated left-to-right and top-to-bottom: a child is generated before the enumeration
		/// of its children.</para>
		/// </remarks>
		public static IEnumerable<TChildren> Descendants<TChildren> (this TChildren root) where TChildren : IComposition<TChildren> {
			Stack<IEnumerator<TChildren>> generationStack = new Stack<IEnumerator<TChildren>> ();
			IEnumerator<TChildren> cur;
			TChildren child;
			generationStack.Push (root.Children ().GetEnumerator ());
			do {
				cur = generationStack.Peek ();
				if (cur.MoveNext ()) {
					child = cur.Current;
					yield return child;
					generationStack.Push (child.Children ().GetEnumerator ());
				} else {
					generationStack.Pop ();
				}
			} while (generationStack.Count > 0x00);
		}

		/// <summary>
		/// Enumerate all the unique descendants of the given <paramref name="root"/> item of the composite pattern.
		/// </summary>
		/// <param name="root">The given root to generate the decendants from.</param>
		/// <typeparam name="TChildren">The type of the children and descendants of the <paramref name="root"/>.</typeparam>
		/// <remarks>
		/// <para>One is not considered to be a descendant from oneself. The given <paramref name="root"/> is not enumerated.</para>
		/// <para>Descendants are enumerated left-to-right and top-to-bottom: a child is generated before the enumeration
		/// of its children.</para>
		/// <para>All items are enumerated at their first occurence.</para>
		/// <para>This method provides additional speedup because already enumerated items are not expanded anymore.
		/// This method is thus more efficient than putting a unique constraint on the output of <see cref="M:Descendants"/></para>
		/// </remarks>
		public static IEnumerable<TChildren> UniqueDescendants<TChildren> (this TChildren root) where TChildren : IComposition<TChildren> {
			HashSet<TChildren> enumerated = new HashSet<TChildren> ();
			enumerated.Add (root);
			Stack<IEnumerator<TChildren>> generationStack = new Stack<IEnumerator<TChildren>> ();
			IEnumerator<TChildren> cur;
			TChildren child;
			generationStack.Push (root.Children ().GetEnumerator ());
			do {
				cur = generationStack.Peek ();
				if (cur.MoveNext ()) {
					child = cur.Current;
					if (enumerated.Add (child)) {
						yield return child;
						generationStack.Push (child.Children ().GetEnumerator ());
					}
				} else {
					generationStack.Pop ();
				}
			} while (generationStack.Count > 0x00);
		}
	}
}

