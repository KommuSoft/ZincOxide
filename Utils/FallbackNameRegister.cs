//
//  FallbackNameRegister.cs
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

namespace ZincOxide.Utils {

    public class FallbackNameRegister<T> : NameRegister<T>, IFallbackNameRegister<T> where T : IName {

        private DNameRegisterFallback<T> fallback;

        public DNameRegisterFallback<T> Fallback {
            get {
                return this.fallback;
            }
            protected set {
                this.fallback = value;
            }
        }

        public FallbackNameRegister (DNameRegisterFallback<T> fallback) {
            this.Fallback = fallback;
        }

        public override bool Contains (string name) {
            if (!base.Contains (name)) {
                try {
                    this.fallback (name);
                    return true;
                } catch (ZincOxideNameNotFoundException) {
                    return false;
                }
            }
            return true;
        }

        public override T Lookup (string name) {
            try {
                return base.Lookup (name);
            } catch (ZincOxideNameNotFoundException) {
                return this.Fallback (name);
            }
        }

    }
}

