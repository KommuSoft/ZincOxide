//
//  ProgramTask.cs
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
	/// An enumeration that specifies the task the program should carry out.
	/// </summary>
	public enum ProgramTask : byte {

		/// <summary>
		/// A MiniZinc model file is given as input and the program should check if the given file is valid.
		/// </summary>
		VerifyModel = 0x00,

		/// <summary>
		/// A MiniZinc data file is given as input and the program should check if the given file is valid.
		/// </summary>
		VerifyData = 0x01,

		/// <summary>
		/// A MiniZinc output file is given as input and the program should check if the given file is valid.
		/// </summary>
		VerifyOutput = 0x02,

		/// <summary>
		/// A MiniZinc model file and a MiniZinc data file are given and the program should check if the data is a data
		/// file of the model.
		/// </summary>
		Match = 0x10,

		/// <summary>
		/// A MiniZinc model file is given and the program should generate heuristics who can solve the problem.
		/// </summary>
		GenerateHeuristics = 0x20,

		/// <summary>
		/// A MiniZinc model file is given and the program generates code to represent the problem and solution for the heuristic.
		/// </summary>
		GenerateBasics = 0x21,

		/// <summary>
		/// A MiniZinc model file is given and the program will generate a random data file who matches the model file.
		/// </summary>
		GenerateData = 0x22,

		/// <summary>
		/// Given a MiniZinc model file with potential data, the program will generate a MiniZinc model file with
		/// ommitted data. This can be used when only a MiniZinc file with data is provided.
		/// </summary>
		SynthesizeAbstractModel = 0x30,

		/// <summary>
		/// Given a MiniZinc model file with data, the program will generate a MiniZinc data file without a model.
		/// This can be used to split the data from the model.
		/// </summary>
		SynthesizeConcreteData = 0x31,

		/// <summary>
		/// A MinZinc model file is given and the program prints a list of assumptions.
		/// </summary>
		Assume = 0x40,

		/// <summary>
		/// A MiniZinc model file is given and the program generates zero, one or more MiniZinc model files describing
		/// the same problem together with channeling heuristics.
		/// </summary>
		Transform = 0x50,

		/// <summary>
		/// Generate statistics based on a large set of data files.
		/// </summary>
		GenerateStatistics = 0x60,

		/// <summary>
		/// A MiniZinc model or data file is given to the program and a stream of tokens is printed on the stdout
		/// representing the file. This task is only used for debugging purposes.
		/// </summary>
		Lex = 0xf0,

		/// <summary>
		/// A MiniZinc model or data file is given to the program and the abstract syntax tree of the file is printed
		/// on the stdout representing the file. This task is only used for debugging purposes.
		/// </summary>
		Parse = 0xf1,

		/// <summary>
		/// A MiniZinc model or data file is given to the program and the same file is echoed again after parsing
		/// and printing. Except for noise like tabs, spaces, the files should be identical. This task is only used
		/// for debugging purposes.
		/// </summary>
		Echo = 0xf2,

		/// <summary>
		/// A MiniZinc model or data file is given to the program and the same file is echoed again after parsing and
		/// printing. Identifiers are anotated with a number so that one can check if the variables are bounded
		/// correctly. This task is only used for debugging purposes.
		/// </summary>
		Bindings = 0xf3
	}
}