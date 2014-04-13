//
//  ValidatableUtils.cs
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
using System.Linq;

namespace ZincOxide.Utils {

	public static class ValidateableUtils {

		public static bool Validate (this ISoftValidateable obj) {
			return obj.SoftValidate ().Take (0x01).Count () < 0x01;
		}

		public static IEnumerable<string> CompositionInnerSoftValidate<T,Q> (this T value) where Q : ISoftValidateable, IComposition<Q> where T : IInnerSoftValidateable, IComposition<Q> {
			foreach (string exception in value.InnerSoftValidate()) {
				yield return exception;
			}
			foreach (Q element in value.Children()) {
				foreach (string exception in element.SoftValidate()) {
					yield return exception;
				}
			}
		}

	}
}

