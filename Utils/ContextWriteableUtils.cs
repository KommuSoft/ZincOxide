//
//  ContextWriteableUtils.cs
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
using System.IO;

namespace ZincOxide.Utils {

	public static class ContextWriteableUtils {
		/// <summary>
		/// Writes the content of the <paramref name="writeable"/> to the <paramref name="stream"/> with indent context.
		/// </summary>
		/// <param name="writeable">The writeable that should be written to the <paramref name="stream"/>.</param>
		/// <param name="stream">The target of the <paramref name="writeable"/>.</param>
		public static void Write (this IContextWriteable writeable, Stream stream) {
			using (ContextStreamWriter sw = new ContextStreamWriter (stream)) {
				writeable.Write (sw);
			}
		}

		/// <summary>
		/// Write the content of the <paramref name="writeable"/> to a file specified by a filename and mode.
		/// </summary>
		/// <param name="writeable">The writeable that should be written to the file.</param>
		/// <param name="filename">The name of the output file.</param>
		/// <param name="mode">The mode that specifies how the file should be created.</param>
		public static void Write (this IContextWriteable writeable, string filename, FileMode mode = FileMode.OpenOrCreate) {
			using (FileStream fs = File.Open (filename, mode, FileAccess.Write)) {
				writeable.Write (fs);
			}
		}
	}
}

