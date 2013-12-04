//
//  ContextStreamWriter.cs
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
using System.Text;
using System.IO;
using System.Security;

namespace ZincOxide.Utils {

	/// <summary>
	/// A subclass of a <see cref="StreamWriter"/> that uses the <see cref="ContextStreamWriter.IndentLevel"/> in order
	/// to make the generated output more readable.
	/// </summary>
	public class ContextStreamWriter : StreamWriter {
		private int indentLevel;
		private string indent;

		/// <summary>
		/// The level of indentation at the current state.
		/// </summary>
		/// <value>The number of indents per line.</value>
		public int IndentLevel {
			get {
				return this.indentLevel;
			}
			protected set {
				this.indentLevel = Math.Max (0x00, value);
			}
		}

		/// <summary>
		/// A string that represents how an indent is formatted. For instance a tab or four spaces.
		/// </summary>
		/// <value>The prefix per indentationlevel per level.</value>
		public string Indent {
			get {
				return this.indent;
			}
			set {
				if (value == null) {
					this.indent = string.Empty;
				} else {
					this.indent = value;
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.Utils.ContextStreamWriter"/> class. With a specified indent.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="indent">The initial indent per line, by default four spaces.</param>
		/// <exception cref="ArgumentException"><paramref name="stream"/> is not writeable.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="stream"/> is null.</exception>
		public ContextStreamWriter (Stream stream, string indent = "    ") : base (stream) {
			this.Indent = indent;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.Utils.ContextStreamWriter"/> class With a specified encoding and indent.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="indent">The initial indent per line, by default four spaces.</param>
		/// <exception cref="ArgumentException"><paramref name="stream"/> is not writeable.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="encoding"/> is null.</exception>
		public ContextStreamWriter (Stream stream, Encoding encoding, string indent = "    ") : base (stream, encoding) {
			this.Indent = indent;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.Utils.ContextStreamWriter"/> class for the specified stream with the specified encoding and buffer size.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="bufferSize">The buffer size, in bytes.</param>
		/// <param name="indent">The initial indent per line, by default four spaces.</param>
		/// <exception cref="ArgumentException"><paramref name="stream"/> is not writeable.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="stream"/> or <paramref name="encoding"/> is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="bufferSize"/> is negative.</exception>
		public ContextStreamWriter (Stream stream, Encoding encoding, int bufferSize, string indent = "    ") : base (stream, encoding, bufferSize) {
			this.Indent = indent;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.Utils.ContextStreamWriter"/> class specified filename.
		/// </summary>
		/// <param name="path">The complete file path to write to. <paramref name="path"/> can be a file name.</param>
		/// <param name="indent">The initial indent per line, by default four spaces.</param>
		/// <exception cref="UnauthorizedAccessException">Access is denied.</exception>
		/// <exception cref="ArgumentException"><paramref name="path"/> is an empty string ("").</exception>
		/// <exception cref="ArgumentException"><paramref name="path"/> contains the name of a system device (com1, com2, and so on).</exception>
		/// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
		/// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
		/// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must not exceed 248 characters, and file names must not exceed 260 characters. </exception>
		/// <exception cref="IOException"><paramref name="path"/> includes an incorrect or invalid syntax for file name, directory name, or volume label syntax.</exception>
		/// <exception cref="SecurityException">The caller does not have the required permission. </exception>
		public ContextStreamWriter (string path, string indent = "    ") : base (path) {
			this.Indent = indent;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.Utils.ContextStreamWriter"/> class with a specified filename. If the file exists, it can be either overwritten or appended to. If the file does not exist, this constructor creates a new file.
		/// </summary>
		/// <param name="path">The complete file path to write to. <paramref name="path"/> can be a file name.</param>
		/// <param name="append"><see langword="true"/> to append data to the file; <see langword="false"/> to overwrite the file. If the specified file does not exist, this parameter has no effect, and the constructor creates a new file.</param>
		/// <param name="indent">The initial indent per line, by default four spaces.</param>
		/// <exception cref="UnauthorizedAccessException">Access is denied.</exception>
		/// <exception cref="ArgumentException"><paramref name="path"/> is an empty string ("").</exception>
		/// <exception cref="ArgumentException"><paramref name="path"/> contains the name of a system device (com1, com2, and so on).</exception>
		/// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
		/// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
		/// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must not exceed 248 characters, and file names must not exceed 260 characters. </exception>
		/// <exception cref="IOException"><paramref name="path"/> includes an incorrect or invalid syntax for file name, directory name, or volume label syntax.</exception>
		/// <exception cref="SecurityException">The caller does not have the required permission. </exception>
		public ContextStreamWriter (string path, bool append, string indent = "    ") : base (path, append) {
			this.Indent = indent;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.Utils.ContextStreamWriter"/> class with a specified filename and encoding. If the file exists, it can be either overwritten or appended to. If the file does not exist, this constructor creates a new file.
		/// </summary>
		/// <param name="path">The complete file path to write to. <paramref name="path"/> can be a file name.</param>
		/// <param name="append"><see langword="true"/> to append data to the file; <see langword="false"/> to overwrite the file. If the specified file does not exist, this parameter has no effect, and the constructor creates a new file.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="indent">The initial indent per line, by default four spaces.</param>
		/// <exception cref="UnauthorizedAccessException">Access is denied.</exception>
		/// <exception cref="ArgumentException"><paramref name="path"/> is an empty string ("").</exception>
		/// <exception cref="ArgumentException"><paramref name="path"/> contains the name of a system device (com1, com2, and so on).</exception>
		/// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="encoding"/> is null.</exception>
		/// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
		/// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must not exceed 248 characters, and file names must not exceed 260 characters. </exception>
		/// <exception cref="IOException"><paramref name="path"/> includes an incorrect or invalid syntax for file name, directory name, or volume label syntax.</exception>
		/// <exception cref="SecurityException">The caller does not have the required permission. </exception>
		public ContextStreamWriter (string path, bool append, Encoding encoding, string indent = "    ") : base (path, append, encoding) {
			this.Indent = indent;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.Utils.ContextStreamWriter"/> class with a specified filename, encoding and buffersize. If the file exists, it can be either overwritten or appended to. If the file does not exist, this constructor creates a new file.
		/// </summary>
		/// <param name="path">The complete file path to write to. <paramref name="path"/> can be a file name.</param>
		/// <param name="append"><see langword="true"/> to append data to the file; <see langword="false"/> to overwrite the file. If the specified file does not exist, this parameter has no effect, and the constructor creates a new file.</param>
		/// <param name="encoding">The character encoding to use.</param>
		/// <param name="bufferSize">The buffer size, in bytes.</param>
		/// <param name="indent">The initial indent per line, by default four spaces.</param>
		/// <exception cref="UnauthorizedAccessException">Access is denied.</exception>
		/// <exception cref="ArgumentException"><paramref name="path"/> is an empty string ("").</exception>
		/// <exception cref="ArgumentException"><paramref name="path"/> contains the name of a system device (com1, com2, and so on).</exception>
		/// <exception cref="ArgumentNullException"><paramref name="path"/> or <paramref name="encoding"/> is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="bufferSize"/> is negative.</exception>
		/// <exception cref="DirectoryNotFoundException">The specified path is invalid (for example, it is on an unmapped drive). </exception>
		/// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must not exceed 248 characters, and file names must not exceed 260 characters. </exception>
		/// <exception cref="IOException"><paramref name="path"/> includes an incorrect or invalid syntax for file name, directory name, or volume label syntax.</exception>
		/// <exception cref="SecurityException">The caller does not have the required permission. </exception>
		public ContextStreamWriter (string path, bool append, Encoding encoding, int bufferSize, string indent = "    ") : base (path, append, encoding, bufferSize) {
			this.Indent = indent;
		}

		/// <summary>
		/// Adds on indent of the indent level.
		/// </summary>
		public void AddLevel () {
			this.IndentLevel++;
		}

		/// <summary>
		/// Subtracts on indent of the indent level.
		/// </summary>
		public void SubLevel () {
			this.IndentLevel--;
		}

		/// <summary>
		/// Appends a line to the stream.
		/// </summary>
		/// <exception cref="ObjectDisposedException">The <see cref="TextWriter"/> is closed.</exception>
		/// <exception cref="IOException">An I/O error occurs.</exception>
		public override void WriteLine () {
			base.WriteLine ();
			for (int i = 0x00; i < this.indentLevel; i++) {
				this.Write (this.indent);
			}
		}
	}
}

