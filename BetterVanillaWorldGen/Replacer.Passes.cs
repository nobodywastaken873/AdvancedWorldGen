namespace AdvancedWorldGen.BetterVanillaWorldGen;

public static partial class Replacer
{
	public static VanillaInterface VanillaInterface = null!;

	public static void ReplaceGenPasses(List<GenPass> genPasses)
	{
		VanillaInterface = new VanillaInterface();
		if (!WorldgenSettings.Instance.FasterWorldgen)
			return;
		genPasses.TryReplacePass("Reset", new ResetPass());
		genPasses.TryReplacePass("Terrain", new TerrainPass());
		genPasses.TryReplacePass("Generate Ice Biome", new GenerateIceBiome());
		genPasses.TryReplacePass("Jungle", new ModifiedJunglePass());
		genPasses.TryReplacePass("Floating Islands", new FloatingIslands());
		genPasses.TryReplacePass("Mushroom Patches", new MushroomPatches());
		genPasses.TryReplacePass("Shinies", new Shinies());
		genPasses.TryReplacePass("Corruption", new Corruption());
		genPasses.TryReplacePass("Dungeon", new DungeonPass());
		genPasses.TryReplacePass("Gems", new Gems());
		genPasses.TryReplacePass("Granite", new Granite());
		genPasses.TryReplacePass("Jungle Temple", new JungleTemple());
		genPasses.TryReplacePass("Jungle Chests", new JungleChests());
		genPasses.TryReplacePass("Shell Piles", new ShellPiles());
		genPasses.TryReplacePass("Life Crystals", new LifeCrystals());
		genPasses.TryReplacePass("Statues", new Statues());
		genPasses.TryReplacePass("Surface Chests", new SurfaceChests());
		genPasses.TryReplacePass("Water Chests", new WaterChests());
		genPasses.TryReplacePass("Spider Caves", new SpiderCaves());
		genPasses.TryReplacePass("Gem Caves", new GemCaves());
		genPasses.TryReplacePass("Hellforge", new Hellforge());
		genPasses.TryReplacePass("Floating Island Houses", new FloatingHouses());
		genPasses.TryReplacePass("Surface Ore and Stone", new SurfaceOreAndStone());
		genPasses.TryReplacePass("Traps", new Traps());
		genPasses.TryReplacePass("Gems In Ice Biome", new IceGems());
		genPasses.TryReplacePass("Random Gems", new RandomGems());
		genPasses.TryReplacePass("Traps", new Traps());

		int index = genPasses.FindIndex(pass => pass.Name == "Micro Biomes");
		if (index != -1)
		{
			for (int i = 1; i <= 8; i++)
			{
				MicroBiomes microBiomes = new(i);
				genPasses.Insert(index + i, microBiomes);
			}

			genPasses.Insert(index + 9, new MicroBiomes(-1)); //For mod compatibility sake
			genPasses.RemoveAt(index);
		}

		GenPasses = genPasses;
	}
}