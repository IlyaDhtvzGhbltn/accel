using System.Drawing;
using System.Collections.Generic;


namespace ShortLinkService.BarCodeGenerator
{
    public class Code39Constants
    {
        public static readonly Color Black = Color.FromArgb(0, 0, 0);
        public static readonly Color White = Color.FromArgb(255, 255, 255);
        private const bool v0 = false;
        private const bool v1 = true;

        #region Base CODE39 Charset
        public static readonly bool[] Asterisk = { v1, v0, v0, v0, v1, v0, v1, v1, v1, v0, v1, v1, v1, v0, v1 };
        public static readonly bool[] Dot = { v1, v1, v1, v0, v0, v0, v1, v0, v1, v0, v1, v1, v1, v0, v1 };
        public static readonly bool[] Dash = { v1, v0, v0, v0, v1, v0, v1, v0, v1, v1, v1, v0, v1, v1, v1 };
        public static readonly bool[] Colon = { v1, v0, v0, v0, v1, v0, v0, v0, v1, v0, v1, v0, v0, v0, v1 };
        public static readonly bool[] Zero = { v1, v0, v1, v0, v0, v0, v1, v1, v1, v0, v1, v1, v1, v0, v1 };
        public static readonly bool[] One = { v1, v1, v1, v0, v1, v0, v0, v0, v1, v0, v1, v0, v1, v1, v1 };
        public static readonly bool[] Two = { v1, v0, v1, v1, v1, v0, v0, v0, v1, v0, v1, v0, v1, v1, v1 };
        public static readonly bool[] Three = { v1, v1, v1, v0, v1, v1, v1, v0, v0, v0, v1, v0, v1, v0, v1 };
        public static readonly bool[] Four = { v1, v0, v1, v0, v0, v0, v1, v1, v1, v0, v1, v0, v1, v1, v1 };
        public static readonly bool[] Five = { v1, v1, v1, v0, v1, v0, v0, v0, v1, v1, v1, v0, v1, v0, v1 };
        public static readonly bool[] Six = { v1, v0, v1, v1, v1, v0, v0, v0, v1, v1, v1, v0, v1, v0, v1 };
        public static readonly bool[] Seven = { v1, v0, v1, v0, v0, v0, v1, v0, v1, v1, v1, v0, v1, v1, v1 };
        public static readonly bool[] Eight = { v1, v1, v1, v0, v1, v0, v0, v0, v1, v0, v1, v1, v1, v0, v1 };
        public static readonly bool[] Nine = { v1, v0, v1, v1, v1, v0, v0, v0, v1, v0, v1, v1, v1, v0, v1 };
        public static readonly bool[] A = { v1, v1, v1, v0, v1, v0, v1, v0, v0, v0, v1, v0, v1, v1, v1 };
        public static readonly bool[] B = { v1, v0, v1, v1, v1, v0, v1, v0, v0, v0, v1, v0, v1, v1, v1 };
        public static readonly bool[] C = { v1, v1, v1, v0, v1, v1, v1, v0, v1, v0, v0, v0, v1, v0, v1 };
        public static readonly bool[] D = { v1, v0, v1, v0, v1, v1, v1, v0, v0, v0, v1, v0, v1, v1, v1 };
        public static readonly bool[] E = { v1, v1, v1, v0, v1, v0, v1, v1, v1, v0, v0, v0, v1, v0, v1 };
        public static readonly bool[] F = { v1, v0, v1, v1, v1, v0, v1, v1, v1, v0, v0, v0, v1, v0, v1 };
        public static readonly bool[] G = { v1, v0, v1, v0, v1, v0, v0, v0, v1, v1, v1, v0, v1, v1, v1 };
        public static readonly bool[] H = { v1, v1, v1, v0, v1, v0, v1, v0, v0, v0, v1, v1, v1, v0, v1 };
        public static readonly bool[] I = { v1, v0, v1, v1, v1, v0, v1, v0, v0, v0, v1, v1, v1, v0, v1 };
        public static readonly bool[] J = { v1, v0, v1, v0, v1, v1, v1, v0, v0, v0, v1, v1, v1, v0, v1 };
        public static readonly bool[] K = { v1, v1, v1, v0, v1, v0, v1, v0, v1, v0, v0, v0, v1, v1, v1 };
        public static readonly bool[] L = { v1, v0, v1, v1, v1, v0, v1, v0, v1, v0, v0, v0, v1, v1, v1 };
        public static readonly bool[] M = { v1, v1, v1, v0, v1, v1, v1, v0, v1, v0, v1, v0, v0, v0, v1 };
        public static readonly bool[] N = { v1, v0, v1, v0, v1, v1, v1, v0, v1, v0, v0, v0, v1, v1, v1 };
        public static readonly bool[] O = { v1, v1, v1, v0, v1, v0, v1, v1, v1, v0, v1, v0, v0, v0, v1 };
        public static readonly bool[] P = { v1, v0, v1, v1, v1, v0, v1, v1, v1, v0, v1, v0, v0, v0, v1 };
        public static readonly bool[] Q = { v1, v0, v1, v0, v1, v0, v1, v1, v1, v0, v0, v0, v1, v1, v1 };
        public static readonly bool[] R = { v1, v1, v1, v0, v1, v0, v1, v0, v1, v1, v1, v0, v0, v0, v1 };
        public static readonly bool[] S = { v1, v0, v1, v1, v1, v0, v1, v0, v1, v1, v1, v0, v0, v0, v1 };
        public static readonly bool[] T = { v1, v0, v1, v0, v1, v1, v1, v0, v1, v1, v1, v0, v0, v0, v1 };
        public static readonly bool[] U = { v1, v1, v1, v0, v0, v0, v1, v0, v1, v0, v1, v0, v1, v1, v1 };
        public static readonly bool[] V = { v1, v0, v0, v0, v1, v1, v1, v0, v1, v0, v1, v0, v1, v1, v1 };
        public static readonly bool[] W = { v1, v1, v1, v0, v0, v0, v1, v1, v1, v0, v1, v0, v1, v0, v1 };
        public static readonly bool[] X = { v1, v0, v0, v0, v1, v0, v1, v1, v1, v0, v1, v0, v1, v1, v1 };
        public static readonly bool[] Y = { v1, v1, v1, v0, v0, v0, v1, v0, v1, v1, v1, v0, v1, v0, v1 };
        public static readonly bool[] Z = { v1, v0, v0, v0, v1, v1, v1, v0, v1, v1, v1, v0, v1, v0, v1 };
        public static readonly bool[] SPACE = { v1, v0, v0, v0, v1, v1, v1, v0, v1, v0, v1, v1, v1, v0, v1 };
        #endregion

        #region Extended CODE39Charset
        public static readonly bool[] Slash = { v1, v0, v0, v0, v1, v0, v0, v0, v1, v0, v1, v0, v0, v0, v1, v1, v0, v0, v0, v1, v1, v1, v0, v1, v1, v1, v0, v1, v0, v1 };
        #endregion

        public static readonly Dictionary<bool[], char> Code39CharSet = new Dictionary<bool[], char>(new BoolArrayComparer()) 
        {
            { Asterisk, '*'},
            { Zero,  '0'},
            { One,   '1'},
            { Two,   '2'},
            { Three, '3'},
            { Four,  '4'},
            { Five,  '5'},
            { Six,   '6'},
            { Seven, '7'},
            { Eight, '8'},
            { Nine,  '9'},

            { A,  'A'},
            { B,  'B'},
            { C,  'C'},
            { D,  'D'},
            { E,  'E'},
            { F,  'F'},
            { G,  'G'},
            { H,  'H'},
            { I,  'I'},
            { J,  'J'},
            { K,  'K'},
            { L,  'L'},
            { M,  'M'},
            { N,  'N'},
            { O,  'O'},
            { P,  'P'},
            { Q,  'Q'},
            { R,  'R'},
            { S,  'S'},
            { T,  'T'},
            { U,  'U'},
            { V,  'V'},
            { W,  'W'},
            { X,  'X'},
            { Y,  'Y'},
            { Z,  'Z'},
            { Dot,  '.'},
            { Slash,  '/'},
            { Dash,  '-'},
            { SPACE,  ' '},
            { Colon, ':'}
        };

        public static readonly Dictionary<bool, Color> BlackWhitePixel = new Dictionary<bool, Color>()
        {
            { true, Color.FromArgb(0, 0, 0) },
            { false, Color.FromArgb(255, 255, 255) }
        };

    }
}
