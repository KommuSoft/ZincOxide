//
//  AcasFunctionInstance.cs
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
using System.Collections.Generic;

namespace ZincOxide {

    public class AcasFunctionInstance : AcasExpressionBase {

        private AcasIExpression[] arguments;
        private AcasFunction function;

        public AcasFunction Function {
            get {
                return function;
            }
        }
        public AcasIExpression this [int index] {
            get {
                return this.arguments [index];
            }
        }

        public AcasFunctionInstance () {
        }

        #region implemented abstract members of ZincOxide.AcasExpressionBase
        public override IEnumerable<AcasVariable> Variables (ISet<AcasIExpression> visited) {
            foreach (AcasIExpression exp in this.arguments) {
                if (visited.Contains (exp)) {
                    foreach (AcasVariable v in exp.Variables(visited)) {
                        yield return v;
                    }
                    visited.Add (exp);
                }
            }
        }
        #endregion


    }
}

