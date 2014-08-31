//
//  ZincOxideFormatException.cs
//
//  Author:
//       Willem Van Onsem <Willem.VanOnsem@cs.kuleuven.be>
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
using System.Runtime.Serialization;

namespace ZincOxide.Exceptions {

	/// <summary>
	/// A <see cref="ZincOxideException"/> that is thrown when the input has the wrong input.
	/// </summary>
	public class ZincOxideFormatException : ZincOxideException {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxideFormatException"/> class without specifying a message or reason.
		/// </summary>
		public ZincOxideFormatException () : base () {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxideFormatException"/> class with a message explaining the error.
		/// </summary>
		/// <param name="message">A message explaining the error.</param>
		public ZincOxideFormatException (string message) : base (message) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxideFormatException"/> class. With a parameteric message.
		/// </summary>
		/// <param name="format">The format of the error message.</param>
		/// <param name="args">Parameters that are shifted into the message.</param>
		/// <exception cref="ArgumentNullException"><paramref name="format"/> or <paramref name="args"/> is null. </exception>
		/// <exception cref="FormatException"><paramref name="format"/> is invalid. </exception>
		/// <exception cref="FormatException"><paramref name="format"/> The index of a format item is less than zero, or greater than or equal to the length of the <paramref name="args"/> array.  </exception>
		public ZincOxideFormatException (string format, params object[] args) : base (format,args) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxideFormatException"/> class. With serialization and streaming info.
		/// </summary>
		/// <param name="info">The <see cref="SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="StreamingContext"/> that contains contextual information about the source or destination.</param>
		/// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is null.</exception>
		/// <exception cref="SerializationException">The class name is null or <see cref="Exception.HResult"/> is zero (0).</exception>
		public ZincOxideFormatException (SerializationInfo info, StreamingContext context) : base (info, context) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincOxideFormatException"/> class with a message explaining the error and another Exception that caused that exception.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified. </param>
		public ZincOxideFormatException (string message, Exception innerException) : base (message, innerException) {
		}
		#endregion

	}

}