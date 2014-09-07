//
//  ProgrammingLanguageParadigm.cs
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

namespace ZincOxide.Codegen.Abstract {

	/// <summary>
	/// An enumeration listing the several programming language paradigms that can be used
	/// to develop a program.
	/// </summary>
	/// <remarks>
	/// <para>Since most programming language are multiparadigm, this enumeration can be used as <see cref="FlagsAttribute"/></para>
	/// </remarks>
	[Flags]
	public enum ProgrammingLanguageParadigm : ulong {
		/// <summary>
		/// The programming language is imperative, the program is described with one or more sequences
		/// of instructions.
		/// </summary>
		Imperative = 0x01,
		/// <summary>
		/// The programming language is object-oriented. The programming language has constructs for classes
		/// objects as well as behavior and interactions for these objects.
		/// </summary>
		ObjectOriented = 0x02
	}
}

