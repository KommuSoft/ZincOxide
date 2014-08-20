//
//  LexSpan.cs
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
using QUT.Gppg;

namespace ZincOxide.Parser {

	/// <summary>
	/// A class that represents the lexeme span: metadata that contains information about the origin of a certain token.
	/// </summary>
	public class LexSpan : ILexSpan {

		#region Fields
		private readonly int startLine;
		private readonly int startColumn;
		private readonly int endLine;
		private readonly int endColumn;
		private readonly int startIndex;
		private readonly int endIndex;
		private readonly ScanBuff buffer;
		#endregion
		#region Properties
		/// <summary>
		/// Gets the line of the file on which the token starts.
		/// </summary>
		/// <value>The line of the file on which the token starts.</value>
		public int StartLine {
			get {
				return startLine;
			}
		}

		/// <summary>
		/// Gets the colon of the first line on which the token starts.
		/// </summary>
		/// <value>The colon of the first line on which the token starts.</value>
		public int StartColumn {
			get {
				return startColumn;
			}
		}

		/// <summary>
		/// Gets the line of the file on which the token ends.
		/// </summary>
		/// <value>The line of the file on which the token ends.</value>
		public int EndLine {
			get {
				return endLine;
			}
		}

		/// <summary>
		/// Gets the colon of the last line on which the token ends.
		/// </summary>
		/// <value>The colon of the last line on which the token ends.</value>
		public int EndColumn {
			get {
				return endColumn;
			}
		}

		/// <summary>
		/// Gets the start index in the original file where the token starts.
		/// </summary>
		/// <value>The start index in the original file where the token starts.</value>
		public int StartIndex {
			get {
				return startIndex;
			}
		}

		/// <summary>
		/// Gets the start index in the original file where the token ends.
		/// </summary>
		/// <value>The start index in the original file where the token ends.</value>
		public int EndIndex {
			get {
				return endIndex;
			}
		}

		/// <summary>
		/// Gets the internally stored <see cref="ScanBuff"/> that contains the currently active file.
		/// </summary>
		/// <value>The internally stored <see cref="ScanBuff"/> that contains the currently active file.</value>
		public ScanBuff Buffer {
			get {
				return buffer;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// The default constructor, used by the <see cref="MiniZincLexer"/>.
		/// </summary>
		public LexSpan () {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LexSpan"/> class with parameters specifying the start and end location and the <see cref="ScanBuff"/>
		/// that represents the currently active file.
		/// </summary>
		/// <param name="sl">The line number where the token starts.</param>
		/// <param name="sc">The column number of the line where the token starts.</param>
		/// <param name="el">The line number where the token ends.</param>
		/// <param name="ec">The column number of the line where the token ends.</param>
		/// <param name="sp">The index of the active file where the token starts.</param>
		/// <param name="ep">The index of the active file where the token ends.</param>
		/// <param name="bf">The <see cref="ScanBuff"/> that represents the active file.</param>
		public LexSpan (int sl, int sc, int el, int ec, int sp, int ep, ScanBuff bf) {
			startLine = sl;
			startColumn = sc;
			endLine = el;
			endColumn = ec;
			startIndex = sp;
			endIndex = ep;
			buffer = bf;
		}
		#endregion
		#region IMerge`1 implementation
		/// <summary>
		/// This method implements the IMerge interface
		/// </summary>
		/// <param name="end">The last span to be merged</param>
		/// <returns>A span from the start of 'this' to the end of 'end'</returns>
		public LexSpan Merge (LexSpan end) {
			return new LexSpan (startLine, startColumn, end.endLine, end.endColumn, startIndex, end.endIndex, buffer);
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Gets the stream content that corresponds with the specified span in a textual context.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the content of the stream specified by this span.</returns>
		public override string ToString () {
			return buffer.GetString (startIndex, endIndex);
		}
		#endregion
		#region ILexSpan implementation
		/// <summary>
		/// Gets the text that is within the quotes of this span.
		/// </summary>
		/// <returns>The content of the literal string.</returns>
		/// <remarks>
		/// <para>In case the token is not a string literal, the behavior is random.</para>
		/// </remarks>
		public string LiteralString () {
			return buffer.GetString (startIndex + 0x01, endIndex - 0x01);
		}
		#endregion
	}
}

