//
//  Class.cs
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
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using ZincOxide.Codegen.Abstract.OO.CSharp;
using ZincOxide.Exceptions;
using ZincOxide.Codegen.Abstract.Typed;

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// The representation of an <see cref="IClass"/> in C#.
	/// </summary>
	public class Class : ClassBase, ICSharpType {

		#region Fields
		private readonly CodeTypeDeclaration data;
		#endregion
		#region Constants
		/// <summary>
		/// The name of the method that is responsible for converting an instance to a textual representation.
		/// </summary>
		public const string FormattingMethodName = "ToString";
		#endregion
		#region implemented abstract members of NameShadow
		/// <summary>
		/// Gets the name of this C# class.
		/// </summary>
		/// <value>The name of this C# class.</value>
		public override string Name {
			get {
				return data.Name;
			}
		}
		#endregion
		#region implemented abstract members of Type
		/// <summary>
		/// Get a reference to this type, used for implementation and the creation of code members.
		/// </summary>
		/// <value>A <see cref="CodeTypeReference"/> that refers to this type.</value>
		public CodeTypeReference Reference {
			get {
				return null;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Class"/> class, used to describe and alter a class in C#.
		/// </summary>
		/// <param name="data">The data that represents the class.</param>
		internal Class (CodeTypeDeclaration data) {
			Contract.Requires (data != null);
			Contract.Ensures (this.data != null);
			this.data = data;
		}
		#endregion
		#region IClass implementation
		/// <summary>
		/// Obtain the constructor with the given <paramref name="parameters"/> types.
		/// </summary>
		/// <returns>A <see cref="IConstructor"/> instance representing the queried constructor, <c>null</c> if such constructor
		/// does not exists.</returns>
		/// <param name="parameters">The list of the type of the parameters (or generalizations) of the requested constructors.</param>
		/// <remarks>
		/// <para>In case such constructor does not exists, an attempt is made to find
		/// a constructor where the parameters are generalized. If this attempt fails
		/// as well, <c>null</c> is returned.</para>
		/// </remarks>
		public override IConstructor GetConstructor (IEnumerable<IType> parameters) {
			return null;//TODO
		}

		/// <summary>
		/// Generate an (override) method that describes how to format the output 
		/// </summary>
		/// <returns>The formatting method.</returns>
		/// <param name="modifiers">The modifiers that specify how the method should be generated.</param>
		public override IMethod GenerateFormattingMethod (OOModifiers modifiers = OOModifiers.Override) {
			return this.GenerateMethod (new TypeReference (typeof(string)), FormattingMethodName, modifiers | OOModifiers.Public);//TODO: additional modifier manipulation?
		}

		/// <summary>
		/// Generate a field stored in this class.
		/// </summary>
		/// <param name='type'>The type of the field.</param>">
		/// <param name='name'>The name of the field to be added.</param>
		/// <returns>A <see cref="IField"/> instance describing the generated field.</returns>
		public override IField GenerateField (IType type, string name) {
			ICSharpType ty = type as ICSharpType;
			if (ty == null) {
				throw new ZincOxideBugException ("The type should be from the same programming language specification.");
			}
			Contract.EndContractBlock ();
			CodeMemberField cmf = new CodeMemberField (ty.Reference, name);
			this.data.Members.Add (cmf);
			return new Field (cmf);
		}

		/// <summary>
		/// Generate a method contained in this class.
		/// </summary>
		/// <returns>A <see cref="IMethod"/> that represents the generated method and can be altered.</returns>
		/// <param name="returnType">A <see cref="IType"/> that specifies the return type of the method, <c>null</c> if the return type is <c>void</c> (or irrelevant).</param>
		/// <param name="name">The name of the method to be generated.</param>
		/// <param name="modifiers">The modifiers that specify how the method should be generated.</param>
		/// <param name="fields">A list of parameters that should be defined by the method.</param>
		/// <remarks>
		/// <para>The default implementation of the method is to return the default value for the <paramref name="returnType"/>.</para>
		/// </remarks>
		public override IMethod GenerateMethod (IType returnType, string name, OOModifiers modifiers = OOModifiers.Public, params IType[] fields) {
			ICSharpType tt = returnType as ICSharpType;
			CodeMemberMethod cmm = new CodeMemberMethod ();
			cmm.Name = name;
			cmm.Attributes = CSharpUtils.ToMemberAttributes (modifiers);
			//cmm.Attributes = MemberAttributes.Public;
			if (tt != null) {
				CodeTypeReference ctr = tt.Reference;
				if (ctr != null) {
					cmm.ReturnType = ctr;
					cmm.Statements.Add (new CodeMethodReturnStatement (new CodeDefaultValueExpression (ctr)));
				}
			}
			this.data.Members.Add (cmm);
			return new Method (cmm);
		}

		/// <summary>
		/// Add a public constructor to the class that instantiates the given fields.
		/// </summary>
		/// <param name="fields">A list of fields that are all instantiated by the constructor.</param>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented.</param>
		/// <remarks>
		/// <para>The order of the constructor parameters is the same as the order of the given list.</para>
		/// <para>Fields not belonging to the class, not effective of from the wrong type are ignored.</para>
		/// </remarks>
		public override void AddConstructor (IEnumerable<IField> fields, OOModifiers modifiers = OOModifiers.Public) {
			this.addConstructor (fields.Where (x => x != null).OfType<Field> ().Select (x => x.Data), modifiers);
		}

		/// <summary>
		/// Add a constructor to the class where all fields are included as parameters.
		/// </summary>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented.</param>
		/// <remarks>
		/// <para>The order is determined by the order in which fields were added to the class.</para>
		/// <para>The constructor simply sets the fields to the given value, no consistency checks are performed.</para>
		/// <para>This method is not declarative: adding fields to the class after calling this method
		/// will not modify the constructor.</para>
		/// </remarks>
		public override void AddFieldConstructor (OOModifiers modifiers = OOModifiers.Public) {
			this.addConstructor (this.data.Members.OfType<CodeMemberField> (), modifiers);
		}

		/// <summary>
		/// Obtain the method with the given <paramref name="name"/> and the given <paramref name="parameters"/> types.
		/// </summary>
		/// <returns>A <see cref="IMethod"/> instance representing the queried method, <c>null</c> if such method
		/// does not exists.</returns>
		/// <param name="name">The name of the requested method.</param>
		/// <param name="parameters">The list of the type of the parameters (or generalizations) of the requested method.</param>
		/// <remarks>
		/// <para>In case such method does not exists, an attempt is made to find
		/// a method where the parameters are generalized. If this attempt fails
		/// as well, <c>null</c> is returned.</para>
		/// </remarks>
		public override IMethod GetMethod (string name, IEnumerable<IType> parameters) {
			return null;//TODO
		}
		#endregion
		#region private methods (for convenience)
		/// <summary>
		/// Add a public constructor to the class that instantiates the given fields.
		/// </summary>
		/// <param name="fields">A list of fields that are all instantiated by the constructor.</param>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented.</param>
		/// <remarks>
		/// <para>The order of the constructor parameters is the same as the order of the given list.</para>
		/// <para>Fields not belonging to the class, not effective of from the wrong type are ignored.</para>
		/// </remarks>
		private void addConstructor (IEnumerable<CodeMemberField> fields, OOModifiers modifiers) {
			CodeConstructor cc = new CodeConstructor ();
			cc.Attributes = CSharpUtils.ToMemberAttributes (modifiers);
			foreach (CodeMemberField f in fields) {
				CodeParameterDeclarationExpression cpde = new CodeParameterDeclarationExpression (f.Type, f.Name);
				cc.Parameters.Add (cpde);
				CodeFieldReferenceExpression cfre = new CodeFieldReferenceExpression (new CodeThisReferenceExpression (), f.Name);
				CodeVariableReferenceExpression cvre = new CodeVariableReferenceExpression (f.Name);
				cc.Statements.Add (new CodeAssignStatement (cfre, cvre));
			}
			this.data.Members.Add (cc);
		}
		#endregion
	}
}

