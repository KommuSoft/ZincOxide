//
//  ProblemRepresentationGen.cs
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
using ZincOxide.Codegen.Abstract;
using ZincOxide.Codegen.Abstract.OO;
using ZincOxide.Codegen.Abstract.OO.Process;
using ZincOxide.Codegen.Abstract.Imperative;

namespace ZincOxide.Codegen.Concrete.OO {

	/// <summary>
	/// A basic implementation of the <see cref="IOOProblemRepresentationGenerator"/>. A class that generates a class for
	/// the problem representation (not a solution).
	/// </summary>
	/// <remarks>
	/// <para>The problem representation should be able to parse the problem input, check constraints,
	/// and initialize solutions.</para>
	/// </remarks>
	public class OOProblemRepresentationGenerator : OOCodegeneratorBase, IOOProblemRepresentationGenerator {

		#region Constants
		/// <summary>
		/// The suffix that of the class name that is used for problem representation.
		/// </summary>
		public const string ProblemRepresentationClassSuffix = "ProblemRepresentation";
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="OOProblemRepresentationGenerator"/> class.
		/// </summary>
		public OOProblemRepresentationGenerator () {
		}
		#endregion
		#region ICodegenerator implementation
		/// <summary>
		/// Generate code in the object-oriented programming paradigm using the given <see cref="IOOCodegenResult"/>
		/// and alter it.
		/// </summary>
		/// <param name="result">The instance that must be modified.</param>
		public override void GenerateCode (IOOCodegenResult result) {
			IClass cls = result.GenerateClass (ProblemRepresentationClassSuffix);
			IField fa = cls.GenerateField (result.GetIntegerType (), "a");
			IField fb = cls.GenerateField (result.GetIntegerType (), "b");
			IField fc = cls.GenerateField (result.GetIntegerType (), "c");
			cls.GenerateMethod (result.GetBooleanType (), "Verify");
			cls.AddConstructor (OOModifiers.Public, fa, fb, fc);
			IMethod im = cls.GenerateFormattingMethod ();
			im.Reimplement (new ReturnCommandBase (null));
		}
		#endregion
	}
}

