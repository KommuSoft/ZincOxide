//
//  IWritable.cs
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

namespace ZincOxide.Utils {

	/// <summary>
	/// An interface specifying that the content of the instance can be written to a stream or file.
	/// </summary>
	/// <remarks>
	/// <para>The <see cref="ReadWriteableUtils"/> provides additional utility methods for <see cref="IWriteable"/> instances.</para>
	/// </remarks>
	public interface IWriteable {

		/// <summary>
		/// Writes the data of this instance to the given <paramref name="writer"/>.
		/// </summary>
		/// <param name="writer">The given <see cref="TextWriter"/> to write the data to.</param>
		void Write (TextWriter writer);
	}
}