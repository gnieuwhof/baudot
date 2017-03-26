namespace nl.gn.BaudotPortable
{
	internal static class Constants
	{
		// Baudot alphabet:
		// http://www.cryptomuseum.com/crypto/baudot.htm

		// Shift to Figures code.
		public static readonly VBit FS = (VBit)27;

		// Shift to Letter code.
		public static readonly VBit LS = (VBit)31;

		/*
         * Note
         * There are two types of lookp arrays in this class:
         * 
         * 1) Char to Code
         * 2) Code to Char
         * 
         * 1 The Char to Code array use the ordinal
         * value of the char as index.
         * 
         * 2 The Code to Char arrays use
         * the code as index.
         */

		/******************************
         * MOST SIGNIFICANT BIT FIRST
         ******************************/

		// Main MSB first lookup array.
		// Char to code.
		// This array handles most of the Baudot characters.
		// Lookup results in 255 if the char is not a supported
		// Baudot code char.
		public static readonly byte[] MsbFirstCodeLookup = new byte[]
		{
			0,      // NUL  0
            0xFF,   // SOH  1
            0xFF,   // STX  2
            0xFF,   // ETX  3
            0xFF,   // EOT  4
            0xFF,   // ENQ  5
            0xFF,   // ACK  6
            0xFF,   // BEL  7
            0xFF,   // BS   8
            0xFF,   // HT   9
            2,      // LF   10
            0xFF,   // VF   11
            0xFF,   // FF   12
            8,      // CR   13
            0xFF,   // SO   14
            0xFF,   // SI   15
            0xFF,   // DLE  16
            0xFF,   // DC1  17
            0xFF,   // DC2  18
            0xFF,   // DC3  19
            0xFF,   // DC4  20
            0xFF,   // NAK  21
            0xFF,   // SYN  22
            0xFF,   // ETB  23
            0xFF,   // CAN  24
            0xFF,   // EM   25
            0xFF,   // SUB  26
            0xFF,   // ESC  27
            0xFF,   // FS   28
            0xFF,   // GS   29
            0xFF,   // RS   30
            0xFF,   // US   31
            4,      // SP   32
            13,     // !    33
            0xFF,   // "    34
            0xFF,   // #    35
            20,     // $    36
            0xFF,   // %    37
            26,     // &    38
            5,      // '    39
            15,     // (    40
            18,     // )    41
            0xFF,   // *    42
            17,     // +    43
            12,     // ,    44
            3,      // -    45
            28,     // .    46
            29,     // /    47
            22,     // 0    48
            23,     // 1    49
            19,     // 2    50
            1,      // 3    51
            10,     // 4    52
            16,     // 5    53
            21,     // 6    54
            7,      // 7    55
            6,      // 8    56
            24,     // 9    57
            14,     // :    58
            0xFF,   // ;    59
            0xFF,   // <    60 SL
            30,     // =    61
            0xFF,   // >    62 SF
            25,     // ?    63
            0xFF,   // @    64 WRU?
            3,      // A    65
            25,     // B    66
            14,     // C    67
            9,      // D    68
            1,      // E    69
            13,     // F    70
            26,     // G    71
            20,     // H    72
            6,      // I    73
            11,     // J    74
            15,     // K    75
            18,     // L    76
            28,     // M    77
            12,     // N    78
            24,     // O    79
            22,     // P    80
            23,     // Q    81
            10,     // R    82
            5,      // S    83
            16,     // T    84
            7,      // U    85
            30,     // V    86
            19,     // W    87
            29,     // X    88
            21,     // Y    89
            17,     // Z    90
        };

		// MSB first Letter Shift lookup array.
		// Code to char.
		public static readonly char[] MsbFirstLetterLookup = new[]
		{
			'\0', // 00000
            'E',  // 00001
            '\n', // 00010
            'A',  // 00011
            ' ',  // 00100
            'S',  // 00101
            'I',  // 00110
            'U',  // 00111
            '\r', // 01000
            'D',  // 01001
            'R',  // 01010
            'J',  // 01011
            'N',  // 01100
            'F',  // 01101
            'C',  // 01110
            'K',  // 01111
            'T',  // 10000
            'Z',  // 10001
            'L',  // 10010
            'W',  // 10011
            'H',  // 10100
            'Y',  // 10101
            'P',  // 10110
            'Q',  // 10111
            'O',  // 11000
            'B',  // 11001
            'G',  // 11010
            '>',  // 11011  // Shift to figures
            'M',  // 11100
            'X',  // 11101
            'V',  // 11110
            '_'   // 11111 // Reserved for lowercase extension
        };

		// MSB first Figure Shift lookup array.
		// Code to char.
		public static readonly char[] MsbFirstFigureLookup = new[]
		{
			'\0', // 00000
            '3',  // 00001
            '\n', // 00010
            '-',  // 00011
            ' ',  // 00100
            '\'', // 00101
            '8',  // 00110
            '7',  // 00111
            '\r', // 01000
            '@',  // 01001 // ENC/WRU?
            '4',  // 01010
            'Ю',  // 01011 // BEL
            ',',  // 01100
            '!',  // 01101
            ':',  // 01110
            '(',  // 01111
            '5',  // 10000
            '+',  // 10001
            ')',  // 10010
            '2',  // 10011
            '$',  // 10100 // £
            '6',  // 10101
            '0',  // 10110
            '1',  // 10111
            '9',  // 11000
            '?',  // 11001
            '&',  // 11010
            '~',  // 11011 // Reserved for figures extension
            '.',  // 11100
            '/',  // 11101
            '=',  // 11110
            '<'   // 11111 // Shift to letters
        };


		/******************************
         * LEAST SIGNIFICANT BIT FIRST
         ******************************/

		// Main LSB first lookup array.
		// Char to code.
		// This array handles most of the Baudot characters.
		// Lookup results in 255 if the char is not a supported
		// Baudot code char.
		public static readonly byte[] LsbFirstCodeLookup = new byte[]
		{
			0,      // NUL  0
            0xFF,   // SOH  1
            0xFF,   // STX  2
            0xFF,   // ETX  3
            0xFF,   // EOT  4
            0xFF,   // ENQ  5
            0xFF,   // ACK  6
            0xFF,   // BEL  7
            0xFF,   // BS   8
            0xFF,   // HT   9
            8,      // LF   10
            0xFF,   // VF   11
            0xFF,   // FF   12
            2,      // CR   13
            0xFF,   // SO   14
            0xFF,   // SI   15
            0xFF,   // DLE  16
            0xFF,   // DC1  17
            0xFF,   // DC2  18
            0xFF,   // DC3  19
            0xFF,   // DC4  20
            0xFF,   // NAK  21
            0xFF,   // SYN  22
            0xFF,   // ETB  23
            0xFF,   // CAN  24
            0xFF,   // EM   25
            0xFF,   // SUB  26
            0xFF,   // ESC  27
            0xFF,   // FS   28
            0xFF,   // GS   29
            0xFF,   // RS   30
            0xFF,   // US   31
            4,      // SP   32
            22,     // !    33
            0xFF,   // "    34
            0xFF,   // #    35
            5,      // $    36
            0xFF,   // %    37
            11,     // &    38
            20,     // '    39
            30,     // (    40
            9,      // )    41
            0xFF,   // *    42
            17,     // +    43
            6,      // ,    44
            24,     // -    45
            7,      // .    46
            23,     // /    47
            13,     // 0    48
            29,     // 1    49
            25,     // 2    50
            16,     // 3    51
            10,     // 4    52
            1,      // 5    53
            21,     // 6    54
            28,     // 7    55
            12,     // 8    56
            3,      // 9    57
            14,     // :    58
            0xFF,   // ;    59
            0xFF,   // <    60 SL
            15,     // =    61
            0xFF,   // >    62 SF
            19,     // ?    63
            0xFF,   // @    64 WRU?
            24,     // A    65
            19,     // B    66
            14,     // C    67
            18,     // D    68
            16,     // E    69
            22,     // F    70
            11,     // G    71
            5,      // H    72
            12,     // I    73
            26,     // J    74
            30,     // K    75
            9,      // L    76
            7,      // M    77
            6,      // N    78
            3,      // O    79
            13,     // P    80
            29,     // Q    81
            10,     // R    82
            20,     // S    83
            1,      // T    84
            28,     // U    85
            15,     // V    86
            25,     // W    87
            23,     // X    88
            21,     // Y    89
            17,     // Z    90
        };

		// LSB first Letter Shift lookup array.
		// Code to char.
		public static readonly char[] LsbFirstLetterLookup = new[]
		{
			'\0', // 00000
            'T',  // 00001
            '\r', // 00010
            'O',  // 00011 
            ' ',  // 00100
            'H',  // 00101
            'N',  // 00110
            'M',  // 00111
            '\n', // 01000
            'L',  // 01001
            'R',  // 01010
            'G',  // 01011
            'I',  // 01100
            'P',  // 01101
            'C',  // 01110
            'V',  // 01111
            'E',  // 10000
            'Z',  // 10001
            'D',  // 10010
            'B',  // 10011
            'S',  // 10100
            'Y',  // 10101
            'F',  // 10110
            'X',  // 10111
            'A',  // 11000
            'W',  // 11001
            'J',  // 11010
            '>',  // 11011 // Shift to figures
            'U',  // 11100
            'Q',  // 11101
            'K',  // 11110
            '_'   // 11111 // Reserved for lowercase extension
        };

		// MSB first Figure Shift lookup array.
		// Code to char.
		public static readonly char[] LsbFirstFigureLookup = new[]
		{
			'\0', // 00000
            '5',  // 00001
            '\r', // 00010
            '9',  // 00011
            ' ',  // 00100
            '$',  // 00101 // or £
            ',',  // 00110
            '.',  // 00111
            '\n', // 01000
            ')',  // 01001
            '4',  // 01010
            '&',  // 01011
            '8',  // 01100
            '0',  // 01101
            ':',  // 01110
            '=',  // 01111
            '3',  // 10000
            '+',  // 10001
            '@',  // 10010 // Enquiry/WRU?
            '?',  // 10011
            '\'', // 10100
            '6',  // 10101
            '!',  // 10110
            '/',  // 10111
            '-',  // 11000
            '2',  // 11001
            'Ю',  // 11010 // BEL
            '~',  // 11011 // Reserved for figures extension
            '7',  // 11100
            '1',  // 11101
            '(',  // 11110
            '<'   // 11111 // Shift to letters
        };
	}
}
