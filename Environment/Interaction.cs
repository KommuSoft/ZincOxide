//
//  Interaction.cs
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
using ZincOxide.Parser;
using System.Configuration;

namespace ZincOxide.Environment {

	/// <summary>
	/// A class designed to interact with the user of the program.
	/// </summary>
	public static class Interaction {
		/// <summary>
		/// The level of verbosity of the program: determines which messages should be printed.
		/// </summary>
		/// <value>A <see cref="ProgramVerbosity"/> describing which classes of messages that will be printed.</value>
		/// <remarks>
		/// By default, only errors and warnings are printed.
		/// </remarks>
		public static ProgramVerbosity VerbosityLevel = ProgramVerbosity.Error | ProgramVerbosity.Warning;

		/// <summary>
		/// The current file that is modified. This is used to provide location information when a parsing error is
		/// reported.
		/// </summary>
		/// <value>The active file.</value>
		public static string ActiveFile {
			get;
			set;
		}

		/// <summary>
		/// The current location within the active file. This is udes to provide location information when a parsing
		/// error is reported.
		/// </summary>
		/// <value>The current location within the active file.</value>
		public static LexSpan Location {
			get;
			set;
		}

		public static void GenericMessage (ProgramVerbosity verbosity, string format, params object[] args) {
			if ((verbosity & VerbosityLevel) != 0x00) {
				Console.Error.Write (verbosity.ToString ());
				Console.Error.Write (": ");
				Console.Error.WriteLine (format, args);
			}
		}

		public static void Warning (string format, params object[] args) {
			GenericMessage (ProgramVerbosity.Remark, format, args);
		}

		public static void ParsingError (string activeFile, string format, params object[] args) {
			ActiveFile = activeFile;
			ParsingError (format, args);
		}

		public static void ParsingError (LexSpan location, string format, params object[] args) {
			Location = location;
			ParsingError (format, args);
		}

		public static void ParsingError (string activeFile, LexSpan location, string format, params object[] args) {
			ActiveFile = activeFile;
			ParsingError (location, format, args);
		}

		public static void ParsingError (string format, params object[] args) {
			GenericMessage (ProgramVerbosity.Error, string.Format ("{0}({1},{2}) {3}", ActiveFile, Location.StartLine, Location.StartColumn, string.Format (format, args)));
		}

		public static void Error (string format, params object[] args) {
			GenericMessage (ProgramVerbosity.Error, format, args);
		}

		public static void Remark (string format, params object[] args) {
			GenericMessage (ProgramVerbosity.Remark, format, args);
		}

		public static void Assumption (string format, params object[] args) {
			GenericMessage (ProgramVerbosity.Assumption, format, args);
		}
	}
}

