//
//  ILexSpan.cs
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
using QUT.Gppg;

namespace ZincOxide.Parser {

	/// <summary>
	/// An interface describing the lexeme span: metadata that contains information about the origin of a certain token.
	/// </summary>
	public interface ILexSpan : IMerge<LexSpan> {

		/// <summary>
		/// Gets the text that is within the quotes of this span.
		/// </summary>
		/// <returns>The content of the literal string.</returns>
		/// <remarks>
		/// <para>In case the token is not a string literal, the behavior is random.</para>
		/// </remarks>
		string LiteralString ();
	}
}

