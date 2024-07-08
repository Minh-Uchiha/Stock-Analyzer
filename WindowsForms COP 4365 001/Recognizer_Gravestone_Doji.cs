using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Gravestone_Doji : Recognizer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Recognizer_Gravestone_Doji() : base("Gravestone Doji", 1)
        {
        }

        /// <summary>
        /// Recognize a candlestick pattern
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
                bool gravestone = scs.upperTail > (scs.range * 0.66m);
                bool doji = scs.bodyRange < (scs.range * 0.03m);
                bool gravestone_doji = gravestone & doji;
                scs.dictionaryPattern.Add(this.patternName, gravestone_doji);
                return gravestone_doji;
            }
        }
    }
}
