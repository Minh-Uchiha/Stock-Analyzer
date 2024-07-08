using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Neutral : Recognizer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Recognizer_Neutral() : base("Neutral", 1)
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
                bool neutral = scs.bodyRange < (scs.range * 0.03m);
                scs.dictionaryPattern.Add(this.patternName, neutral);
                return neutral;
            }
        }
    }
}
