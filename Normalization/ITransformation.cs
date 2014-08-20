//
//  ITransformation.cs
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
using ZincOxide.MiniZinc.Items;

namespace ZincOxide.Normalization {

	/// <summary>
	/// An interface that specifies a transformation on a <see cref="IZincFile"/>. A transformation is an operation
	/// that maintains the semantic of the <see cref="IZincFile"/>, but alters certain properties such that parsing,
	/// interpreting becomes easier.
	/// </summary>
	public interface ITransformation {

		/// <summary>
		/// Transforms the given <see cref="IZincFile"/> as specified by the concrete <see cref="ITransformation"/>.
		/// </summary>
		/// <param name="file">The <see cref="IZincFile"/> to transform.</param>
		void Transform (IZincFile file);
	}
}

