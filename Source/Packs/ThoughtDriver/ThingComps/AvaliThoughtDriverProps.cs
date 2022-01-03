using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AvaliMod
{
    public class AvaliDriverThoughtProps : CompProperties
    {
        public ThoughtDef inSameRoomThought;
        public List<HediffDef> packLossPreventers;
        public ThoughtDef sharedBedroomThought;
        public ThoughtDef sleptApartThought;

        public AvaliDriverThoughtProps()
        {
            compClass = typeof(AvaliThoughtDriver);
        }
    }
}
