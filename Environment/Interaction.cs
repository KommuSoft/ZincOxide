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
using System.Diagnostics.Contracts;

namespace ZincOxide.Environment {

	/// <summary>
	/// A class designed to interact with the user of the program. In most cases, this means that it prints out error messages.
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

		/// <summary>
		/// Prints a generic message with a give verbosity, message format and zero or more message arguments.
		/// </summary>
		/// <param name="verbosity">The verbosity-level of the message.</param>
		/// <param name="format">The format of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format. </param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="format"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
		/// <exception cref="FormatException">The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		/// <remarks>
		/// <para>If the interaction level doesn't support the given level, no message is printed.</para>
		/// </remarks>
		public static void GenericMessage (ProgramVerbosity verbosity, string format, params object[] args) {
			if ((verbosity & VerbosityLevel) != 0x00) {
				Console.Error.Write (verbosity.ToString ());
				Console.Error.Write (": ");
				Console.Error.WriteLine (format, args);
			}
		}

		/// <summary>
		/// Prints a warning message with a given format and arguments.
		/// </summary>
		/// <param name="format">The format of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format.</param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="format"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
		/// <exception cref="FormatException">The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		/// <remarks>
		/// <para>If the interaction level doesn't support warnings, no message is printed.</para>
		/// </remarks>
		public static void Warning (string format, params object[] args) {
			GenericMessage (ProgramVerbosity.Remark, format, args);
		}

		/// <summary>
		/// Prints a parsing error message with a given format, arguments and the name of the active file. <see cref="Interaction.Location"/> will provide
		/// the location within the active file.
		/// </summary>
		/// <param name="activeFile">The name of the active file.</param>
		/// <param name="format">The format of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format. </param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="format"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
		/// <exception cref="FormatException">The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		/// <remarks>
		/// <para>If the active file or the location are not effective, no parsing error message will be printed.</para>
		/// <para>If the interaction level doesn't support errors, no message is printed.</para>
		/// </remarks>
		public static void ParsingError (string activeFile, string format, params object[] args) {
			ActiveFile = activeFile;
			ParsingError (format, args);
		}

		/// <summary>
		/// Prints a parsing error message with a given format, arguments and the location of the error. <see cref="Interaction.ActiveFile"/> will provide the active file.
		/// </summary>
		/// <param name="location">The location within the active file of the error.</param>
		/// <param name="format">The format of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format. </param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="format"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
		/// <exception cref="FormatException">The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		/// <remarks>
		/// <para>If the active file or the location are not effective, no parsing error message will be printed.</para>
		/// <para>If the interaction level doesn't support errors, no message is printed.</para>
		/// </remarks>
		public static void ParsingError (LexSpan location, string format, params object[] args) {
			Location = location;
			ParsingError (format, args);
		}

		/// <summary>
		/// Prints a parsing error message with a given format, arguments and the name of the file and the location of the error.
		/// </summary>
		/// <param name="activeFile">The name of the file where the error is detected.</param>
		/// <param name="location">The location within the active file of the error.</param>
		/// <param name="format">The format of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format. </param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="format"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
		/// <exception cref="FormatException">The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		/// <remarks>
		/// <para>If the active file or the location are not effective, no parsing error message will be printed.</para>
		/// <para>If the interaction level doesn't support errors, no message is printed.</para>
		/// </remarks>
		public static void ParsingError (string activeFile, LexSpan location, string format, params object[] args) {
			ActiveFile = activeFile;
			ParsingError (location, format, args);
		}

		/// <summary>
		/// Prints a parsing error message with a given format and arguments. <see cref="Interaction.ActiveFile"/> and <see cref="Interaction.Location"/> will provide
		/// the name of the file and the location of the error.
		/// </summary>
		/// <param name="format">The format of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format. </param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="format"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
		/// <exception cref="FormatException">The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		/// <remarks>
		/// <para>If the active file or the location are not effective, no parsing error message will be printed.</para>
		/// <para>If the interaction level doesn't support errors, no message is printed.</para>
		/// </remarks>
		public static void ParsingError (string format, params object[] args) {
			if (ActiveFile != null && Location != null) {
				GenericMessage (ProgramVerbosity.Error, string.Format ("{0}({1},{2}) {3}", ActiveFile, Location.StartLine, Location.StartColumn, string.Format (format, args)));
			}
		}

		/// <summary>
		/// Prints an error message with a given format and arguments.
		/// </summary>
		/// <param name="format">The format of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format. </param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="format"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
		/// <exception cref="FormatException">The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		/// <remarks>
		/// <para>If the interaction level doesn't support errors, no message is printed.</para>
		/// </remarks>
		public static void Error (string format, params object[] args) {
			GenericMessage (ProgramVerbosity.Error, format, args);
		}

		/// <summary>
		/// Prints a remark message with a given format and arguments.
		/// </summary>
		/// <param name="format">The format of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format. </param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="format"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
		/// <exception cref="FormatException">The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		/// <remarks>
		/// <para>If the interaction level doesn't support remarks, no message is printed.</para>
		/// </remarks>
		public static void Remark (string format, params object[] args) {
			GenericMessage (ProgramVerbosity.Remark, format, args);
		}

		/// <summary>
		/// Prints an assumption message with a given format and arguments.
		/// </summary>
		/// <param name="format">The format of the message.</param>
		/// <param name="args">An object array that contains zero or more objects to format. </param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="format"/> is <see langword="null"/>.</exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid.</exception>
		/// <exception cref="FormatException">The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.</exception>
		/// <remarks>
		/// <para>If the interaction level doesn't support assumptions, no message is printed.</para>
		/// </remarks>
		public static void Assumption (string format, params object[] args) {
			GenericMessage (ProgramVerbosity.Assumption, format, args);
		}
	}
}

