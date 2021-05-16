﻿using RimWorld;
<<<<<<< HEAD
=======
using RimWorld.Planet;
>>>>>>> beta
using Verse;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System;
<<<<<<< HEAD

namespace AvaliMod
{
    public class AvaliPackDriver : MapComponent
=======
using System.Threading.Tasks;

namespace AvaliMod
{
    public class AvaliPackDriver : GameComponent//WorldComponent//MapComponent//
>>>>>>> beta
    {
        private RimValiModSettings settings = LoadedModManager.GetMod<RimValiMod>().GetSettings<RimValiModSettings>();
        private readonly bool enableDebug = LoadedModManager.GetMod<RimValiMod>().GetSettings<RimValiModSettings>().enableDebugMode;
        private readonly int maxSize = LoadedModManager.GetMod<RimValiMod>().GetSettings<RimValiModSettings>().maxPackSize;
        private readonly bool packsEnabled = LoadedModManager.GetMod<RimValiMod>().GetSettings<RimValiModSettings>().packsEnabled;
        private readonly bool checkOtherRaces = LoadedModManager.GetMod<RimValiMod>().GetSettings<RimValiModSettings>().checkOtherRaces;
        private readonly bool allowAllRaces = LoadedModManager.GetMod<RimValiMod>().GetSettings<RimValiModSettings>().allowAllRaces;
        private readonly bool multiThreaded = LoadedModManager.GetMod<RimValiMod>().GetSettings<RimValiModSettings>().packMultiThreading;
        private readonly Dictionary<string, bool> otherRaces = LoadedModManager.GetMod<RimValiMod>().GetSettings<RimValiModSettings>().enabledRaces;
        private bool HasStarted = false;
<<<<<<< HEAD
        public static List<AvaliPack> packs = new List<AvaliPack>();
        private int onTick = 0;
        public Dictionary<Pawn, bool> pawnsHaveHadPacks = new Dictionary<Pawn, bool>(new PawnEqaulityComparer());
        public AvaliPackDriver(Map map)
            : base(map)
        {

        }
        List<ThingDef> racesInPacks = new List<ThingDef>();
=======
        public bool ThreadIsActive;
        public List<AvaliPack> packs = new List<AvaliPack>();
        private int onTick = 0;
        public Dictionary<Pawn, bool> pawnsHaveHadPacks = new Dictionary<Pawn, bool>();
        public List<Pawn> pawns = new List<Pawn>();
        public List<bool> bools = new List<bool>();

        //public AvaliPackDriver(Map map) : base(map) { }

        //public AvaliPackDriver(World world) : base(world) { }

        public AvaliPackDriver(Game game) {
            StartedNewGame();
        }//: base(game) { }

        public List<ThingDef> racesInPacks = new List<ThingDef>();

        public override void StartedNewGame()
        {
            packs = new List<AvaliPack>();
            foreach (ThingDef def in DefDatabase<ThingDef>.AllDefs.Where(x => x.HasComp(typeof(PackComp))))
            {
                racesInPacks.Add(def);
            }
            if (checkOtherRaces)
            {
                foreach (ThingDef race in RimValiDefChecks.potentialPackRaces)
                {
                    racesInPacks.Add(race);
                }
            }
            if (allowAllRaces)
            {
                foreach (ThingDef race in RimValiDefChecks.potentialRaces)
                {
                    if (otherRaces.TryGetValue(race.defName) == true)
                    {
                        racesInPacks.Add(race);
                        if (enableDebug)
                        {
                            Log.Message("Adding race: " + race.defName + " to racesInPacks.");
                        }
                    }
                }
            }
        }

        public override void LoadedGame()
        {

            foreach (ThingDef def in DefDatabase<ThingDef>.AllDefs.Where(x => x.HasComp(typeof(PackComp))))
            {
                racesInPacks.Add(def);
            }
            if (checkOtherRaces)
            {
                foreach (ThingDef race in RimValiDefChecks.potentialPackRaces)
                {
                    racesInPacks.Add(race);
                }
            }
            if (allowAllRaces)
            {
                foreach (ThingDef race in RimValiDefChecks.potentialRaces)
                {
                    if (otherRaces.TryGetValue(race.defName) == true)
                    {
                        racesInPacks.Add(race);
                        if (enableDebug)
                        {
                            Log.Message("Adding race: " + race.defName + " to racesInPacks.");
                        }
                    }
                }
            }
            ConvertAvaliContinued();
            base.LoadedGame();
        }
        public Pawn ConPawn(Pawn pawn)
        {

            Thing newSpawn = GenSpawn.Spawn(AvaliDefs.RimVali, pawn.Position, pawn.Map);
            Pawn newPawn = newSpawn as Pawn;
            newPawn.skills = pawn.skills;
            newPawn.relations = pawn.relations;
            newPawn.Name = pawn.Name;
            newPawn.needs = pawn.needs;
            newPawn.health = pawn.health;
            newPawn.inventory = pawn.inventory;
            newPawn.interactions = pawn.interactions;
            newPawn.kindDef = pawn.kindDef;
            newPawn.story = pawn.story;
            pawn.Destroy();
            return newPawn;
        }
        public void ConvertAvaliContinued()
        {
            try
            {
                foreach (Pawn pawn in PawnsFinder.All_AliveOrDead.Where(p => p.def.defName == "Avali"))
                {
                    Pawn nPawn = ConPawn(pawn);
                    RimValiRaceDef def = nPawn.def as RimValiRaceDef;
                    def.GenGraphics(nPawn);
                    
                }
            }
            catch
            {

            }
        }

>>>>>>> beta
        public void LoadAll()
        {
            packs = new List<AvaliPack>();
            if (!HasStarted)
            {
<<<<<<< HEAD
                
                racesInPacks.Add(AvaliDefs.RimVali);
                if (checkOtherRaces)
                {
                    foreach(ThingDef race in RimvaliPotentialPackRaces.potentialPackRaces)
=======
                foreach(ThingDef def in DefDatabase<ThingDef>.AllDefs.Where(x => x.HasComp(typeof(PackComp))))
                {
                    racesInPacks.Add(def);
                }
                //racesInPacks.Add(AvaliDefs.RimVali);
                if (checkOtherRaces)
                {
                    foreach(ThingDef race in RimValiDefChecks.potentialPackRaces)
>>>>>>> beta
                    {
                        racesInPacks.Add(race);
                    }
                }
                if (allowAllRaces)
                {
<<<<<<< HEAD
                    foreach(ThingDef race in RimvaliPotentialPackRaces.potentialRaces)
=======
                    foreach(ThingDef race in RimValiDefChecks.potentialRaces)
>>>>>>> beta
                    {
                        if(otherRaces.TryGetValue(race.defName) == true)
                        {
                            racesInPacks.Add(race);
<<<<<<< HEAD
=======
                            if (enableDebug)
                            {
                                Log.Message("Adding race: " + race.defName + " to racesInPacks.");
                            }
>>>>>>> beta
                        }
                    }
                }
                HasStarted = true;
            }
        }
<<<<<<< HEAD

        public override void ExposeData()
        {
            Scribe_Collections.Look<AvaliPack>(ref packs, "packs", LookMode.Deep, Array.Empty<object>());
            base.ExposeData();
        }

        public void UpdatePacks()
        {
            if (enableDebug && multiThreaded)
            {
                //Log.Message("Thread started.");
            }
            IEnumerable<Pawn> pawnsOnMap = RimValiUtility.AllPawnsOfRaceInWorld(AvaliDefs.RimVali).Where<Pawn>(x => RimValiUtility.GetPackSize(x) < maxSize);
            foreach (Pawn pawn in pawnsOnMap)
            {
//Log.Message(pawn.Faction.Name);
                //Log.Message(pawn.Name.ToString() + " updatePacks()");
                PackComp comp = pawn.TryGetComp<PackComp>();
                if (!(comp == null))
                {
                    //Pull the comp info from the pawn
                    SimpleCurve ageCurve = comp.Props.packGenChanceOverAge;
                    //Tells us that this pawn has had a pack
                    if (enableDebug)
                    {
                        //Log.Message("Attempting to make pack.. [Base pack]");
 
                    }
                    //Makes the pack.
                    //Log.Message("EiPackHandlerFromPackDriverMapComp started.");
                    packs = RimValiUtility.EiPackHandler(packs, pawn, racesInPacks, maxSize);
                }
            }
        }

        public override void MapComponentTick()
        {
            if (!HasStarted)
            {
                LoadAll();
            }
            if (onTick == 0)
            {
                if (packsEnabled)
                {
                    if (multiThreaded)
                    {
                        if (enableDebug)
                        {
                            //Log.Message("Attempting to make new thread.");
                        }
                        ThreadStart packThreadRef = new ThreadStart(UpdatePacks);
                        Thread packThread = new Thread(packThreadRef);
                        packThread.Start();
                    }
                    else
                    {
                        UpdatePacks();
                    }
                   /* Log.Message(packs.Count.ToString());
                    if (packs.Count > 0)
                    {
                        Log.Message(packs[0].name);
                    }*/
=======
        
        public override void ExposeData()
        {
            if (!pawnsHaveHadPacks.EnumerableNullOrEmpty())
            {
                foreach (Pawn pawn in pawnsHaveHadPacks.Keys)
                {
                    pawns.Add(pawn);
                    bools.Add(pawnsHaveHadPacks[pawn]);
                }
            }
            //Scribe_Collections.Look<AvaliPack>(ref packs, "packs", LookMode.Deep);
            //Scribe_Collections.Look<Pawn, bool>(ref pawnsHaveHadPacks, "pawnsHasHadPacks", LookMode.Reference, LookMode.Undefined, ref pawns, ref bools);
            Scribe_Collections.Look<Pawn, bool>(ref pawnsHaveHadPacks, "pawnsHasHadPacks", LookMode.Reference, LookMode.Undefined, ref pawns, ref bools);
            Scribe_Collections.Look<AvaliPack>(ref packs, "packs", LookMode.Deep);


            if (pawnsHaveHadPacks == null)
            {
                pawnsHaveHadPacks = new Dictionary<Pawn, bool>();
            }
            if (packs == null)
            {
                packs = new List<AvaliPack>();
            }
            if (pawns == null)
            {
                pawns = new List<Pawn>();
            }
            if (bools == null)
            {
                bools = new List<bool>();
            }
            base.ExposeData();
        }
        public void UpdatePacks()
        {
            lock (packs)
            {
                IEnumerable<Pawn> pawnsInWorld = RimValiUtility.AllPawnsOfRaceInWorld(racesInPacks).Where<Pawn>(x => RimValiUtility.GetPackSize(x) < maxSize && x.Spawned);
                foreach (Pawn pawn in pawnsInWorld)
                {
                    PackComp comp = pawn.TryGetComp<PackComp>();
                    if (!(comp == null))
                    {
                        packs = RimValiUtility.EiPackHandler(packs, pawn, racesInPacks, maxSize);
                    }
                }
            }
            ThreadIsActive = false;
        }

        public override void GameComponentTick()
        {

            if (onTick == 0 && packsEnabled)
            {
                if (multiThreaded && !ThreadIsActive)
                {
                    ThreadIsActive = true;
                    Task packTask = new Task(UpdatePacks);
                    packTask.Start();
                }
                else
                {
                    UpdatePacks();
>>>>>>> beta
                }
                onTick = 120;
            }
            else
            {
                onTick--;
            }
        }
<<<<<<< HEAD

=======
    }

    public class Converter : WorldComponent
    {
        public Converter(World world) : base(world)
        {
        }
        public void ConPawn(Pawn pawn, ThingDef def)
        {
            Pawn newPawn = PawnGenerator.GeneratePawn(pawn.kindDef, pawn.Faction);
            newPawn.def = def;
            newPawn.skills = pawn.skills;
            newPawn.relations = pawn.relations;
            newPawn.Name = pawn.Name;
            newPawn.needs = pawn.needs;
            newPawn.health = pawn.health;
            newPawn.inventory = pawn.inventory;
            newPawn.interactions = pawn.interactions;
            newPawn.story = pawn.story;
            try
            {
                
                GenSpawn.Spawn(newPawn, pawn.Position, pawn.Map);
                RimValiRaceDef d = newPawn.def as RimValiRaceDef;
                d.GenGraphics(newPawn);
                //pawn.Destroy();
            }
            catch(Exception e)
            {
                Log.Error(e.Message);
            }
            
        }
        public void ConvertAvaliContinued()
        {
            try
            {
                foreach (Pawn pawn in PawnsFinder.AllMaps.Where(p => p.def.defName == "Avali"))
                {
                    Log.Message("test world comp");
                    if (pawn != null)
                    {
                        ConPawn(pawn, AvaliMod.AvaliDefs.RimVali);
                    }
                    Log.Message("test2");
                    

                }
            }
            catch(Exception e)
            {
                Log.Message(e.Message);
            }
        }
        private bool started;
        public override void WorldComponentTick()
        {
            if (!started)
            {
                started = true;
                ConvertAvaliContinued();
            }
            base.WorldComponentTick();
        }
>>>>>>> beta
    }
}