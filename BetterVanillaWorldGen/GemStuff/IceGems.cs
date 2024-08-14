namespace AdvancedWorldGen.BetterVanillaWorldGen.GemStuff;

public class IceGems : ControlledWorldGenPass
{
	public IceGems() : base("Gems In Ice Biome", 895.426f)
	{
	}

    protected override void ApplyPass()
    {
        Progress.Set(1.0);
        double iceGemsRate = AdvancedWorldGenMod.Instance.UIChanger.GemConfigurator.Configuration.Get<double>("ExposedIceGemsRate");
        for (int index277 = 0; (double)index277 < (double)Main.maxTilesX * 0.25 * iceGemsRate; ++index277)
        {
            int index278 = !WorldGen.remixWorldGen ? WorldGen.genRand.Next((int)(Main.worldSurface + Main.rockLayer) / 2, GenVars.lavaLine) : WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);
            int index279 = WorldGen.genRand.Next(GenVars.snowMinX[index278], GenVars.snowMaxX[index278]);
            if (Main.tile[index279, index278].HasTile && (Main.tile[index279, index278].TileType == (ushort)147 || Main.tile[index279, index278].TileType == (ushort)161 || Main.tile[index279, index278].TileType == (ushort)162 || Main.tile[index279, index278].TileType == (ushort)224))
            {
                int num347 = WorldGen.genRand.Next(1, 4);
                int num348 = WorldGen.genRand.Next(1, 4);
                int num349 = WorldGen.genRand.Next(1, 4);
                int num350 = WorldGen.genRand.Next(1, 4);
                int num351 = WorldGen.genRand.Next(12);
                int style = num351 >= 3 ? (num351 >= 6 ? (num351 >= 8 ? (num351 >= 10 ? (num351 >= 11 ? 5 : 4) : 3) : 2) : 1) : 0;
                for (int i = index279 - num347; i < index279 + num348; ++i)
                {
                    for (int j = index278 - num349; j < index278 + num350; ++j)
                    {
                        if (!Main.tile[i, j].HasTile)
                            WorldGen.PlaceTile(i, j, 178, true, style: style);
                    }
                }
            }
        }
    }
}