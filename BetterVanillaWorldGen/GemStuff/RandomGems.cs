namespace AdvancedWorldGen.BetterVanillaWorldGen.GemStuff;

public class RandomGems : ControlledWorldGenPass
{
	public RandomGems() : base("Random Gems", 895.426f)
	{
	}

	protected override void ApplyPass()
	{
        Progress.Set(1.0);
        double desertGemsRate = AdvancedWorldGenMod.Instance.UIChanger.GemConfigurator.Configuration.Get<double>("ExposedDesertGemsRate");
        double stoneGemsRate = AdvancedWorldGenMod.Instance.UIChanger.GemConfigurator.Configuration.Get<double>("ExposedStoneGemsRate");
        for (int index = 0; index < Main.maxTilesX * stoneGemsRate; ++index)
        {
            int i = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
            int j = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 300);
            if (!Main.tile[i, j].HasTile && !(Main.tile[i, j].LiquidType == LiquidID.Lava && Main.tile[i, j].LiquidAmount > 0) && !Main.wallDungeon[(int)Main.tile[i, j].WallType] && Main.tile[i, j].WallType != (ushort)27)
            {
                int num = WorldGen.genRand.Next(12);
                int style = num >= 3 ? (num >= 6 ? (num >= 8 ? (num >= 10 ? (num >= 11 ? 5 : 4) : 3) : 2) : 1) : 0;
                WorldGen.PlaceTile(i, j, 178, true, style: style);
            }
        }
        for (int index280 = 0; index280 < Main.maxTilesX * desertGemsRate; ++index280)
        {
            int index281 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
            int index282 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 300);
            if (!Main.tile[index281, index282].HasTile && !(Main.tile[index281, index282].LiquidType == LiquidID.Lava && Main.tile[index281, index282].LiquidAmount > 0) && (Main.tile[index281, index282].WallType == (ushort)216 || Main.tile[index281, index282].WallType == (ushort)187))
            {
                int num352 = WorldGen.genRand.Next(1, 4);
                int num353 = WorldGen.genRand.Next(1, 4);
                int num354 = WorldGen.genRand.Next(1, 4);
                int num355 = WorldGen.genRand.Next(1, 4);
                for (int i = index281 - num352; i < index281 + num353; ++i)
                {
                    for (int j = index282 - num354; j < index282 + num355; ++j)
                    {
                        if (!Main.tile[i, j].HasTile)
                            WorldGen.PlaceTile(i, j, 178, true, style: 6);
                    }
                }
            }
        }
    }

    
}
