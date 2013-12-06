//
//  ZincScalarType.cs
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

namespace ZincOxide.MiniZinc.Types.Fundamental {

	/// <summary>
	/// An enum that represents the four different scalar types in (Mini)Zinc.
	/// </summary>
	public enum ZincScalarType : byte {
		/// <summary>
		/// Booleans represent truthhood or falsify. Booleans can be both fixed and unfixed.
		/// </summary>
		/// <remarks>
		/// <para>Fixed booleans are writted <c>bool</c> or <c>par bool</c>. Unfixed booleans are written as <c>var bool</c>.</para>
		/// <para>The domain of a boolean is finite: it contains <c>true</c> and <c>fase</c>.</para>
		/// <para>The value <c>false</c> is considered smaller than <c>true</c>.</para>
		/// <para>A fixed boolean variable must be initialized at instance-time. An unfixed boolean variable need not be.</para>
		/// <para>Varification: <c>par bool</c> to<c>var bool</c> and <c>var bool</c> to <c>var bool</c>.</para>
		/// <para>Coercion: <c>par bool</c> to <c>var bool</c>.</para>
		/// </remarks>
		Boolean = 0x00,
		/// <summary>
		/// Integers represent integral numbers. Integer representations are implementation-defined. This means the representable
		/// range of integers is implementation-defined. However, an implementation should abort at run-time if an integer operation
		/// overflows. Integers can be both fixed and unfixed.
		/// </summary>
		/// <remarks>
		/// <para>Fixed integers are writted <c>int</c> or <c>par int</c>. Unfixed integers are written as <c>var int</c>.</para>
		/// <para>The domain of a integers is infinite, unless constrainted by a set expression.</para>
		/// <para>The values have a standard order.</para>
		/// <para>A fixed integer variable must be initialized at instance-time. An unfixed integer variable need not be.</para>
		/// <para>Varification: <c>par int</c> to<c>var int</c> and <c>var int</c> to <c>var int</c>.</para>
		/// <para>Coercion: <c>par int</c> to <c>var int</c>.</para>
		/// </remarks>
		Integer = 0x01,
		/// <summary>
		/// Floats represent real numbers. Float representations are implementation-defined. This means that the representable range
		/// and precision of floats is implementation-defined. However an implementation should abort at-runtime on exceptional float
		/// operations (e.g. those that produce <c>NaN</c>s if using IEEE754 floats). Floats can be fixed or unfixed.
		/// </summary>
		/// <remarks>
		/// <para>Fixed floats are writted <c>float</c> or <c>par floats</c>. Unfixed floats are written as <c>var float</c>.</para>
		/// <para>The domain of a floats is infinite, unless constrainted by a set expression.</para>
		/// <para>The values have a standard order.</para>
		/// <para>A fixed float variable must be initialized at instance-time. An unfixed float variable need not be.</para>
		/// <para>Varification: <c>par float</c> to<c>var float</c> and <c>var float</c> to <c>var float</c>.</para>
		/// <para>Coercion: <c>par int</c> to <c>par float</c>, <c>par int</c> to <c>var float</c>, <c>var int</c> to <c>var float</c>,
		/// <c>par float</c> to <c>var float</c>.</para>
		/// </remarks>
		Float = 0x02,
		/// <summary>
		/// Strings are primitive, i.e. they are not a list of characters. String expressions are used in assertions, output items and annotations,
		/// and string literals are used in include items. Strings must be fixed.
		/// </summary>
		/// <remarks>
		/// <para>Fixed strings are writted <c>string</c> or <c>par string</c>.</para>
		/// <para>The domain of a strings is infinite, unless constrainted by a set expression.</para>
		/// <para>Strings are ordered lexicographically, using the underlying character codes.</para>
		/// <para>A string variable (which can only be fixed) must be initialized at instance-time.</para>
		/// <para>Varification: none.</para>
		/// <para>Coercion: none automatically. However any non-string value can be manually converted to a string using the built-in
		/// <c>show</c> function.</para>
		/// </remarks>
		String = 0x03
	}
}

