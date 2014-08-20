//
//  ZincBoolLiteral.cs
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

namespace ZincOxide.MiniZinc.Structures {

	public class ZincBoolLiteral : ZincNumExpLiteralBase {

		#region Fields
		private bool value;
		#endregion
		#region Properties
		public bool Value {
			get {
				return this.value;
			}
		}
		#endregion
		#region Constructors
		public ZincBoolLiteral (string text) {
			this.value = bool.Parse (text);
		}

		public ZincBoolLiteral (bool value) {
			this.value = value;
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincBoolLiteral"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincBoolLiteral"/>.</returns>
		/// <remarks>
		/// <para>The result is either <c>true</c> or <c>false</c>.</para>
		/// </remarks>
		public override string ToString () {
			return this.value.ToString ();
		}
		#endregion
		#region Conversion operators
		public static implicit operator ZincBoolLiteral (bool value) {
			return new ZincBoolLiteral (value);
		}
		#endregion
	}
}

