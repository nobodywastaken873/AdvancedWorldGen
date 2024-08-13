using System.Security.Cryptography.X509Certificates;
using Terraria.Graphics;

namespace AdvancedWorldGen.BetterVanillaWorldGen;

public class Shinies : ControlledWorldGenPass
{
  public Shinies() : base("Shinies", 895.426f)
  {
  }

  protected override void ApplyPass()
  {
    Progress.Message = Lang.gen[16].Value;
    if (WorldGen.remixWorldGen)
    {
      GenerateLayers(
        Quad(6E-05, 8E-05, 0.0002, 0.0002), AdvancedWorldGenMod.Instance.UIChanger.CopperConfigurator.Configuration,
        GenVars.copper, Pair(166, 7)
      );
      GenerateLayers(
        Quad(3E-05, 8E-05, 0.0002, 0.0002), AdvancedWorldGenMod.Instance.UIChanger.IronConfigurator.Configuration,
        GenVars.iron, Pair(167, 6)
      );
      GenerateLayers(
        Quad(2.6E-05, 2.6E-05, 0.00015, 0.00017), AdvancedWorldGenMod.Instance.UIChanger.SilverConfigurator.Configuration,
        GenVars.silver, Pair(168, 9)
      );
      GenerateLayers(
        Quad(0.00012, 0.00012, 0.00012, 0.00012), AdvancedWorldGenMod.Instance.UIChanger.GoldConfigurator.Configuration,
        GenVars.gold, Pair(169, 8)
      );
      double demoniteMultiplier = AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("UndergroundCavernsRate");
      Tuple<int, int> demoniteStrength = Pair(AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("VeinStrengthMin"),
                                              AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("VeinStrengthMax"));
      Tuple<int, int> demoniteSteps = Pair(AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("VeinStepMin"),
                                           AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("VeinStepMax"));
      if (WorldGen.drunkWorldGen)
      {
        GenerateEvilOres(2.25E-05/2, demoniteMultiplier, 204, Pair((int)Main.rockLayer, Main.maxTilesY), demoniteStrength, demoniteSteps);
        GenerateEvilOres(2.25E-05/2, demoniteMultiplier, 22, Pair((int)Main.rockLayer, Main.maxTilesY), demoniteStrength, demoniteSteps);
      }
      if (WorldGen.crimson)
      {
        GenerateEvilOres(4.25E-05, demoniteMultiplier, 204, Pair((int)Main.rockLayer, Main.maxTilesY), demoniteStrength, demoniteSteps);
      }
      else
      {
        GenerateEvilOres(4.25E-05, demoniteMultiplier, 22, Pair((int)Main.rockLayer, Main.maxTilesY), demoniteStrength, demoniteSteps);
      }
    }
    else
    {
      GenerateLayers(
        Quad(6E-05, 8E-05, 0.0002, 0.0002), AdvancedWorldGenMod.Instance.UIChanger.CopperConfigurator.Configuration,
        GenVars.copper, Pair(166, 7)
      );
      GenerateLayers(
        Quad(3E-05, 8E-05, 0.0002, 0.0002), AdvancedWorldGenMod.Instance.UIChanger.IronConfigurator.Configuration,
        GenVars.iron, Pair(167, 6)
      );
      GenerateLayers(
        Quad(2.6E-05, 2.6E-05, 0.00015, 0.00017), AdvancedWorldGenMod.Instance.UIChanger.SilverConfigurator.Configuration,
        GenVars.silver, Pair(168, 9)
      );
      GenerateLayers(
        Quad(0.00012, 0.00012, 0.00012, 0.00012), AdvancedWorldGenMod.Instance.UIChanger.GoldConfigurator.Configuration,
        GenVars.gold, Pair(169, 8)
      );
      double demoniteMultiplier = AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("UndergroundCavernsRate");
      Tuple<int, int> demoniteStrength = Pair(AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("VeinStrengthMin"),
                                              AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("VeinStrengthMax"));
      Tuple<int, int> demoniteSteps = Pair(AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("VeinStepMin"),
                                           AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator.Configuration.Get<int>("VeinStepMax"));
      if (WorldGen.drunkWorldGen)
      {
        GenerateEvilOres(2.25E-05/2, demoniteMultiplier, 204, Pair((int)Main.rockLayer, Main.maxTilesY), demoniteStrength, demoniteSteps);
        GenerateEvilOres(2.25E-05/2, demoniteMultiplier, 22, Pair((int)Main.rockLayer, Main.maxTilesY), demoniteStrength, demoniteSteps);
      }
      if (WorldGen.crimson)
      {
        GenerateEvilOres(2.25E-05, demoniteMultiplier, 204, Pair((int)Main.rockLayer, Main.maxTilesY), demoniteStrength, demoniteSteps);
      }
      else
      {
        GenerateEvilOres(2.25E-05, demoniteMultiplier, 22, Pair((int)Main.rockLayer, Main.maxTilesY), demoniteStrength, demoniteSteps);
      }
    }
  }
/* baserates : (surface, underground, caverns, sky islands) - ones that are not normally possible (ie silver in surface) is filled in with whatever is above/below it (surface silver base
                                                              would be filled with underground silver base rates)
*/
  private static void GenerateLayers(Tuple<double, double, double, double> baseRates, GameConfiguration Config, int defaultOre, Tuple<int, int> bothOre) {
    GenerateNormalOres(
      baseRates.Item1, Config.Next("Surface").Get<double>("VeinMultiplier"), defaultOre, bothOre, Pair(GenVars.worldSurfaceLow, GenVars.worldSurfaceHigh),
      Pair(Config.Next("Surface").Get<int>("VeinStrengthMin"), Config.Next("Surface").Get<int>("VeinStrengthMax")),
      Pair(Config.Next("Surface").Get<int>("VeinStepMin"), Config.Next("Surface").Get<int>("VeinStepMax"))
    );
    GenerateNormalOres(
      baseRates.Item2, Config.Next("Underground").Get<double>("VeinMultiplier"), defaultOre, bothOre, Pair(GenVars.worldSurfaceHigh, GenVars.rockLayerHigh),
      Pair(Config.Next("Underground").Get<int>("VeinStrengthMin"), Config.Next("Underground").Get<int>("VeinStrengthMax")),
      Pair(Config.Next("Underground").Get<int>("VeinStepMin"), Config.Next("Underground").Get<int>("VeinStepMax"))
    );
    GenerateNormalOres(
      baseRates.Item3, Config.Next("Caverns").Get<double>("VeinMultiplier"), defaultOre, bothOre, Pair(GenVars.rockLayerLow, Main.maxTilesY),
      Pair(Config.Next("Caverns").Get<int>("VeinStrengthMin"), Config.Next("Caverns").Get<int>("VeinStrengthMax")),
      Pair(Config.Next("Caverns").Get<int>("VeinStepMin"), Config.Next("Caverns").Get<int>("VeinStepMax"))
    );
    GenerateNormalOres(
      baseRates.Item4, Config.Next("SkyIslands").Get<double>("VeinMultiplier"), defaultOre, bothOre, Pair(0, GenVars.worldSurfaceLow - (defaultOre == 169 || defaultOre == 8 ? 20 : 0)),
      Pair(Config.Next("SkyIslands").Get<int>("VeinStrengthMin"), Config.Next("SkyIslands").Get<int>("VeinStrengthMax")),
      Pair(Config.Next("SkyIslands").Get<int>("VeinStepMin"), Config.Next("SkyIslands").Get<int>("VeinStepMax"))
    );
  }

  private static void GenerateNormalOres(double baseRate, double rateModifier, int defaultOre, Tuple<int, int> bothOre, Tuple<int, int> yGenRange, Tuple<int, int> veinStrengthRange, Tuple<int, int> veinStepRange) {
    for (int index = 0; index < (int)((double)(Main.maxTilesX * Main.maxTilesY) * baseRate * rateModifier); ++index)
    {
      if (WorldGen.drunkWorldGen)
        defaultOre = !WorldGen.genRand.NextBool(2)? bothOre.Item1 : bothOre.Item2;
      WorldGen.TileRunner(
        WorldGen.genRand.Next(0, Main.maxTilesX), 
        WorldGen.genRand.Next(yGenRange.Item1, yGenRange.Item2), 
        WorldGen.genRand.Next(veinStrengthRange.Item1, veinStrengthRange.Item2), 
        WorldGen.genRand.Next(veinStepRange.Item1, veinStepRange.Item2), defaultOre
      );
    }
  }

  private static void GenerateEvilOres(double baseRate, double rateModifier, int defaultOre, Tuple<int, int> yGenRange, Tuple<int, int> veinStrengthRange, Tuple<int, int> veinStepRange) {
    for (int index = 0; index < (int)((double)(Main.maxTilesX * Main.maxTilesY) * baseRate * rateModifier); ++index)
    {
      WorldGen.TileRunner(
        WorldGen.genRand.Next(0, Main.maxTilesX), 
        WorldGen.genRand.Next(yGenRange.Item1, yGenRange.Item2), 
        WorldGen.genRand.Next(veinStrengthRange.Item1, veinStrengthRange.Item2), 
        WorldGen.genRand.Next(veinStepRange.Item1, veinStepRange.Item2), defaultOre
      );
    }
  }

  private static Tuple<int, int> Pair(int item1, int item2) {
    return new Tuple<int, int>(item1, item2);
  }

  private static Tuple<int, int> Pair(double item1, double item2) {
    return new Tuple<int, int>((int)item1, (int)item2);
  }

  private static Tuple<double, double, double, double> Quad(double item1, double item2, double item3, double item4) {
    return new Tuple<double, double, double, double>(item1, item2, item3, item4);
  }
} 