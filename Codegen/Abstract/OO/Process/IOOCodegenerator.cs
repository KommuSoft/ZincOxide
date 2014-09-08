//
//  IOOCodegenerator.cs
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
using ZincOxide.Codegen.Abstract.Result;

namespace ZincOxide.Codegen.Abstract.OO.Process {

	/// <summary>
	/// A code generator for the object-oriented programming paradigm.
	/// </summary>
	public interface IOOCodegenerator : ICodegenerator {

		/// <summary>
		/// Generate code in the object-oriented programming paradigm using the given <see cref="IOOCodegenResult"/>
		/// and alter it.
		/// </summary>
		/// <param name="result">The instance that must be modified.</param>
		void GenerateCode (IOOCodegenResult result);
	}
}

