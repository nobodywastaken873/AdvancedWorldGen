namespace AdvancedWorldGen.UI;

public class OreWorldGenConfigurator : UIState
{
	public WorldSettings WorldSettings;

	public OreWorldGenConfigurator()
	{
		WorldSettings = OptionHelper.WorldSettings;
		CreateCustomSizeUI();
	}

	public void CreateCustomSizeUI()
	{
		UIPanel uiPanel = new()
		{
			HAlign = 0.5f,
			VAlign = 0.5f,
			Width = new StyleDimension(0, 0.5f),
			Height = new StyleDimension(0, 0.5f),
			BackgroundColor = UICommon.MainPanelBackground
		};
		Append(uiPanel);

		UIText uiTitle = new("Ore Options", 0.75f, true) { HAlign = 0.5f };
		uiTitle.Height = uiTitle.MinHeight;
		uiPanel.Append(uiTitle);
		uiPanel.Append(new UIHorizontalSeparator
		{
			Width = new StyleDimension(0f, 1f),
			Top = new StyleDimension(43f, 0f),
			Color = Color.Lerp(Color.White, new Color(63, 65, 151, 255), 0.85f) * 0.9f
		});

		UIScrollbar uiScrollbar = new()
		{
			Height = new StyleDimension(-110f, 1f),
			Top = new StyleDimension(50, 0f),
			HAlign = 1f
		};
		UIList uiList = new()
		{
			Height = new StyleDimension(-110f, 1f),
			Width = new StyleDimension(-20f, 1f),
			Top = new StyleDimension(50, 0f)
		};
		uiList.SetScrollbar(uiScrollbar);
		uiPanel.Append(uiScrollbar);
		uiPanel.Append(uiList);
		int index = 0;


		UITextPanel<string> goToCopperConfig =
			new(Language.GetTextValue("Mods.AdvancedWorldGen.CopperConfig"))
			{
				Width = new StyleDimension(0f, 1f)
			};
		uiList.Add(goToCopperConfig);

		goToCopperConfig.OnLeftClick += ConfigCopperWorldGen;
		goToCopperConfig.OnMouseOver += UIChanger.FadedMouseOver;
		goToCopperConfig.OnMouseOut += UIChanger.FadedMouseOut;

		UITextPanel<string> goToIronConfig =
			new(Language.GetTextValue("Mods.AdvancedWorldGen.IronConfig"))
			{
				Width = new StyleDimension(0f, 1f)
			};
		uiList.Add(goToIronConfig);

		goToIronConfig.OnLeftClick += ConfigIronWorldGen;
		goToIronConfig.OnMouseOver += UIChanger.FadedMouseOver;
		goToIronConfig.OnMouseOut += UIChanger.FadedMouseOut;

		UITextPanel<string> goToSilverConfig =
			new(Language.GetTextValue("Mods.AdvancedWorldGen.SilverConfig"))
			{
				Width = new StyleDimension(0f, 1f)
			};
		uiList.Add(goToSilverConfig);

		goToSilverConfig.OnLeftClick += ConfigSilverWorldGen;
		goToSilverConfig.OnMouseOver += UIChanger.FadedMouseOver;
		goToSilverConfig.OnMouseOut += UIChanger.FadedMouseOut;

		UITextPanel<string> goToGoldConfig =
			new(Language.GetTextValue("Mods.AdvancedWorldGen.GoldConfig"))
			{
				Width = new StyleDimension(0f, 1f)
			};
		uiList.Add(goToGoldConfig);

		goToGoldConfig.OnLeftClick += ConfigGoldWorldGen;
		goToGoldConfig.OnMouseOver += UIChanger.FadedMouseOver;
		goToGoldConfig.OnMouseOut += UIChanger.FadedMouseOut;

		UITextPanel<string> goToDemoniteConfig =
			new(Language.GetTextValue("Mods.AdvancedWorldGen.DemoniteConfig"))
			{
				Width = new StyleDimension(0f, 1f)
			};
		uiList.Add(goToDemoniteConfig);

		goToDemoniteConfig.OnLeftClick += ConfigDemoniteWorldGen;
		goToDemoniteConfig.OnMouseOver += UIChanger.FadedMouseOver;
		goToDemoniteConfig.OnMouseOut += UIChanger.FadedMouseOut;

		UITextPanel<string> goToGemsConfig =
			new(Language.GetTextValue("Mods.AdvancedWorldGen.GemsConfig"))
			{
				Width = new StyleDimension(0f, 1f)
			};
		uiList.Add(goToGemsConfig);

		goToGemsConfig.OnLeftClick += ConfigGemsWorldGen;
		goToGemsConfig.OnMouseOver += UIChanger.FadedMouseOver;
		goToGemsConfig.OnMouseOut += UIChanger.FadedMouseOut;

		UITextPanel<string> goBack = new(Language.GetTextValue("UI.Back"))
		{
			Width = new StyleDimension(0f, 0.1f),
			Top = new StyleDimension(0f, 0.75f),
			HAlign = 0.5f
		};
		goBack.OnLeftClick += GoBack;
		goBack.OnMouseOver += UIChanger.FadedMouseOver;
		goBack.OnMouseOut += UIChanger.FadedMouseOut;
		Append(goBack);
	}

	private static void ConfigCopperWorldGen(UIMouseEvent evt, UIElement listeningElement)
	{
		SoundEngine.PlaySound(SoundID.MenuOpen);
		Main.MenuUI.SetState(AdvancedWorldGenMod.Instance.UIChanger.CopperConfigurator);
	}

	private static void ConfigIronWorldGen(UIMouseEvent evt, UIElement listeningElement)
	{
		SoundEngine.PlaySound(SoundID.MenuOpen);
		Main.MenuUI.SetState(AdvancedWorldGenMod.Instance.UIChanger.IronConfigurator);
	}

	private static void ConfigSilverWorldGen(UIMouseEvent evt, UIElement listeningElement)
	{
		SoundEngine.PlaySound(SoundID.MenuOpen);
		Main.MenuUI.SetState(AdvancedWorldGenMod.Instance.UIChanger.SilverConfigurator);
	}

	private static void ConfigGoldWorldGen(UIMouseEvent evt, UIElement listeningElement)
	{
		SoundEngine.PlaySound(SoundID.MenuOpen);
		Main.MenuUI.SetState(AdvancedWorldGenMod.Instance.UIChanger.GoldConfigurator);
	}

	private static void ConfigDemoniteWorldGen(UIMouseEvent evt, UIElement listeningElement)
	{
		SoundEngine.PlaySound(SoundID.MenuOpen);
		Main.MenuUI.SetState(AdvancedWorldGenMod.Instance.UIChanger.DemoniteConfigurator);
	}

	private static void ConfigGemsWorldGen(UIMouseEvent evt, UIElement listeningElement)
	{
		SoundEngine.PlaySound(SoundID.MenuOpen);
		Main.MenuUI.SetState(AdvancedWorldGenMod.Instance.UIChanger.GemConfigurator);
	}

	private void GoBack(UIMouseEvent evt, UIElement listeningElement)
	{
		SoundEngine.PlaySound(SoundID.MenuClose);
		Main.MenuUI.SetState(new OptionsSelector());
	}

	
}