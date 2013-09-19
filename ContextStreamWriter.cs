//
//  ContextStreamWriter.cs
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
using System.Text;
using System.IO;

namespace ZincOxide {
    public class ContextStreamWriter : StreamWriter {

        private int indentLevel;
        private string indent = "    ";

        public int IndentLevel {
            get {
                return this.indentLevel;
            }
        }

        public string Indent {
            get {
                return this.indent;
            }
            set {
                this.indent = value;
            }
        }

        public ContextStreamWriter (Stream stream) : base(stream) {
        }

        public ContextStreamWriter (Stream stream, Encoding encoding) : base(stream,encoding) {
        }

        public ContextStreamWriter (Stream stream, Encoding encoding, int bufferSize) : base(stream,encoding,bufferSize) {
        }

        public ContextStreamWriter (string path) : base(path) {
        }

        public ContextStreamWriter (string path, bool append) : base(path,append) {
        }

        public ContextStreamWriter (string path, bool append, Encoding encoding) : base(path,append,encoding) {
        }

        public ContextStreamWriter (string path, bool append, Encoding encoding, int bufferSize) : base(path,append,encoding,bufferSize) {
        }

        public void AddLevel () {
            this.indentLevel++;
        }

        public void SubLevel () {
            this.indentLevel = Math.Max (0x00, this.indentLevel - 0x01);
        }

    }
}

