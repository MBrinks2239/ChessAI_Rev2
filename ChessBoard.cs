using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAI
{
    public class ChessBoard
    {
        /// <summary>
        /// <list>
        /// <item>int[0] = col</item>
        /// <item>int [1] = row</item>
        /// </list>
        /// </summary>
        public static int[] boardLoc(string loc)
        {
            int[] location = new int[2];
            string temp = loc[1].ToString();
            int num = 8 - Int32.Parse(temp);
            int lett = loc.ToLower()[0] - 97;
            location[1] = num;
            location[0] = lett;
            return location;
        }

        /// <summary>
        /// <list>
        /// <item>int[0] = col</item>
        /// <item>int [1] = row</item>
        /// </list>
        /// </summary>

        public static string boardLoc(params int[] loc)
        {
            string location = "";
            string lett = ((char)(loc[1] + 97)).ToString().ToUpper();
            location += lett;
            location += 8-loc[0];
            return location;
        }
    }
}
