//
//  INameRegisterFallback.cs
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

namespace ZincOxide.Utils {

    /// <summary>
    /// A delegate who is used as a fallback mechanism in case the name is not found in the <see cref="T:IFallbackNameRegister"/>.
    /// </summary>
    /// <param name="name">The name looked for by the <see cref="T:IFallbackNameRegister"/></param>.
    /// <returns>The value corresponding to the given name who was looked for by the <see cref="T:IFallbackNameRegister"/></returns>
    /// <exception cref="ZincOxideNameNotFoundException">In case the fallback mechanism fails as well.</exception>
    public delegate T DNameRegisterFallback<T> (string name) where T : IName;

}