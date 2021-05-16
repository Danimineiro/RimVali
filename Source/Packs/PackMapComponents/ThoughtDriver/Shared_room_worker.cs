﻿using System;
using Verse;
using RimWorld;
namespace AvaliMod
{
    public class Shared_workRoom : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn pawn)
        {
            AvaliThoughtDriver avaliThoughtDriver = pawn.TryGetComp<AvaliThoughtDriver>();
            PackComp packComp = pawn.TryGetComp<PackComp>();
            if (!(avaliThoughtDriver == null))
            {
                if (pawn.Awake())
                {
                    if (pawn.CheckIfPackmatesInRoom())
                    {
                        return ThoughtState.ActiveDefault;
                    }
                    else
                    {
                        return ThoughtState.Inactive;
                    }
                }
                else
                {
                    return ThoughtState.Inactive;
                }
            }
            else
            {
                return ThoughtState.Inactive;
            }
        }
    }
}