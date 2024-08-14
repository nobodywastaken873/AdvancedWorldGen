namespace AdvancedWorldGen.BetterVanillaWorldGen;

public class SpiderCaves : ControlledWorldGenPass
{
    public SpiderCaves() : base("Spider Caves", 895.426f)
    {
    }

    protected override void ApplyPass()
    {
        Progress.Message = Lang.gen[64].Value;
        WorldGen.maxTileCount = 3500;
        int num242 = Main.maxTilesX / 2;
        int num243 = (int) OverhauledWorldGenConfigurator.Configuration.Next("SpiderCaves")
                            .Get<JsonRange>("Count").GetRandom(WorldGen.genRand);
        if (WorldGen.getGoodWorldGen)
          num243 *= 3;
        if (WorldGen.notTheBees)
          Main.tileSolid[225] = true;
        for (int index = 0; index < num243; ++index)
        {
          double num244 = (double) index / ((double) Main.maxTilesX * 0.005);
          Progress.Set(num244);
          int num245 = 0;
          int x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
          int y = WorldGen.genRand.Next((int) (Main.worldSurface + Main.rockLayer) / 2, Main.maxTilesY - 230);
          if (WorldGen.remixWorldGen)
            y = WorldGen.genRand.Next((int) Main.worldSurface, (int) Main.rockLayer);
          int num246 = WorldGen.countTiles(x, y, lavaOk: true);
          while ((num246 >= 3500 || num246 < 500) && num245 < num242)
          {
            ++num245;
            x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
            y = WorldGen.genRand.Next((int) Main.rockLayer + 30, Main.maxTilesY - 230);
            if (WorldGen.remixWorldGen)
              y = WorldGen.genRand.Next((int) Main.worldSurface, (int) Main.rockLayer);
            num246 = WorldGen.countTiles(x, y, lavaOk: true);
            if (WorldGen.shroomCount > 1)
              num246 = 0;
          }
          if (num245 < num242)
            WorldGen.Spread.Spider(x, y);
        }
        if (WorldGen.notTheBees)
          Main.tileSolid[225] = false;
        Main.tileSolid[162] = true;
    }
}