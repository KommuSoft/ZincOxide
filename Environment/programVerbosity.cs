//
//  CompilerVerbosity.cs
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

namespace ZincOxide.Environment {

	/// <summary>
	/// An enumeration of levels of the verbosity of the program. Note that <see cref="FlagsAttribute"/> is enabled: one can select
	/// multiple verbosity levels.
	/// </summary>
	[Flags]
	public enum ProgramVerbosity : byte {
		/// <summary>
		/// Remarks is a verbosity level where simple message printed giving information about the current flow of the program.
		/// </summary>
		Remark = 0x08,
		/// <summary>
		/// Assumptions are a verbosity level where messages give information about the assumptions made by the program.
		/// This is useful to debug or to reason why the program takes certain decisions.
		/// </summary>
		Assumption = 0x04,
		/// <summary>
		/// Warnings are a verbosity level where messages note strange aspects in the input who are not necessary wrong, but atypical.
		/// For instance a variable is specified who is not bounded by any constraints.
		/// </summary>
		Warning = 0x02,
		/// <summary>
		/// Errors are a verbosity level where message note that certain aspects of the input can't be interpreted. For instance because
		/// the input file doesn't follow the specific rules.
		/// </summary>
		Error = 0x01
	}
}

