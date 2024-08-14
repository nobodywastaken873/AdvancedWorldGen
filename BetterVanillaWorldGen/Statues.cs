namespace AdvancedWorldGen.BetterVanillaWorldGen;

public class Statues : ControlledWorldGenPass
{
    public Statues() : base("Statues", 895.426f)
    {
    }

    protected override void ApplyPass()
    {
        Progress.Message = Lang.gen[29].Value;
        int index148 = 0;
        double num219 = (double)Main.maxTilesX / 4200.0;
        int num220 = (int)((double)(GenVars.statueList.Length * 2) * num219);
        if (WorldGen.noTrapsWorldGen)
        {
            num220 *= 15;
            if (WorldGen.tenthAnniversaryWorldGen || WorldGen.notTheBees)
                num220 /= 5;
        }
        if (Main.starGame)
            num220 = (int)((double)num220 * Main.starGameMath(0.2));
        num220 = (int) (num220 * AdvancedWorldGenMod.Instance.UIChanger.TrapConfigurator.Configuration.Get<double>("StatueRate"));
        for (int index149 = 0; index149 < num220; ++index149)
        {
            if (index148 >= GenVars.statueList.Length)
                index148 = 0;
            int x = (int)GenVars.statueList[index148].X;
            int y3 = (int)GenVars.statueList[index148].Y;
            double num221 = (double)(index149 / num220);
            Progress.Set(num221);
            bool flag = false;
            int num222 = 0;
            while (!flag)
            {
                int index150 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
                int y4 = WorldGen.genRand.Next((int)(Main.worldSurface * 2.0 + Main.rockLayer) / 3, Main.maxTilesY - 300);
                if (WorldGen.remixWorldGen)
                    WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 400);
                while (WorldGen.oceanDepths(index150, y4))
                {
                    index150 = WorldGen.genRand.Next(20, Main.maxTilesX - 20);
                    y4 = WorldGen.genRand.Next((int)(Main.worldSurface * 2.0 + Main.rockLayer) / 3, Main.maxTilesY - 300);
                    if (WorldGen.remixWorldGen)
                        WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY - 400);
                }
                while (!Main.tile[index150, y4].HasTile)
                {
                    ++y4;
                    if (y4 >= Main.maxTilesY)
                        break;
                }
                if (y4 < Main.maxTilesY)
                {
                    int index151 = y4 - 1;
                    if (!(Main.tile[index150, index151].LiquidType == LiquidID.Shimmer && Main.tile[index150, index151].LiquidAmount > 0))
                        WorldGen.PlaceTile(index150, index151, x, true, true, style: y3);
                    if (Main.tile[index150, index151].HasTile && (int)Main.tile[index150, index151].TileType == x)
                    {
                        flag = true;
                        if (GenVars.StatuesWithTraps.Contains(index148))
                            WorldGen.PlaceStatueTrap(index150, index151);
                        ++index148;
                    }
                    else
                    {
                        ++num222;
                        if (num222 >= 10000)
                            flag = true;
                    }
                }
            }
        }
    }
}