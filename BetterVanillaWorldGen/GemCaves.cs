namespace AdvancedWorldGen.BetterVanillaWorldGen;

public class GemCaves : ControlledWorldGenPass
{
    public GemCaves() : base("Gem Caves", 895.426f)
    {
    }

    protected override void ApplyPass()
    {
        if (WorldGen.notTheBees)
          return;
        Progress.Message = Lang.gen[64].Value;
        WorldGen.maxTileCount = 300;
        double num247 = (double) OverhauledWorldGenConfigurator.Configuration.Next("GemCaves")
                        .Get<JsonRange>("Count").GetRandom(WorldGen.genRand);
        if (WorldGen.tenthAnniversaryWorldGen)
          num247 *= 1.5;
        if (Main.starGame)
          num247 *= Main.starGameMath(0.2);
        for (int index163 = 0; (double) index163 < num247; ++index163)
        {
          double num248 = (double) index163 / num247;
          Progress.Set(num248);
          int num249 = 0;
          int x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
          int y = WorldGen.genRand.Next((int) Main.rockLayer + 30, Main.maxTilesY - 230);
          if (WorldGen.remixWorldGen)
            y = WorldGen.genRand.Next((int) Main.worldSurface + 30, (int) Main.rockLayer - 30);
          for (int index164 = WorldGen.countTiles(x, y); (index164 >= 300 || index164 < 50 || WorldGen.lavaCount > 0 || WorldGen.iceCount > 0 || WorldGen.rockCount == 0) && num249 < 1000; index164 = WorldGen.countTiles(x, y))
          {
            ++num249;
            x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
            y = WorldGen.genRand.Next((int) Main.rockLayer + 30, Main.maxTilesY - 230);
            if (WorldGen.remixWorldGen)
              y = WorldGen.genRand.Next((int) Main.worldSurface + 30, (int) Main.rockLayer - 30);
          }
          if (num249 < 1000)
            WorldGen.gemCave(x, y);
        }
    }
}