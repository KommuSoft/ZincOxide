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

namespace ZincOxide.Utils {

	public class GenerateFallbackNameRegister<T> : FallbackNameRegister<T>, IGenerateFallbackNameRegister<T> where T : IName {

		private Func<string,T> generator;

        #region IGenerateNameRegister implementation
		public Func<string,T> Generator {
			get {
				return this.generator;
			}
			set {
				this.generator = value;
			}
		}
        #endregion

		public GenerateFallbackNameRegister (DNameRegisterFallback<T> fallback, Func<string,T> generator) : base(fallback) {
			this.Generator = generator;
		}

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

	}

}