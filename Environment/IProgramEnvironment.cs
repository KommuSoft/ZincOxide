//
//  IProgramEnvironment.cs
//
//  Author:
//       Willem Van Onsem <Willem.VanOnsem@cs.kuleuven.be>
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

namespace ZincOxide.Environment {

	public interface IProgramEnvironment {

		/// <summary>
		/// The task that should be carried out of a program environment.
		/// </summary>
		ProgramTask Task {
			get;
			set;
		}

		/// <summary>
		/// The verbosity level of the program. By default only <see cref="ProgramVerbosity.Error"/> and <see cref="ProgramVerbosity.Warning"/> are selected.
		/// </summary>
		ProgramVerbosity Verbosity {
			get;
			set;
		}

		/// <summary>
		/// The way integers will be represented in the generated output.
		/// </summary>
		ProgramIntegerRepresentation IntegerRepresentation {
			get;
			set;
		}

		/// <summary>
		/// The way floats will be represented in the generated output.
		/// </summary>
		ProgramFloatRepresentation FloatRepresentation {
			get;
			set;
		}

		/// <summary>
		/// Sets the verbosity level of the program using textual input.
		/// </summary>
		/// <param name="level">The verbosity level specified by textual input.</param>
		void SetVerbosity (string level);

		/// <summary>
		/// Sets the task that should be carried out by the program using textual input.
		/// </summary>
		/// <param name="task">The task that should be carried out specified by textual input.</param>
		void SetTask (string task);
	}

}