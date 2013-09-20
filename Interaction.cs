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

namespace ZincOxide {

    public static class Interaction {

        private static ProgramVerbosity verbosityLevel = ProgramVerbosity.Error | ProgramVerbosity.Warning;

        public static void SetLevel (ProgramVerbosity verbosity) {
            verbosityLevel = verbosity;
        }

        public static void GenericMessage (ProgramVerbosity verbosity, string format, params object[] args) {
            if ((verbosity & verbosityLevel) != 0x00) {
                Console.Write (verbosity.ToString ());
                Console.Write (": ");
                Console.WriteLine (format, args);
            }
        }

        public static void Warning (string format, params object[] args) {
            GenericMessage (ProgramVerbosity.Remark, format, args);
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

