//
//  CSharpUtils.cs
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
using System;
using System.CodeDom;

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// A utility class used to write C# code more effectively.
	/// </summary>
	public static class CSharpUtils {

		/// <summary>
		/// Converts the given <paramref name="modifiers"/> to a <see cref="MemberAttributes"/> value
		/// with approximately the same semantical value.
		/// </summary>
		/// <returns>A <see cref="MemberAttributes"/> value that corresponds to the given <paramref name="modifiers"/>.</returns>
		/// <param name="modifiers">The given modifiers to convert.</param>
		public static MemberAttributes ToMemberAttributes (OOModifiers modifiers) {//TODO
			if ((modifiers & OOModifiers.Public) != 0x00) {
				return MemberAttributes.Public;
			} else {
				return MemberAttributes.Private;
			}
		}
	}
}

