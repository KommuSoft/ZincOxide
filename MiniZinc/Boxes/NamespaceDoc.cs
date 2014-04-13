//
//  NamespaceDoc.cs
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


namespace ZincOxide.MiniZinc.Boxes {

	/// <summary>
	/// The <c>Boxes</c> namespace mainly groups fields together who are frequently used in expressions.
	/// </summary>
	/// <remarks>
	/// <para>Methods who are executed recursively on expressions are implemented as well such that the calls are
	/// propagated automatically.</para>
	/// <para>This namespace is mainly used to reduce code complexity and to make sure propagation is implemented correctly.</para>
	/// <para>The names of the interfaces and classes use the following abbreviations:
	/// <list type="table">
	/// <listheader><term>Abbreviation</term><description>References</description></listheader>
	/// <item><term><c>As</c></term><description><see cref="ZincOxide.MiniZinc.Structures.IZincAnnotations"/></description></item>
	/// <item><term><c>Ex</c></term><description><see cref="ZincOxide.MiniZinc.Structures.IZincExp"/></description></item>
	/// <item><term><c>Id</c></term><description><see cref="ZincOxide.MiniZinc.Structures.IZincIdent"/></description></item>
	/// <item><term><c>Num</c></term><description><see cref="ZincOxide.MiniZinc.Structures.IZincNumExp"/></description></item>
	/// <item><term><c>Tia</c></term><description><see cref="ZincOxide.MiniZinc.Structures.IZincTypeInstExprAndIdent"/></description></item>
	/// <item><term><c>Tie</c></term><description><see cref="ZincOxide.MiniZinc.Structures.IZincTypeInstExpression"/></description></item>
	/// <item><term><c>Ty</c></term><description><see cref="ZincOxide.MiniZinc.Structures.IZincType"/></description></item>
	/// </list>
	/// </para>
	/// </remarks>
	public static class NamespaceDoc {
	}
}

