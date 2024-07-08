using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Doji : Recognizer
    {
        public Recognizer_Doji() : base("Doji", 1)
        {
        }

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
                bool doji = scs.bodyRange < (scs.range * 0.03m);
                scs.dictionaryPattern.Add(this.patternName, doji);
                return doji;
            }
        }
    }
}
