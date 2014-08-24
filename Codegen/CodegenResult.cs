//
//  CodegenResult.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
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
using System;
using System.Diagnostics.Contracts;

namespace ZincOxide.Codegen {

	/// <summary>
	/// An implementation of the <see cref="ICodegenResult"/> interface describing the code generator result,
	/// the result can be altered by <see cref="ICodegenerator"/> instances.
	/// </summary>
	public class CodegenResult : ICodegenResult {

		#region Fields
		/// <summary>
		/// The environment describing how code should be written.
		/// </summary>
		private readonly ICodegenEnvironment environment;
		#endregion
		#region ICodegenResult implementation
		/// <summary>
		/// Get the environment that determines how the code should be written.
		/// </summary>
		/// <value>A <see cref="ICodegenEnvironment"/> instance specifying how code should be written.</value>
		/// <remarks>
		/// <para>The environment is ensured to be effective.</para>
		/// </remarks>
		public ICodegenEnvironment Environment {
			get {
				Contract.Ensures (Contract.Result<ICodegenEnvironment> () != null);
				return this.environment;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CodegenResult"/> class.
		/// </summary>
		/// <exception cref="ArgumentNullException">If the given environment is not effective.</exception>
		public CodegenResult (ICodegenEnvironment environment) {
			if (environment == null) {
				throw new ArgumentNullException ("environment");
			}
			Contract.EndContractBlock ();
			Contract.Ensures (this.environment != null);
			Contract.Ensures (this.environment == environment);
			this.environment = environment;
		}
		#endregion
		#region ICodegenResult implementation
		/// <summary>
		/// Generate a class with the given name.
		/// </summary>
		/// <param name="name">The name of the class that must be generated/returned.</param>
		/// <remarks>
		/// <para>The name is prefixed with the <see cref="P:ICodegenEnvironment.ClassPrefix"/> name automatically.</para>
		/// </remarks>
		public void GenerateClass (string name) {
			throw new NotImplementedException ();
		}
		#endregion
	}
}

