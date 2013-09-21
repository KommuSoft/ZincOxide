//
//  CSharpUtils.cs
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

namespace ZincOxide.Codegen.CSharp {

    public static class CSharpUtils {

        private static readonly Regex rgxIdentifier = new Regex (@"[A-Za-z][A-Za-z0-9_]*", RegexOptions.Compiled);
        private static readonly Regex rgxPackage = new Regex (@"[A-Za-z][A-Za-z0-9_]*(\.[A-Za-z][A-Za-z0-9_]*)*", RegexOptions.Compiled);

        public static bool ValidIdentifier (string name) {
            return rgxIdentifier.IsMatch (name);
        }

        public static bool ValidPackage (string name) {
            return rgxPackage.IsMatch (name);
        }

    }
}

