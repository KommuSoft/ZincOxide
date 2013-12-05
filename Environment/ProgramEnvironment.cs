//
//  ProgramEnvironment.cs
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

using System.Text.RegularExpressions;

namespace ZincOxide.Environment {

	/// <summary>
	/// A class that is used to set different parameters of the running program (for instance the task that should be executed, the verbosity level, etc.)
	/// </summary>
	public class ProgramEnvironment {
		private ProgramIntegerRepresentation dataRepresentation = ProgramIntegerRepresentation.IntegerAsInt32 | ProgramIntegerRepresentation.FloatAsSingle;
		/// <summary>
		/// The task that should be carried out. By default the <see cref="ProgramTask.GenerateHeuristics"/> is selected.
		/// </summary>
		public ProgramTask Task = ProgramTask.GenerateHeuristics;
		/// <summary>
		/// The verbosity level of the program. By default only <see cref="ProgramVerbosity.Error"/> and <see cref="ProgramVerbosity.Warning"/> are selected.
		/// </summary>
		public ProgramVerbosity Verbosity = ProgramVerbosity.Error | ProgramVerbosity.Warning;

		public ProgramIntegerRepresentation DataRepresentation {
			get {
				return this.dataRepresentation;
			}
			set {
				this.dataRepresentation = value;
				//TODO: check if valid.
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxide.Environment.ProgramEnvironment"/> class.
		/// </summary>
		public ProgramEnvironment () {
		}

		/// <summary>
		/// Sets the verbosity level of the program using textual input.
		/// </summary>
		/// <param name="level">The verbosity level specified by textual input.</param>
		public void SetVerbosity (string level) {
			ProgramVerbosity result;
			if (ProgramTask.TryParse (level, true, out result)) {
				this.Verbosity = result;
			} else {
				throw new ZincOxideException ("Cannot parse the verbositylevel to be executed.");
			}
		}

		/// <summary>
		/// Sets the task that should be carried out by the program using textual input.
		/// </summary>
		/// <param name="task">The task that should be carried out specified by textual input.</param>
		public void SetTask (string task) {
			ProgramTask result;
			if (ProgramTask.TryParse (task, true, out result)) {
				this.Task = result;
			} else {
				throw new ZincOxideException ("Cannot parse the task to be executed.");
			}
		}
	}
}

