namespace AdvancedWorldGen.BetterVanillaWorldGen;

public class SurfaceChests : ControlledWorldGenPass
{
    public SurfaceChests() : base("Surface Chests", 895.426f)
    {
    }

    protected override void ApplyPass()
    {
        Progress.Message = Lang.gen[31].Value;
        int chestCount = (int) OverhauledWorldGenConfigurator.Configuration.Next("SurfaceChests")
                        .Get<JsonRange>("Count").GetRandom(WorldGen.genRand);
        for (int index155 = 0; index155 < chestCount; ++index155)
        {
            double num230 = (double)index155 / ((double)Main.maxTilesX * 0.005);
            Progress.Set(num230);
            bool flag22 = false;
            int num231 = 0;
            while (!flag22)
            {
                int index156 = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int index157 = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)Main.worldSurface);
                if (WorldGen.remixWorldGen)
                {
                    index157 = WorldGen.genRand.Next(Main.maxTilesY - 400, Main.maxTilesY - 150);
                }
                else
                {
                    for (; WorldGen.oceanDepths(index156, index157); index157 = WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)Main.worldSurface))
                        index156 = WorldGen.genRand.Next(300, Main.maxTilesX - 300);
                }
                bool flag23 = false;
                if (!Main.tile[index156, index157].HasTile)
                {
                    if (Main.tile[index156, index157].WallType == (ushort)2 || Main.tile[index156, index157].WallType == (ushort)59 || Main.tile[index156, index157].WallType == (ushort)244 || WorldGen.remixWorldGen)
                        flag23 = true;
                }
                else
                {
                    int num232 = 50;
                    int num233 = index156;
                    int num234 = index157;
                    int maxValue = 1;
                    for (int index158 = num233 - num232; index158 <= num233 + num232; index158 += 2)
                    {
                        for (int index159 = num234 - num232; index159 <= num234 + num232; index159 += 2)
                        {
                            if ((double)index159 < Main.worldSurface && !Main.tile[index158, index159].HasTile && Main.tile[index158, index159].WallType == (ushort)244 && WorldGen.genRand.Next(maxValue) == 0)
                            {
                                ++maxValue;
                                flag23 = true;
                                index156 = index158;
                                index157 = index159;
                            }
                        }
                    }
                }
                if (flag23 && WorldGen.AddBuriedChest(index156, index157, notNearOtherChests: true))
                {
                    flag22 = true;
                }
                else
                {
                    ++num231;
                    if (num231 >= 2000)
                        flag22 = true;
                }
            }
        }
    }
}