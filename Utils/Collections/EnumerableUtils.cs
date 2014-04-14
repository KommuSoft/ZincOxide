//
//  EnumerableUtils.cs
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

namespace ZincOxide.Utils {

	/// <summary>
	/// A static class with utility methods for <see cref="IEnumerable{T}"/>.
	/// </summary>
	public static class EnumerableUtils {
		/// <summary>
		/// An empty enumerable used when an enumerable is taken as input.
		/// </summary>
		/// <typeparam name="T">The type of the resulting <see cref="IEnumerable{T}"/>.</typeparam>
		public static IEnumerable<T> Empty<T> () {
			yield break;
		}

		/// <summary>
		/// Filters the elements that belong to the result type and are effective.
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> of the elements that belong to the result type and are effective.</returns>
		/// <param name="source">The source of elements.</param>
		/// <typeparam name="T">The type of the elements of the source.</typeparam>
		/// <typeparam name="TRes">The type of the resulting elements.</typeparam>
		public static IEnumerable<TRes> FilterCast <T,TRes> (this IEnumerable<T> source) where TRes : T {
			foreach (T t in source) {
				if (t != null && t is TRes) {
					yield return (TRes)t;
				}
			}
		}

		/// <summary>
		/// Appends the given value with a list of enumerables.
		/// </summary>
		/// <param name="value">The first element of the resulting <see cref="IEnumerable{T}"/>.</param>
		/// <param name="lists">A list of enumerable that succeed the first element of the resulting <see cref="IEnumerable{T}"/>.</param>
		/// <typeparam name="T">The type of the resulting <see cref="IEnumerable{T}"/>.</typeparam>
		public static IEnumerable<T> Append<T> (T value, params IEnumerable<T>[] lists) {
			yield return value;
			foreach (IEnumerable<T> list in lists) {
				foreach (T val in list) {
					yield return val;
				}
			}
		}

		/// <summary>
		/// A generalization of the all method.
		/// </summary>
		/// <param name="sourcex">The first source of values with a <see cref="IEnumerable{T}"/>.</param>
		/// <param name="sourcey">The second source of values with a <see cref="IEnumerable{T}"/>.</param>
		/// <param name="function">A predicate that takes as input two elements and returns a <see cref="Boolean"/>.</param>
		/// <typeparam name="T">The type of the first list (<paramref name="sourcex"/>).</typeparam>
		/// <typeparam name="Q">The type of the second list (<paramref name="sourcey"/>).</typeparam>
		public static bool All<T,Q> (this IEnumerable<T> sourcex, IEnumerable<Q> sourcey, Func<T,Q,bool> function) {
			IEnumerator<T> enumx = sourcex.GetEnumerator ();
			IEnumerator<Q> enumy = sourcey.GetEnumerator ();
			bool movex = enumx.MoveNext ();
			bool movey = enumy.MoveNext ();
			while (movex && movey) {
				if (!function (enumx.Current, enumy.Current)) {
					return false;
				}
				movex = enumx.MoveNext ();
				movey = enumy.MoveNext ();
			}
			return movex == movey;
		}

		/// <summary>
		/// Appends the list of <see cref="IEnumerable{T}"/>.
		/// </summary>
		/// <param name="lists">The list of <see cref="IEnumerable{T}"/> sources.</param>
		/// <typeparam name="T">The type of the <see cref="IEnumerable{T}"/> lists and the resulting <see cref="IEnumerable{T}"/>.</typeparam>
		public static IEnumerable<T> Append<T> (params IEnumerable<T>[] lists) {
			return Append (lists);
		}

		/// <summary>
		/// Append the specified enumerable of <see cref="IEnumerable{T}"/>.
		/// </summary>
		/// <param name="lists">The list of <see cref="IEnumerable{T}"/> sources.</param>
		/// <typeparam name="T">The type of the <see cref="IEnumerable{T}"/> lists and the resulting <see cref="IEnumerable{T}"/>.</typeparam>
		public static IEnumerable<T> Append<T> (IEnumerable<IEnumerable<T>> lists) {
			if (lists != null) {
				foreach (IEnumerable<T> list in lists) {
					if (list != null) {
						foreach (T t in list) {
							yield return t;
						}
					}
				}
			}
		}
	}
}

