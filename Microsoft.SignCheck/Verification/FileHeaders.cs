﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SignCheck.Verification
{
    public static class FileHeaders
    {
        public const uint Zip = 0x04034b50; // PK..
        public const ushort Dos = 0x5a4d; // MZ
        public const uint Cab = 0x4d534346; // MSCF
    }
}
