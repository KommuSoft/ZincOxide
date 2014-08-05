//
//  IGeneratedNameRegister.cs
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
using ZincOxide.Utils.Abstract;

namespace ZincOxide.Utils.Nameregister {

	/// <summary>
	/// A <see cref="T:INameRegister`1"/> with an attached generator: a function that generates an instance
	/// and adds it to the register in case a lookup operation fails.
	/// </summary>
	public interface IGenerateNameRegister<T> : INameRegister<T> where T : IName {
		
		/// <summary>
		/// Gets or sets the generator that generates new instances for the register.
		/// </summary>
		/// <value>The generator used to generate new instance to store in this
		/// <see cref="T:GenerateFallbackNameRegister`1"/>.</value>
		Func<string,T> Generator {
			get;
		}
	}
}

