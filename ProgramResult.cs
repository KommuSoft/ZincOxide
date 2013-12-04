//
//  EvaluationResult.cs
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

namespace ZincOxide {

	/// <summary>
	/// An enumeration describing the different exit codes and their meaning.
	/// </summary>
	public enum ProgramResult : byte {
		/// <summary>
		/// The MiniZinc file is compiled to heuristics.
		/// </summary>
		Compiled = 0x00,
		/// <summary>
		/// The MiniZinc file and the datafile match.
		/// </summary>
		Match = 0x00,
		/// <summary>
		/// The given query or test was successfull. Or the hyper-heuristic was executed correctly.
		/// </summary>
		Succes = 0x00,
		/// <summary>
		/// There was a runtime error when executing the hyper-heuristic.
		/// </summary>
		RuntimeError = 0x01,
		/// <summary>
		/// The MiniZinc file and the data file don't match.
		/// </summary>
		NoMatch = 0x03,
		/// <summary>
		/// There was a static error. For instance the semantic of the MiniZinc file is not valid.
		/// </summary>
		StaticError = 0x02,
		/// <summary>
		/// The given input is not valid. For instance a corrupt MiniZinc file, no heuristics provided,...
		/// </summary>
		CorruptInput = 0x03
	}
}