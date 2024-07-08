using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_COP_4365_001
{
    internal class Recognizer_Peak : Recognizer
    {
        //Inherit Constructor
        public Recognizer_Peak() : base("Peak", 3)
        {
        }

        //Abstract Method
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
                //Return false if out of bounds or continue to calculation
                int offset = this.patternLength / 2;
                if ((index < offset) | (index == scsList.Count() - offset))
                {
                    scs.dictionaryPattern.Add(this.patternName, false);
                    return false;
                }
                else
                {
                    SmartCandlestick prev = scsList[index - offset];
                    SmartCandlestick next = scsList[index + offset];
                    bool peak = (scs.high > prev.high) & (scs.high > next.high);
                    scs.dictionaryPattern.Add(this.patternName, peak);
                    return peak;
                }
            }
        }
    }
}
