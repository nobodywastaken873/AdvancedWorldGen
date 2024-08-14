namespace AdvancedWorldGen.BetterVanillaWorldGen;

public class WaterChests : ControlledWorldGenPass
{
    public WaterChests() : base("Water Chests", 895.426f)
    {
    }

    protected override void ApplyPass()
    {
        Progress.Message = Lang.gen[33].Value;
        for (int index = 0; index < GenVars.numOceanCaveTreasure; ++index)
        {
          int contain = (int) WorldGen.genRand.NextFromList<short>((short) 863, (short) 186, (short) 277, (short) 187, (short) 4404);
          bool flag = false;
          double num235 = 2.0;
          while (!flag && num235 < 50.0)
          {
            num235 += 0.1;
            int num236 = WorldGen.genRand.Next(GenVars.oceanCaveTreasure[index].X - (int) num235, GenVars.oceanCaveTreasure[index].X + (int) num235 + 1);
            int j = WorldGen.genRand.Next(GenVars.oceanCaveTreasure[index].Y - (int) num235 / 2, GenVars.oceanCaveTreasure[index].Y + (int) num235 / 2 + 1);
            int i = num236 >= Main.maxTilesX ? (int) ((double) num236 + num235 / 2.0) : (int) ((double) num236 - num235 / 2.0);
            if (Main.tile[i, j].LiquidAmount > (byte) 250 && (Main.tile[i, j].LiquidType == (byte) 0 || WorldGen.notTheBees || WorldGen.remixWorldGen))
              flag = WorldGen.AddBuriedChest(i, j, contain, Style: 17, trySlope: true);
          }
        }
        int num237 = 0;
        int numChests = (int) OverhauledWorldGenConfigurator.Configuration.Next("WaterChests")
                        .Get<JsonRange>("Count").GetRandom(WorldGen.genRand) / 2;
        for (int index = 0; (double) index < numChests; ++index)
        {
          double num239 = (double) index / (numChests);
          Progress.Set(num239);
          ++num237;
          int maxValue = 10;
          if (WorldGen.tenthAnniversaryWorldGen)
            maxValue = 7;
          int contain;
          if (WorldGen.genRand.Next(maxValue) == 0)
          {
            contain = 863;
          }
          else
          {
            switch (num237)
            {
              case 1:
                contain = 186;
                break;
              case 2:
                contain = 4404;
                break;
              case 3:
                contain = 277;
                break;
              default:
                contain = 187;
                num237 = 0;
                break;
            }
          }
          bool flag24 = false;
          int num240 = 0;
          while (!flag24)
          {
            int i = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
            int j;
            for (j = WorldGen.genRand.Next(1, Main.UnderworldLayer); Main.tile[i, j].LiquidAmount < (byte) 250 || Main.tile[i, j].LiquidType != (byte) 0 && !WorldGen.notTheBees && !WorldGen.remixWorldGen; j = WorldGen.genRand.Next(50, Main.UnderworldLayer))
              i = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
            flag24 = WorldGen.AddBuriedChest(i, j, contain, Style: 17, trySlope: i < WorldGen.beachDistance || i > Main.maxTilesX - WorldGen.beachDistance);
            ++num240;
            if (num240 > 10000)
              break;
          }
          bool flag25 = false;
          int num241 = 0;
          while (!flag25)
          {
            int i = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
            int j;
            for (j = WorldGen.genRand.Next((int) Main.worldSurface, Main.UnderworldLayer); Main.tile[i, j].LiquidAmount < (byte) 250 || Main.tile[i, j].LiquidType != (byte) 0 && !WorldGen.notTheBees; j = WorldGen.genRand.Next((int) Main.worldSurface, Main.UnderworldLayer))
              i = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
            flag25 = WorldGen.AddBuriedChest(i, j, contain, Style: 17, trySlope: i < WorldGen.beachDistance || i > Main.maxTilesX - WorldGen.beachDistance);
            ++num241;
            if (num241 > 10000)
              break;
          }
        }
    }
}