using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Dragonfly_Doji : Recognizer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Recognizer_Dragonfly_Doji() : base("Dragonfly Doji", 1)
        {
        }

        /// <summary>
        /// Recognize a candlestick pattern
        /// </summary>
        /// <param name="scsList"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
                bool dragonfly = scs.lowerTail > (scs.range * 0.66m);
                bool doji = scs.bodyRange < (scs.range * 0.03m);
                bool dragonfly_doji = dragonfly & doji;
                scs.dictionaryPattern.Add(this.patternName, dragonfly_doji);
                return dragonfly_doji;
            }
        }
    }
}
