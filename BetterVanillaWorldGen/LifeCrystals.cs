namespace AdvancedWorldGen.BetterVanillaWorldGen;

public class LifeCrystals : ControlledWorldGenPass
{
  public LifeCrystals() : base("Life Crystals", 895.426f)
  {
  }

  protected override void ApplyPass()
  {
    if (WorldGen.getGoodWorldGen)
      Main.tileSolid[56] = false;
    /*if (WorldGen.notTheBees)
      WorldGen.NotTheBees();*/
    Progress.Message = Lang.gen[28].Value;
    double num216 = (double)(Main.maxTilesX * Main.maxTilesY) * 2E-05 * Params.LifeCrystalMultiplier;
    if (WorldGen.tenthAnniversaryWorldGen)
      num216 *= 1.2;
    if (Main.starGame)
      num216 *= Main.starGameMath(0.2);
    for (int index = 0; index < (int)num216; ++index)
    {
      double num217 = (double)index / ((double)(Main.maxTilesX * Main.maxTilesY) * 2E-05);
      Progress.Set(num217);
      bool flag = false;
      int num218 = 0;
      while (!flag)
      {
        int j = WorldGen.genRand.Next((int)(Main.worldSurface * 2.0 + Main.rockLayer) / 3, Main.maxTilesY - 300);
        if (WorldGen.remixWorldGen)
          j = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 400);
        if (WorldGen.AddLifeCrystal(WorldGen.genRand.Next(Main.offLimitBorderTiles, Main.maxTilesX - Main.offLimitBorderTiles), j))
        {
          flag = true;
        }
        else
        {
          ++num218;
          if (num218 >= 10000)
            flag = true;
        }
      }
    }
    Main.tileSolid[225] = false;
  }

  /*private static void NotTheBees()
    {
      int num = Main.maxTilesX / 7;
      if (!WorldGen.notTheBees)
        return;
		//go through every block above underworld/below surface
      for (int x = 0; x < Main.maxTilesX; ++x)
      {
        for (int y = 0; y < Main.maxTilesY - 180; ++y)
        {
			//not zenith/getfixedboi or specific spots in getfixedboi
          if (!WorldGen.remixWorldGen || x >= num + WorldGen.genRand.Next(3) && x < Main.maxTilesX - num - WorldGen.genRand.Next(3) && ((double) y <= (Main.worldSurface * 2.0 + Main.rockLayer) / 3.0 + (double) WorldGen.genRand.Next(3) || y >= Main.maxTilesY - 350 - WorldGen.genRand.Next(3)))
          {
			//normal -> jungle vine
            if (Main.tile[x, y].type == (ushort) 52)
              Main.tile[x, y].type = (ushort) 62;
            if ((WorldGen.SolidOrSlopedTile(x, y) || TileID.Sets.CrackedBricks[(int) Main.tile[x, y].type]) && !TileID.Sets.Ore[(int) Main.tile[x, y].type] && Main.tile[x, y].type != (ushort) 123 && Main.tile[x, y].type != (ushort) 40)
            {
				//change living wood to mahogany
              if (Main.tile[x, y].type == (ushort) 191 || Main.tile[x, y].type == (ushort) 383)
              {
                if (!WorldGen.remixWorldGen)
                  Main.tile[x, y].type = (ushort) 383;
              }
              //
			  else if (Main.tile[x, y].type == (ushort) 192 || Main.tile[x, y].type == (ushort) 384)
              {
                if (!WorldGen.remixWorldGen)
                  Main.tile[x, y].type = (ushort) 384;
              }
              else if (Main.tile[x, y].type != (ushort) 151 && Main.tile[x, y].type != (ushort) 662 && Main.tile[x, y].type != (ushort) 661 && Main.tile[x, y].type != (ushort) 189 && Main.tile[x, y].type != (ushort) 196 && Main.tile[x, y].type != (ushort) 120 && Main.tile[x, y].type != (ushort) 158 && Main.tile[x, y].type != (ushort) 175 && Main.tile[x, y].type != (ushort) 45 && Main.tile[x, y].type != (ushort) 119)
              {
                if (Main.tile[x, y].type >= (ushort) 63 && Main.tile[x, y].type <= (ushort) 68)
                  Main.tile[x, y].type = (ushort) 230;
                else if (Main.tile[x, y].type != (ushort) 57 && Main.tile[x, y].type != (ushort) 76 && Main.tile[x, y].type != (ushort) 75 && Main.tile[x, y].type != (ushort) 229 && Main.tile[x, y].type != (ushort) 230 && Main.tile[x, y].type != (ushort) 407 && Main.tile[x, y].type != (ushort) 404)
                {
                  if (Main.tile[x, y].type == (ushort) 224)
                    Main.tile[x, y].type = (ushort) 229;
                  else if (Main.tile[x, y].type == (ushort) 53)
                  {
                    if (x < WorldGen.beachDistance + WorldGen.genRand.Next(3) || x > Main.maxTilesX - WorldGen.beachDistance - WorldGen.genRand.Next(3))
                      Main.tile[x, y].type = (ushort) 229;
                  }
                  else if ((x <= WorldGen.beachDistance - WorldGen.genRand.Next(3) || x >= Main.maxTilesX - WorldGen.beachDistance + WorldGen.genRand.Next(3) || Main.tile[x, y].type != (ushort) 397 && Main.tile[x, y].type != (ushort) 396) && Main.tile[x, y].type != (ushort) 10 && Main.tile[x, y].type != (ushort) 203 && Main.tile[x, y].type != (ushort) 25 && Main.tile[x, y].type != (ushort) 137 && Main.tile[x, y].type != (ushort) 138 && Main.tile[x, y].type != (ushort) 141)
                  {
                    if (Main.tileDungeon[(int) Main.tile[x, y].type] || TileID.Sets.CrackedBricks[(int) Main.tile[x, y].type])
                      Main.tile[x, y].color((byte) 14);
                    else if (Main.tile[x, y].type == (ushort) 226)
                      Main.tile[x, y].color((byte) 15);
                    else if (Main.tile[x, y].type != (ushort) 202 && Main.tile[x, y].type != (ushort) 70 && Main.tile[x, y].type != (ushort) 48 && Main.tile[x, y].type != (ushort) 232)
                    {
                      if (TileID.Sets.Conversion.Grass[(int) Main.tile[x, y].type] || Main.tile[x, y].type == (ushort) 60 || Main.tile[x, y].type == (ushort) 70)
                        Main.tile[x, y].type = y <= GenVars.lavaLine + WorldGen.genRand.Next(-2, 3) + 2 ? (ushort) 60 : (ushort) 70;
                      else if (Main.tile[x, y].type == (ushort) 0 || Main.tile[x, y].type == (ushort) 59)
                        Main.tile[x, y].type = (ushort) 59;
                      else if (Main.tile[x, y].type != (ushort) 633)
                      {
                        if (y > GenVars.lavaLine + WorldGen.genRand.Next(-2, 3) + 2)
                          Main.tile[x, y].type = (ushort) 230;
                        else if (!WorldGen.remixWorldGen || (double) y > Main.worldSurface + (double) WorldGen.genRand.Next(-1, 2))
                          Main.tile[x, y].type = (ushort) 225;
                      }
                    }
                  }
                }
              }
            }
            if (Main.tile[x, y].wall != (ushort) 15 && Main.tile[x, y].wall != (ushort) 64 && Main.tile[x, y].wall != (ushort) 204 && Main.tile[x, y].wall != (ushort) 205 && Main.tile[x, y].wall != (ushort) 206 && Main.tile[x, y].wall != (ushort) 207 && Main.tile[x, y].wall != (ushort) 23 && Main.tile[x, y].wall != (ushort) 24 && Main.tile[x, y].wall != (ushort) 42 && Main.tile[x, y].wall != (ushort) 10 && Main.tile[x, y].wall != (ushort) 21 && Main.tile[x, y].wall != (ushort) 82 && Main.tile[x, y].wall != (ushort) 187 && Main.tile[x, y].wall != (ushort) 216 && Main.tile[x, y].wall != (ushort) 34 && Main.tile[x, y].wall != (ushort) 244)
            {
              if (Main.tile[x, y].wall == (ushort) 87)
                Main.tile[x, y].wallColor((byte) 15);
              else if (Main.wallDungeon[(int) Main.tile[x, y].wall])
                Main.tile[x, y].wallColor((byte) 14);
              else if (Main.tile[x, y].wall == (ushort) 2)
                Main.tile[x, y].wall = (ushort) 2;
              else if (Main.tile[x, y].wall == (ushort) 196)
                Main.tile[x, y].wall = (ushort) 196;
              else if (Main.tile[x, y].wall == (ushort) 197)
                Main.tile[x, y].wall = (ushort) 197;
              else if (Main.tile[x, y].wall == (ushort) 198)
                Main.tile[x, y].wall = (ushort) 198;
              else if (Main.tile[x, y].wall == (ushort) 199)
                Main.tile[x, y].wall = (ushort) 199;
              else if (Main.tile[x, y].wall == (ushort) 63)
                Main.tile[x, y].wall = (ushort) 64;
              else if (Main.tile[x, y].wall != (ushort) 3 && Main.tile[x, y].wall != (ushort) 83 && Main.tile[x, y].wall != (ushort) 73 && Main.tile[x, y].wall != (ushort) 62 && Main.tile[x, y].wall != (ushort) 13 && Main.tile[x, y].wall != (ushort) 14 && Main.tile[x, y].wall > (ushort) 0 && (!WorldGen.remixWorldGen || (double) y > Main.worldSurface + (double) WorldGen.genRand.Next(-1, 2)))
                Main.tile[x, y].wall = (ushort) 86;
            }
            if (Main.tile[x, y].liquid > (byte) 0 && y <= GenVars.lavaLine + 2)
            {
              if ((double) y > Main.rockLayer && (x < WorldGen.beachDistance + 200 || x > Main.maxTilesX - WorldGen.beachDistance - 200))
                Main.tile[x, y].honey(false);
              else if (Main.wallDungeon[(int) Main.tile[x, y].wall])
                Main.tile[x, y].honey(false);
              else
                Main.tile[x, y].honey(true);
            }
          }
        }
      }
    }*/
}