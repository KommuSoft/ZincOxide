//
//  ProgramTask.cs
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

namespace ZincOxide {

    public enum ProgramTask : byte {
        VerifyModel             = 0x00,
        VerifyData              = 0x01,
        Match                   = 0x10,
        GenerateHeuristics      = 0x20,
        GenerateBasics          = 0x21,
        GenerateData            = 0x22,
        SynthesizeAbstractModel = 0x30,
        SynthesizeConcreteData  = 0x31,
        Assume                  = 0x40,
        Transform               = 0x50,
        Lex                     = 0xf0,
        Parse                   = 0xf1,
        Echo                    = 0xf2,
        Bindings                = 0xf3
    }

}