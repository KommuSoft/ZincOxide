//
//  GenerateFallbackNameRegister.cs
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
using ZincOxide.Exceptions;
using ZincOxide.Utils.Abstract;

namespace ZincOxide.Utils.Nameregister {

	/// <summary>
	/// A name register that provides a generator and supports the use of a fallback mechanism: a mechanism
	/// used to search for the identifier if not stored in this register.
	/// </summary>
	public class GenerateFallbackNameRegister<T> : FallbackNameRegister<T>, IGenerateFallbackNameRegister<T> where T : IName {

		#region Fields
		/// <summary>
		/// The generator function used to generate a new instance.
		/// </summary>
		private Func<string,T> generator;
		#endregion
		#region IGenerateNameRegister implementation
		/// <summary>
		/// Gets or sets the generator that generates new instances for the register.
		/// </summary>
		/// <value>The generator used to generate new instance to store in this
		/// <see cref="T:GenerateFallbackNameRegister`1"/>.</value>
		public Func<string,T> Generator {
			get {
				return this.generator;
			}
			set {
				this.generator = value;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="T:GenerateFallbackNameRegister`1"/> class with a given
		/// intial generator.
		/// </summary>
		/// <param name="generator">The given intial generator function.</param>
		/// <remarks>
		/// <para>The system is initialized without fallback mechanism, no fallback will be executed.</para>
		/// </remarks>
		public GenerateFallbackNameRegister (Func<string,T> generator) : base(null) {
			this.Generator = generator;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:GenerateFallbackNameRegister`1"/> class with a given
		/// fallback mechanism and generator function.
		/// </summary>
		/// <param name="fallback">The fallback mechanism that must be used before the system aims to
		/// generate a new instance.</param>
		/// <param name="generator">The generator, that must generate new instances .</param>
		public GenerateFallbackNameRegister (DNameRegisterFallback<T> fallback, Func<string,T> generator) : base(fallback) {
			this.Generator = generator;
		}
		#endregion
		#region FallbackNameRegister override
		/// <summary>
		/// Looks up the given name in the name register. If the register contains an object with the given name, the
		/// object is returned. Otherwise the object is generated using the fallback mechanism, stored in register and
		/// returned.
		/// </summary>
		/// <param name="name">The specified key to lookup.</param>
		public override T Lookup (string name) {
			T val;
			try {
				return base.Lookup (name);
			} catch (ZincOxideNameNotFoundException) {
				val = this.Generator (name);
				this.Register (val);
				return val;
			}
		}
		#endregion
	}
}