namespace AdvancedWorldGen.BetterVanillaWorldGen.TrapStuff;

public class Traps : ControlledWorldGenPass
{
  public Traps() : base("Traps", 895.426f)
  {
  }

  protected override void ApplyPass()
  {
    if (WorldGen.notTheBees && !WorldGen.noTrapsWorldGen && !WorldGen.remixWorldGen)
      return;
    WorldGen.placingTraps = true;
    Progress.Message = Lang.gen[34].Value;
    if (WorldGen.noTrapsWorldGen)
      Progress.Message = Lang.gen[91].Value;
    double num295 = (double)Main.maxTilesX * 0.05;
    if (WorldGen.noTrapsWorldGen)
    {
      if (WorldGen.tenthAnniversaryWorldGen || WorldGen.notTheBees)
        num295 *= 5.0;
      else
        num295 *= 100.0;
    }
    else if (WorldGen.getGoodWorldGen)
      num295 *= 1.5;
    if (Main.starGame)
      num295 *= Main.starGameMath(0.2);
    num295 *= AdvancedWorldGenMod.Instance.UIChanger.TrapConfigurator.Configuration.Get<double>("TrapRate");
    for (int index208 = 0; (double)index208 < num295; ++index208)
    {
      Progress.Set((double)index208 / num295 / 2.0);
      for (int index209 = 0; index209 < 1150; ++index209)
      {
        if (WorldGen.noTrapsWorldGen)
        {
          int x2 = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
          int y2 = WorldGen.genRand.Next(50, Main.maxTilesY - 50);
          if (WorldGen.remixWorldGen)
            y2 = WorldGen.genRand.Next(50, Main.maxTilesY - 210);
          if (((double)y2 > Main.worldSurface || Main.tile[x2, y2].WallType > (ushort)0) && WorldGen.placeTrap(x2, y2))
            break;
        }
        else
        {
          int index210 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
          int index211;
          for (index211 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 210); WorldGen.oceanDepths(index210, index211); index211 = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 210))
            index210 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
          if (Main.tile[index210, index211].WallType == (ushort)0 && WorldGen.placeTrap(index210, index211))
            break;
        }
      }
    }
    if (WorldGen.noTrapsWorldGen)
    {
      double num296 = (double)(Main.maxTilesX * 3) * AdvancedWorldGenMod.Instance.UIChanger.TrapConfigurator.Configuration.Get<double>("TntBarrelRateInNoTraps");
      if (Main.remixWorld)
        num296 = (double)(Main.maxTilesX / 3);
      if (Main.starGame)
        num296 *= Main.starGameMath(0.2);
      for (int index = 0; (double)index < num296; ++index)
      {
        if (Main.remixWorld)
          placeTNTBarrel(WorldGen.genRand.Next(50, Main.maxTilesX - 50), WorldGen.genRand.Next((int)Main.worldSurface, (int)((double)(Main.maxTilesY - 350) + Main.rockLayer) / 2));
        else
          placeTNTBarrel(WorldGen.genRand.Next(50, Main.maxTilesX - 50), WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200));
      }
    }
    double num297 = (double)Main.maxTilesX * 0.003;
    if (WorldGen.noTrapsWorldGen)
      num297 *= 5.0;
    else if (WorldGen.getGoodWorldGen)
      num297 *= 1.5;
    for (int index212 = 0; (double)index212 < num297; ++index212)
    {
      Progress.Set((double)index212 / num297 / 2.0 + 0.5);
      for (int index213 = 0; index213 < 20000; ++index213)
      {
        int i = WorldGen.genRand.Next((int)((double)Main.maxTilesX * 0.15), (int)((double)Main.maxTilesX * 0.85));
        int j = WorldGen.genRand.Next((int)Main.worldSurface + 20, Main.maxTilesY - 210);
        if (Main.tile[i, j].WallType == (ushort)187 && WorldGen.PlaceSandTrap(i, j))
          break;
      }
    }
    if (WorldGen.drunkWorldGen && !WorldGen.noTrapsWorldGen && !WorldGen.notTheBees)
    {
      for (int index214 = 0; index214 < 8; ++index214)
      {
        Progress.Message = Lang.gen[34].Value;
        double num298 = 100.0;
        for (int index215 = 0; (double)index215 < num298; ++index215)
        {
          Progress.Set((double)index215 / num298);
          Thread.Sleep(10);
        }
      }
    }
    if (WorldGen.noTrapsWorldGen)
      Main.tileSolid[138] = true;
    WorldGen.placingTraps = false;
  }

  public static bool placeTNTBarrel(int x, int y)
    {
      int i = x;
      int index = y;
      while (!Main.tile[i, index].HasTile)
      {
        ++index;
        if (index > Main.maxTilesY - 350)
          return false;
      }
      int j = index - 1;
      return Main.tile[i, j].LiquidType != LiquidID.Shimmer && Main.tile[i, j].LiquidAmount > 0 && WorldGen.PlaceTile(i, j, 654);
    }
}