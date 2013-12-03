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

    public class ProgramEnvironment {

        private ProgramTask task = ProgramTask.GenerateHeuristics;
        private ProgramVerbosity verbosity = ProgramVerbosity.Error | ProgramVerbosity.Warning;

        public ProgramTask Task {
            get {
                return this.task;
            }
            set {
                this.task = value;
            }
        }

        public ProgramVerbosity Verbosity {
            get {
                return this.verbosity;
            }
            set {
                this.verbosity = value;
            }
        }

        public ProgramEnvironment () {
        }

        public void SetVersbosity (string level) {
            ProgramVerbosity result;
            if (ProgramTask.TryParse (level, true, out result)) {
                this.Verbosity = result;
            } else {
                throw new ZincOxideException ("Cannot parse the verbositylevel to be executed.");
            }
        }

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

