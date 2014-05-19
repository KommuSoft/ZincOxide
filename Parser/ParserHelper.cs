//
//  ParserHelper.cs
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
using System.IO;
using ZincOxide.MiniZinc.Items;

namespace ZincOxide.Parser {

	/// <summary>
	/// A class representing the MiniZinc parser. A parser takes as input a stream of tokens or a <see cref="MiniZincLexer"/>
	/// that provides tokens and converts them into a <see cref="ZincModel"/> containing the same data.
	/// </summary>
	public partial class MiniZincParser {

		private ZincModel result;

		/// <summary>
		/// Gets the result after parsing the stream of tokens.
		/// </summary>
		/// <value>A <see cref="ZincModel"/> that contains all the information that was stored in the textual representation that is parsed.</value>
		/// <remarks>
		/// <para>Before parsing is complete, the result is not effective.</para>
		/// </remarks>
		public ZincModel Result {
			get {
				return this.result;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MiniZincParser"/> class with a given <see cref="MiniZincLexer"/> that will provide
		/// the stream of tokens.
		/// </summary>
		/// <param name="scanner">A lexer that will provide the tokens to parse.</param>
		public MiniZincParser (MiniZincLexer scanner) : base(scanner) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MiniZincParser"/> class with a given stream that contains the content to be parsed.
		/// </summary>
		/// <param name="stream">A stream containing the textual representation of the data that needs to be parsed.</param>
		public MiniZincParser (Stream stream) : this(new MiniZincLexer(stream)) {

		}
	}
}

