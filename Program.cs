//
//  Program.cs
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

#define PARSE

using System;
using System.Collections.Generic;
using System.IO;
using Mono.Options;
using ZincOxide.Environment;
using ZincOxide.Parser;

namespace ZincOxide {

	/// <summary>
	/// A static class that implements the entry-point of the program.
	/// </summary>
	public static class Program {
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		/// <returns>The exit code that is given to the operating system after the program ends.</returns>
		public static int Main (string[] args) {
			bool show_help = false;
			ProgramEnvironment env = new ProgramEnvironment ();
			var p = new OptionSet () { {
					"t|task=",
					"The task to be executed (validate-model,validate-data,match,generate-data,generate-heuristics,assume).",
					env.SetTask
				},
				{ "v|verbosity=","The level of verbosity (error,warning,assumption,remark).",env.SetVersbosity },
				{ "h|help","Show this help message and exit.", x => show_help = x != null }
			};

			List<string> files = new List<string> ();
			try {
				files = p.Parse (args);
				Interaction.VerbosityLevel = env.Verbosity;
			} catch (OptionException e) {
				Console.Error.Write ("zincoxide: ");
				Console.Error.WriteLine (e.Message);
				Console.Error.WriteLine ("Try 'zincoxide --help' for more information.");
				return (int)ProgramResult.StaticError;
			} catch (ZincOxideException e) {
				Interaction.Error (e.Message);
				return (int)ProgramResult.StaticError;
			}

			if (show_help) {
				Console.Error.WriteLine ("Usage: zincoxide [Options]+ files");
				Console.Error.WriteLine ();
				Console.Error.WriteLine ("Options: ");
				p.WriteOptionDescriptions (Console.Error);
			} else {
				DirectoryInfo dirInfo = new DirectoryInfo (".");
				foreach (string name in files) {
					FileInfo[] fInfo = dirInfo.GetFiles (name);
					foreach (FileInfo info in fInfo) {
						try {
							using (FileStream file = new FileStream (info.FullName, FileMode.Open)) {
								MiniZincLexer scnr = new MiniZincLexer (file);
								MiniZincParser pars = new MiniZincParser (scnr);

								Interaction.ActiveFile = info.Name;

								Console.Error.WriteLine ("File: " + info.Name);
#if PARSE
								pars.Parse ();
#else
                                foreach (Token tok in scnr.Tokenize()) {
                                    Console.Error.Write (tok);
                                    Console.Error.Write (' ');
                                }
#endif
								if (pars.Result != null) {
									Console.Error.WriteLine ("echo: ");
									pars.Result.Write (Console.Out);
								} else {
									Interaction.Warning ("File \"{0}\" is not a valid MiniZinc file.");
								}
							}
						} catch (IOException) {
							Interaction.Warning ("File \"{0}\" not found.", info.Name);
						}
					}
				}
			}
			return (int)ProgramResult.Succes;
		}
	}
}

