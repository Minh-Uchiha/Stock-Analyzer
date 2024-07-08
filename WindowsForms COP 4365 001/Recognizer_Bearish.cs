using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Bearish : Recognizer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Recognizer_Bearish() : base("Bearish", 1)
        {
        }

        /// <summary>
        /// Inherited method to recognize a candlestick
        /// </summary>
        /// <param name="scsList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool Recognize(List<SmartCandlestick> scsList, int index)
        {
            //Return existing value or calculate
            SmartCandlestick scs = scsList[index];
            if (scs.dictionaryPattern.TryGetValue(this.patternName, out bool value))
            {
                return value;
            }
            else
            {
                bool bearish = scs.open > scs.close;
                scs.dictionaryPattern.Add(this.patternName, bearish);
                return bearish;
            }
        }
    }
}
