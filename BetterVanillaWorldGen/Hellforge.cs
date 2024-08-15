namespace AdvancedWorldGen.BetterVanillaWorldGen;

public class Hellforge : ControlledWorldGenPass
{
    public Hellforge() : base("Hellforge", 895.426f)
    {
    }

    protected override void ApplyPass()
    {
        Progress.Message = Lang.gen[36].Value;
        int hellforgeCount = (int) OverhauledWorldGenConfigurator.Configuration.Next("Hellforges")
                        .Get<JsonRange>("Count").GetRandom(WorldGen.genRand);
        for (int index186 = 0; index186 < hellforgeCount; ++index186)
        {
          double num276 = (double) index186 / (double) (Main.maxTilesX / 200);
          Progress.Set(num276);
          bool flag = false;
          int num277 = 0;
          while (!flag)
          {
            int i = WorldGen.genRand.Next(1, Main.maxTilesX);
            int index187 = WorldGen.genRand.Next(Main.maxTilesY - 250, Main.maxTilesY - 30);
            try
            {
              if (Main.tile[i, index187].WallType != (ushort) 13)
              {
                if (Main.tile[i, index187].WallType != (ushort) 14)
                  continue;
              }
              while (!Main.tile[i, index187].HasTile && index187 < Main.maxTilesY - 20)
                ++index187;
              int j = index187 - 1;
              WorldGen.PlaceTile(i, j, 77);
              if (Main.tile[i, j].TileType == (ushort) 77)
              {
                flag = true;
              }
              else
              {
                ++num277;
                if (num277 >= 10000)
                  flag = true;
              }
            }
            catch
            {
              ++num277;
              if (num277 >= 10000)
                flag = true;
            }
          }
        }
    }
}