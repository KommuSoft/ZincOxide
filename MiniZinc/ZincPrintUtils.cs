//
//  ZincPrintUtils.cs
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
using ZincOxide.MiniZinc.Structures;
using ZincOxide.MiniZinc.Types.Fundamental;
using System.Diagnostics.Contracts;

namespace ZincOxide.MiniZinc {

	/// <summary>
	/// A utlity class, used to print information according to the MiniZinc standards.
	/// </summary>
	public static class ZincPrintUtils {

		#region Print literals
		/// <summary>
		/// Converts a given <see cref="string"/> to a string literal.
		/// </summary>
		/// <returns>The given value as a string literal.</returns>
		/// <param name="value">The given value to print as a string literal.</param>
		public static string StringLiteral (string value) {
			Contract.Requires (value != null);//TODO: reenable contracts
			//Contract.Ensures (Contract.Result<string> () != null);
			//Contract.Ensures (Contract.Result<string> ().Length > 0x00);
			return string.Format ("\"{0}\"", value);
		}

		/// <summary>
		/// Converts a given <see cref="ZincVarPar"/> instance to a var-par literal.
		/// </summary>
		/// <returns>The given <paramref name="varpar"/> as a var-par literal.</returns>
		/// <param name="varpar">The given <see cref="ZincVarPar"/> to convert.</param>
		public static string VarParLiteral (ZincVarPar varpar) {
			//Contract.Ensures (Contract.Result<string> () != null);
			//Contract.Ensures (Contract.Result<string> ().Length > 0x00);
			return varpar.ToString ().ToLower ();
		}

		/// <summary>
		/// Converts the given <see cref="ZincScalar"/> to its literal counterpart.
		/// </summary>
		/// <returns>The scalar literal of the given <see cref="ZincScalar"/>.</returns>
		/// <param name="scalar">The given <see cref="ZincScalar"/> to convert to its literal counterpart.</param>
		public static string ScalarLiteral (ZincScalar scalar) {
			//Contract.Ensures (Contract.Result<string> () != null);
			//Contract.Ensures (Contract.Result<string> ().Length > 0x00);
			return scalar.ToString ().ToLower ();
		}

		/// <summary>
		/// Converts the given <see cref="ZincSolveType"/> instance to its solve type literal.
		/// </summary>
		/// <returns>The solve type literal that represents the given <see cref="ZincSolveType"/>.</returns>
		/// <param name="solvetype">The given <see cref="ZincSolveType"/> to convert.</param>
		public static string SolveTypeLiteral (ZincSolveType solvetype) {
			//Contract.Ensures (Contract.Result<string> () != null);
			//Contract.Ensures (Contract.Result<string> ().Length > 0x00);
			return solvetype.ToString ().ToLower ();
		}
		#endregion
	}
}