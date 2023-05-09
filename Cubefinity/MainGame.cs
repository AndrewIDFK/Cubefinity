using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Timers;



namespace Cubefinity
{
    public class MainGame : Game
    {
        private Timer _saveTimer;
        ResourceManager resourceManager;
        BigNumber expoNumeration;
        private ConfirmationPopup _confirmationPopup;


        public static List<CubeGenerator> _cubeGenerators;
        public static List<FractalGenerator> _fractalGenerators;
        public static List<FluxStuff> _fluxStuff;
        public static List<Upgrade> _upgrades;
        public static List<Upgrade> _fluxUpgrades;
        public static List<Upgrade> _prismUpgrades;
        public static List<Upgrade> _fractalUpgrades;
        public static List<Achievement> _achievements;

        private GameState _gameState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #region Generators And Such
        CubeGenerator cubeProducer;
        CubeGenerator cubeArchitect;
        CubeGenerator cubeEngineer;
        UIButtonSmallFont cubeProducerButton;
        UIButtonSmallFont cubeArchitectButton;
        UIButtonSmallFont cubeEngineerButton;

        CubeGenerator cubeVisionary;
        UIButtonSmallFont cubeVisionaryButton;
        CubeGenerator cubeOmni;
        UIButtonSmallFont cubeOmniButton;
        

        public static FluxStuff primer;
        UIButtonSmallFont primerButton;
        public static FluxStuff overcharger;
        UIButtonSmallFont overchargerButton;

        FractalGenerator fractalWeaver;
        UIButtonSmallFont fractalWeaverButton;
        FractalGenerator fractalForger;
        UIButtonSmallFont fractalForgerButton;
        FractalGenerator fractalNexus;
        UIButtonSmallFont fractalNexusButton;

        #endregion

        #region upgrades

        //Upgrades
        Upgrade prodUpgrade1;
        UIUpgradeButton prodUpgrade1Button;
        Upgrade archUpgrade1;
        UIUpgradeButton archUpgrade1Button;
        Upgrade engiUpgrade1;
        UIUpgradeButton engiUpgrade1Button;
        Upgrade prodMultiFromArch;
        UIUpgradeButton prodMultiFromArchButton;
        Upgrade prodMultiFromArchMulti;
        UIUpgradeButton prodMultiFromArchMultiButton;
        Upgrade allCubeMultiUp;
        UIUpgradeButton allCubeMultiUpButton;
        Upgrade archMultiFromEngi;
        UIUpgradeButton archMultiFromEngiButton;
        Upgrade cube10GenToMulti;
        UIUpgradeButton cube10GenToMultiButton;
        Upgrade prod5Multi;
        UIUpgradeButton prod5MultiButton;
        Upgrade arch5Multi;
        UIUpgradeButton arch5MultiButton;
        Upgrade engi5Multi;
        UIUpgradeButton engi5MultiButton;
        Upgrade archMultiFromEngiMulti;
        UIUpgradeButton archMultiFromEngiMultiButton;
        Upgrade prodSaleUpgrade;
        UIUpgradeButton prodSaleUpgradeButton;
        Upgrade archSaleUpgrade;
        UIUpgradeButton archSaleUpgradeButton;
        Upgrade engiSaleUpgrade;
        UIUpgradeButton engiSaleUpgradeButton;
        Upgrade engiMultiFromProd;
        UIUpgradeButton engiMultiFromProdButton;
        Upgrade cube10GenToSale;
        UIUpgradeButton cube10GenToSaleButton;
        Upgrade cube50ProdToProdMult;
        UIUpgradeButton cube50ProdToProdMultButton;
        Upgrade visMultFromProd;
        UIUpgradeButton visMultFromProdButton;
        Upgrade visMultFromArch;
        UIUpgradeButton visMultFromArchButton; 
        Upgrade visMultFromEngi;
        UIUpgradeButton visMultFromEngiButton; 
        Upgrade visBaseMultUp;
        UIUpgradeButton visBaseMultUpButton;
        Upgrade threeMultiUpFromVis;
        UIUpgradeButton threeMultiUpFromVisButton;
    
        Upgrade prodFromPrimer;
        UIUpgradeButton prodFromPrimerButton;
        Upgrade archFromPrimer;
        UIUpgradeButton archFromPrimerButton;
        Upgrade engiFromPrimer;
        UIUpgradeButton engiFromPrimerButton;
        Upgrade visFromOvercharger;
        UIUpgradeButton visFromOverchargerButton;
        Upgrade omniFromOvercharger;
        UIUpgradeButton omniFromOverchargerButton;
        Upgrade baseOmniMultiUp;
        UIUpgradeButton baseOmniMultiUpButton;
        Upgrade allGen100ToOmniMult;
        UIUpgradeButton allGen100ToOmniMultButton;
        Upgrade cubeFinalUpgrade1;
        UIUpgradeButton cubeFinalUpgrade1Button;
        Upgrade cubeFinalUpgrade2;
        UIUpgradeButton cubeFinalUpgrade2Button;
        
        //Automation upgrades
        Upgrade autoProducers; 
        UIUpgradeButton autoProducersButton;
        Upgrade autoArchitects;
        UIUpgradeButton autoArchitectsButton; 
        Upgrade autoEngineers;
        UIUpgradeButton autoEngineersButton; 
        Upgrade autoVisionary;
        UIUpgradeButton autoVisionaryButton;  
        Upgrade autoOmni;
        UIUpgradeButton autoOmniButton;

        // from fluxAchievement7
        Upgrade autoProducersBoost; 
        UIUpgradeButton autoProducersBoostButton;
        Upgrade autoArchitectsBoost; 
        UIUpgradeButton autoArchitectsBoostButton;
        Upgrade autoEngineersBoost; 
        UIUpgradeButton autoEngineersBoostButton;
        Upgrade autoVisionaryBoost; 
        UIUpgradeButton autoVisionaryBoostButton;
        Upgrade autoOmniBoost; 
        UIUpgradeButton autoOmniBoostButton;

        // from fluxAchievement7
        Upgrade autoPrimer;
        UIUpgradeButton autoPrimerButton;
        Upgrade autoOvercharger;
        UIUpgradeButton autoOverchargerButton;

        // from fluxAchievement9
        Upgrade autoPrimerBoost;
        UIUpgradeButton autoPrimerBoostButton;
        Upgrade autoOverchargerBoost;
        UIUpgradeButton autoOverchargerBoostButton;

        // from fluxAchievement5
        Upgrade fluxUpgrade1; 
        UIUpgradeButton fluxUpgrade1Button; 
        Upgrade fluxUpgrade2;
        UIUpgradeButton fluxUpgrade2Button; 
        Upgrade fluxUpgrade3;
        UIUpgradeButton fluxUpgrade3Button; 
        Upgrade fluxUpgrade4;
        UIUpgradeButton fluxUpgrade4Button;
        Upgrade fluxUpgrade5;
        UIUpgradeButton fluxUpgrade5Button;
        Upgrade fluxUpgrade6;
        UIUpgradeButton fluxUpgrade6Button;

        // from fluxAchievement6
        Upgrade fluxUpgrade7;
        UIUpgradeButton fluxUpgrade7Button;
        Upgrade fluxUpgrade8;
        UIUpgradeButton fluxUpgrade8Button;
        Upgrade fluxUpgrade9;
        UIUpgradeButton fluxUpgrade9Button;
        

        // from ritualAchievement1
        Upgrade prismUpgrade1;
        UIUpgradeButton prismUpgrade1Button;
        Upgrade prismUpgrade2;
        UIUpgradeButton prismUpgrade2Button;
        Upgrade prismUpgrade3;
        UIUpgradeButton prismUpgrade3Button;

        // from ritualAchievement2
        Upgrade prismUpgrade4;
        UIUpgradeButton prismUpgrade4Button;
        Upgrade prismUpgrade5;
        UIUpgradeButton prismUpgrade5Button;
        Upgrade prismUpgrade6;
        UIUpgradeButton prismUpgrade6Button;

        // Fractal Upgrades
        Upgrade fractalUpgrade1;
        UIUpgradeButton fractalUpgrade1Button;
        Upgrade fractalUpgrade2;
        UIUpgradeButton fractalUpgrade2Button;
        Upgrade fractalUpgrade3;
        UIUpgradeButton fractalUpgrade3Button;
        Upgrade fractalUpgrade4;
        UIUpgradeButton fractalUpgrade4Button;
        Upgrade fractalUpgrade5;
        UIUpgradeButton fractalUpgrade5Button;
        Upgrade fractalUpgrade6;
        UIUpgradeButton fractalUpgrade6Button;
        Upgrade fractalUpgrade7;
        UIUpgradeButton fractalUpgrade7Button;
        Upgrade fractalUpgrade8;
        UIUpgradeButton fractalUpgrade8Button;
        Upgrade fractalUpgrade9;
        UIUpgradeButton fractalUpgrade9Button;
        Upgrade fractalUpgrade10;
        UIUpgradeButton fractalUpgrade10Button;
        Upgrade fractalUpgrade11;
        UIUpgradeButton fractalUpgrade11Button;

        // from ritualAchievement3
        Upgrade prismUpgrade7;
        UIUpgradeButton prismUpgrade7Button;
        Upgrade prismUpgrade8;
        UIUpgradeButton prismUpgrade8Button;
        Upgrade prismUpgrade9;
        UIUpgradeButton prismUpgrade9Button;

        // from ritualAchievement5
        Upgrade prismUpgrade10;
        UIUpgradeButton prismUpgrade10Button;
        Upgrade prismUpgrade11;
        UIUpgradeButton prismUpgrade11Button;
        Upgrade prismUpgrade12;
        UIUpgradeButton prismUpgrade12Button;
        Upgrade prismUpgrade13;
        UIUpgradeButton prismUpgrade13Button;
        Upgrade prismUpgrade14;
        UIUpgradeButton prismUpgrade14Button;
        
        // from cubeAmountAch13
        Upgrade trueFinalCubeUpgrade;
        UIUpgradeButton trueFinalCubeUpgradeButton;

        // from ritualAmountAch6
        Upgrade prismUpgrade15;
        UIUpgradeButton prismUpgrade15Button;
        Upgrade prismUpgrade16;
        UIUpgradeButton prismUpgrade16Button;
        Upgrade prismUpgrade17;
        UIUpgradeButton prismUpgrade17Button;

        // from ritualAmountAch6
        Upgrade prismUpgrade18;
        UIUpgradeButton prismUpgrade18Button;
        Upgrade prismUpgrade19;
        UIUpgradeButton prismUpgrade19Button;

        // from fractalAmountAch5
        Upgrade fractalUpgrade12;
        UIUpgradeButton fractalUpgrade12Button;
        Upgrade fractalUpgrade13;
        UIUpgradeButton fractalUpgrade13Button;
        Upgrade fractalUpgrade14;
        UIUpgradeButton fractalUpgrade14Button;
        Upgrade fractalUpgrade15;
        UIUpgradeButton fractalUpgrade15Button;

        #endregion

        #region Achievements

        Achievement cubeAmountAch1;
        UIAchievementButton cubeAmountAch1Button;
        Achievement cubeAmountAch2;
        UIAchievementButton cubeAmountAch2Button;
        Achievement cubeAmountAch3;
        UIAchievementButton cubeAmountAch3Button;
        Achievement cubeAmountAch4;
        UIAchievementButton cubeAmountAch4Button;
        Achievement cubeAmountFluxUnlock;
        UIAchievementButton cubeAmountFluxUnlockButton;
        Achievement cubeAmountAch6;
        UIAchievementButton cubeAmountAch6Button;
        Achievement cubeAmountAch7;
        UIAchievementButton cubeAmountAch7Button;
        Achievement cubeAmountAch8;
        UIAchievementButton cubeAmountAch8Button;

        Achievement fluxuateAmountAch1;
        UIAchievementButton fluxuateAmountAch1Button;
        Achievement fluxuateAmountAch2;
        UIAchievementButton fluxuateAmountAch2Button;
        Achievement fluxuateAmountAch3;
        UIAchievementButton fluxuateAmountAch3Button; 
        Achievement fluxuateAmountAch4;
        UIAchievementButton fluxuateAmountAch4Button;
        Achievement fluxuateAmountAch5;
        UIAchievementButton fluxuateAmountAch5Button;
        Achievement fluxuateAmountAch6;
        UIAchievementButton fluxuateAmountAch6Button; 
        
        Achievement cubeAmountAch9;
        UIAchievementButton cubeAmountAch9Button;
        Achievement cubeAmountAch10;
        UIAchievementButton cubeAmountAch10Button;
        
        Achievement ritualAmountAch1;
        UIAchievementButton ritualAmountAch1Button; 
        Achievement ritualAmountAch2;
        UIAchievementButton ritualAmountAch2Button;
        Achievement ritualAmountAch3;
        UIAchievementButton ritualAmountAch3Button;
        Achievement ritualAmountAch4;
        UIAchievementButton ritualAmountAch4Button;
        Achievement ritualAmountAch5;
        UIAchievementButton ritualAmountAch5Button;
        Achievement ritualAmountAch6;
        UIAchievementButton ritualAmountAch6Button;

        Achievement cubeAmountAch11;
        UIAchievementButton cubeAmountAch11Button;
        Achievement cubeAmountAch12;
        UIAchievementButton cubeAmountAch12Button;
        Achievement cubeAmountAch13;
        UIAchievementButton cubeAmountAch13Button;
        Achievement cubeAmountAch14;
        UIAchievementButton cubeAmountAch14Button;
        Achievement cubeAmountAch15;
        UIAchievementButton cubeAmountAch15Button;
        Achievement cubeAmountAch16;
        UIAchievementButton cubeAmountAch16Button; 
        Achievement cubeAmountAch17;
        UIAchievementButton cubeAmountAch17Button;

        Achievement fluxuateAmountAch7;
        UIAchievementButton fluxuateAmountAch7Button; 
        Achievement fluxuateAmountAch8;
        UIAchievementButton fluxuateAmountAch8Button; 
        Achievement fluxuateAmountAch9;
        UIAchievementButton fluxuateAmountAch9Button; 
        Achievement fluxuateAmountAch10;
        UIAchievementButton fluxuateAmountAch10Button; 
        Achievement fluxuateAmountAch11;
        UIAchievementButton fluxuateAmountAch11Button; 
        Achievement fluxuateAmountAch12;
        UIAchievementButton fluxuateAmountAch12Button; 

        Achievement ritualAmountAch7;
        UIAchievementButton ritualAmountAch7Button;

        Achievement fractalAmountAch1;
        UIAchievementButton fractalAmountAch1Button;
        Achievement fractalAmountAch2;
        UIAchievementButton fractalAmountAch2Button;
        Achievement fractalAmountAch3;
        UIAchievementButton fractalAmountAch3Button;
        Achievement fractalAmountAch4;
        UIAchievementButton fractalAmountAch4Button;
        Achievement fractalAmountAch5;
        UIAchievementButton fractalAmountAch5Button;


        #endregion

        #region statics

        public static SpriteFont font;
        public static SpriteFont infoFont;
        public static SpriteFont currencyFont;
        public static Texture2D EmptyTexture;
        public static Texture2D ButtonTexture;
        public static Texture2D BuyButtonTexture;
        public static Texture2D BuyAmountButtonTexture;
        public static Texture2D UpgradeTexture;
        public static Texture2D BaseCubeUpgradeIcon;
        public static Texture2D CubeUpgradeRecycleIcon;
        public static Texture2D MultiCubeUpgradeIcon;
        public static Texture2D CubeUpgradeXIcon;
        public static Texture2D CubeUpgradeSaleIcon;
        public static Texture2D MultiCubeSaleIcon;
        public static Texture2D TwoCubeSaleIcon;
        public static Texture2D AchievementTexture;
        public static Texture2D AutoCubeUpgradeIcon;
        public static Texture2D PrimerUpgradeIcon;
        public static Texture2D PrimerUpgradeSaleIcon;
        public static Texture2D PrimerUpgradeRecycleIcon;
        public static Texture2D PrismUpgradeIcon;
        public static Texture2D PrismUpgradeRecycleIcon;
        public static Texture2D FractalUpgradeIcon;
        public static Texture2D FractalUpgradeRecycleIcon;
        public static Texture2D FractalUpgradeSaleIcon;
        public static Texture2D PrismUpgradeSaleIcon;
        public static Texture2D AutoFluxUpgradeIcon;
        public static Color colorLineColor; 
        public static Color rightPanelColor;
        #endregion

        string currentHoverText = "";
        string currentFluxHoverText = "";
        private List<Component> _gameComponents;

        UILabel titleLabel;
        UILabel cubeLabel;
        UILabel fluxLabel;
        UILabel prismLabel;
        UILabel fractalLabel;
        UILabel sigilCubeLabel;
        UIButton generatorsButton;
        UIButton upgradesButton;
        UIButton achievementsButton;
        UIButton fractGenButton;
        UIButton sigilsButton;


        UIButton cubeBuy1Button;
        UIButton cubeBuy10Button;
        UIButton cubeBuy25Button;
        UIButton cubeBuy50Button;
        UIButton cubeBuy100Button;
        UIButton cubeBuyMaxButton;

        UIButton fluxuateButton;
        UIButton ritualButton;

        public static double _baseProducerMultiplier = 1;
        public static double _baseProducerCostMulti = 1;
        public static double _baseArchitectMultiplier = 1;
        public static double _baseArchitectCostMulti = 1;
        public static double _baseEngineerMultiplier = 1;
        public static double _baseEngineerCostMulti = 1;

        public static double _baseVisionaryMultiplier = 1;
        public static double _baseVisionaryCostMulti = 1; 
        public static double _baseOmniMultiplier = 1;
        public static double _baseOmniCostMulti = 1;

        public static double _basePrimerCostMulti = 1;
        public static double _baseOverchargerCostMulti = 1;

        public static double _baseWeaverMultiplier = 1;
        public static double _baseWeaverCostMulti = 1;
        public static double _baseForgerMultiplier = 1;
        public static double _baseForgerCostMulti = 1;
        public static double _baseNexusMultiplier = 1;
        public static double _baseNexusCostMulti = 1;


        bool isCubeGeneratorsSectionOpen = false;
        bool isUpgradeSectionOpen = false;
        bool isAchievementSectionOpen = false;
        bool isFractalGeneratorsSectionOpen = false;
        bool isSigilsSectionOpen = false;
        private AchievementPopup _achievementPopup;
        public static Queue<AchievementPopup> AchievementQueue = new Queue<AchievementPopup>();

        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            Window.Position = new Point(0, 0);

            Window.ClientSizeChanged += OnClientSizeChanged;
        }
        private void OnClientSizeChanged(object sender, EventArgs e)
        {
            UpdateUIPositions();
        }
        public const float DesignWidth = 1920;
        public const float DesignHeight = 1080;

        private void UpdateUIPositions()
        {
            fluxuatePos = new Vector2(1920 * 0.847f - 85 + 25, 1080 * 0.825f);

            genButtonPos = new Vector2(1920 * 0.05125f + 40, 1080 * 0.45f); 
            upgradeButtonPos = new Vector2(1920 * 0.05f + 40, 1080 * 0.50f); 
            achievementButtonPos = new Vector2(1920 * 0.05f + 40, 1080 * 0.55f);  

            cubeUpgrade1Pos = new Vector2(1920 * 0.3f - 120 + 40, 1080 * 0.025f);
            achievement1Pos = new Vector2(1920 * 0.165f - 120 + 40, 1080 * 0.05f);

            cubeBuyAmountPos = new Vector2(1920 * 0.1705f - 80 + 40, 1080 * 0);
            cubeProducerPos = new Vector2(1920 * 0.235f - 80 + 40, 1080 * 0.25f);
        }



        #region Vector2
        Vector2 fluxuatePos;

        Vector2 genButtonPos;
        Vector2 upgradeButtonPos;
        Vector2 achievementButtonPos;

        Vector2 cubeUpgrade1Pos;
        Vector2 achievement1Pos;

        Vector2 cubeBuyAmountPos;
        Vector2 cubeProducerPos;

        #endregion

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            colorLineColor = new Color(27, 24, 102);

            rightPanelColor = new Color(42, 42, 42);
            #region Content Loading
            // Load the stuff
            MainGame.font = Content.Load<SpriteFont>("UI/MenuFont");
            MainGame.infoFont = Content.Load<SpriteFont>("UI/InfoFont");
            MainGame.currencyFont = Content.Load<SpriteFont>("UI/CurrencyFont");
            MainGame.EmptyTexture = Content.Load<Texture2D>("UI/EmptyTexture");
            MainGame.ButtonTexture = Content.Load<Texture2D>("UI/ButtonTexture");
            MainGame.BuyButtonTexture = Content.Load<Texture2D>("UI/BuyButtonTexture");
            MainGame.BuyAmountButtonTexture = Content.Load<Texture2D>("UI/BuyAmountButtonTexture");
            MainGame.UpgradeTexture = Content.Load<Texture2D>("UI/SquareDiamondTexture");
            MainGame.BaseCubeUpgradeIcon = Content.Load<Texture2D>("UI/UpgradeIcons/BaseCubeUpgradeIcon");
            MainGame.CubeUpgradeRecycleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/CubeUpgradeRecycleIcon");
            MainGame.MultiCubeUpgradeIcon = Content.Load<Texture2D>("UI/UpgradeIcons/MultiCubeUpgradeIcon");
            MainGame.CubeUpgradeXIcon = Content.Load<Texture2D>("UI/UpgradeIcons/CubeUpgradeXIcon");
            MainGame.CubeUpgradeSaleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/CubeUpgradeSaleIcon");
            MainGame.MultiCubeSaleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/MultiCubeSaleIcon");
            MainGame.TwoCubeSaleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/TwoCubeSaleIcon");
            MainGame.AchievementTexture = Content.Load<Texture2D>("UI/TriangleTexture");
            MainGame.AutoCubeUpgradeIcon = Content.Load<Texture2D>("UI/UpgradeIcons/AutoCubeUpgradeIcon");
            MainGame.PrimerUpgradeIcon = Content.Load<Texture2D>("UI/UpgradeIcons/PrimerUpgradeIcon");
            MainGame.PrimerUpgradeSaleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/PrimerUpgradeSaleIcon");
            MainGame.PrimerUpgradeRecycleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/PrimerUpgradeRecycleIcon");
            MainGame.PrismUpgradeIcon = Content.Load<Texture2D>("UI/UpgradeIcons/PrismUpgradeIcon");
            MainGame.PrismUpgradeRecycleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/PrismUpgradeRecycleIcon");
            MainGame.FractalUpgradeIcon = Content.Load<Texture2D>("UI/UpgradeIcons/FractalUpgradeIcon");
            MainGame.FractalUpgradeRecycleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/FractalUpgradeRecycleIcon");
            MainGame.FractalUpgradeSaleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/FractalUpgradeSaleIcon");
            MainGame.PrismUpgradeSaleIcon = Content.Load<Texture2D>("UI/UpgradeIcons/PrismUpgradeSaleIcon");
            MainGame.AutoFluxUpgradeIcon = Content.Load<Texture2D>("UI/UpgradeIcons/AutoFluxUpgradeIcon");
            #endregion

            titleLabel = new UILabel(new Vector2(70, 50), "CUBEFINITY", font, 1.1f);
            cubeLabel = new UILabel(new Vector2(1640, 44), "Cubes", currencyFont, 1.05f);
            fluxLabel = new UILabel(new Vector2(1640, 44 + 50), "Flux", currencyFont, 1.05f);
            prismLabel = new UILabel(new Vector2(1640, 44 + 100), "Prisms", currencyFont, 1.05f);
            fractalLabel = new UILabel(new Vector2(1640, 44 + 150), "Fractals", currencyFont, 1.05f);
            sigilCubeLabel = new UILabel(new Vector2(1920 / 2, 44 + 200), "Sigil Cubes", currencyFont, 1.05f);

            #region Left Menu Buttons

            generatorsButton = new UIButton(ButtonTexture, new Rectangle(0, 120, 220, 50), new Vector2(60, 450), "Cube Generators", font, new Color(27, 24, 102), Color.White);
            upgradesButton = new UIButton(ButtonTexture, new Rectangle(60, 170, 160, 50), new Vector2(60, 500), "Upgrades", font, new Color(153, 72, 21), Color.White);
            achievementsButton = new UIButton(ButtonTexture, new Rectangle(30, 220, 190, 50), new Vector2(60, 550), "Achievements", font, new Color(184, 138, 13), Color.White);
            fractGenButton = new UIButton(ButtonTexture, new Rectangle(30, 220, 265, 50), new Vector2(-10, 400), "Fractal Gens", font, new Color(184, 13, 59), Color.White);
            sigilsButton = new UIButton(ButtonTexture, new Rectangle(30, 220, 295, 50), new Vector2(-10, 400), "Sigils", font, new Color(147, 9, 22), Color.White);
            generatorsButton.Click += GeneratorsButton_Clicked;
            upgradesButton.Click += UpgradesButton_Clicked;
            achievementsButton.Click += AchievementsButton_Clicked;
            fractGenButton.Click += FractGenButton_Clicked;
            sigilsButton.Click += SigilsButton_Clicked;
            #endregion

            _prodAutoButton = new UIButton(ButtonTexture, new Rectangle(0, 220, 140, 24), new Vector2(cubeProducerPos.X + 60, cubeProducerPos.Y - 20), "AUTO", font, Color.DarkRed, Color.White);
            _prodAutoButton.Click += ProdAutoButton_Clicked;

            _archAutoButton = new UIButton(ButtonTexture, new Rectangle(0, 220, 140, 24), new Vector2(cubeProducerPos.X + 390 + 60, cubeProducerPos.Y - 20), "AUTO", font, Color.DarkRed, Color.White);
            _archAutoButton.Click += ArchAutoButton_Clicked;

            _engiAutoButton = new UIButton(ButtonTexture, new Rectangle(0, 220, 140, 24), new Vector2(cubeProducerPos.X + 780 + 60, cubeProducerPos.Y - 20), "AUTO", font, Color.DarkRed, Color.White);
            _engiAutoButton.Click += EngiAutoButton_Clicked;

            _visAutoButton = new UIButton(ButtonTexture, new Rectangle(0, 220, 140, 24), new Vector2(cubeProducerPos.X + 195 + 60, cubeProducerPos.Y - 20 + 300), "AUTO", font, Color.DarkRed, Color.White);
            _visAutoButton.Click += VisAutoButton_Clicked;

            _omniAutoButton = new UIButton(ButtonTexture, new Rectangle(0, 220, 140, 24), new Vector2(cubeProducerPos.X + 585 + 60, cubeProducerPos.Y - 20 + 300), "AUTO", font, Color.DarkRed, Color.White);
            _omniAutoButton.Click += OmniAutoButton_Clicked;

            _primerAutoButton = new UIButton(ButtonTexture, new Rectangle(0, 220, 140, 24), new Vector2(cubeProducerPos.X + 60, cubeProducerPos.Y + 600 - 20), "AUTO", font, Color.DarkRed, Color.White);
            _primerAutoButton.Click += PrimerAutoButton_Clicked;
            
            _overchargerAutoButton = new UIButton(ButtonTexture, new Rectangle(0, 220, 140, 24), new Vector2(cubeProducerPos.X + 780 + 60, cubeProducerPos.Y + 600 - 20), "AUTO", font, Color.DarkRed, Color.White);
            _overchargerAutoButton.Click += OverchargerAutoButton_Clicked;


            #region Cube Generator Area

            cubeProducerButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), cubeProducerPos, "", font, new Color(36, 36, 36), Color.White);
            cubeProducerButton.Click += CubeProducerButton_Clicked;

            cubeArchitectButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), new Vector2(cubeProducerPos.X + 390, cubeProducerPos.Y), "", font, new Color(36, 36, 36), Color.White);
            cubeArchitectButton.Click += CubeArchitectButton_Clicked;

            cubeEngineerButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), new Vector2(cubeProducerPos.X + 780, cubeProducerPos.Y), "", font, new Color(36, 36, 36), Color.White);
            cubeEngineerButton.Click += CubeEngineerButton_Clicked;

            cubeVisionaryButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), new Vector2(cubeProducerPos.X + 195, cubeProducerPos.Y + 300), "", font, new Color(36, 36, 36), Color.White);
            cubeVisionaryButton.Click += CubeVisionaryButton_Clicked;

            cubeOmniButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), new Vector2(cubeProducerPos.X + 585, cubeProducerPos.Y + 300), "", font, new Color(36, 36, 36), Color.White);
            cubeOmniButton.Click += CubeOmniButton_Clicked;

            cubeBuy1Button = new UIButton(EmptyTexture, new Rectangle(0, 220, 48, 32), cubeBuyAmountPos, "1", font, new Color(42, 42, 42), Color.White);
            cubeBuy1Button.Click += CubeBuy1Button_Clicked;

            cubeBuy10Button = new UIButton(EmptyTexture, new Rectangle(0, 220, 48, 32), new Vector2(cubeBuyAmountPos.X + 48, cubeBuyAmountPos.Y), "10", font, new Color(42, 42, 42), Color.White);
            cubeBuy10Button.Click += CubeBuy10Button_Clicked;

            cubeBuy25Button = new UIButton(EmptyTexture, new Rectangle(0, 220, 48, 32), new Vector2(cubeBuyAmountPos.X + 96, cubeBuyAmountPos.Y), "25", font, new Color(42, 42, 42), Color.White);
            cubeBuy25Button.Click += CubeBuy25Button_Clicked;

            cubeBuy50Button = new UIButton(EmptyTexture, new Rectangle(0, 220, 48, 32), new Vector2(cubeBuyAmountPos.X + 144, cubeBuyAmountPos.Y), "50", font, new Color(42, 42, 42), Color.White);
            cubeBuy50Button.Click += CubeBuy50Button_Clicked;

            cubeBuy100Button = new UIButton(EmptyTexture, new Rectangle(0, 220, 48, 32), new Vector2(cubeBuyAmountPos.X + 192, cubeBuyAmountPos.Y), "100", font, new Color(42, 42, 42), Color.White);
            cubeBuy100Button.Click += CubeBuy100Button_Clicked;

            cubeBuyMaxButton = new UIButton(EmptyTexture, new Rectangle(0, 220, 48, 32), new Vector2(cubeBuyAmountPos.X + 240, cubeBuyAmountPos.Y), "MAX", font, new Color(42, 42, 42), Color.White);
            cubeBuyMaxButton.Click += CubeBuyMaxButton_Clicked;

            #endregion

            #region Fractal Generator Area //IT ALSO USES BUY BUTTONS FROM CUBE GEN AREA

            fractalWeaverButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), cubeProducerPos, "", font, new Color(36, 36, 36), Color.White);
            fractalWeaverButton.Click += FractalWeaverButton_Clicked;

            fractalForgerButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), new Vector2(cubeProducerPos.X + 390, cubeProducerPos.Y), "", font, new Color(36, 36, 36), Color.White);
            fractalForgerButton.Click += FractalForgerButton_Clicked;

            fractalNexusButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), new Vector2(cubeProducerPos.X + 780, cubeProducerPos.Y), "", font, new Color(36, 36, 36), Color.White);
            fractalNexusButton.Click += FractalNexusButton_Clicked;
            #endregion

            primerButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), new Vector2(cubeProducerPos.X, cubeProducerPos.Y + 600), "", font, new Color(36, 36, 36), Color.White);
            primerButton.Click += PrimerButton_Clicked;
            overchargerButton = new UIButtonSmallFont(EmptyTexture, new Rectangle(0, 220, 260, 32), new Vector2(cubeProducerPos.X + 780, cubeProducerPos.Y + 600), "", font, new Color(36, 36, 36), Color.White);
            overchargerButton.Click += OverchargerButton_Clicked;

            fluxuateButton = new UIButton(ButtonTexture, new Rectangle(0, 100, 220, 50), fluxuatePos, "", font, new Color(36, 36, 36), Color.White);
            _fluxuateAutoButton = new UIButton(ButtonTexture, new Rectangle(0, 220, 140, 24), new Vector2(fluxuatePos.X + 40, fluxuatePos.Y + 44), "AUTO", font, Color.DarkRed, Color.White);
            _fluxuateAutoButton.Click += FluxuateAutoButton_Clicked;

            ritualButton = new UIButton(ButtonTexture, new Rectangle(0, 100, 220, 50), new Vector2(fluxuatePos.X, fluxuatePos.Y - 120), "", font, new Color(36, 36, 36), Color.White);
            _ritualAutoButton = new UIButton(ButtonTexture, new Rectangle(0, 220, 140, 24), new Vector2(fluxuatePos.X + 40, fluxuatePos.Y - 120 + 44), "AUTO", font, Color.DarkRed, Color.White);
            _ritualAutoButton.Click += RitualAutoButton_Clicked;


            _gameComponents = new List<Component>()
            {
                generatorsButton,
                upgradesButton,
                achievementsButton,
                cubeProducerButton,
                cubeBuy1Button,
                cubeBuy10Button,
                cubeBuy25Button,
                cubeBuy50Button,
                cubeBuy100Button,
                //cubeBuyMaxButton,
                cubeArchitectButton,
                cubeEngineerButton,
                prodUpgrade1Button,
                archUpgrade1Button,
                engiUpgrade1Button,
                prodMultiFromArchButton,
                prodMultiFromArchMultiButton,
                allCubeMultiUpButton,
                archMultiFromEngiButton,
                cube10GenToMultiButton,
                prod5MultiButton,
                arch5MultiButton,
                engi5MultiButton,
                archMultiFromEngiMultiButton,
                prodSaleUpgradeButton,
                archSaleUpgradeButton,
                engiSaleUpgradeButton,
                engiMultiFromProdButton,
                cube10GenToSaleButton,
                cube50ProdToProdMultButton,
                cubeAmountAch1Button,
                cubeAmountAch2Button,
                cubeAmountAch3Button,
                cubeAmountAch4Button,
                cubeAmountFluxUnlockButton,
                fluxuateButton,
                cubeAmountAch6Button,
                cubeAmountAch7Button,
                cubeAmountAch8Button,
                fluxuateAmountAch1Button,
                fluxuateAmountAch2Button,
                primerButton,
                overchargerButton,
                cubeVisionaryButton,
                visMultFromProdButton,
                visMultFromArchButton,
                visMultFromEngiButton,
                cubeOmniButton,
                visBaseMultUpButton,
                threeMultiUpFromVisButton,
                prodFromPrimerButton,
                archFromPrimerButton,
                engiFromPrimerButton,
                visFromOverchargerButton,
                omniFromOverchargerButton,
                baseOmniMultiUpButton,
                allGen100ToOmniMultButton,
                fluxuateAmountAch3Button,
                autoProducersButton,
                autoProducersBoostButton,
                autoArchitectsBoostButton,
                autoEngineersBoostButton,
                autoVisionaryBoostButton,
                autoOmniBoostButton,
                autoPrimerBoostButton,
                autoOverchargerBoostButton,
                autoArchitectsButton,
                autoEngineersButton,
                autoVisionaryButton,
                autoOmniButton,
                fluxuateAmountAch4Button,
                fluxuateAmountAch5Button,
                fluxUpgrade1Button,
                fluxUpgrade2Button,
                fluxUpgrade3Button,
                fluxUpgrade4Button,
                fluxUpgrade5Button,
                fluxUpgrade6Button,
                fluxuateAmountAch6Button,
                fluxuateAmountAch7Button,
                fluxuateAmountAch8Button,
                fluxuateAmountAch9Button,
                fluxuateAmountAch10Button,
                fluxuateAmountAch11Button,
                fluxuateAmountAch12Button,
                fluxUpgrade7Button,
                fluxUpgrade8Button,
                fluxUpgrade9Button,
                cubeAmountAch9Button,
                ritualButton,
                cubeAmountAch10Button,
                cubeFinalUpgrade1Button,
                cubeFinalUpgrade2Button,
                ritualAmountAch1Button,
                prismUpgrade1Button,
                prismUpgrade2Button,
                prismUpgrade3Button,
                fractalWeaverButton,
                fractalForgerButton,
                fractalNexusButton,
                ritualAmountAch2Button,
                prismUpgrade4Button,
                prismUpgrade5Button,
                prismUpgrade6Button,
                fractalUpgrade1Button,
                fractalUpgrade2Button,
                fractalUpgrade3Button,
                fractalUpgrade4Button,
                fractalUpgrade5Button,
                fractalUpgrade6Button,
                fractalUpgrade7Button,
                fractalUpgrade8Button,
                fractalUpgrade9Button,
                fractalUpgrade10Button,
                fractalUpgrade11Button,
                ritualAmountAch3Button,
                prismUpgrade7Button,
                prismUpgrade8Button,
                prismUpgrade9Button,
                ritualAmountAch4Button,
                autoPrimerButton,
                autoOverchargerButton,
                ritualAmountAch5Button,
                prismUpgrade10Button,
                prismUpgrade11Button,
                prismUpgrade12Button,
                prismUpgrade13Button,
                prismUpgrade14Button,
                ritualAmountAch6Button,
                cubeAmountAch11Button,
                cubeAmountAch12Button,
                cubeAmountAch13Button,
                cubeAmountAch14Button,
                cubeAmountAch15Button,
                cubeAmountAch16Button,
                cubeAmountAch17Button,
                trueFinalCubeUpgradeButton,
                prismUpgrade15Button,
                prismUpgrade16Button,
                prismUpgrade17Button,
                ritualAmountAch7Button,
                prismUpgrade18Button,
                prismUpgrade19Button,
                fractalAmountAch1Button,
                fractalAmountAch2Button,
                fractalAmountAch3Button,
                fractalAmountAch4Button,
                fractalAmountAch5Button,
                fractalUpgrade12Button,
                fractalUpgrade13Button,
                fractalUpgrade14Button,
                fractalUpgrade15Button,
            };
        }

        private UIButton _prodAutoButton;
        private bool _prodAutoBuyEnabled;
        private UIButton _archAutoButton;
        private bool _archAutoBuyEnabled; 
        private UIButton _engiAutoButton;
        private bool _engiAutoBuyEnabled;
        private UIButton _visAutoButton;
        private bool _visAutoBuyEnabled; 
        private UIButton _omniAutoButton;
        private bool _omniAutoBuyEnabled;
        private UIButton _primerAutoButton;
        private bool _primerAutoBuyEnabled;
        private UIButton _overchargerAutoButton;
        private bool _overchargerAutoBuyEnabled;

        private UIButton _fluxuateAutoButton;
        private bool _fluxuateAutoEnabled;
        private UIButton _ritualAutoButton;
        private bool _ritualAutoEnabled;

        private Dictionary<string, Func<bool>> _achievementCriteria;

        protected override void Initialize()
        {
            UpdateUIPositions();
            _fluxStuff = new List<FluxStuff>();
            _cubeGenerators = new List<CubeGenerator>();
            _fractalGenerators = new List<FractalGenerator>();            
            _upgrades = new List<Upgrade>();
            _fluxUpgrades = new List<Upgrade>();
            _prismUpgrades = new List<Upgrade>();
            _fractalUpgrades = new List<Upgrade>();
            _achievements = new List<Achievement>();

            

            _achievementPopup = new AchievementPopup(GraphicsDevice, "", "", font, new Rectangle(0, 0, 260 * 3, 32 * 3), new Vector2(1920 / 2 - 300, 1080 - 110), Color.White);
            // Create UI elements
            cubeProducer = new CubeGenerator("CubeProducer", 0.1, 0.06, 0.02, 1); // 0.1, 0.08, 0.01, 1
            _cubeGenerators.Add(cubeProducer);
            cubeArchitect = new CubeGenerator("CubeArchitect", 5, 0.06, 1, 1); // 5, 0.08, 0.5, 1
            _cubeGenerators.Add(cubeArchitect);
            cubeEngineer = new CubeGenerator("CubeEngineer", 100, 0.06, 25, 1); // 100, 0.08, 10
            _cubeGenerators.Add(cubeEngineer);
            cubeVisionary = new CubeGenerator("CubeVisionary", 12500, 0.06, 2000, 1); // 10000, 0.08, 1000
            _cubeGenerators.Add(cubeVisionary);
            cubeOmni = new CubeGenerator("CubeOmnificents", 1e7, 0.06, 2500000, 1); // 1e7, 0.08, 1e6
            _cubeGenerators.Add(cubeOmni);

            primer = new FluxStuff("Primer", 1, 0.03, 0.25); // 1, 0.03, 0.25
            _fluxStuff.Add(primer);
            overcharger = new FluxStuff("Overcharger", 2.5, 0.03, 0.15); // 5, 0.03, 0.15
            _fluxStuff.Add(overcharger);


            fractalWeaver = new FractalGenerator("FractalWeaver", 0.5, 0.08, 0.001, 1); 
            _fractalGenerators.Add(fractalWeaver);
            fractalForger = new FractalGenerator("FractalForger", 10, 0.08, 0.05, 1);
            _fractalGenerators.Add(fractalForger);
            fractalNexus = new FractalGenerator("FractalNexus", 500, 0.08, 2.5, 1);
            _fractalGenerators.Add(fractalNexus);

            #region upgrades
            prodUpgrade1 = new Upgrade("Increases base multiplier for Producers by +0.1x", 0.5); //0
            _upgrades.Add(prodUpgrade1);
            archUpgrade1 = new Upgrade("Increases base multiplier for Architects by +0.1x", 25); // 1
            _upgrades.Add(archUpgrade1);
            engiUpgrade1 = new Upgrade("Increases base multiplier for Designers by +0.1x", 500); // 2
            _upgrades.Add(engiUpgrade1);
            prodMultiFromArch = new Upgrade("Each Architect owned increases Producers multiplier by +0.05x", 50); // 3   
            _upgrades.Add(prodMultiFromArch);
            prodMultiFromArchMulti = new Upgrade("Architects multiplier is also added to Producers multiplier", 250); // 4
            _upgrades.Add(prodMultiFromArchMulti);
            allCubeMultiUp = new Upgrade("Increases Producers, Architects and Designers multipliers by +0.25x", 1000); // 5
            _upgrades.Add(allCubeMultiUp);
            archMultiFromEngi = new Upgrade("Each Designer owned increases the Architect multiplier by +0.1x", 5000); // 6  
            _upgrades.Add(archMultiFromEngi);
            cube10GenToMulti = new Upgrade("For every 5-set of Producers, Architects and Designers, \nboost Producers, Architects and Designers multipliers by +0.05x", 10000); // 7 
            _upgrades.Add(cube10GenToMulti);
            prod5Multi = new Upgrade("Increases Producers base multiplier by +15x", 2500); // 8 
            _upgrades.Add(prod5Multi);
            arch5Multi = new Upgrade("Increases Architects base multiplier by +7.5x", 7500); // 9
            _upgrades.Add(arch5Multi);
            engi5Multi = new Upgrade("Increases Designers base multiplier by +5x", 15000); // 10
            _upgrades.Add(engi5Multi);
            archMultiFromEngiMulti = new Upgrade("Designers multiplier is also added to Architects multiplier", 25000); // 11
            _upgrades.Add(archMultiFromEngiMulti);
            prodSaleUpgrade = new Upgrade("Decreases the cost of Producers by 25%", 20000); // 12
            _upgrades.Add(prodSaleUpgrade);
            archSaleUpgrade = new Upgrade("Decreases the cost of Architects by 50%", 40000); // 13
            _upgrades.Add(archSaleUpgrade);
            engiSaleUpgrade = new Upgrade("Decreases the cost of Designers by 75%", 80000); // 14
            _upgrades.Add(engiSaleUpgrade);
            engiMultiFromProd = new Upgrade("Each Producer owned increases Designers multiplier by +0.15x", 250000); // 15   
            _upgrades.Add(engiMultiFromProd);
            cube10GenToSale = new Upgrade("For every 25-set of Producers, Architects and Designers, \nreduce the price of Producers, Architects and Designers by 3% \n(diminishing returns)", 750000); // 16
            _upgrades.Add(cube10GenToSale);
            cube50ProdToProdMult = new Upgrade("Every 50 Producers increases Producers base multiplier by +5x", 500000); // 17   
            _upgrades.Add(cube50ProdToProdMult);
            visMultFromProd = new Upgrade("Each Producer owned increases Visionaries multiplier by +0.25x", 350000); // 18    
            _upgrades.Add(visMultFromProd);
            visMultFromArch = new Upgrade("Each Architect owned increases Visionaries multiplier by +0.75x", 1e6); // 19    
            _upgrades.Add(visMultFromArch);
            visMultFromEngi = new Upgrade("Each Designer owned increases Visionaries multiplier by +1.25x", 1e7); // 20   
            _upgrades.Add(visMultFromEngi);
            visBaseMultUp = new Upgrade("Increases Visionaries base multiplier by +25x", 1e8); // 21
            _upgrades.Add(visBaseMultUp);
            threeMultiUpFromVis = new Upgrade("Each Visionary increases base Producers, Architects and \nDesigners multiplier by +0.5x", 1e11); // 22
            _upgrades.Add(threeMultiUpFromVis);
            prodFromPrimer = new Upgrade("Each level of Primer grants an additional Producer", 1e12); // 23
            _upgrades.Add(prodFromPrimer);
            archFromPrimer = new Upgrade("Every 2 levels of Primer grants an additional Architect", 1e13); // 24
            _upgrades.Add(archFromPrimer);
            engiFromPrimer = new Upgrade("Every 3 levels of Primer grants an additional Designer", 1e14); // 25
            _upgrades.Add(engiFromPrimer);
            visFromOvercharger = new Upgrade("Each level of Overcharger grants an additional Visionary", 1e15); // 26
            _upgrades.Add(visFromOvercharger);

            omniFromOvercharger = new Upgrade("Every 2 levels of Overcharger grants an additional Omnificent", 1e15); // 27
            _upgrades.Add(omniFromOvercharger);
            baseOmniMultiUp = new Upgrade("Increases Omnificents base multiplier by +50x", 1e16); // 28
            _upgrades.Add(baseOmniMultiUp);
            allGen100ToOmniMult = new Upgrade("Visionaries multiplier is also added to Omnificents multiplier", 1e17); // 29
            _upgrades.Add(allGen100ToOmniMult);

            cubeFinalUpgrade1 = new Upgrade("Increases the base multiplier of all Cube generators by +1e15x", 1e30); // 30
            _upgrades.Add(cubeFinalUpgrade1);
            cubeFinalUpgrade2 = new Upgrade("Decreases the cost of all Cube generators by 95%", 1e35); // 31
            _upgrades.Add(cubeFinalUpgrade2);
            trueFinalCubeUpgrade = new Upgrade("For every Producer owned, increase the base multiplier of all Cube generators by +5x", 1e100); // 32
            _upgrades.Add(trueFinalCubeUpgrade);


            autoProducers = new Upgrade("Unlocks the option to automate Producers", 100); // Flux 0
            _fluxUpgrades.Add(autoProducers);
            autoArchitects = new Upgrade("Unlocks the option to automate Architects", 1000); // Flux 1
            _fluxUpgrades.Add(autoArchitects);
            autoEngineers = new Upgrade("Unlocks the option to automate Designers", 10000); // Flux 2
            _fluxUpgrades.Add(autoEngineers);
            autoVisionary = new Upgrade("Unlocks the option to automate Visionaries", 100000); // Flux 3
            _fluxUpgrades.Add(autoVisionary);
            autoOmni = new Upgrade("Unlocks the option to automate Omnificents", 1e6); // Flux 4
            _fluxUpgrades.Add(autoOmni);

            fluxUpgrade1 = new Upgrade("Increases Primer boost from 0.25x/level to 0.45x/level", 1e6); // Flux 5
            _fluxUpgrades.Add(fluxUpgrade1);
            fluxUpgrade2 = new Upgrade("Increases Overcharger boost from 0.15x/level to 0.25x/level", 2e6); // Flux 6
            _fluxUpgrades.Add(fluxUpgrade2);
            fluxUpgrade3 = new Upgrade("Every 5 levels of Overcharger grants an additional Primer level", 1e7); // Flux 7
            _fluxUpgrades.Add(fluxUpgrade3);
            fluxUpgrade4 = new Upgrade("Decreases the cost of Primer levels by 75%", 5e7); // Flux 8
            _fluxUpgrades.Add(fluxUpgrade4);
            fluxUpgrade5 = new Upgrade("Decreases the cost of Overcharger levels by 50%", 1e8); // Flux 9
            _fluxUpgrades.Add(fluxUpgrade5);
            fluxUpgrade6 = new Upgrade("Every 10 levels of Primer grants an additional Overcharger level", 5e8); // Flux 10
            _fluxUpgrades.Add(fluxUpgrade6);

            fluxUpgrade7 = new Upgrade("Increases the amount of Flux gained from Fluxuations by A LOT!", 1e9); // Flux 11
            _fluxUpgrades.Add(fluxUpgrade7);
            fluxUpgrade8 = new Upgrade("Further decreases the cost of Primer levels by 50%", 1e10); // Flux 12
            _fluxUpgrades.Add(fluxUpgrade8);
            fluxUpgrade9 = new Upgrade("Further decreases the cost of Overcharger levels by 25%", 1e11); // Flux 13
            _fluxUpgrades.Add(fluxUpgrade9);

            
            prismUpgrade1 = new Upgrade("For each Prism in your wallet, all Cube multipliers are multiplied by 0.1x", 0.5); // Prism 0
            _prismUpgrades.Add(prismUpgrade1);
            prismUpgrade2 = new Upgrade("Reduces the cost of Primer and Overcharger levels by 75%", 0.75); // Prism 1
            _prismUpgrades.Add(prismUpgrade2);
            prismUpgrade3 = new Upgrade("Grants 25 free Primer and Overcharger levels for each Ritual conducted", 1); // Prism 2
            _prismUpgrades.Add(prismUpgrade3);

            prismUpgrade4 = new Upgrade("Increases the base multiplier of Weavers by +0.25x", 1.25); // Prism 3
            _prismUpgrades.Add(prismUpgrade4);
            prismUpgrade5 = new Upgrade("Each Ritual conducted grants an additional Weaver", 5); // Prism 4
            _prismUpgrades.Add(prismUpgrade5);
            prismUpgrade6 = new Upgrade("Increases the base multiplier of Forgers by +0.25x", 15); // Prism 5
            _prismUpgrades.Add(prismUpgrade6);

            

            fractalUpgrade1 = new Upgrade("Each Fractal in your wallet increases Flux gained from Fluxuations by 5%", 0.01); // Fractal 0
            _fractalUpgrades.Add(fractalUpgrade1);
            fractalUpgrade2 = new Upgrade("For each Fractal owned, decrease the cost of Producers, Architects and Designers by 0.25% \n(diminishing returns)", 1); // Fractal 1
            _fractalUpgrades.Add(fractalUpgrade2);
            fractalUpgrade3 = new Upgrade("For each Fractal owned, decrease the cost of Visionaries and Omnificents by 0.25% \n(diminishing returns)", 2.5); // Fractal 2
            _fractalUpgrades.Add(fractalUpgrade3);
            fractalUpgrade4 = new Upgrade("Every Weaver owned grants an additional Producer, Architect and Designer", 250); // Fractal 3
            _fractalUpgrades.Add(fractalUpgrade4);
            fractalUpgrade5 = new Upgrade("Every Forger owned grants an additional Visionary and Omnificent", 750); // Fractal 4
            _fractalUpgrades.Add(fractalUpgrade5);
            fractalUpgrade6 = new Upgrade("Every Nexus owned increase the base multiplier of all Cube generators by +0.5x", 7500); // Fractal 5
            _fractalUpgrades.Add(fractalUpgrade6);
            fractalUpgrade7 = new Upgrade("Each Fractal in your wallet increases Prisms gained from Rituals by 1%", 1); // Fractal 6
            _fractalUpgrades.Add(fractalUpgrade7);
            fractalUpgrade8 = new Upgrade("Decreases the cost of Primer and Overcharger levels by 95%", 2.5); // Fractal 7
            _fractalUpgrades.Add(fractalUpgrade8);
            fractalUpgrade9 = new Upgrade("Grants 5 additional Primer levels for each Fluxuation performed", 250); // Fractal 8
            _fractalUpgrades.Add(fractalUpgrade9);
            fractalUpgrade10 = new Upgrade("Grants 2 additional Overcharger levels for each Fluxuation performed", 750); // Fractal 9
            _fractalUpgrades.Add(fractalUpgrade10);
            fractalUpgrade11 = new Upgrade("Conducting Rituals will also grant rewards from Fluxuations", 7500); // Fractal 10
            _fractalUpgrades.Add(fractalUpgrade11);

            prismUpgrade7 = new Upgrade("Decreases the cost of Weavers by 50%", 25); // Prism 6
            _prismUpgrades.Add(prismUpgrade7);
            prismUpgrade8 = new Upgrade("For each Ritual conducted, decrease the cost of Forgers by 2% \n(diminishing returns)", 50); // Prism 7
            _prismUpgrades.Add(prismUpgrade8);
            prismUpgrade9 = new Upgrade("Further increases the base multiplier of Weavers by +0.75x", 100); // Prism 8
            _prismUpgrades.Add(prismUpgrade9);

            autoPrimer = new Upgrade("Unlocks the option to automate Primer levels", 150); // Prism 9
            _prismUpgrades.Add(autoPrimer);
            autoOvercharger = new Upgrade("Unlocks the option to automate Overcharger levels", 200); // Prism 10
            _prismUpgrades.Add(autoOvercharger);

            prismUpgrade10 = new Upgrade("Weavers multiplier is also added to Forgers multiplier", 250); // Prism 11
            _prismUpgrades.Add(prismUpgrade10);
            prismUpgrade11 = new Upgrade("Every 5 Weavers increases Weavers base multiplier by +0.25x", 300); // Prism 12
            _prismUpgrades.Add(prismUpgrade11);
            prismUpgrade12 = new Upgrade("Further increases the base multiplier of Forgers by +1.25x", 350); // Prism 13
            _prismUpgrades.Add(prismUpgrade12);
            prismUpgrade13 = new Upgrade("Increases the base multiplier of Nexus by +1.5x", 750); // Prism 14
            _prismUpgrades.Add(prismUpgrade13);
            prismUpgrade14 = new Upgrade("Forgers multiplier is also added to Nexus multiplier", 1500); // Prism 15
            _prismUpgrades.Add(prismUpgrade14);


            autoProducersBoost = new Upgrade("Increases the speed of the Producers automator by 10x", 1e15); // Flux 14
            _fluxUpgrades.Add(autoProducersBoost);
            autoArchitectsBoost = new Upgrade("Increases the speed of the Architects automator by 10x", 5e15); // Flux 15
            _fluxUpgrades.Add(autoArchitectsBoost);
            autoEngineersBoost = new Upgrade("Increases the speed of the Designers automator by 10x", 1e16); // Flux 16
            _fluxUpgrades.Add(autoEngineersBoost);
            autoVisionaryBoost = new Upgrade("Increases the speed of the Visionaries automator by 10x", 5e16); // Flux 17
            _fluxUpgrades.Add(autoVisionaryBoost);
            autoOmniBoost = new Upgrade("Increases the speed of the Omnificents automator by 10x", 1e17); // Flux 18
            _fluxUpgrades.Add(autoOmniBoost);

            autoPrimerBoost = new Upgrade("Increases the speed of the Primer automator by 10x", 5000); // Prism 16
            _prismUpgrades.Add(autoPrimerBoost);
            autoOverchargerBoost = new Upgrade("Increases the speed of the Overcharger automator by 10x", 7500); // Prism 17
            _prismUpgrades.Add(autoOverchargerBoost);

            prismUpgrade15 = new Upgrade("Further increases Weavers base multiplier by +100x", 2500); // Prism 18
            _prismUpgrades.Add(prismUpgrade15);
            prismUpgrade16 = new Upgrade("Further increases Forgers base multiplier by +75x", 5000); // Prism 19
            _prismUpgrades.Add(prismUpgrade16);
            prismUpgrade17 = new Upgrade("Further increases Nexus base multiplier by +50x", 7500); // Prism 20
            _prismUpgrades.Add(prismUpgrade17);
            prismUpgrade18 = new Upgrade("Every 2 Rituals conducted grants an additional Forger", 25000); // Prism 21
            _prismUpgrades.Add(prismUpgrade18);
            prismUpgrade19 = new Upgrade("Every 5 Rituals conducted grants an additional Nexus", 50000); // Prism 22
            _prismUpgrades.Add(prismUpgrade19);

            fractalUpgrade12 = new Upgrade("Grants 100 additional Producers for each Ritual conducted", 75); // Fractal 11
            _fractalUpgrades.Add(fractalUpgrade12);
            fractalUpgrade13 = new Upgrade("Grants 75 additional Architects for each Ritual conducted", 100); // Fractal 12
            _fractalUpgrades.Add(fractalUpgrade13);
            fractalUpgrade14 = new Upgrade("Grants 50 additional Designers for each Ritual conducted", 125); // Fractal 13
            _fractalUpgrades.Add(fractalUpgrade14);
            fractalUpgrade15 = new Upgrade("Grants 10 additional Visionaries and Omnificents for each Ritual conducted", 250); // Fractal 14
            _fractalUpgrades.Add(fractalUpgrade15);


            #endregion


            #region Achievements

            cubeAmountAch1 = new Achievement("The Beginning of The Cube Era", "Get your hands on an entire Cube!", "", "88fcc2", this); // 0
            _achievements.Add(cubeAmountAch1);
            cubeAmountAch2 = new Achievement("Mo' Cubes, Mo' Cubes", "Have 100 Cubes in your Cube Wallet!", "", "88fcc2", this); // 1
            _achievements.Add(cubeAmountAch2);
            cubeAmountAch3 = new Achievement("Cube-hoarding 101", "Have 10,000 Cubes in your Cube Wallet!", "", "88fcc2", this); // 2
            _achievements.Add(cubeAmountAch3);
            cubeAmountAch4 = new Achievement("Highroller Life", "Have 100,000 Cubes in your Cube Wallet!", "", "88fcc2", this); // 3
            _achievements.Add(cubeAmountAch4);
            cubeAmountFluxUnlock = new Achievement("Cube-inspired Epiphany!", "Have 1e6 Cubes in your Cube Wallet!\n", "\n[c:c288fc]Unlocks Fluxuations!", "88fcc2", this); // 4
            _achievements.Add(cubeAmountFluxUnlock);
            cubeAmountAch6 = new Achievement("Cubes? CUBES!", "Have 1e8 Cubes in your Cube Wallet!\n", "\n[c:c288fc]Unlocks an additional Cube generator and new Cube upgrades!", "88fcc2", this); // 5
            _achievements.Add(cubeAmountAch6);
            cubeAmountAch7 = new Achievement("Ya Gotta Have More", "Have 1e12 Cubes in your Cube Wallet!\n", "\n[c:c288fc]Unlocks new Cube upgrades!", "88fcc2", this); // 6
            _achievements.Add(cubeAmountAch7);
            cubeAmountAch8 = new Achievement("No End In Sight", "Have 1e16 Cubes in your Cube Wallet!\n", "\n[c:c288fc]Unlocks the final Cube generator and new Cube upgrades!", "88fcc2", this); // 7
            _achievements.Add(cubeAmountAch8);


            fluxuateAmountAch1 = new Achievement("Deja-Vu!", "Perform your first Fluxuation!\n", "\n[c:c288fc]Unlocks the Cube Primer!", "88fcc2", this); // 8
            _achievements.Add(fluxuateAmountAch1);
            fluxuateAmountAch2 = new Achievement("I've Just Been In This Place Before", "Perform 5 Fluxuations in total!\n", "\n[c:c288fc]Unlocks the Cube Overcharger!", "88fcc2", this); // 9
            _achievements.Add(fluxuateAmountAch2);
            fluxuateAmountAch3 = new Achievement("Repetition = Success", "Perform 10 Fluxuations in total!\n", "\n[c:c288fc]Unlocks Automation upgrades for Cube generators!", "88fcc2", this); // 10
            _achievements.Add(fluxuateAmountAch3);
            fluxuateAmountAch4 = new Achievement("Speeding Things Up", "Perform 25 Fluxuations in total!\n", "\n[c:c288fc]Unlocks Automation for Fluxuations!", "88fcc2", this); // 11
            _achievements.Add(fluxuateAmountAch4);
            fluxuateAmountAch5 = new Achievement("But Wait, There's More!", "Perform 50 Fluxuations in total!\n", "\n[c:c288fc]Unlocks Flux upgrades!", "88fcc2", this); // 12
            _achievements.Add(fluxuateAmountAch5);
            fluxuateAmountAch6 = new Achievement("Give Me Some More", "Perform 100 Fluxuations in total!\n", "\n[c:c288fc]Unlocks new Flux upgrades!", "88fcc2", this); // 13
            _achievements.Add(fluxuateAmountAch6);
            

            cubeAmountAch9 = new Achievement("Chant, Chant, Chant, Chant", "Have 1e19 Cubes in your Cube Wallet!\n", "\n[c:c288fc]Unlocks Rituals!", "88fcc2", this); // 14
            _achievements.Add(cubeAmountAch9);
            cubeAmountAch10 = new Achievement("Climbing The Infinite Ladder", "Have 1e30 Cubes in your Cube Wallet!\n", "\n[c:c288fc]Unlocks even more Cube upgrades!", "88fcc2", this); // 15
            _achievements.Add(cubeAmountAch10);

            ritualAmountAch1 = new Achievement("Naturally Supernatural", "Conduct your very first Ritual!\n", "\n[c:c288fc]Unlocks Fractal generators and Prism upgrades!", "88fcc2", this); // 16
            _achievements.Add(ritualAmountAch1);
            ritualAmountAch2 = new Achievement("You Shall Burn In...", "Conduct 5 Rituals in total!\n", "\n[c:c288fc]Unlocks new Prism upgrades!", "88fcc2", this); // 17
            _achievements.Add(ritualAmountAch2); 
            ritualAmountAch3 = new Achievement("The Fires of Pandemonium!", "Conduct 10 Rituals in total!\n", "\n[c:c288fc]Unlocks new NEW Prism upgrades!", "88fcc2", this); // 18
            _achievements.Add(ritualAmountAch3);
            ritualAmountAch4 = new Achievement("Don't Hug Me I'm Satanic!", "Conduct 25 Rituals in total!\n", "\n[c:c288fc]Unlocks Ritual automation!", "88fcc2", this); // 19
            _achievements.Add(ritualAmountAch4);
            ritualAmountAch5 = new Achievement("Do Prisms Dream of Reflection?", "Conduct 50 Rituals in total!\n", "\n[c:c288fc]Unlocks new Prism upgrades! (Woah, unique!)", "88fcc2", this); // 20
            _achievements.Add(ritualAmountAch5); 
            ritualAmountAch6 = new Achievement("Rituals Are Red All Over", "Conduct 100 Rituals in total!\n", "\n[c:c288fc]Guess what, it's more Prism upgrades!", "88fcc2", this); // 21
            _achievements.Add(ritualAmountAch6);

            cubeAmountAch11 = new Achievement("So Many Cubes...", "Have 1e50 Cubes in your Cube Wallet!", "", "88fcc2", this); // 22    MAYBE MAKE THIS AND OTHER SIMILAR ONES PERMANENTLY UNLOCK CUBE UPGRADES :SHRUG:
            _achievements.Add(cubeAmountAch11);
            cubeAmountAch12 = new Achievement("And They're All Yours!", "Have 1e75 Cubes in your Cube Wallet!", "", "88fcc2", this); // 23
            _achievements.Add(cubeAmountAch12);

            cubeAmountAch13 = new Achievement("Just Googol It", "Have 1e100 Cubes in your Cube Wallet!\n", "\n[c:c288fc]Unlocks the final Cube Upgrade!", "88fcc2", this); // 24
            _achievements.Add(cubeAmountAch13);
            cubeAmountAch14 = new Achievement("Not Just A River In Ireland", "Have 1e120 Cubes in your Cube Wallet!", "", "88fcc2", this); // 25
            _achievements.Add(cubeAmountAch14);
            cubeAmountAch15 = new Achievement("A Nuwa High Score!", "Have 1e150 Cubes in your Cube Wallet!", "", "88fcc2", this); // 26
            _achievements.Add(cubeAmountAch15);
            cubeAmountAch16 = new Achievement("Walk The Long Planck, Cube!", "Have 4.65e185 Cubes in your Cube Wallet!", "", "88fcc2", this); // 27
            _achievements.Add(cubeAmountAch16);            
            cubeAmountAch17 = new Achievement("Aw, There's A Cap?", "Have 1e200 Cubes in your Cube Wallet!\n", "\n[c:c288fc]Unlocks Sigil Cubes and Sigils", "88fcc2", this); // 28
            _achievements.Add(cubeAmountAch17);

            fluxuateAmountAch7 = new Achievement("Keeping Up With The Costs", "Perform 250 Fluxuations in total!\n", "\n[c:c288fc]Unlocks new Automation upgrades!", "88fcc2", this); // 29
            _achievements.Add(fluxuateAmountAch7);
            fluxuateAmountAch8 = new Achievement("The Last Fluxuation Achievement!", "Perform 500 Fluxuations in total!\n", "\n[c:c288fc]Unlocks new Automation upgrades, speeding things up!", "88fcc2", this); // 30
            _achievements.Add(fluxuateAmountAch8);
            fluxuateAmountAch9 = new Achievement("Wait... Hold On, What?", "Perform 1000 Fluxuations in total!\n", "\n[c:c288fc]Unlocks new Automation upgrades...?", "88fcc2", this); // 31
            _achievements.Add(fluxuateAmountAch9);
            fluxuateAmountAch10 = new Achievement("How Many Of These Are There?!", "2500 Fluxuations has to be the end, right? RIGHT?!", "", "88fcc2", this); // 32  ///UNLCOKS QUICKBUY FOR CUBE UPGRADES, TODO
            _achievements.Add(fluxuateAmountAch10);
            fluxuateAmountAch11 = new Achievement("This HAS To Be The Last One!", "No more! 5000 Fluxuations is too many...", "", "88fcc2", this); // 33
            _achievements.Add(fluxuateAmountAch11);
            fluxuateAmountAch12 = new Achievement("10K Fluxuations: The End?", "Why is there a question mark? WHY IS THERE A FU-", "", "88fcc2", this); // 34
            _achievements.Add(fluxuateAmountAch12);

            ritualAmountAch7 = new Achievement("Feelin' Cute, Time For Rituals", "Conduct 250 Rituals in total!\n", "\n[c:c288fc]Oh boy, a few new Prism upgrades? Aw, you shouldn't have. I mean it, stop it.", "88fcc2", this); // 35
            _achievements.Add(ritualAmountAch7);

            
            fractalAmountAch1 = new Achievement("And On And On And On And On...", "Have 0.1 Fractals in your Fractal Wallet!", "", "88fcc2", this); // 36
            _achievements.Add(fractalAmountAch1);
            fractalAmountAch2 = new Achievement("Infinite Possibilities", "Have 1 Fractal in your Fractal Wallet!", "", "88fcc2", this); // 37
            _achievements.Add(fractalAmountAch2);
            fractalAmountAch3 = new Achievement("Fractional Fractal Fractions", "Have 10 Fractals in your Fractal Wallet!", "", "88fcc2", this); // 38
            _achievements.Add(fractalAmountAch3);
            fractalAmountAch4 = new Achievement("Create The Endless Cycle", "Have 100 Fractals in your Fractal Wallet!", "", "88fcc2", this); // 39
            _achievements.Add(fractalAmountAch4);
            fractalAmountAch5 = new Achievement("Fractals Require Power", "Have 250 Fractals in your Fractal Wallet!\n", "\n[c:c288fc]Unlocks a couple new Fractal upgrades!", "88fcc2", this); // 40
            _achievements.Add(fractalAmountAch5);

            
            InitializeAchievementCriteria();
            #endregion


            CubeGenerator.BuyAmount = 1;              
            UpgradeLoading();
            AchievementLoading();
            _gameState = new GameState();  
            base.Initialize();
            // Set the game window icon
 

            resourceManager = new ResourceManager(_cubeGenerators, _upgrades, _fluxStuff, _fluxUpgrades, _prismUpgrades, _fractalGenerators, _fractalUpgrades, _achievements);
            _saveTimer = new Timer(60000); // Auto-save every 60 seconds (60000 milliseconds)
            _saveTimer.Elapsed += AutoSave;
            _saveTimer.AutoReset = true;
            _saveTimer.Enabled = true;
            LoadSavedData();
           
        }
        private void InitializeAchievementCriteria()
        {
            _achievementCriteria = new Dictionary<string, Func<bool>>
            {
                { "The Beginning of The Cube Era", () => resourceManager.GetCubes() >= 1 },
                { "Mo' Cubes, Mo' Cubes", () => resourceManager.GetCubes() >= 100 },
                { "Cube-hoarding 101", () => resourceManager.GetCubes() >= 10000 },
                { "Highroller Life", () => resourceManager.GetCubes() >= 100000 },
                { "Cube-inspired Epiphany!", () => resourceManager.GetCubes() >= 1e6 },
                { "Cubes? CUBES!", () => resourceManager.GetCubes() >= 1e8 },
                { "Ya Gotta Have More", () => resourceManager.GetCubes() >= 1e12 },
                { "No End In Sight", () => resourceManager.GetCubes() >= 1e16 },

                { "Deja-Vu!", () => resourceManager.GetFluxuateAmount() >= 1 },
                { "I've Just Been In This Place Before", () => resourceManager.GetFluxuateAmount() >= 5 },
                { "Repetition = Success", () => resourceManager.GetFluxuateAmount() >= 10 },
                { "Speeding Things Up", () => resourceManager.GetFluxuateAmount() >= 25 },
                { "But Wait, There's More!", () => resourceManager.GetFluxuateAmount() >= 50 },
                { "Give Me Some More", () => resourceManager.GetFluxuateAmount() >= 100 },
                

                { "Chant, Chant, Chant, Chant", () => resourceManager.GetCubes() >= 1e19 },
                { "Climbing The Infinite Ladder", () => resourceManager.GetCubes() >= 1e30 },

                { "Naturally Supernatural", () => resourceManager.GetRitualAmount() >= 1 },
                { "You Shall Burn In...", () => resourceManager.GetRitualAmount() >= 5 },
                { "The Fires of Pandemonium!", () => resourceManager.GetRitualAmount() >= 10 },
                { "Don't Hug Me I'm Satanic!", () => resourceManager.GetRitualAmount() >= 25 },
                { "Do Prisms Dream of Reflection?", () => resourceManager.GetRitualAmount() >= 50 },
                { "Rituals Are Red All Over", () => resourceManager.GetRitualAmount() >= 100 },

                { "So Many Cubes...", () => resourceManager.GetCubes() >= 1e50 },
                { "And They're All Yours!", () => resourceManager.GetCubes() >= 1e75 },
                { "Just Googol It", () => resourceManager.GetCubes() >= 1e100 },
                { "Not Just A River In Ireland", () => resourceManager.GetCubes() >= 1e120 },
                { "A Nuwa High Score!", () => resourceManager.GetCubes() >= 1e150 },
                { "Walk The Long Planck, Cube!", () => resourceManager.GetCubes() >= 4.65e185 },
                { "Aw, There's A Cap?", () => resourceManager.GetCubes() >= 1e200 },

                { "Keeping Up With The Costs", () => resourceManager.GetFluxuateAmount() >= 250 },
                { "The Last Fluxuation Achievement!", () => resourceManager.GetFluxuateAmount() >= 500 },
                { "Wait... Hold On, What?", () => resourceManager.GetFluxuateAmount() >= 1000 },
                { "How Many Of These Are There?!", () => resourceManager.GetFluxuateAmount() >= 2500 },
                { "This HAS To Be The Last One!", () => resourceManager.GetFluxuateAmount() >= 5000 },
                { "10K Fluxuations: The End?", () => resourceManager.GetFluxuateAmount() >= 10000 },

                { "Feelin' Cute, Time For Rituals", () => resourceManager.GetRitualAmount() >= 250 },
                
                { "And On And On And On And On...", () => resourceManager.GetFractals() >= 0.1 },
                { "Infinite Possibilities", () => resourceManager.GetFractals() >= 1 },
                { "Fractional Fractal Fractions", () => resourceManager.GetFractals() >= 10 },
                { "Create The Endless Cycle", () => resourceManager.GetFractals() >= 100 },
                { "Fractals Require Power", () => resourceManager.GetFractals() >= 250 },

            };
        }

        private void UpdateGameState()
        {
            
            _gameState.FluxStuff = _fluxStuff;
            _gameState.CubeGenerators = _cubeGenerators;           
            _gameState.FractalGenerators = _fractalGenerators;           
            _gameState.Upgrades = _upgrades;
            _gameState.FluxUpgrades = _fluxUpgrades;
            _gameState.PrismUpgrades = _prismUpgrades;
            _gameState.FractalUpgrades = _fractalUpgrades;
            _gameState.Achievements = _achievements;
            _gameState.Cubes = resourceManager.GetCubes();
            _gameState.Fractals = resourceManager.GetFractals();
            _gameState.Flux = resourceManager.GetFlux();
            _gameState.Prism = resourceManager.GetPrism();
            _gameState.FluxuateAmount = resourceManager.GetFluxuateAmount();
            _gameState.RitualAmount = resourceManager.GetRitualAmount();
        }
        private void LoadSavedData()
        {
            InitializeAchievementCriteria();

            GameState savedData = SaveSystem.Load();
            
            // Use the saved data to set the initial state of your game objects
            resourceManager.UpdateUpgrades(savedData.Upgrades);
            resourceManager.UpdateFluxStuff(savedData.FluxStuff);
            resourceManager.UpdateFluxUpgrade(savedData.FluxUpgrades);
            resourceManager.UpdatePrismUpgrade(savedData.PrismUpgrades);
            resourceManager.UpdateFractalUpgrade(savedData.FractalUpgrades);
            resourceManager.UpdateCubeGenerators(savedData.CubeGenerators);
            resourceManager.UpdateFractalGenerators(savedData.FractalGenerators);
            resourceManager.UpdateAchievement(savedData.Achievements);
            _fluxStuff = savedData.FluxStuff;                        
            _upgrades = savedData.Upgrades;
            _fluxUpgrades = savedData.FluxUpgrades;
            _prismUpgrades = savedData.PrismUpgrades;
            _fractalUpgrades = savedData.FractalUpgrades;
            _achievements = savedData.Achievements;
            _cubeGenerators = savedData.CubeGenerators;
            _fractalGenerators = savedData.FractalGenerators;
            savedData.CalculateOfflineGains();
            resourceManager.SetCubes(savedData.Cubes);
            resourceManager.SetFractals(savedData.Fractals);
            resourceManager.SetFlux(savedData.Flux);
            resourceManager.SetPrism(savedData.Prism);
            resourceManager.SetFluxuateAmount(savedData.FluxuateAmount);
            resourceManager.SetRitualAmount(savedData.RitualAmount);

            primer = _fluxStuff[0];
            overcharger = _fluxStuff[1];

            

            // Update the individual CubeGenerator references
            cubeProducer = _cubeGenerators[0];
            cubeArchitect = _cubeGenerators[1];
            cubeEngineer = _cubeGenerators[2];
            cubeVisionary = _cubeGenerators[3];
            cubeOmni = _cubeGenerators[4];


            // Update the individual FractalGenerator references
            fractalWeaver = _fractalGenerators[0];
            fractalForger = _fractalGenerators[1];
            fractalNexus = _fractalGenerators[2];

            

            // Update the individual Upgrade references
            prodUpgrade1 = _upgrades[0];
            archUpgrade1 = _upgrades[1];
            engiUpgrade1 = _upgrades[2];
            prodMultiFromArch = _upgrades[3];
            prodMultiFromArchMulti = _upgrades[4];
            allCubeMultiUp = _upgrades[5];
            archMultiFromEngi = _upgrades[6];
            cube10GenToMulti = _upgrades[7];
            prod5Multi = _upgrades[8];
            arch5Multi = _upgrades[9];
            engi5Multi = _upgrades[10];
            archMultiFromEngiMulti = _upgrades[11];
            prodSaleUpgrade = _upgrades[12];
            archSaleUpgrade = _upgrades[13];
            engiSaleUpgrade = _upgrades[14];
            engiMultiFromProd = _upgrades[15];
            cube10GenToSale = _upgrades[16];
            cube50ProdToProdMult = _upgrades[17];
            visMultFromProd = _upgrades[18];
            visMultFromArch = _upgrades[19];
            visMultFromEngi = _upgrades[20];
            visBaseMultUp = _upgrades[21];
            threeMultiUpFromVis = _upgrades[22];
            prodFromPrimer = _upgrades[23];
            archFromPrimer = _upgrades[24];
            engiFromPrimer = _upgrades[25];
            visFromOvercharger = _upgrades[26];
            omniFromOvercharger = _upgrades[27];
            baseOmniMultiUp = _upgrades[28];
            allGen100ToOmniMult = _upgrades[29];
            cubeFinalUpgrade1 = _upgrades[30];
            cubeFinalUpgrade2 = _upgrades[31];
            trueFinalCubeUpgrade = _upgrades[32];



            autoProducers = _fluxUpgrades[0];
            autoArchitects = _fluxUpgrades[1];
            autoEngineers = _fluxUpgrades[2];
            autoVisionary = _fluxUpgrades[3];
            autoOmni = _fluxUpgrades[4];
            fluxUpgrade1 = _fluxUpgrades[5];
            fluxUpgrade2 = _fluxUpgrades[6];
            fluxUpgrade3 = _fluxUpgrades[7];
            fluxUpgrade4 = _fluxUpgrades[8];
            fluxUpgrade5 = _fluxUpgrades[9];
            fluxUpgrade6 = _fluxUpgrades[10];
            fluxUpgrade7 = _fluxUpgrades[11];
            fluxUpgrade8 = _fluxUpgrades[12];
            fluxUpgrade9 = _fluxUpgrades[13];
            autoProducersBoost = _fluxUpgrades[14];
            autoArchitectsBoost = _fluxUpgrades[15];
            autoEngineersBoost = _fluxUpgrades[16];
            autoVisionaryBoost = _fluxUpgrades[17];
            autoOmniBoost = _fluxUpgrades[18];

            prismUpgrade1 = _prismUpgrades[0];
            prismUpgrade2 = _prismUpgrades[1];
            prismUpgrade3 = _prismUpgrades[2];
            prismUpgrade4 = _prismUpgrades[3];
            prismUpgrade5 = _prismUpgrades[4];
            prismUpgrade6 = _prismUpgrades[5];
            prismUpgrade7 = _prismUpgrades[6];
            prismUpgrade8 = _prismUpgrades[7];
            prismUpgrade9 = _prismUpgrades[8];
            autoPrimer = _prismUpgrades[9];
            autoOvercharger = _prismUpgrades[10];
            prismUpgrade10 = _prismUpgrades[11];
            prismUpgrade11 = _prismUpgrades[12];
            prismUpgrade12 = _prismUpgrades[13];
            prismUpgrade13 = _prismUpgrades[14];
            prismUpgrade14 = _prismUpgrades[15];
            autoPrimerBoost = _prismUpgrades[16];
            autoOverchargerBoost = _prismUpgrades[17];
            prismUpgrade15 = _prismUpgrades[18];
            prismUpgrade16 = _prismUpgrades[19];
            prismUpgrade17 = _prismUpgrades[20];
            prismUpgrade18 = _prismUpgrades[21];
            prismUpgrade19 = _prismUpgrades[22];

            fractalUpgrade1 = _fractalUpgrades[0];
            fractalUpgrade2 = _fractalUpgrades[1];
            fractalUpgrade3 = _fractalUpgrades[2];
            fractalUpgrade4 = _fractalUpgrades[3];
            fractalUpgrade5 = _fractalUpgrades[4];
            fractalUpgrade6 = _fractalUpgrades[5];
            fractalUpgrade7 = _fractalUpgrades[6];
            fractalUpgrade8 = _fractalUpgrades[7];
            fractalUpgrade9 = _fractalUpgrades[8];
            fractalUpgrade10 = _fractalUpgrades[9];
            fractalUpgrade11 = _fractalUpgrades[10];
            fractalUpgrade12 = _fractalUpgrades[11];
            fractalUpgrade13 = _fractalUpgrades[12];
            fractalUpgrade14 = _fractalUpgrades[13];
            fractalUpgrade15 = _fractalUpgrades[14];




            // Update the individual Achievement references
            foreach (var achievement in _achievements)
            {
                achievement.SetMainGame(this);
            }

            cubeAmountAch1 = _achievements[0];
            cubeAmountAch2 = _achievements[1];
            cubeAmountAch3 = _achievements[2];
            cubeAmountAch4 = _achievements[3];
            cubeAmountFluxUnlock = _achievements[4];
            cubeAmountAch6 = _achievements[5];
            cubeAmountAch7 = _achievements[6];
            cubeAmountAch8 = _achievements[7];

            fluxuateAmountAch1 = _achievements[8];
            fluxuateAmountAch2 = _achievements[9];
            fluxuateAmountAch3 = _achievements[10];
            fluxuateAmountAch4 = _achievements[11];
            fluxuateAmountAch5 = _achievements[12];
            fluxuateAmountAch6 = _achievements[13];

            cubeAmountAch9 = _achievements[14];
            cubeAmountAch10 = _achievements[15];

            ritualAmountAch1 = _achievements[16];
            ritualAmountAch2 = _achievements[17];
            ritualAmountAch3 = _achievements[18];
            ritualAmountAch4 = _achievements[19];
            ritualAmountAch5 = _achievements[20];
            ritualAmountAch6 = _achievements[21];
            cubeAmountAch11 = _achievements[22];
            cubeAmountAch12 = _achievements[23];
            
            // UPDATE 0.3 ACHIEVEMENTS BELOW
            cubeAmountAch13 = _achievements[24];
            cubeAmountAch14 = _achievements[25];
            cubeAmountAch15 = _achievements[26];
            cubeAmountAch16 = _achievements[27];
            cubeAmountAch17 = _achievements[28];
            fluxuateAmountAch7 = _achievements[29];
            fluxuateAmountAch8 = _achievements[30];
            fluxuateAmountAch9 = _achievements[31];
            fluxuateAmountAch10 = _achievements[32];
            fluxuateAmountAch11 = _achievements[33];
            fluxuateAmountAch12 = _achievements[34];
            ritualAmountAch7 = _achievements[35];
            fractalAmountAch1 = _achievements[36];
            fractalAmountAch2 = _achievements[37];
            fractalAmountAch3 = _achievements[38];
            fractalAmountAch4 = _achievements[39];
            fractalAmountAch5 = _achievements[40];


            _prevProdCount = savedData.PrevProdCount;
            _prevProdCount2 = savedData.PrevProdCount2;
            _prevArchCount = savedData.PrevArchCount;
            _prevArchCount2 = savedData.PrevArchCount2;
            _prevEngiCount = savedData.PrevEngiCount;
            _prevEngiCount2 = savedData.PrevEngiCount2;
            _prevVisCount = savedData.PrevVisCount;
            _prevPrimerLevel = savedData.PrevPrimerLevel;
            _prevPrimerLevel2 = savedData.PrevPrimerLevel2;
            _prevPrimerLevel3 = savedData.PrevPrimerLevel3;
            _prevOverchargerLevel = savedData.PrevOverchargerLevel;
            _prevOverchargerLevel2 = savedData.PrevOverchargerLevel2;
            _crossFunctionalOmni = savedData.CrossFunctionalOmni;
            _crossFunctionalContribution = savedData.CrossFunctionalContribution;
            _crossFunctionalContribution2 = savedData.CrossFunctionalContribution2;
            _crossFunctionalContribution3 = savedData.CrossFunctionalContribution3;
            _crossFunctionalContribution4 = savedData.CrossFunctionalContribution4;
            _architectMultiplierContribution = savedData.ArchitectMultiplierContribution;
            _architectContribution = savedData.ArchitectContribution;
            _engineerMultiplierContribution = savedData.EngineerMultiplierContribution;
            _visionaryMultiplierContribution = savedData.VisionaryMultiplierContribution;
            _previousArchitectMultiplier = savedData.PreviousArchitectMultiplier;
            _previousVisionaryMultiplier = savedData.PreviousVisionaryMultiplier;
            _previousEngineerMultiplier = savedData.PreviousEngineerMultiplier;
            _prevOverchargerLevel3 = savedData.PrevOverchargerLevel3;
            _prevPrimerLevel4 = savedData.PrevPrimerLevel4;

            _prismUpgrade1Multi = savedData.PrismUpgrade1Multi;
            _prevRitualAmount1 = savedData.PrevRitualAmount1;
            _prevRitualAmount2 = savedData.PrevRitualAmount2;
            _prevRitualAmount3 = savedData.PrevRitualAmount3;
            _prevRitualAmount4 = savedData.PrevRitualAmount4;
            _prevRitualAmount5 = savedData.PrevRitualAmount5;
            howManyTimes = savedData.HowManyTimes;
            howManyTimes2 = savedData.HowManyTimes2;
            howManyTimes3 = savedData.HowManyTimes3;


            _baseProducerMultiplier = savedData.BaseProducerMultiplier;
            _baseProducerCostMulti = savedData.BaseProducerCostMulti;
            _baseArchitectMultiplier = savedData.BaseArchitectMultiplier;
            _baseArchitectCostMulti = savedData.BaseArchitectCostMulti;
            _baseEngineerMultiplier = savedData.BaseEngineerMultiplier;
            _baseEngineerCostMulti = savedData.BaseEngineerCostMulti;

            _baseVisionaryMultiplier = savedData.BaseVisionaryMultiplier;
            _baseVisionaryCostMulti = savedData.BaseVisionaryCostMulti;
            _baseOmniMultiplier = savedData.BaseOmniMultiplier;
            _baseOmniCostMulti = savedData.BaseOmniCostMulti;

            _basePrimerCostMulti = savedData.BasePrimerCostMulti;
            _baseOverchargerCostMulti = savedData.BaseOverchargerCostMulti;

            _baseWeaverMultiplier = savedData.BaseWeaverMultiplier;
            _baseWeaverCostMulti = savedData.BaseWeaverCostMulti;
            _baseForgerMultiplier = savedData.BaseForgerMultiplier;
            _baseForgerCostMulti = savedData.BaseForgerCostMulti;
            _baseNexusMultiplier = savedData.BaseNexusMultiplier;
            _baseNexusCostMulti = savedData.BaseNexusCostMulti;

            _fractalFluxuateMulti = savedData.FractalFluxuateMulti;
            _fractalRitualMulti = savedData.FractalRitualMulti;
            _prevFractCount = savedData.PrevFractCount;
            _prevFractCount2 = savedData.PrevFractCount2;
            _prevWeaverCount = savedData.PrevWeaverCount;
            _prevForgerCount = savedData.PrevForgerCount;
            _prevNexusCount = savedData.PrevNexusCount;
            _prevFluxuateCount = savedData.PrevFluxuateCount;
            _prevFluxuateCount2 = savedData.PrevFluxuateCount2;
            fluxuateFromRitual = savedData.FluxuateFromRitual;

            _previousWeaverMultiplier = savedData.PreviousWeaverMultiplier;
            _prismUpgrade11Contri = savedData.PrismUpgrade11Contri;
            _previousForgerMultiplier = savedData.PreviousForgerMultiplier;

            _prevRitualCount1 = savedData.PrevRitualCount1;
            _prevRitualCount2 = savedData.PrevRitualCount2;
            _prevRitualCount3 = savedData.PrevRitualCount3;
            _prevRitualCount4 = savedData.PrevRitualCount4;

            _prevPrimerQuantity = savedData.PrevPrimerQuantity;
            _prevOverchargerQuantity = savedData.PrevOverchargerQuantity;

        }

        private void AutoSave(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine($"Auto-Saving");
            UpdateGameState();
            SaveSystem.Save(_gameState);
        }

        protected override void OnExiting(object sender, EventArgs args)
        {
            UpdateGameState();
            SaveSystem.Save(_gameState);
            base.OnExiting(sender, args);
        }
      
        public void UpgradeLoading()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            prodUpgrade1Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), cubeUpgrade1Pos, EmptyTexture, "", new Color(36, 36, 36));
            prodUpgrade1Button.Click += ProdUpgrade1Button_Clicked;

            archUpgrade1Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            archUpgrade1Button.Click += ArchiUpgrade1Button_Clicked;

            engiUpgrade1Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 2, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            engiUpgrade1Button.Click += EngiUpgrade1Button_Clicked;

            prodMultiFromArchButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            prodMultiFromArchButton.Click += ProdMultiFromArchButton_Clicked;

            prodMultiFromArchMultiButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 2, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            prodMultiFromArchMultiButton.Click += ProdMultiFromArchMultiButton_Clicked;

            allCubeMultiUpButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 3, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            allCubeMultiUpButton.Click += AllCubeMultiUpButton_Clicked;

            archMultiFromEngiButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 4, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            archMultiFromEngiButton.Click += ArchMultiFromEngiButton_Clicked;

            cube10GenToMultiButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 6, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            cube10GenToMultiButton.Click += Cube10GenToMultiButton_Clicked;

            prod5MultiButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 4, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            prod5MultiButton.Click += Prod5MultiButton_Clicked;

            arch5MultiButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 5, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            arch5MultiButton.Click += Arch5MultiButton_Clicked;

            engi5MultiButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 6, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            engi5MultiButton.Click += Engi5MultiButton_Clicked;

            archMultiFromEngiMultiButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 8, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            archMultiFromEngiMultiButton.Click += ArchMultiFromEngiMultiButton_Clicked;

            prodSaleUpgradeButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 7, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            prodSaleUpgradeButton.Click += ProdSaleUpgradeButton_Clicked;

            archSaleUpgradeButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 8, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            archSaleUpgradeButton.Click += ArchSaleUpgradeButton_Clicked;

            engiSaleUpgradeButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 9, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            engiSaleUpgradeButton.Click += EngiSaleUpgradeButton_Clicked;

            engiMultiFromProdButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 10, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            engiMultiFromProdButton.Click += EngiMultiFromProdButton_Clicked;

            cube10GenToSaleButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 12, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            cube10GenToSaleButton.Click += Cube10GenToSaleButton_Clicked;

            cube50ProdToProdMultButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 11, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            cube50ProdToProdMultButton.Click += Cube50ProdToProdMultButton_Clicked;


            visMultFromProdButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 10, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            visMultFromProdButton.Click += VisMultFromProdButton_Clicked;

            visMultFromArchButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 12, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            visMultFromArchButton.Click += VisMultFromArchButton_Clicked;

            visMultFromEngiButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 13, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            visMultFromEngiButton.Click += VisMultFromEngiButton_Clicked;

            visBaseMultUpButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 14, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            visBaseMultUpButton.Click += VisBaseMultUpButton_Clicked;


            threeMultiUpFromVisButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 14, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            threeMultiUpFromVisButton.Click += ThreeMultiUpFromVisButton_Clicked;
            
            prodFromPrimerButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 15, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            prodFromPrimerButton.Click += ProdFromPrimerButton_Clicked;

            archFromPrimerButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 16, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            archFromPrimerButton.Click += ArchFromPrimerButton_Clicked;

            engiFromPrimerButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 16, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            engiFromPrimerButton.Click += EngiFromPrimerButton_Clicked;

            visFromOverchargerButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 17, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            visFromOverchargerButton.Click += VisFromOverchargerButton_Clicked;


            omniFromOverchargerButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 18, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            omniFromOverchargerButton.Click += OmniFromOverchargerButton_Clicked;

            baseOmniMultiUpButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 18, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            baseOmniMultiUpButton.Click += BaseOmniMultiUpButton_Clicked;

            allGen100ToOmniMultButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 19, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            allGen100ToOmniMultButton.Click += AllGen100ToOmniMultButton_Clicked;

            cubeFinalUpgrade1Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 20, cubeUpgrade1Pos.Y + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            cubeFinalUpgrade1Button.Click += CubeFinalUpgrade1Button_Clicked;

            cubeFinalUpgrade2Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 20, cubeUpgrade1Pos.Y), EmptyTexture, "", new Color(36, 36, 36));
            cubeFinalUpgrade2Button.Click += CubeFinalUpgrade2Button_Clicked;

            trueFinalCubeUpgradeButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 21, cubeUpgrade1Pos.Y + 42), EmptyTexture, "", new Color(36, 36, 36));
            trueFinalCubeUpgradeButton.Click += TrueFinalCubeUpgradeButton_Clicked;



            autoProducersButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X, cubeUpgrade1Pos.Y + (42 * 5)), EmptyTexture, "", new Color(36, 36, 36));
            autoProducersButton.Click += AutoProducersButton_Clicked;
            
            autoArchitectsButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42, cubeUpgrade1Pos.Y + (42 * 5) + 42), EmptyTexture, "", new Color(36, 36, 36));
            autoArchitectsButton.Click += AutoArchitectsButton_Clicked;
            
            autoEngineersButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X, cubeUpgrade1Pos.Y + (42 * 5) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            autoEngineersButton.Click += AutoEngineersButton_Clicked; 
            
            autoVisionaryButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 2, cubeUpgrade1Pos.Y + (42 * 5)), EmptyTexture, "", new Color(36, 36, 36));
            autoVisionaryButton.Click += AutoVisionaryButton_Clicked;

            autoOmniButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 3, cubeUpgrade1Pos.Y + (42 * 5) + 42), EmptyTexture, "", new Color(36, 36, 36));
            autoOmniButton.Click += AutoOmniButton_Clicked;

            autoPrimerButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 2, cubeUpgrade1Pos.Y + (42 * 5) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            autoPrimerButton.Click += AutoPrimerButton_Clicked;
            
            autoOverchargerButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 4, cubeUpgrade1Pos.Y + (42 * 5)), EmptyTexture, "", new Color(36, 36, 36));
            autoOverchargerButton.Click += AutoOverchargerButton_Clicked;

            autoProducersBoostButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 5, cubeUpgrade1Pos.Y + (42 * 5) + 42), EmptyTexture, "", new Color(36, 36, 36));
            autoProducersBoostButton.Click += AutoProducersBoostButton_Clicked;
           
            autoArchitectsBoostButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 4, cubeUpgrade1Pos.Y + (42 * 5) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            autoArchitectsBoostButton.Click += AutoArchitectsBoostButton_Clicked;

            autoEngineersBoostButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 6, cubeUpgrade1Pos.Y + (42 * 5)), EmptyTexture, "", new Color(36, 36, 36));
            autoEngineersBoostButton.Click += AutoEngineersBoostButton_Clicked;
            
            autoVisionaryBoostButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 7, cubeUpgrade1Pos.Y + (42 * 5) + 42), EmptyTexture, "", new Color(36, 36, 36));
            autoVisionaryBoostButton.Click += AutoVisionaryBoostButton_Clicked;
            
            autoOmniBoostButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 6, cubeUpgrade1Pos.Y + (42 * 5) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            autoOmniBoostButton.Click += AutoOmniBoostButton_Clicked;

            autoPrimerBoostButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 8, cubeUpgrade1Pos.Y + (42 * 5)), EmptyTexture, "", new Color(36, 36, 36));
            autoPrimerBoostButton.Click += AutoPrimerBoostButton_Clicked;
            
            autoOverchargerBoostButton = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 9, cubeUpgrade1Pos.Y + (42 * 5) + 42), EmptyTexture, "", new Color(36, 36, 36));
            autoOverchargerBoostButton.Click += AutoOverchargerBoostButton_Clicked;



            fluxUpgrade1Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X, cubeUpgrade1Pos.Y + (42 * 10)), EmptyTexture, "", new Color(36, 36, 36));
            fluxUpgrade1Button.Click += FluxUpgrade1Button_Clicked;

            fluxUpgrade2Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42, cubeUpgrade1Pos.Y + (42 * 10) + 42), EmptyTexture, "", new Color(36, 36, 36));
            fluxUpgrade2Button.Click += FluxUpgrade2Button_Clicked;
           
            fluxUpgrade3Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X, cubeUpgrade1Pos.Y + (42 * 10) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            fluxUpgrade3Button.Click += FluxUpgrade3Button_Clicked;

            fluxUpgrade4Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 2, cubeUpgrade1Pos.Y + (42 * 10)), EmptyTexture, "", new Color(36, 36, 36));
            fluxUpgrade4Button.Click += FluxUpgrade4Button_Clicked;

            fluxUpgrade5Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 3, cubeUpgrade1Pos.Y + (42 * 10) + 42), EmptyTexture, "", new Color(36, 36, 36));
            fluxUpgrade5Button.Click += FluxUpgrade5Button_Clicked;
            
            fluxUpgrade6Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 2, cubeUpgrade1Pos.Y + (42 * 10) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            fluxUpgrade6Button.Click += FluxUpgrade6Button_Clicked;

            fluxUpgrade7Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 4, cubeUpgrade1Pos.Y + (42 * 10)), EmptyTexture, "", new Color(36, 36, 36));
            fluxUpgrade7Button.Click += FluxUpgrade7Button_Clicked;
            
            fluxUpgrade8Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 5, cubeUpgrade1Pos.Y + (42 * 10) + 42), EmptyTexture, "", new Color(36, 36, 36));
            fluxUpgrade8Button.Click += FluxUpgrade8Button_Clicked;
            
            fluxUpgrade9Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 4, cubeUpgrade1Pos.Y + (42 * 10) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            fluxUpgrade9Button.Click += FluxUpgrade9Button_Clicked;


            prismUpgrade1Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X, cubeUpgrade1Pos.Y + (42 * 15)), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade1Button.Click += PrismUpgrade1Button_Clicked;

            prismUpgrade2Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42, cubeUpgrade1Pos.Y + (42 * 15) + 42), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade2Button.Click += PrismUpgrade2Button_Clicked;
            
            prismUpgrade3Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X, cubeUpgrade1Pos.Y + (42 * 15) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade3Button.Click += PrismUpgrade3Button_Clicked;


            prismUpgrade4Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 2, cubeUpgrade1Pos.Y + (42 * 15)), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade4Button.Click += PrismUpgrade4Button_Clicked;
            
            prismUpgrade5Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 3, cubeUpgrade1Pos.Y + (42 * 15) + 42), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade5Button.Click += PrismUpgrade5Button_Clicked;
            
            prismUpgrade6Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 2, cubeUpgrade1Pos.Y + (42 * 15) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade6Button.Click += PrismUpgrade6Button_Clicked;

            prismUpgrade7Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 4, cubeUpgrade1Pos.Y + (42 * 15)), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade7Button.Click += PrismUpgrade7Button_Clicked;
            
            prismUpgrade8Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 5, cubeUpgrade1Pos.Y + (42 * 15) + 42), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade8Button.Click += PrismUpgrade8Button_Clicked;

            prismUpgrade9Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 4, cubeUpgrade1Pos.Y + (42 * 15) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade9Button.Click += PrismUpgrade9Button_Clicked;

            prismUpgrade10Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 6, cubeUpgrade1Pos.Y + (42 * 15)), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade10Button.Click += PrismUpgrade10Button_Clicked;

            prismUpgrade11Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 7, cubeUpgrade1Pos.Y + (42 * 15) + 42), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade11Button.Click += PrismUpgrade11Button_Clicked;
           
            prismUpgrade12Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 6, cubeUpgrade1Pos.Y + (42 * 15) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade12Button.Click += PrismUpgrade12Button_Clicked;
            
            prismUpgrade13Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 8, cubeUpgrade1Pos.Y + (42 * 15)), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade13Button.Click += PrismUpgrade13Button_Clicked;
            
            prismUpgrade14Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 9, cubeUpgrade1Pos.Y + (42 * 15) + 42), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade14Button.Click += PrismUpgrade14Button_Clicked;
            
            prismUpgrade15Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 8, cubeUpgrade1Pos.Y + (42 * 15) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade15Button.Click += PrismUpgrade15Button_Clicked;

            prismUpgrade16Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 10, cubeUpgrade1Pos.Y + (42 * 15)), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade16Button.Click += PrismUpgrade16Button_Clicked;
            
            prismUpgrade17Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 11, cubeUpgrade1Pos.Y + (42 * 15) + 42), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade17Button.Click += PrismUpgrade17Button_Clicked;
            
            prismUpgrade18Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 10, cubeUpgrade1Pos.Y + (42 * 15) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade18Button.Click += PrismUpgrade18Button_Clicked;
            
            prismUpgrade19Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(cubeUpgrade1Pos.X + 42 * 12, cubeUpgrade1Pos.Y + (42 * 15)), EmptyTexture, "", new Color(36, 36, 36));
            prismUpgrade19Button.Click += PrismUpgrade19Button_Clicked;


            
            
            // FRACTAL UPGRADES
            fractalUpgrade1Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2((1920 / 2) - 164, cubeProducerPos.Y + 400), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade1Button.Click += FractalUpgrade1Button_Clicked;

            fractalUpgrade2Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) - 42, (cubeProducerPos.Y + 400) + 42), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade2Button.Click += FractalUpgrade2Button_Clicked;
            
            fractalUpgrade3Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) - 42 * 2, (cubeProducerPos.Y + 400) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade3Button.Click += FractalUpgrade3Button_Clicked;
           
            fractalUpgrade4Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) - 42 * 2, (cubeProducerPos.Y + 400)), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade4Button.Click += FractalUpgrade4Button_Clicked;
            
            fractalUpgrade5Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) - 42 * 3, (cubeProducerPos.Y + 400) + 42), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade5Button.Click += FractalUpgrade5Button_Clicked;
            
            fractalUpgrade6Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) - 42 * 5, (cubeProducerPos.Y + 400) + 42), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade6Button.Click += FractalUpgrade6Button_Clicked;

            fractalUpgrade7Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) + 42, (cubeProducerPos.Y + 400) + 42), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade7Button.Click += FractalUpgrade7Button_Clicked;

            fractalUpgrade8Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) + 42 * 2, (cubeProducerPos.Y + 400) + 42 * 2), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade8Button.Click += FractalUpgrade8Button_Clicked;
            
            fractalUpgrade9Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) + 42 * 2, (cubeProducerPos.Y + 400)), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade9Button.Click += FractalUpgrade9Button_Clicked;
            
            fractalUpgrade10Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) + 42 * 3, (cubeProducerPos.Y + 400 + 42)), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade10Button.Click += FractalUpgrade10Button_Clicked;
           
            fractalUpgrade11Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) + 42 * 5, (cubeProducerPos.Y + 400 + 42)), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade11Button.Click += FractalUpgrade11Button_Clicked;
          
            fractalUpgrade12Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) - 42, (cubeProducerPos.Y + 400 + 42 * 3)), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade12Button.Click += FractalUpgrade12Button_Clicked;
           
            fractalUpgrade13Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) - 42 * 2, (cubeProducerPos.Y + 400 + 42 * 4)), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade13Button.Click += FractalUpgrade13Button_Clicked;
          
            fractalUpgrade14Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) - 42 * 3, (cubeProducerPos.Y + 400 + 42 * 3)), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade14Button.Click += FractalUpgrade14Button_Clicked;
           
            fractalUpgrade15Button = new UIUpgradeButton(EmptyTexture, new Rectangle(64, 64, 86, 86), new Vector2(((1920 / 2) - 164) - 42 * 2, (cubeProducerPos.Y + 400 + 42 * 6)), EmptyTexture, "", new Color(36, 36, 36));
            fractalUpgrade15Button.Click += FractalUpgrade15Button_Clicked;

        }
        public void AchievementLoading()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            cubeAmountAch1Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), achievement1Pos, EmptyTexture, "", new Color(36, 36, 36), false);
            cubeAmountAch2Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), true);
            cubeAmountAch3Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 2, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), false);
            cubeAmountAch4Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 3, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), true);
            cubeAmountFluxUnlockButton = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 4, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), false);
            cubeAmountAch6Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 5, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), true);
            cubeAmountAch7Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 6, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), false);
            cubeAmountAch8Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 7, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), true);

            fluxuateAmountAch1Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), true);
            fluxuateAmountAch2Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), false);
            fluxuateAmountAch3Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 2, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), true);
            fluxuateAmountAch4Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 3, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), false);
            fluxuateAmountAch5Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 4, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), true);
            fluxuateAmountAch6Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 5, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), false);

            cubeAmountAch9Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 8, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), false);
            cubeAmountAch10Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 9, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), true);

            ritualAmountAch1Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X, achievement1Pos.Y + 160), EmptyTexture, "", new Color(36, 36, 36), false);
            ritualAmountAch2Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50, achievement1Pos.Y + 160), EmptyTexture, "", new Color(36, 36, 36), true);
            ritualAmountAch3Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 2, achievement1Pos.Y + 160), EmptyTexture, "", new Color(36, 36, 36), false);
            ritualAmountAch4Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 3, achievement1Pos.Y + 160), EmptyTexture, "", new Color(36, 36, 36), true);
            ritualAmountAch5Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 4, achievement1Pos.Y + 160), EmptyTexture, "", new Color(36, 36, 36), false);
            ritualAmountAch6Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 5, achievement1Pos.Y + 160), EmptyTexture, "", new Color(36, 36, 36), true);

            cubeAmountAch11Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 10, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), false);
            cubeAmountAch12Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 11, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), true);
            cubeAmountAch13Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 12, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), false);
            cubeAmountAch14Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 13, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), true);
            cubeAmountAch15Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 14, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), false);
            cubeAmountAch16Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 15, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), true);
            cubeAmountAch17Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 16, achievement1Pos.Y), EmptyTexture, "", new Color(36, 36, 36), false);

            fluxuateAmountAch7Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 6, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), true);
            fluxuateAmountAch8Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 7, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), false);
            fluxuateAmountAch9Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 8, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), true);
            fluxuateAmountAch10Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 9, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), false);
            fluxuateAmountAch11Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 10, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), true);
            fluxuateAmountAch12Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 11, achievement1Pos.Y + 80), EmptyTexture, "", new Color(36, 36, 36), false);

            ritualAmountAch7Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 6, achievement1Pos.Y + 160), EmptyTexture, "", new Color(36, 36, 36), false);
           
            fractalAmountAch1Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X, achievement1Pos.Y + 240), EmptyTexture, "", new Color(36, 36, 36), true);
            fractalAmountAch2Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50, achievement1Pos.Y + 240), EmptyTexture, "", new Color(36, 36, 36), false);
            fractalAmountAch3Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 2, achievement1Pos.Y + 240), EmptyTexture, "", new Color(36, 36, 36), true);
            fractalAmountAch4Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 3, achievement1Pos.Y + 240), EmptyTexture, "", new Color(36, 36, 36), false);
            fractalAmountAch5Button = new UIAchievementButton(EmptyTexture, new Rectangle(100, 80, 100, 80), new Vector2(achievement1Pos.X + 50 * 4, achievement1Pos.Y + 240), EmptyTexture, "", new Color(36, 36, 36), true);

        }
        private void ProdAutoButton_Clicked(object sender, EventArgs e)
        {
            if (isCubeGeneratorsSectionOpen)
            {
                if (autoProducers.IsActive)
                {
                    _prodAutoBuyEnabled = !_prodAutoBuyEnabled;
                    _prodAutoButton.extraButtonColor = _prodAutoBuyEnabled ? Color.DarkGreen : Color.DarkRed;
                }
            }
        } 
        private void ArchAutoButton_Clicked(object sender, EventArgs e)
        {
            if (isCubeGeneratorsSectionOpen)
            {
                if (autoArchitects.IsActive)
                {
                    _archAutoBuyEnabled = !_archAutoBuyEnabled;
                    _archAutoButton.extraButtonColor = _archAutoBuyEnabled ? Color.DarkGreen : Color.DarkRed;
                }
            }
        }
        private void EngiAutoButton_Clicked(object sender, EventArgs e)
        {
            if (isCubeGeneratorsSectionOpen)
            {
                if (autoEngineers.IsActive)
                {
                    _engiAutoBuyEnabled = !_engiAutoBuyEnabled;
                    _engiAutoButton.extraButtonColor = _engiAutoBuyEnabled ? Color.DarkGreen : Color.DarkRed;
                }
            }
        }
        private void VisAutoButton_Clicked(object sender, EventArgs e)
        {
            if (isCubeGeneratorsSectionOpen && cubeAmountAch6.IsUnlocked)
            {
                if (autoVisionary.IsActive)
                {
                    _visAutoBuyEnabled = !_visAutoBuyEnabled;
                    _visAutoButton.extraButtonColor = _visAutoBuyEnabled ? Color.DarkGreen : Color.DarkRed;
                }
            }
        } 
        private void OmniAutoButton_Clicked(object sender, EventArgs e)
        {
            if (isCubeGeneratorsSectionOpen && cubeAmountAch8.IsUnlocked)
            {
                if (autoOmni.IsActive)
                {
                    _omniAutoBuyEnabled = !_omniAutoBuyEnabled;
                    _omniAutoButton.extraButtonColor = _omniAutoBuyEnabled ? Color.DarkGreen : Color.DarkRed;
                }
            }
        } 
        private void PrimerAutoButton_Clicked(object sender, EventArgs e)
        {
            if (isCubeGeneratorsSectionOpen && fluxuateAmountAch7.IsUnlocked)
            {
                if (autoPrimer.IsActive)
                {
                    _primerAutoBuyEnabled = !_primerAutoBuyEnabled;
                    _primerAutoButton.extraButtonColor = _primerAutoBuyEnabled ? Color.DarkGreen : Color.DarkRed;
                }
            }
        }  
        private void OverchargerAutoButton_Clicked(object sender, EventArgs e)
        {
            if (isCubeGeneratorsSectionOpen && fluxuateAmountAch7.IsUnlocked)
            {
                if (autoOvercharger.IsActive)
                {
                    _overchargerAutoBuyEnabled = !_overchargerAutoBuyEnabled;
                    _overchargerAutoButton.extraButtonColor = _overchargerAutoBuyEnabled ? Color.DarkGreen : Color.DarkRed;
                }
            }
        } 
        private void FluxuateAutoButton_Clicked(object sender, EventArgs e)
        {
            if (fluxuateAmountAch4.IsUnlocked)
            {
                _fluxuateAutoEnabled = !_fluxuateAutoEnabled;
                _fluxuateAutoButton.extraButtonColor = _fluxuateAutoEnabled ? Color.DarkGreen : Color.DarkRed;
            }        
        } 
        private void RitualAutoButton_Clicked(object sender, EventArgs e)
        {
            if (ritualAmountAch4.IsUnlocked)
            {
                _ritualAutoEnabled = !_ritualAutoEnabled;
                _ritualAutoButton.extraButtonColor = _ritualAutoEnabled ? Color.DarkGreen : Color.DarkRed;
            }        
        }
        private void GeneratorsButton_Clicked(object sender, EventArgs e)
        {
            // Perform the action for the generators button
            if (_confirmationPopup == null)
            {
                colorLineColor = new Color(27, 24, 102);
                isCubeGeneratorsSectionOpen = true;
                isUpgradeSectionOpen = false;
                isAchievementSectionOpen = false;
                isFractalGeneratorsSectionOpen = false;
                isSigilsSectionOpen = false;
            }
        }
        private void UpgradesButton_Clicked(object sender, EventArgs e)
        {
            // Perform the action for the upgrades button
            if (_confirmationPopup == null)
            {
                colorLineColor = new Color(153, 72, 21);
                isCubeGeneratorsSectionOpen = false;
                isUpgradeSectionOpen = true;
                isAchievementSectionOpen = false;
                isFractalGeneratorsSectionOpen = false;
                isSigilsSectionOpen = false;
            }
        }
        private void AchievementsButton_Clicked(object sender, EventArgs e)
        {
            // Perform the action for the achievements button
            if (_confirmationPopup == null)
            {
                colorLineColor = new Color(184, 138, 13);
                isCubeGeneratorsSectionOpen = false;
                isUpgradeSectionOpen = false;
                isAchievementSectionOpen = true;
                isFractalGeneratorsSectionOpen = false;
                isSigilsSectionOpen = false;
            }
        } 
        private void FractGenButton_Clicked(object sender, EventArgs e)
        {
            // Perform the action for the achievements button
            if (_confirmationPopup == null && ritualAmountAch1.IsUnlocked)
            {
                colorLineColor = new Color(184, 13, 59);
                isCubeGeneratorsSectionOpen = false;
                isUpgradeSectionOpen = false;
                isAchievementSectionOpen = false;
                isFractalGeneratorsSectionOpen = true;
                isSigilsSectionOpen = false;
            }
        }
        private void SigilsButton_Clicked(object sender, EventArgs e)
        {
            // Perform the action for the achievements button
            if (_confirmationPopup == null && cubeAmountAch17.IsUnlocked)
            {
                colorLineColor = new Color(147, 9, 22);
                isCubeGeneratorsSectionOpen = false;
                isUpgradeSectionOpen = false;
                isAchievementSectionOpen = false;
                isFractalGeneratorsSectionOpen = false;
                isSigilsSectionOpen = true;
            }
        }
        private void ProdUpgrade1Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prodUpgrade1.CanAfford(resourceManager.GetCubes()) && !prodUpgrade1.IsActive)
                    {
                        resourceManager.RemoveCubes(prodUpgrade1.Cost);
                        prodUpgrade1.Buy();
                        _baseProducerMultiplier += 0.1;
                        cubeProducer.CubeMultiplier += 0.1;
                    }
                }
            }
        }
        private void ArchiUpgrade1Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (archUpgrade1.CanAfford(resourceManager.GetCubes()) && !archUpgrade1.IsActive)
                    {
                        resourceManager.RemoveCubes(archUpgrade1.Cost);
                        archUpgrade1.Buy();
                        _baseArchitectMultiplier += 0.1;
                        cubeArchitect.CubeMultiplier += 0.1;
                    }
                }
            }
        }
        private void EngiUpgrade1Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (engiUpgrade1.CanAfford(resourceManager.GetCubes()) && !engiUpgrade1.IsActive)
                    {
                        resourceManager.RemoveCubes(engiUpgrade1.Cost);
                        engiUpgrade1.Buy();
                        _baseEngineerMultiplier += 0.1;
                        cubeEngineer.CubeMultiplier += 0.1;
                    }
                }
            }
        } 
        private void ProdMultiFromArchButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prodMultiFromArch.CanAfford(resourceManager.GetCubes()) && !prodMultiFromArch.IsActive)
                    {
                        resourceManager.RemoveCubes(prodMultiFromArch.Cost);
                        prodMultiFromArch.Buy();

                    }
                }
            }
        } 
        private void ProdMultiFromArchMultiButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prodMultiFromArchMulti.CanAfford(resourceManager.GetCubes()) && !prodMultiFromArchMulti.IsActive)
                    {
                        resourceManager.RemoveCubes(prodMultiFromArchMulti.Cost);
                        prodMultiFromArchMulti.Buy();

                    }
                }
            }
        } 
        private void AllCubeMultiUpButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (allCubeMultiUp.CanAfford(resourceManager.GetCubes()) && !allCubeMultiUp.IsActive)
                    {
                        resourceManager.RemoveCubes(allCubeMultiUp.Cost);
                        allCubeMultiUp.Buy();
                        _baseProducerMultiplier += 0.25;
                        _baseArchitectMultiplier += 0.25;
                        _baseEngineerMultiplier += 0.25;
                        cubeProducer.CubeMultiplier += 0.25;
                        cubeArchitect.CubeMultiplier += 0.25;
                        cubeEngineer.CubeMultiplier += 0.25;
                    }
                }
            }
        } 
        private void ArchMultiFromEngiButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (archMultiFromEngi.CanAfford(resourceManager.GetCubes()) && !archMultiFromEngi.IsActive)
                    {
                        resourceManager.RemoveCubes(archMultiFromEngi.Cost);
                        archMultiFromEngi.Buy();

                    }
                }
            }
        } 
        private void Cube10GenToMultiButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (cube10GenToMulti.CanAfford(resourceManager.GetCubes()) && !cube10GenToMulti.IsActive)
                    {
                        resourceManager.RemoveCubes(cube10GenToMulti.Cost);
                        cube10GenToMulti.Buy();

                    }
                }
            }
        } 
        private void Prod5MultiButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prod5Multi.CanAfford(resourceManager.GetCubes()) && !prod5Multi.IsActive)
                    {
                        resourceManager.RemoveCubes(prod5Multi.Cost);
                        prod5Multi.Buy();
                        _baseProducerMultiplier += 15;
                        cubeProducer.CubeMultiplier += 15;

                    }
                }
            }
        }
        private void Arch5MultiButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (arch5Multi.CanAfford(resourceManager.GetCubes()) && !arch5Multi.IsActive)
                    {
                        resourceManager.RemoveCubes(arch5Multi.Cost);
                        arch5Multi.Buy();
                        _baseArchitectMultiplier += 7.5;
                        cubeArchitect.CubeMultiplier += 7.5;

                    }
                }
            }
        } 
        private void Engi5MultiButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (engi5Multi.CanAfford(resourceManager.GetCubes()) && !engi5Multi.IsActive)
                    {
                        resourceManager.RemoveCubes(engi5Multi.Cost);
                        engi5Multi.Buy();
                        _baseEngineerMultiplier += 5;
                        cubeEngineer.CubeMultiplier += 5;
                    }
                }
            }
        }   
        private void ArchMultiFromEngiMultiButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (archMultiFromEngiMulti.CanAfford(resourceManager.GetCubes()) && !archMultiFromEngiMulti.IsActive)
                    {
                        resourceManager.RemoveCubes(archMultiFromEngiMulti.Cost);
                        archMultiFromEngiMulti.Buy();

                    }
                }
            }
        } 
        private void ProdSaleUpgradeButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prodSaleUpgrade.CanAfford(resourceManager.GetCubes()) && !prodSaleUpgrade.IsActive)
                    {
                        resourceManager.RemoveCubes(prodSaleUpgrade.Cost);
                        prodSaleUpgrade.Buy();
                        _baseProducerCostMulti *= 0.75;
                        cubeProducer.CurrentCost *= _baseProducerCostMulti;
                    }
                }
            }
        } 
        private void ArchSaleUpgradeButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (archSaleUpgrade.CanAfford(resourceManager.GetCubes()) && !archSaleUpgrade.IsActive)
                    {
                        resourceManager.RemoveCubes(archSaleUpgrade.Cost);
                        archSaleUpgrade.Buy();
                        _baseArchitectCostMulti *= 0.5;
                        cubeArchitect.CurrentCost *= _baseArchitectCostMulti;
                    }
                }
            }
        }
        private void EngiSaleUpgradeButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (engiSaleUpgrade.CanAfford(resourceManager.GetCubes()) && !engiSaleUpgrade.IsActive)
                    {
                        resourceManager.RemoveCubes(engiSaleUpgrade.Cost);
                        engiSaleUpgrade.Buy();
                        _baseEngineerCostMulti *= 0.25;
                        cubeEngineer.CurrentCost *= _baseEngineerCostMulti;
                    }
                }
            }
        } 
        private void EngiMultiFromProdButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (engiMultiFromProd.CanAfford(resourceManager.GetCubes()) && !engiMultiFromProd.IsActive)
                    {
                        resourceManager.RemoveCubes(engiMultiFromProd.Cost);
                        engiMultiFromProd.Buy();
                    }
                }
            }
        } 
        private void Cube10GenToSaleButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (cube10GenToSale.CanAfford(resourceManager.GetCubes()) && !cube10GenToSale.IsActive)
                    {
                        resourceManager.RemoveCubes(cube10GenToSale.Cost);
                        cube10GenToSale.Buy();
                    }
                }
            }
        } 
        private void Cube50ProdToProdMultButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (cube50ProdToProdMult.CanAfford(resourceManager.GetCubes()) && !cube50ProdToProdMult.IsActive)
                    {
                        resourceManager.RemoveCubes(cube50ProdToProdMult.Cost);
                        cube50ProdToProdMult.Buy();
                    }
                }
            }
        } 
        private void VisMultFromProdButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (visMultFromProd.CanAfford(resourceManager.GetCubes()) && !visMultFromProd.IsActive)
                    {
                        resourceManager.RemoveCubes(visMultFromProd.Cost);
                        visMultFromProd.Buy();
                    }
                }
            }
        } 
        private void VisMultFromArchButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (visMultFromArch.CanAfford(resourceManager.GetCubes()) && !visMultFromArch.IsActive)
                    {
                        resourceManager.RemoveCubes(visMultFromArch.Cost);
                        visMultFromArch.Buy();
                    }
                }
            }
        } 
        private void VisMultFromEngiButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (visMultFromEngi.CanAfford(resourceManager.GetCubes()) && !visMultFromEngi.IsActive)
                    {
                        resourceManager.RemoveCubes(visMultFromEngi.Cost);
                        visMultFromEngi.Buy();
                    }
                }
            }
        }
        private void VisBaseMultUpButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (visBaseMultUp.CanAfford(resourceManager.GetCubes()) && !visBaseMultUp.IsActive)
                    {
                        resourceManager.RemoveCubes(visBaseMultUp.Cost);
                        visBaseMultUp.Buy();
                        _baseVisionaryMultiplier += 25;
                        cubeVisionary.CubeMultiplier += 25;
                    }
                }
            }
        } 
        private void AllGen100ToOmniMultButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (allGen100ToOmniMult.CanAfford(resourceManager.GetCubes()) && !allGen100ToOmniMult.IsActive)
                    {
                        resourceManager.RemoveCubes(allGen100ToOmniMult.Cost);
                        allGen100ToOmniMult.Buy();
                    }
                }
            }
        }
        private void ThreeMultiUpFromVisButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (threeMultiUpFromVis.CanAfford(resourceManager.GetCubes()) && !threeMultiUpFromVis.IsActive)
                    {
                        resourceManager.RemoveCubes(threeMultiUpFromVis.Cost);
                        threeMultiUpFromVis.Buy();
                    }
                }
            }
        }
        private void ProdFromPrimerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prodFromPrimer.CanAfford(resourceManager.GetCubes()) && !prodFromPrimer.IsActive)
                    {
                        resourceManager.RemoveCubes(prodFromPrimer.Cost);
                        prodFromPrimer.Buy();
                    }
                }
            }
        } 
        private void ArchFromPrimerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (archFromPrimer.CanAfford(resourceManager.GetCubes()) && !archFromPrimer.IsActive)
                    {
                        resourceManager.RemoveCubes(archFromPrimer.Cost);
                        archFromPrimer.Buy();
                    }
                }
            }
        } 
        private void EngiFromPrimerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (engiFromPrimer.CanAfford(resourceManager.GetCubes()) && !engiFromPrimer.IsActive)
                    {
                        resourceManager.RemoveCubes(engiFromPrimer.Cost);
                        engiFromPrimer.Buy();
                    }
                }
            }
        } 
        private void VisFromOverchargerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (visFromOvercharger.CanAfford(resourceManager.GetCubes()) && !visFromOvercharger.IsActive)
                    {
                        resourceManager.RemoveCubes(visFromOvercharger.Cost);
                        visFromOvercharger.Buy();
                    }
                }
            }
        }
        private void OmniFromOverchargerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (omniFromOvercharger.CanAfford(resourceManager.GetCubes()) && !omniFromOvercharger.IsActive)
                    {
                        resourceManager.RemoveCubes(omniFromOvercharger.Cost);
                        omniFromOvercharger.Buy();
                    }
                }
            }
        } 
        private void BaseOmniMultiUpButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    if (baseOmniMultiUp.CanAfford(resourceManager.GetCubes()) && !baseOmniMultiUp.IsActive)
                    {
                        resourceManager.RemoveCubes(baseOmniMultiUp.Cost);
                        baseOmniMultiUp.Buy();
                        _baseOmniMultiplier += 50;
                        cubeOmni.CubeMultiplier += 50;
                    }
                }
            }
        } 
        private void AutoProducersButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoProducers.CanAfford(resourceManager.GetFlux()) && !autoProducers.IsActive)
                    {
                        resourceManager.RemoveFlux(autoProducers.Cost);
                        autoProducers.Buy();
                    }
                }
            }
        }
        private void AutoProducersBoostButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch8.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoProducersBoost.CanAfford(resourceManager.GetFlux()) && !autoProducersBoost.IsActive)
                    {
                        resourceManager.RemoveFlux(autoProducersBoost.Cost);
                        autoProducersBoost.Buy();
                    }
                }
            }
        }
        private void AutoArchitectsBoostButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch8.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoArchitectsBoost.CanAfford(resourceManager.GetFlux()) && !autoArchitectsBoost.IsActive)
                    {
                        resourceManager.RemoveFlux(autoArchitectsBoost.Cost);
                        autoArchitectsBoost.Buy();
                    }
                }
            }
        }
        private void AutoEngineersBoostButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch8.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoEngineersBoost.CanAfford(resourceManager.GetFlux()) && !autoEngineersBoost.IsActive)
                    {
                        resourceManager.RemoveFlux(autoEngineersBoost.Cost);
                        autoEngineersBoost.Buy();
                    }
                }
            }
        }
        private void AutoVisionaryBoostButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch8.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoVisionaryBoost.CanAfford(resourceManager.GetFlux()) && !autoVisionaryBoost.IsActive)
                    {
                        resourceManager.RemoveFlux(autoVisionaryBoost.Cost);
                        autoVisionaryBoost.Buy();
                    }
                }
            }
        }
        private void AutoOmniBoostButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch8.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoOmniBoost.CanAfford(resourceManager.GetFlux()) && !autoOmniBoost.IsActive)
                    {
                        resourceManager.RemoveFlux(autoOmniBoost.Cost);
                        autoOmniBoost.Buy();
                    }
                }
            }
        }
        private void AutoPrimerBoostButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch9.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoPrimerBoost.CanAfford(resourceManager.GetPrism()) && !autoPrimerBoost.IsActive)
                    {
                        resourceManager.RemovePrism(autoPrimerBoost.Cost);
                        autoPrimerBoost.Buy();
                    }
                }
            }
        }
        private void AutoOverchargerBoostButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch9.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoOverchargerBoost.CanAfford(resourceManager.GetPrism()) && !autoOverchargerBoost.IsActive)
                    {
                        resourceManager.RemovePrism(autoOverchargerBoost.Cost);
                        autoOverchargerBoost.Buy();
                    }
                }
            }
        }
        private void AutoArchitectsButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoArchitects.CanAfford(resourceManager.GetFlux()) && !autoArchitects.IsActive)
                    {
                        resourceManager.RemoveFlux(autoArchitects.Cost);
                        autoArchitects.Buy();
                    }
                }
            }
        } 
        private void AutoEngineersButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoEngineers.CanAfford(resourceManager.GetFlux()) && !autoEngineers.IsActive)
                    {
                        resourceManager.RemoveFlux(autoEngineers.Cost);
                        autoEngineers.Buy();
                    }
                }
            }
        }
        private void AutoVisionaryButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoVisionary.CanAfford(resourceManager.GetFlux()) && !autoVisionary.IsActive)
                    {
                        resourceManager.RemoveFlux(autoVisionary.Cost);
                        autoVisionary.Buy();
                    }
                }
            }
        }
        private void AutoOmniButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoOmni.CanAfford(resourceManager.GetFlux()) && !autoOmni.IsActive)
                    {
                        resourceManager.RemoveFlux(autoOmni.Cost);
                        autoOmni.Buy();
                    }
                }
            }
        } 
        private void AutoPrimerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch7.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoPrimer.CanAfford(resourceManager.GetPrism()) && !autoPrimer.IsActive)
                    {
                        resourceManager.RemovePrism(autoPrimer.Cost);
                        autoPrimer.Buy();
                    }
                }
            }
        }  
        private void AutoOverchargerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch7.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (autoOvercharger.CanAfford(resourceManager.GetPrism()) && !autoOvercharger.IsActive)
                    {
                        resourceManager.RemovePrism(autoOvercharger.Cost);
                        autoOvercharger.Buy();
                    }
                }
            }
        }  
        private void CubeFinalUpgrade1Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (cubeFinalUpgrade1.CanAfford(resourceManager.GetCubes()) && !cubeFinalUpgrade1.IsActive)
                    {
                        resourceManager.RemoveFlux(cubeFinalUpgrade1.Cost);
                        cubeFinalUpgrade1.Buy();

                        _baseProducerMultiplier += 1e15;
                        cubeProducer.CubeMultiplier += 1e15;

                        _baseArchitectMultiplier += 1e15;
                        cubeArchitect.CubeMultiplier += 1e15;
                        
                        _baseEngineerMultiplier += 1e15;
                        cubeEngineer.CubeMultiplier += 1e15; 
                        
                        _baseVisionaryMultiplier += 1e15;
                        cubeVisionary.CubeMultiplier += 1e15;
                        
                        _baseOmniMultiplier += 1e15;
                        cubeOmni.CubeMultiplier += 1e15;
                    }
                }
            }
        }     
        private void CubeFinalUpgrade2Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (cubeFinalUpgrade2.CanAfford(resourceManager.GetCubes()) && !cubeFinalUpgrade2.IsActive)
                    {
                        resourceManager.RemoveFlux(cubeFinalUpgrade2.Cost);
                        cubeFinalUpgrade2.Buy();

                        _baseProducerCostMulti *= 0.05;
                        cubeProducer.CurrentCost *= _baseProducerCostMulti;
                        
                        _baseArchitectCostMulti *= 0.05;
                        cubeArchitect.CurrentCost *= _baseArchitectCostMulti;
                        
                        _baseEngineerCostMulti *= 0.05;
                        cubeEngineer.CurrentCost *= _baseEngineerCostMulti;
                       
                        _baseVisionaryCostMulti *= 0.05;
                        cubeVisionary.CurrentCost *= _baseVisionaryCostMulti;
                        
                        _baseOmniCostMulti *= 0.05;
                        cubeOmni.CurrentCost *= _baseOmniCostMulti;


                    }
                }
            }
        } 
        private void TrueFinalCubeUpgradeButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && cubeAmountAch13.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (trueFinalCubeUpgrade.CanAfford(resourceManager.GetCubes()) && !trueFinalCubeUpgrade.IsActive)
                    {
                        resourceManager.RemoveFlux(trueFinalCubeUpgrade.Cost);
                        trueFinalCubeUpgrade.Buy();
                    }
                }
            }
        } 
        private void FluxUpgrade1Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (fluxUpgrade1.CanAfford(resourceManager.GetFlux()) && !fluxUpgrade1.IsActive)
                    {
                        resourceManager.RemoveFlux(fluxUpgrade1.Cost);
                        fluxUpgrade1.Buy();
                    }
                }
            }
        } 
        private void FluxUpgrade2Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (fluxUpgrade2.CanAfford(resourceManager.GetFlux()) && !fluxUpgrade2.IsActive)
                    {
                        resourceManager.RemoveFlux(fluxUpgrade2.Cost);
                        fluxUpgrade2.Buy();
                    }
                }
            }
        }
        private void FluxUpgrade3Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (fluxUpgrade3.CanAfford(resourceManager.GetFlux()) && !fluxUpgrade3.IsActive)
                    {
                        resourceManager.RemoveFlux(fluxUpgrade3.Cost);
                        fluxUpgrade3.Buy();
                    }
                }
            }
        }
        private void FluxUpgrade4Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (fluxUpgrade4.CanAfford(resourceManager.GetFlux()) && !fluxUpgrade4.IsActive)
                    {
                        resourceManager.RemoveFlux(fluxUpgrade4.Cost);
                        fluxUpgrade4.Buy();
                        _basePrimerCostMulti *= 0.25;
                        primer.CurrentCost *= _basePrimerCostMulti;
                    }
                }
            }
        }
        private void FluxUpgrade5Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (fluxUpgrade5.CanAfford(resourceManager.GetFlux()) && !fluxUpgrade5.IsActive)
                    {
                        resourceManager.RemoveFlux(fluxUpgrade5.Cost);
                        fluxUpgrade5.Buy();
                        _baseOverchargerCostMulti *= 0.5;
                        overcharger.CurrentCost *= _baseOverchargerCostMulti;
                    }
                }
            }
        }
        private void FluxUpgrade6Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (fluxUpgrade6.CanAfford(resourceManager.GetFlux()) && !fluxUpgrade6.IsActive)
                    {
                        resourceManager.RemoveFlux(fluxUpgrade6.Cost);
                        fluxUpgrade6.Buy();
                    }
                }
            }
        }
        private void FluxUpgrade7Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch6.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (fluxUpgrade7.CanAfford(resourceManager.GetFlux()) && !fluxUpgrade7.IsActive)
                    {
                        resourceManager.RemoveFlux(fluxUpgrade7.Cost);
                        fluxUpgrade7.Buy();

                    }
                }
            }
        }
        private void FluxUpgrade8Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch6.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (fluxUpgrade8.CanAfford(resourceManager.GetFlux()) && !fluxUpgrade8.IsActive)
                    {
                        resourceManager.RemoveFlux(fluxUpgrade8.Cost);
                        fluxUpgrade8.Buy();
                        _basePrimerCostMulti *= 0.5;
                        primer.CurrentCost *= _basePrimerCostMulti;
                    }
                }
            }
        }      
        private void FluxUpgrade9Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && fluxuateAmountAch6.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (fluxUpgrade9.CanAfford(resourceManager.GetFlux()) && !fluxUpgrade9.IsActive)
                    {
                        resourceManager.RemoveFlux(fluxUpgrade9.Cost);
                        fluxUpgrade9.Buy();
                        _baseOverchargerCostMulti *= 0.75;
                        overcharger.CurrentCost *= _baseOverchargerCostMulti;
                    }
                }
            }
        } 
        private void PrismUpgrade1Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch1.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade1.CanAfford(resourceManager.GetPrism()) && !prismUpgrade1.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade1.Cost);
                        prismUpgrade1.Buy();
                    }
                }
            }
        } 
        private void PrismUpgrade2Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch1.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade2.CanAfford(resourceManager.GetPrism()) && !prismUpgrade2.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade2.Cost);
                        prismUpgrade2.Buy();
                        _basePrimerCostMulti *= 0.25;
                        primer.CurrentCost *= _basePrimerCostMulti; 
                        _baseOverchargerCostMulti *= 0.25;
                        overcharger.CurrentCost *= _baseOverchargerCostMulti;
                    }
                }
            }
        }
        private void PrismUpgrade3Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch1.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade3.CanAfford(resourceManager.GetPrism()) && !prismUpgrade3.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade3.Cost);
                        prismUpgrade3.Buy();
                    }
                }
            }
        }
        private void PrismUpgrade4Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch2.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade4.CanAfford(resourceManager.GetPrism()) && !prismUpgrade4.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade4.Cost);
                        prismUpgrade4.Buy();
                        _baseWeaverMultiplier += 0.25;
                        fractalWeaver.FractalMultiplier += 0.25;
                    }
                }
            }
        }
        private void PrismUpgrade5Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch2.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade5.CanAfford(resourceManager.GetPrism()) && !prismUpgrade5.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade5.Cost);
                        prismUpgrade5.Buy();
                    }
                }
            }
        }
        private void PrismUpgrade6Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch2.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade6.CanAfford(resourceManager.GetPrism()) && !prismUpgrade6.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade6.Cost);
                        prismUpgrade6.Buy();
                        _baseForgerMultiplier += 0.25;
                        fractalForger.FractalMultiplier += 0.25;
                    }
                }
            }
        }        
        private void PrismUpgrade7Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade7.CanAfford(resourceManager.GetPrism()) && !prismUpgrade7.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade7.Cost);
                        prismUpgrade7.Buy();
                        _baseWeaverCostMulti *= 0.5;
                        fractalWeaver.CurrentCost *= _baseWeaverCostMulti;
                    }
                }
            }
        }        
        private void PrismUpgrade8Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade8.CanAfford(resourceManager.GetPrism()) && !prismUpgrade8.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade8.Cost);
                        prismUpgrade8.Buy();
                    }
                }
            }
        }       
        private void PrismUpgrade9Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade9.CanAfford(resourceManager.GetPrism()) && !prismUpgrade9.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade9.Cost);
                        prismUpgrade9.Buy();
                        _baseWeaverMultiplier += 0.75;
                        fractalWeaver.FractalMultiplier += 0.75;
                    }
                }
            }
        }       
        private void PrismUpgrade10Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch3.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade10.CanAfford(resourceManager.GetPrism()) && !prismUpgrade10.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade10.Cost);
                        prismUpgrade10.Buy();
                    }
                }
            }
        }        
        private void PrismUpgrade11Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade11.CanAfford(resourceManager.GetPrism()) && !prismUpgrade11.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade11.Cost);
                        prismUpgrade11.Buy();
                    }
                }
            }
        }        
        private void PrismUpgrade12Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade12.CanAfford(resourceManager.GetPrism()) && !prismUpgrade12.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade12.Cost);
                        prismUpgrade12.Buy();
                        _baseForgerMultiplier += 1.25;
                        fractalForger.FractalMultiplier += 1.25;
                    }
                }
            }
        }       
        private void PrismUpgrade13Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade13.CanAfford(resourceManager.GetPrism()) && !prismUpgrade13.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade13.Cost);
                        prismUpgrade13.Buy();
                        _baseNexusMultiplier += 1.5;
                        fractalNexus.FractalMultiplier += 1.5;
                    }
                }
            }
        }        
        private void PrismUpgrade14Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch5.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade14.CanAfford(resourceManager.GetPrism()) && !prismUpgrade14.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade14.Cost);
                        prismUpgrade14.Buy();
                    }
                }
            }
        }        
        private void PrismUpgrade15Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch6.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade15.CanAfford(resourceManager.GetPrism()) && !prismUpgrade15.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade15.Cost);
                        prismUpgrade15.Buy();
                        _baseWeaverMultiplier += 100;
                        fractalWeaver.FractalMultiplier += 100;
                    }
                }
            }
        }        
        private void PrismUpgrade16Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch6.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade16.CanAfford(resourceManager.GetPrism()) && !prismUpgrade16.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade16.Cost);
                        prismUpgrade16.Buy();
                        _baseForgerMultiplier += 75;
                        fractalForger.FractalMultiplier += 75;
                    }
                }
            }
        }        
        private void PrismUpgrade17Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch6.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade17.CanAfford(resourceManager.GetPrism()) && !prismUpgrade17.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade17.Cost);
                        prismUpgrade17.Buy();
                        _baseNexusMultiplier += 50;
                        fractalNexus.FractalMultiplier += 50;
                    }
                }
            }
        }        
        private void PrismUpgrade18Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch7.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade18.CanAfford(resourceManager.GetPrism()) && !prismUpgrade18.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade18.Cost);
                        prismUpgrade18.Buy();
                    }
                }
            }
        }        
        private void PrismUpgrade19Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null && ritualAmountAch7.IsUnlocked)
            {
                if (isUpgradeSectionOpen)
                {
                    if (prismUpgrade19.CanAfford(resourceManager.GetPrism()) && !prismUpgrade19.IsActive)
                    {
                        resourceManager.RemovePrism(prismUpgrade19.Cost);
                        prismUpgrade19.Buy();
                    }
                }
            }
        }        
        private void FractalUpgrade1Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade1.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade1.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade1.Cost);
                        fractalUpgrade1.Buy();
                        
                    }
                }
            }
        } 
        private void FractalUpgrade2Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade2.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade2.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade2.Cost);
                        fractalUpgrade2.Buy();
                        
                    }
                }
            }
        } 
        private void FractalUpgrade3Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade3.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade3.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade3.Cost);
                        fractalUpgrade3.Buy();
                        
                    }
                }
            }
        }
        private void FractalUpgrade4Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade4.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade4.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade4.Cost);
                        fractalUpgrade4.Buy();
                        
                    }
                }
            }
        }
        private void FractalUpgrade5Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade5.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade5.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade5.Cost);
                        fractalUpgrade5.Buy();
                        
                    }
                }
            }
        }
        private void FractalUpgrade6Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade6.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade6.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade6.Cost);
                        fractalUpgrade6.Buy();
                        
                    }
                }
            }
        }
        private void FractalUpgrade7Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade7.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade7.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade7.Cost);
                        fractalUpgrade7.Buy();
                        
                    }
                }
            }
        } 
        private void FractalUpgrade8Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade8.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade8.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade8.Cost);
                        fractalUpgrade8.Buy();
                        _basePrimerCostMulti *= 0.05;
                        primer.CurrentCost *= _basePrimerCostMulti;
                        _baseOverchargerCostMulti *= 0.05;
                        overcharger.CurrentCost *= _baseOverchargerCostMulti;
                    }
                }
            }
        } 
        private void FractalUpgrade9Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade9.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade9.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade9.Cost);
                        fractalUpgrade9.Buy();
                    }
                }
            }
        }
        private void FractalUpgrade10Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade10.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade10.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade10.Cost);
                        fractalUpgrade10.Buy();
                    }
                }
            }
        }
        private void FractalUpgrade11Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (fractalUpgrade11.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade11.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade11.Cost);
                        fractalUpgrade11.Buy();
                    }
                }
            }
        }
        private void FractalUpgrade12Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen && fractalAmountAch5.IsUnlocked)
                {
                    if (fractalUpgrade12.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade12.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade12.Cost);
                        fractalUpgrade12.Buy();
                    }
                }
            }
        }
        private void FractalUpgrade13Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen && fractalAmountAch5.IsUnlocked)
                {
                    if (fractalUpgrade13.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade13.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade13.Cost);
                        fractalUpgrade13.Buy();
                    }
                }
            }
        }
        private void FractalUpgrade14Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen && fractalAmountAch5.IsUnlocked)
                {
                    if (fractalUpgrade14.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade14.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade14.Cost);
                        fractalUpgrade14.Buy();
                    }
                }
            }
        }
        private void FractalUpgrade15Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen && fractalAmountAch5.IsUnlocked)
                {
                    if (fractalUpgrade15.CanAfford(resourceManager.GetFractals()) && !fractalUpgrade15.IsActive)
                    {
                        resourceManager.RemoveFractals(fractalUpgrade15.Cost);
                        fractalUpgrade15.Buy();
                    }
                }
            }
        }
        private void CubeProducerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isCubeGeneratorsSectionOpen)
                {
                    if (CubeGenerator.BuyAmount == -1) // MAX option
                    {
                        int maxBuyable = cubeProducer.CalculateMaxBuyable(resourceManager.GetCubes(), _baseProducerCostMulti);
                        if (maxBuyable > 0)
                        {
                            resourceManager.RemoveCubes(cubeProducer.CalculateTotalCost(maxBuyable));
                            cubeProducer.Buy(maxBuyable);
                        }
                    }
                    else
                    {
                        if (cubeProducer.CanAfford(resourceManager.GetCubes()))
                        {
                            resourceManager.RemoveCubes(cubeProducer.CalculateTotalCost(CubeGenerator.BuyAmount));
                            cubeProducer.Buy(CubeGenerator.BuyAmount);
                        }
                    }
                }
            }
        }
        private void CubeArchitectButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isCubeGeneratorsSectionOpen)
                {
                    if (CubeGenerator.BuyAmount == -1) // MAX option
                    {
                        int maxBuyable = cubeArchitect.CalculateMaxBuyable(resourceManager.GetCubes(), _baseArchitectCostMulti);
                        if (maxBuyable > 0)
                        {
                            resourceManager.RemoveCubes(cubeArchitect.CalculateTotalCost(maxBuyable));
                            cubeArchitect.Buy(maxBuyable);
                        }
                    }
                    else
                    {
                        if (cubeArchitect.CanAfford(resourceManager.GetCubes()))
                        {
                            resourceManager.RemoveCubes(cubeArchitect.CalculateTotalCost(CubeGenerator.BuyAmount));
                            cubeArchitect.Buy(CubeGenerator.BuyAmount);
                        }
                    }
                }
            }
        } 
        private void CubeEngineerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isCubeGeneratorsSectionOpen)
                {
                    if (CubeGenerator.BuyAmount == -1) // MAX option
                    {
                        int maxBuyable = cubeEngineer.CalculateMaxBuyable(resourceManager.GetCubes(), _baseEngineerCostMulti);
                        if (maxBuyable > 0)
                        {
                            resourceManager.RemoveCubes(cubeEngineer.CalculateTotalCost(maxBuyable));
                            cubeEngineer.Buy(maxBuyable);
                        }
                    }
                    else
                    {
                        if (cubeEngineer.CanAfford(resourceManager.GetCubes()))
                        {
                            resourceManager.RemoveCubes(cubeEngineer.CalculateTotalCost(CubeGenerator.BuyAmount));
                            cubeEngineer.Buy(CubeGenerator.BuyAmount);
                        }
                    }
                }
            }
        }
        private void CubeVisionaryButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isCubeGeneratorsSectionOpen)
                {
                    if (cubeAmountAch6.IsUnlocked)
                    {
                        if (CubeGenerator.BuyAmount == -1) // MAX option
                        {
                            int maxBuyable = cubeVisionary.CalculateMaxBuyable(resourceManager.GetCubes(), _baseVisionaryMultiplier);
                            if (maxBuyable > 0)
                            {
                                resourceManager.RemoveCubes(cubeVisionary.CalculateTotalCost(maxBuyable));
                                cubeVisionary.Buy(maxBuyable);
                            }
                        }
                        else
                        {
                            if (cubeVisionary.CanAfford(resourceManager.GetCubes()))
                            {
                                resourceManager.RemoveCubes(cubeVisionary.CalculateTotalCost(CubeGenerator.BuyAmount));
                                cubeVisionary.Buy(CubeGenerator.BuyAmount);
                            }
                        }
                    }
                }
            }
        }
        private void CubeOmniButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isCubeGeneratorsSectionOpen)
                {
                    if (cubeAmountAch8.IsUnlocked)
                    {
                        if (CubeGenerator.BuyAmount == -1) // MAX option
                        {
                            int maxBuyable = cubeOmni.CalculateMaxBuyable(resourceManager.GetCubes(), _baseOmniMultiplier);
                            if (maxBuyable > 0)
                            {
                                resourceManager.RemoveCubes(cubeOmni.CalculateTotalCost(maxBuyable));
                                cubeOmni.Buy(maxBuyable);
                            }
                        }
                        else
                        {
                            if (cubeOmni.CanAfford(resourceManager.GetCubes()))
                            {
                                resourceManager.RemoveCubes(cubeOmni.CalculateTotalCost(CubeGenerator.BuyAmount));
                                cubeOmni.Buy(CubeGenerator.BuyAmount);
                            }
                        }
                    }
                }
            }
        }
        private void FluxuateButton_Clicked(object sender, EventArgs e)
        {
           
            if (cubeAmountFluxUnlock.IsUnlocked && _confirmationPopup == null && resourceManager.GetCubes() >= 1e7)
            {
                colorLineColor = new Color(61, 156, 250);
                _confirmationPopup = new ConfirmationPopup(GraphicsDevice, "Fluxuate?", new Rectangle(0, 0, 300, 120), new Vector2(fluxuatePos.X - 40, fluxuatePos.Y - 120), new Color(136, 252, 252), font);
                _confirmationPopup.YesButtonClicked += (s, args) =>
                {
                    resourceManager.Fluxuate();
                    _confirmationPopup = null;
                };
                _confirmationPopup.NoButtonClicked += (s, args) =>
                {
                    _confirmationPopup = null;
                };
            }
        }
        private void RitualButton_Clicked(object sender, EventArgs e)
        {
            
            if (cubeAmountAch9.IsUnlocked && _confirmationPopup == null && resourceManager.GetCubes() >= 1e20)
            {
                colorLineColor = new Color(252, 136, 136);
                _confirmationPopup = new ConfirmationPopup(GraphicsDevice, "Perform a Ritual?", new Rectangle(0, 0, 300, 120), new Vector2(fluxuatePos.X - 40, fluxuatePos.Y - 120 - 120), new Color(252, 132, 132), font);
                _confirmationPopup.YesButtonClicked += (s, args) =>
                {
                    resourceManager.Ritual();
                    _confirmationPopup = null;
                };
                _confirmationPopup.NoButtonClicked += (s, args) =>
                {
                    _confirmationPopup = null;
                };
            }
        }
        private void PrimerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isCubeGeneratorsSectionOpen)
                {
                    if (fluxuateAmountAch1.IsUnlocked)
                    {
                        if (CubeGenerator.BuyAmount == -1) // MAX option
                        {
                            int maxBuyable = primer.CalculateMaxBuyable(resourceManager.GetFlux(), _basePrimerCostMulti);
                            if (maxBuyable > 0)
                            {
                                resourceManager.RemoveFlux(primer.CalculateTotalCost(maxBuyable));
                                primer.Buy(maxBuyable);
                            }
                        }
                        else
                        {
                            if (primer.CanAfford(resourceManager.GetFlux()))
                            {
                                resourceManager.RemoveFlux(primer.CalculateTotalCost(CubeGenerator.BuyAmount));
                                primer.Buy(CubeGenerator.BuyAmount);
                            }
                        }
                    }
                }
            }
        } 
        private void OverchargerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isCubeGeneratorsSectionOpen)
                {
                    if (fluxuateAmountAch2.IsUnlocked)
                    {
                        if (CubeGenerator.BuyAmount == -1) // MAX option
                        {
                            int maxBuyable = overcharger.CalculateMaxBuyable(resourceManager.GetFlux(), _baseOverchargerCostMulti);
                            if (maxBuyable > 0)
                            {
                                resourceManager.RemoveFlux(overcharger.CalculateTotalCost(maxBuyable));
                                overcharger.Buy(maxBuyable);
                            }
                        }
                        else
                        {
                            if (overcharger.CanAfford(resourceManager.GetFlux()))
                            {
                                resourceManager.RemoveFlux(overcharger.CalculateTotalCost(CubeGenerator.BuyAmount));
                                overcharger.Buy(CubeGenerator.BuyAmount);
                            }
                        }
                    }
                }
            }
        }
        //Fractal Area
        private void FractalWeaverButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (CubeGenerator.BuyAmount == -1) // MAX option
                    {
                        int maxBuyable = fractalWeaver.CalculateMaxBuyable(resourceManager.GetPrism(), 1);
                        if (maxBuyable > 0)
                        {
                            resourceManager.RemovePrism(fractalWeaver.CalculateTotalCost(maxBuyable));
                            fractalWeaver.Buy(maxBuyable);
                        }
                    }
                    else
                    {
                        if (fractalWeaver.CanAfford(resourceManager.GetPrism()))
                        {
                            resourceManager.RemovePrism(fractalWeaver.CalculateTotalCost(CubeGenerator.BuyAmount));
                            fractalWeaver.Buy(CubeGenerator.BuyAmount);
                        }
                    }
                }
            }
        }
        private void FractalForgerButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (CubeGenerator.BuyAmount == -1) // MAX option
                    {
                        int maxBuyable = fractalForger.CalculateMaxBuyable(resourceManager.GetPrism(), 1);
                        if (maxBuyable > 0)
                        {
                            resourceManager.RemovePrism(fractalForger.CalculateTotalCost(maxBuyable));
                            fractalForger.Buy(maxBuyable);
                        }
                    }
                    else
                    {
                        if (fractalForger.CanAfford(resourceManager.GetPrism()))
                        {
                            resourceManager.RemovePrism(fractalForger.CalculateTotalCost(CubeGenerator.BuyAmount));
                            fractalForger.Buy(CubeGenerator.BuyAmount);
                        }
                    }
                }
            }
        }
        private void FractalNexusButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null)
            {
                if (isFractalGeneratorsSectionOpen)
                {
                    if (CubeGenerator.BuyAmount == -1) // MAX option
                    {
                        int maxBuyable = fractalNexus.CalculateMaxBuyable(resourceManager.GetPrism(), 1);
                        if (maxBuyable > 0)
                        {
                            resourceManager.RemovePrism(fractalNexus.CalculateTotalCost(maxBuyable));
                            fractalNexus.Buy(maxBuyable);
                        }
                    }
                    else
                    {
                        if (fractalNexus.CanAfford(resourceManager.GetPrism()))
                        {
                            resourceManager.RemovePrism(fractalNexus.CalculateTotalCost(CubeGenerator.BuyAmount));
                            fractalNexus.Buy(CubeGenerator.BuyAmount);
                        }
                    }
                }
            }
        }


        #region Cube Buy Amount Clicks
        private void CubeBuy1Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null) if (isCubeGeneratorsSectionOpen || isFractalGeneratorsSectionOpen) { CubeGenerator.BuyAmount = 1; }
        }
        private void CubeBuy10Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null) if (isCubeGeneratorsSectionOpen || isFractalGeneratorsSectionOpen) { CubeGenerator.BuyAmount = 10; }
        }
        private void CubeBuy25Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null) if (isCubeGeneratorsSectionOpen || isFractalGeneratorsSectionOpen) { CubeGenerator.BuyAmount = 25; }
        }
        private void CubeBuy50Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null) if (isCubeGeneratorsSectionOpen || isFractalGeneratorsSectionOpen) { CubeGenerator.BuyAmount = 50; }
        }
        private void CubeBuy100Button_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null) if (isCubeGeneratorsSectionOpen || isFractalGeneratorsSectionOpen) { CubeGenerator.BuyAmount = 100; }
        }
        private void CubeBuyMaxButton_Clicked(object sender, EventArgs e)
        {
            if (_confirmationPopup == null) if (isCubeGeneratorsSectionOpen || isFractalGeneratorsSectionOpen) { CubeGenerator.BuyAmount = -1; }
        }
        #endregion



        private float _fluxAutoUpdateTime;
        private float _fluxAutoUpdateInterval = 0.11f; // seconds
        private float _ritualAutoUpdateTime;
        private float _ritualAutoUpdateInterval = 0.11f; // seconds

        protected override void Update(GameTime gameTime)
        {
            foreach (var component in _gameComponents) component.Update(gameTime);

            cubeProducer.Quantity = Math.Floor(cubeProducer.Quantity);
            cubeArchitect.Quantity = Math.Floor(cubeArchitect.Quantity);
            cubeEngineer.Quantity = Math.Floor(cubeEngineer.Quantity);
            cubeVisionary.Quantity = Math.Floor(cubeVisionary.Quantity);
            cubeOmni.Quantity = Math.Floor(cubeOmni.Quantity);
            primer.Quantity = Math.Floor(primer.Quantity);
            overcharger.Quantity = Math.Floor(overcharger.Quantity);
            fractalWeaver.Quantity = Math.Floor(fractalWeaver.Quantity);
            fractalForger.Quantity = Math.Floor(fractalForger.Quantity);
            fractalNexus.Quantity = Math.Floor(fractalNexus.Quantity);

            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            double cubes = resourceManager.GetCubes();
            if (cubes > 1e200)
            {
                double excessCubes = cubes - 1e200;
                double sigilCubesGenerated = excessCubes / 1e200 * elapsedTime;
                resourceManager.AddSigilCubes(sigilCubesGenerated);
                resourceManager.SetCubes(1e200);
            }

            if(cubeProducer.CurrentCost <= 0.00001) cubeProducer.CurrentCost = 0.00001;
            if(cubeArchitect.CurrentCost <= 0.00001) cubeArchitect.CurrentCost = 0.00001;
            if(cubeEngineer.CurrentCost <= 0.00001) cubeEngineer.CurrentCost = 0.00001;
            if(cubeVisionary.CurrentCost <= 0.00001) cubeVisionary.CurrentCost = 0.00001;
            if(cubeOmni.CurrentCost <= 0.00001) cubeOmni.CurrentCost = 0.00001;
            if(primer.CurrentCost <= 0.00001) primer.CurrentCost = 0.00001;
            if(overcharger.CurrentCost <= 0.00001) overcharger.CurrentCost = 0.00001;
            if(fractalWeaver.CurrentCost <= 0.00001) fractalWeaver.CurrentCost = 0.00001;
            if(fractalForger.CurrentCost <= 0.00001) fractalForger.CurrentCost = 0.00001;
            if(fractalNexus.CurrentCost <= 0.00001) fractalNexus.CurrentCost = 0.00001;

            if(cubeProducer.Quantity >= 1e300) cubeProducer.Quantity = 1e300;
            if(cubeArchitect.Quantity >= 1e300) cubeArchitect.Quantity = 1e300;
            if(cubeEngineer.Quantity >= 1e300) cubeEngineer.Quantity = 1e300;
            if(cubeVisionary.Quantity >= 1e300) cubeVisionary.Quantity = 1e300;
            if(cubeOmni.Quantity >= 1e300) cubeOmni.Quantity = 1e300;
            if(primer.Quantity >= 1e300) primer.Quantity = 1e300;
            if(overcharger.Quantity >= 1e300) overcharger.Quantity = 1e300;
            if(fractalWeaver.Quantity >= 1e300) fractalWeaver.Quantity = 1e300;
            if(fractalForger.Quantity >= 1e300) fractalForger.Quantity = 1e300;
            if(fractalNexus.Quantity >= 1e300) fractalNexus.Quantity = 1e300;

            if (resourceManager.GetFlux() > 1e300)
            {
                resourceManager.SetFlux(1e300);
            }
            if(resourceManager.GetPrism() > 1e300)
            {
                resourceManager.SetPrism(1e300);
            }

            if (autoProducers.IsActive)
            {
                _prodAutoButton.Update(gameTime);
            } 
            if (autoArchitects.IsActive)
            {
                _archAutoButton.Update(gameTime);
            }
            if (autoEngineers.IsActive)
            {
                _engiAutoButton.Update(gameTime);
            }
            if (autoVisionary.IsActive && cubeAmountAch6.IsUnlocked)
            {
                _visAutoButton.Update(gameTime);
            } 
            if (autoOmni.IsActive && cubeAmountAch8.IsUnlocked)
            {
                _omniAutoButton.Update(gameTime);
            } 
            if (autoPrimer.IsActive && fluxuateAmountAch1.IsUnlocked)
            {
                _primerAutoButton.Update(gameTime);
            } 
            if (autoOvercharger.IsActive && fluxuateAmountAch2.IsUnlocked)
            {
                _overchargerAutoButton.Update(gameTime);
            }
            if (fluxuateAmountAch4.IsUnlocked)
            {
                _fluxuateAutoButton.Update(gameTime);
            }
            if (ritualAmountAch4.IsUnlocked)
            {
                _ritualAutoButton.Update(gameTime);
            }
            FractalNexusUpdate(gameTime);
            FractalForgerUpdate(gameTime);
            FractalWeaverUpdate(gameTime);
            CubeProducerUpdate(gameTime);
            PrimerUpdate(gameTime);
            OverchargerUpdate(gameTime);
            CubeArchitectUpdate(gameTime);
            CubeEngineerUpdate(gameTime);
            CubeVisionaryUpdate(gameTime);
            CubeOmniUpdate(gameTime);
            CubeUpgradeUpdate(gameTime);
            AutomateUpgradeUpdate(gameTime);
            FluxUpgradeUpdate(gameTime);
            PrismUpgradeUpdate(gameTime);
            FractalUpgradeUpdate(gameTime);
            AchievementUpdate(gameTime);

            if (isCubeGeneratorsSectionOpen || isFractalGeneratorsSectionOpen)
            {
                cubeBuy1Button.ButtonTexture = BuyButtonTexture;
                cubeBuy1Button.Text = "1";
                cubeBuy10Button.ButtonTexture = BuyButtonTexture;
                cubeBuy10Button.Text = "10";
                cubeBuy25Button.ButtonTexture = BuyButtonTexture;
                cubeBuy25Button.Text = "25";
                cubeBuy50Button.ButtonTexture = BuyButtonTexture;
                cubeBuy50Button.Text = "50";
                cubeBuy100Button.ButtonTexture = BuyButtonTexture;
                cubeBuy100Button.Text = "100";
                cubeBuyMaxButton.ButtonTexture = BuyButtonTexture;
                cubeBuyMaxButton.Text = "MAX";

                if (CubeGenerator.BuyAmount == 1) { cubeBuy1Button.extraButtonColor = new Color(62, 62, 149); } else cubeBuy1Button.extraButtonColor = new Color(42, 42, 42);
                if (CubeGenerator.BuyAmount == 10) { cubeBuy10Button.extraButtonColor = new Color(62, 62, 149); } else cubeBuy10Button.extraButtonColor = new Color(42, 42, 42);
                if (CubeGenerator.BuyAmount == 25) { cubeBuy25Button.extraButtonColor = new Color(62, 62, 149); } else cubeBuy25Button.extraButtonColor = new Color(42, 42, 42);
                if (CubeGenerator.BuyAmount == 50) { cubeBuy50Button.extraButtonColor = new Color(62, 62, 149); } else cubeBuy50Button.extraButtonColor = new Color(42, 42, 42);
                if (CubeGenerator.BuyAmount == 100) { cubeBuy100Button.extraButtonColor = new Color(62, 62, 149); } else cubeBuy100Button.extraButtonColor = new Color(42, 42, 42);
                if (CubeGenerator.BuyAmount == -1) { cubeBuyMaxButton.extraButtonColor = new Color(62, 62, 149); } else cubeBuyMaxButton.extraButtonColor = new Color(42, 42, 42);

            }
            else
            {
                cubeBuy1Button.ButtonTexture = EmptyTexture;
                cubeBuy1Button.Text = "";
                cubeBuy10Button.ButtonTexture = EmptyTexture;
                cubeBuy10Button.Text = "";
                cubeBuy25Button.ButtonTexture = EmptyTexture;
                cubeBuy25Button.Text = "";
                cubeBuy50Button.ButtonTexture = EmptyTexture;
                cubeBuy50Button.Text = "";
                cubeBuy100Button.ButtonTexture = EmptyTexture;
                cubeBuy100Button.Text = "";
                cubeBuyMaxButton.ButtonTexture = EmptyTexture;
                cubeBuyMaxButton.Text = "";
            }

            if (ritualAmountAch1.IsUnlocked)
            {
                fractGenButton.Update(gameTime);
                fractGenButton.ButtonTexture = ButtonTexture;
                fractGenButton.Text = "Fractal Generators";

                expoNumeration = new BigNumber(resourceManager.GetFractals());
                fractalLabel.Text = $"FRACTALS: {expoNumeration.ToString()}";
                fractalLabel.TextColor = new Color(213, 73, 103);
            }
            else
            {
                fractGenButton.ButtonTexture = EmptyTexture;
                fractGenButton.Text = "";
                
            }

            if (cubeAmountAch17.IsUnlocked)
            {
                sigilsButton.Update(gameTime);
                sigilsButton.ButtonTexture = ButtonTexture;
                sigilsButton.Text = "Sigils";

                expoNumeration = new BigNumber(resourceManager.GetFractals());
                sigilCubeLabel.Text = $"SIGIL CUBES: {expoNumeration.ToString()}";
                sigilCubeLabel.TextColor = new Color(191, 105, 105);
            }
            else
            {
                sigilsButton.ButtonTexture = EmptyTexture;
                sigilsButton.Text = "";
                
            }



            expoNumeration = new BigNumber(resourceManager.GetCubes());
            cubeLabel.Text = $"CUBES: {expoNumeration.ToString()}";
            cubeLabel.TextColor = new Color(136, 194, 252);



            if (cubeAmountFluxUnlock.IsUnlocked)
            {
                UpdateHoverText2();
                fluxuateButton.Text = "FLUXUATE";
                fluxuateButton.ButtonTexture = ButtonTexture;
                if (_confirmationPopup == null)
                {
                    fluxuateButton.HoverText = $"[c:88c2fc]Cubes Needed: {new BigNumber(resourceManager.GetCubes())} / 1e7 \n[c:88fcfc]Flux Gained: {new BigNumber(resourceManager.CalculateFlux(resourceManager.GetCubes(), fluxUpgrade7.IsActive))}";
                    fluxuateButton.Click += FluxuateButton_Clicked;
                }
                else fluxuateButton.HoverText = "";
                fluxuateButton.extraButtonColor = (resourceManager.GetCubes() >= 1e7) ? new Color(136, 252, 252) : new Color(42, 42, 42);
                expoNumeration = new BigNumber(resourceManager.GetFlux());
                fluxLabel.Text = $"FLUX: {expoNumeration.ToString()}";
                fluxLabel.TextColor = new Color(136, 252, 252);
            }
            else
            {
                fluxuateButton.Text = "";
                fluxuateButton.ButtonTexture = EmptyTexture;
                fluxuateButton.HoverText = "";
            }
            
            if (cubeAmountAch9.IsUnlocked)
            {
                UpdateHoverText2();
                ritualButton.Text = "RITUAL";
                ritualButton.ButtonTexture = ButtonTexture;
                if (_confirmationPopup == null)
                {
                    if(fluxuateFromRitual)
                    {
                        ritualButton.HoverText = $"[c:88c2fc]Cubes Needed: {new BigNumber(resourceManager.GetCubes())} / 1e20 \n[c:fc8888]Prisms Gained: {new BigNumber(resourceManager.CalculatePrism(resourceManager.GetCubes()))} \n[c:88fcfc]Flux Gained: {new BigNumber(resourceManager.CalculateFlux(resourceManager.GetCubes(), fluxUpgrade7.IsActive))}";
                    }
                    else ritualButton.HoverText = $"[c:88c2fc]Cubes Needed: {new BigNumber(resourceManager.GetCubes())} / 1e20 \n[c:fc8888]Prisms Gained: {new BigNumber(resourceManager.CalculatePrism(resourceManager.GetCubes()))}";
              

                    ritualButton.Click += RitualButton_Clicked;
                }
                else ritualButton.HoverText = "";
                ritualButton.extraButtonColor = (resourceManager.GetCubes() >= 1e20) ? new Color(252, 136, 136) : new Color(42, 42, 42);
                expoNumeration = new BigNumber(resourceManager.GetPrism());
                prismLabel.Text = $"PRISMS: {expoNumeration.ToString()}";
                prismLabel.TextColor = new Color(252, 136, 136);
            }
            else
            {
                ritualButton.Text = "";
                ritualButton.ButtonTexture = EmptyTexture;
                ritualButton.HoverText = "";
            }

            if (_confirmationPopup != null)
            {
                MouseState mouseState = Mouse.GetState();
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    _confirmationPopup.HandleMouseClick(new Point(mouseState.X, mouseState.Y));
                }
            }

            // Auto-buy for cubeProducer
            if (autoProducers.IsActive && _prodAutoBuyEnabled)
            {
                int purchaseCount = autoProducersBoost.IsActive ? 10 : 1;
                AutoBuyCubeGenerators(purchaseCount, cubeProducer);
            }

            // Auto-buy for cubeArchitect
            if (autoArchitects.IsActive && _archAutoBuyEnabled)
            {
                int purchaseCount = autoArchitectsBoost.IsActive ? 10 : 1;
                AutoBuyCubeGenerators(purchaseCount, cubeArchitect);
            }

            // Auto-buy for cubeEngineer
            if (autoEngineers.IsActive && _engiAutoBuyEnabled)
            {
                int purchaseCount = autoEngineersBoost.IsActive ? 10 : 1;
                AutoBuyCubeGenerators(purchaseCount, cubeEngineer);
            }

            // Auto-buy for cubeVisionary
            if (autoVisionary.IsActive && cubeAmountAch6.IsUnlocked && _visAutoBuyEnabled)
            {
                int purchaseCount = autoVisionaryBoost.IsActive ? 10 : 1;
                AutoBuyCubeGenerators(purchaseCount, cubeVisionary);
            }

            // Auto-buy for cubeOmni
            if (autoOmni.IsActive && cubeAmountAch8.IsUnlocked && _omniAutoBuyEnabled)
            {
                int purchaseCount = autoOmniBoost.IsActive ? 10 : 1;
                AutoBuyCubeGenerators(purchaseCount, cubeOmni);
            }

            // Auto-buy for primer
            if (autoPrimer.IsActive && fluxuateAmountAch1.IsUnlocked && _primerAutoBuyEnabled)
            {             
                int purchaseCount = autoPrimerBoost.IsActive ? 10 : 1;
                AutoBuyFluxStuff(purchaseCount, primer);
            }

            // Auto-buy for overcharger
            if (autoOvercharger.IsActive && fluxuateAmountAch1.IsUnlocked && _overchargerAutoBuyEnabled)
            {
                int purchaseCount = autoOverchargerBoost.IsActive ? 10 : 1;
                AutoBuyFluxStuff(purchaseCount, overcharger);
            }   

            if (fluxuateAmountAch4.IsUnlocked)
            {
                _fluxuateAutoButton.HoverText = "Fluxuates immediately when conditions are met!";
                if (_fluxuateAutoEnabled)
                {
                    _fluxAutoUpdateTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (_fluxAutoUpdateTime >= _fluxAutoUpdateInterval)
                    {
                        if (resourceManager.CalculateFlux(resourceManager.GetCubes(), fluxUpgrade7.IsActive) >= 1.0000001)
                        {
                            resourceManager.Fluxuate();
                        }
                        _fluxAutoUpdateTime = 0f;
                    }
                }
            }

            if (ritualAmountAch4.IsUnlocked)
            {
                _ritualAutoButton.HoverText = "Conducts a Ritual immediately when conditions are met!";
                if (_ritualAutoEnabled)
                {                    
                    _ritualAutoUpdateTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                    if (_ritualAutoUpdateTime >= _ritualAutoUpdateInterval)
                    {
                        if (resourceManager.CalculatePrism(resourceManager.GetCubes()) >= 1.0000001)
                        {
                            resourceManager.Ritual();
                        }
                        _ritualAutoUpdateTime = 0f;
                    }
                    
                }
            }
            
            _achievementPopup.Update(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            base.Update(gameTime);
        }

        private void AutoBuyCubeGenerators(int purchaseCount, CubeGenerator generator)
        {
            for (int i = 0; i < purchaseCount; i++)
            {
                if (generator.CanAffordAuto(resourceManager.GetCubes()))
                {
                    resourceManager.RemoveCubes(generator.CalculateTotalCost(1));
                    generator.Buy(1);
                }
                else break;
                
            }
        }
        private void AutoBuyFluxStuff(int purchaseCount, FluxStuff fluxStuff)
        {
            for (int i = 0; i < purchaseCount; i++)
            {
                if (fluxStuff.CanAffordAuto(resourceManager.GetFlux()))
                {
                    resourceManager.RemoveFlux(fluxStuff.CalculateTotalCost(1));
                    fluxStuff.Buy(1);
                }
                else break;    
            }
        }
        private void AchievementUpdate(GameTime gameTime)
        {       
            UpdateHoverText();
            UpdateAchievementButton(cubeAmountAch1Button, cubeAmountAch1, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch2Button, cubeAmountAch2, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch3Button, cubeAmountAch3, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch4Button, cubeAmountAch4, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountFluxUnlockButton, cubeAmountFluxUnlock, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch6Button, cubeAmountAch6, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch7Button, cubeAmountAch7, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch8Button, cubeAmountAch8, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));

            UpdateAchievementButton(fluxuateAmountAch1Button, fluxuateAmountAch1, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch2Button, fluxuateAmountAch2, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch3Button, fluxuateAmountAch3, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch4Button, fluxuateAmountAch4, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch5Button, fluxuateAmountAch5, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch6Button, fluxuateAmountAch6, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));

            UpdateAchievementButton(cubeAmountAch9Button, cubeAmountAch9, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch10Button, cubeAmountAch10, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));

            UpdateAchievementButton(ritualAmountAch1Button, ritualAmountAch1, AchievementTexture, Content.Load<Texture2D>("UI/PrismTexture"));
            UpdateAchievementButton(ritualAmountAch2Button, ritualAmountAch2, AchievementTexture, Content.Load<Texture2D>("UI/PrismTexture"));
            UpdateAchievementButton(ritualAmountAch3Button, ritualAmountAch3, AchievementTexture, Content.Load<Texture2D>("UI/PrismTexture"));
            UpdateAchievementButton(ritualAmountAch4Button, ritualAmountAch4, AchievementTexture, Content.Load<Texture2D>("UI/PrismTexture"));
            UpdateAchievementButton(ritualAmountAch5Button, ritualAmountAch5, AchievementTexture, Content.Load<Texture2D>("UI/PrismTexture"));
            UpdateAchievementButton(ritualAmountAch6Button, ritualAmountAch6, AchievementTexture, Content.Load<Texture2D>("UI/PrismTexture"));

            UpdateAchievementButton(cubeAmountAch11Button, cubeAmountAch11, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch12Button, cubeAmountAch12, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch13Button, cubeAmountAch13, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch14Button, cubeAmountAch14, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch15Button, cubeAmountAch15, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch16Button, cubeAmountAch16, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));
            UpdateAchievementButton(cubeAmountAch17Button, cubeAmountAch17, AchievementTexture, Content.Load<Texture2D>("UI/CubeTexture"));

            UpdateAchievementButton(fluxuateAmountAch7Button, fluxuateAmountAch7, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch8Button, fluxuateAmountAch8, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch9Button, fluxuateAmountAch9, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch10Button, fluxuateAmountAch10, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch11Button, fluxuateAmountAch11, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));
            UpdateAchievementButton(fluxuateAmountAch12Button, fluxuateAmountAch12, AchievementTexture, Content.Load<Texture2D>("UI/FluxTexture"));

            UpdateAchievementButton(ritualAmountAch7Button, ritualAmountAch7, AchievementTexture, Content.Load<Texture2D>("UI/PrismTexture"));
           
            UpdateAchievementButton(fractalAmountAch1Button, fractalAmountAch1, AchievementTexture, Content.Load<Texture2D>("UI/FractalTexture"));
            UpdateAchievementButton(fractalAmountAch2Button, fractalAmountAch2, AchievementTexture, Content.Load<Texture2D>("UI/FractalTexture"));
            UpdateAchievementButton(fractalAmountAch3Button, fractalAmountAch3, AchievementTexture, Content.Load<Texture2D>("UI/FractalTexture"));
            UpdateAchievementButton(fractalAmountAch4Button, fractalAmountAch4, AchievementTexture, Content.Load<Texture2D>("UI/FractalTexture"));
            UpdateAchievementButton(fractalAmountAch5Button, fractalAmountAch5, AchievementTexture, Content.Load<Texture2D>("UI/FractalTexture"));

        }
        private void UpdateAchievementButton(UIAchievementButton btn, Achievement ach, Texture2D tex, Texture2D icn)
        {
            if (_confirmationPopup == null)
            {
                if (!ach.IsUnlocked)
                {
                    Func<bool> unlockCriteria = _achievementCriteria[ach.Name];
                    ach.CheckIfUnlocked(unlockCriteria);
                    if (ach.IsUnlocked)
                    {
                        ach.HexCode = "88fcc2";
                    }
                    else ach.HexCode = "fc8888";               
                }

                if (isAchievementSectionOpen)
                {
                    btn.ButtonTexture = tex;
                    btn.Icon = icn;
                    btn.HoverText = $"[c:fcfc88]{ach.Name} \n \n[c:{ach.HexCode}]{ach.Requirement} {ach.RewardDescription}";
                    btn.extraButtonColor = ach.IsUnlocked ? new Color(252, 252, 136) : new Color(42, 42, 42);
                }
                else
                {
                    btn.ButtonTexture = EmptyTexture;
                    btn.Icon = EmptyTexture;
                    btn.HoverText = "";
                }
            }
        }
        private void UpdateUpgradeButton(UIUpgradeButton btn, Upgrade upg, Texture2D tex, Texture2D icn, int currencyType, bool isUnlocked)
        {
            if (_confirmationPopup == null)
            {
                if (isUnlocked)
                {
                    if (isUpgradeSectionOpen)
                    {
                        btn.ButtonTexture = tex;
                        btn.Icon = icn;
                        BigNumber expoNum = new BigNumber(upg.Cost);
                        if (currencyType == 0)
                        {
                            btn.HoverText = $"{upg.Name} \n \n[c:88c2fc]Costs {expoNum.ToString()} Cubes";
                            btn.extraButtonColor = upg.IsActive ? new Color(50, 199, 45) : (upg.CanAfford(resourceManager.GetCubes()) ? new Color(160, 160, 160) : new Color(42, 42, 42));
                        }
                        if (currencyType == 1)
                        {
                            btn.HoverText = $"{upg.Name} \n \n[c:88fcfc]Costs {expoNum.ToString()} Flux \n[c:c288fc]Not reset by Fluxuations";
                            btn.extraButtonColor = upg.IsActive ? new Color(50, 199, 45) : (upg.CanAfford(resourceManager.GetFlux()) ? new Color(160, 160, 160) : new Color(42, 42, 42));
                        }
                        if (currencyType == 2)
                        {
                            btn.HoverText = $"{upg.Name} \n \n[c:fc8888]Costs {expoNum.ToString()} Prisms \n[c:c288fc]Not reset by Fluxuations and Rituals";
                            btn.extraButtonColor = upg.IsActive ? new Color(50, 199, 45) : (upg.CanAfford(resourceManager.GetPrism()) ? new Color(160, 160, 160) : new Color(42, 42, 42));
                        }
                        if (currencyType == 3)
                        {
                            btn.HoverText = $"{upg.Name} \n \n[c:d54967]Costs {expoNum.ToString()} Fractals \n[c:c288fc]Not reset by Fluxuations and Rituals";
                            btn.extraButtonColor = upg.IsActive ? new Color(50, 199, 45) : (upg.CanAfford(resourceManager.GetFractals()) ? new Color(160, 160, 160) : new Color(42, 42, 42));
                        }

                    }
                    else
                    {
                        btn.ButtonTexture = EmptyTexture;
                        btn.Icon = EmptyTexture;
                        btn.HoverText = "";
                    }
                }
                else
                {
                    btn.ButtonTexture = EmptyTexture;
                    btn.Icon = EmptyTexture;
                    btn.HoverText = "";
                }
            }
        } 
        private void UpdateFractalUpgradeButton(UIUpgradeButton btn, Upgrade upg, Texture2D tex, Texture2D icn, int currencyType, bool isUnlocked)
        {
            if (_confirmationPopup == null)
            {
                if (isUnlocked)
                {
                    if (isFractalGeneratorsSectionOpen)
                    {
                        btn.ButtonTexture = tex;
                        btn.Icon = icn;
                        BigNumber expoNum = new BigNumber(upg.Cost);
                        if (currencyType == 0)
                        {
                            btn.HoverText = $"{upg.Name} \n \n[c:88c2fc]Costs {expoNum.ToString()} Cubes";
                            btn.extraButtonColor = upg.IsActive ? new Color(50, 199, 45) : (upg.CanAfford(resourceManager.GetCubes()) ? new Color(160, 160, 160) : new Color(42, 42, 42));
                        }
                        if (currencyType == 1)
                        {
                            btn.HoverText = $"{upg.Name} \n \n[c:88fcfc]Costs {expoNum.ToString()} Flux \n[c:c288fc]Not reset by Fluxuations";
                            btn.extraButtonColor = upg.IsActive ? new Color(50, 199, 45) : (upg.CanAfford(resourceManager.GetFlux()) ? new Color(160, 160, 160) : new Color(42, 42, 42));
                        }
                        if (currencyType == 2)
                        {
                            btn.HoverText = $"{upg.Name} \n \n[c:fc8888]Costs {expoNum.ToString()} Prisms \n[c:c288fc]Not reset by Fluxuations and Rituals";
                            btn.extraButtonColor = upg.IsActive ? new Color(50, 199, 45) : (upg.CanAfford(resourceManager.GetPrism()) ? new Color(160, 160, 160) : new Color(42, 42, 42));
                        }
                        if (currencyType == 3)
                        {
                            btn.HoverText = $"{upg.Name} \n \n[c:d54967]Costs {expoNum.ToString()} Fractals \n[c:c288fc]Not reset by Fluxuations and Rituals";
                            btn.extraButtonColor = upg.IsActive ? new Color(50, 199, 45) : (upg.CanAfford(resourceManager.GetFractals()) ? new Color(160, 160, 160) : new Color(42, 42, 42));
                        }

                    }
                    else
                    {
                        btn.ButtonTexture = EmptyTexture;
                        btn.Icon = EmptyTexture;
                        btn.HoverText = "";
                    }
                }
                else
                {
                    btn.ButtonTexture = EmptyTexture;
                    btn.Icon = EmptyTexture;
                    btn.HoverText = "";
                }
            }
        }
        private void UpdateHoverText()
        {
            if (_confirmationPopup == null)
            {
                if (isUpgradeSectionOpen)
                {
                    currentHoverText = new List<UIHoverableButton>
                    {
                        prodUpgrade1Button, archUpgrade1Button, engiUpgrade1Button,
                        prodMultiFromArchButton, prodMultiFromArchMultiButton, allCubeMultiUpButton,
                        archMultiFromEngiButton, cube10GenToMultiButton, prod5MultiButton,
                        arch5MultiButton, engi5MultiButton, archMultiFromEngiMultiButton,
                        prodSaleUpgradeButton, archSaleUpgradeButton, engiSaleUpgradeButton,
                        engiMultiFromProdButton, cube10GenToSaleButton, cube50ProdToProdMultButton,
                        visMultFromProdButton, visMultFromArchButton, visMultFromEngiButton,
                        visBaseMultUpButton, threeMultiUpFromVisButton, prodFromPrimerButton,
                        archFromPrimerButton, engiFromPrimerButton, visFromOverchargerButton,
                        omniFromOverchargerButton, baseOmniMultiUpButton, allGen100ToOmniMultButton,
                        autoProducersButton, autoArchitectsButton, autoEngineersButton, autoVisionaryButton,
                        autoOmniButton, fluxUpgrade1Button, fluxUpgrade2Button, fluxUpgrade3Button, 
                        fluxUpgrade4Button, fluxUpgrade5Button, fluxUpgrade6Button, fluxUpgrade7Button,
                        fluxUpgrade8Button, fluxUpgrade9Button, cubeFinalUpgrade1Button, cubeFinalUpgrade2Button, 
                        prismUpgrade1Button, prismUpgrade2Button, prismUpgrade3Button, prismUpgrade4Button, prismUpgrade5Button, prismUpgrade6Button, 
                        prismUpgrade7Button, prismUpgrade8Button, prismUpgrade9Button, autoPrimerButton, autoOverchargerButton,
                        prismUpgrade10Button, prismUpgrade11Button, prismUpgrade12Button, prismUpgrade13Button, prismUpgrade14Button, 
                        trueFinalCubeUpgradeButton, autoProducersBoostButton, autoArchitectsBoostButton, autoEngineersBoostButton, autoVisionaryBoostButton,
                        autoOmniBoostButton, autoPrimerBoostButton, autoOverchargerBoostButton, prismUpgrade15Button,
                        prismUpgrade16Button, prismUpgrade17Button, prismUpgrade18Button, prismUpgrade19Button,
                        
                    }
                    .FirstOrDefault(btn => btn._isHovering)?.HoverText ?? "";
                }
                else if(isAchievementSectionOpen)
                {
                    currentHoverText = new List<UIHoverableButton>
                    {
                        cubeAmountAch1Button, cubeAmountAch2Button, cubeAmountAch3Button, cubeAmountAch4Button,
                        cubeAmountFluxUnlockButton, cubeAmountAch6Button, cubeAmountAch7Button, cubeAmountAch8Button,
                        fluxuateAmountAch1Button, fluxuateAmountAch2Button, fluxuateAmountAch3Button, fluxuateAmountAch4Button,
                        fluxuateAmountAch5Button, fluxuateAmountAch6Button, cubeAmountAch9Button, cubeAmountAch10Button,
                        ritualAmountAch1Button, ritualAmountAch2Button, ritualAmountAch3Button, ritualAmountAch4Button,
                        ritualAmountAch5Button, ritualAmountAch6Button, cubeAmountAch11Button, cubeAmountAch12Button,
                        cubeAmountAch13Button, cubeAmountAch14Button, cubeAmountAch15Button, cubeAmountAch16Button,
                        cubeAmountAch17Button, fluxuateAmountAch7Button, fluxuateAmountAch8Button, fluxuateAmountAch9Button,
                        fluxuateAmountAch10Button, fluxuateAmountAch11Button, fluxuateAmountAch12Button, ritualAmountAch7Button,
                        fractalAmountAch1Button, fractalAmountAch2Button, fractalAmountAch3Button, fractalAmountAch4Button,
                        fractalAmountAch5Button, 
                    }
                    .FirstOrDefault(btn => btn._isHovering)?.HoverText ?? "";
                }
                else if(isFractalGeneratorsSectionOpen)
                {
                    currentHoverText = new List<UIHoverableButton>
                    {
                        fractalUpgrade1Button, fractalUpgrade2Button, fractalUpgrade3Button, fractalUpgrade4Button, fractalUpgrade5Button,
                        fractalUpgrade6Button, fractalUpgrade7Button, fractalUpgrade8Button, fractalUpgrade9Button, fractalUpgrade10Button,
                        fractalUpgrade11Button, fractalUpgrade12Button, fractalUpgrade13Button, fractalUpgrade14Button, fractalUpgrade15Button,

                    }
                    .FirstOrDefault(btn => btn._isHovering)?.HoverText ?? "";
                }
            }
        }
        private void UpdateHoverText2()
        {
            currentFluxHoverText = new List<UIHoverableButton> { fluxuateButton, _fluxuateAutoButton, ritualButton, _ritualAutoButton }.FirstOrDefault(btn => btn._isHovering)?.HoverText ?? "";
        }

        private void PrimerUpdate(GameTime gameTime)
        {
            int maxBuyable = primer.CalculateMaxBuyable(resourceManager.GetFlux(), _basePrimerCostMulti);
            double fluxTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {
                if (primer.CanAfford(resourceManager.GetFlux()))
                {
                    primerButton.extraButtonColor = new Color(44, 80, 190);
                }
                else
                {
                    primerButton.extraButtonColor = new Color(36, 36, 36);
                }

                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    fluxTotalCost += (primer.CurrentCost * Math.Pow((1 + primer.CostIncrease), i));
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    primerButton.extraButtonColor = new Color(44, 80, 190);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        fluxTotalCost += (primer.CurrentCost * Math.Pow((1 + primer.CostIncrease), i));
                    }
                }
                else
                {
                    primerButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        fluxTotalCost += (primer.CurrentCost * Math.Pow((1 + primer.CostIncrease), i));
                    }
                }
            }
            if (isCubeGeneratorsSectionOpen)
            {
                if (fluxuateAmountAch1.IsUnlocked)
                {
                    primerButton.ButtonTexture = BuyButtonTexture;
                    expoNumeration = new BigNumber(fluxTotalCost);
                    primerButton.Text = $"Cost: {expoNumeration.ToString()} Flux";
                }
                else
                {
                    primerButton.ButtonTexture = EmptyTexture;
                    primerButton.Text = "";
                }
            }
            else
            {
                primerButton.ButtonTexture = EmptyTexture;
                primerButton.Text = "";
            }
        }
        private void OverchargerUpdate(GameTime gameTime)
        {
            int maxBuyable = overcharger.CalculateMaxBuyable(resourceManager.GetFlux(), _baseOverchargerCostMulti);
            double fluxTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {
                if (overcharger.CanAfford(resourceManager.GetFlux()))
                {
                    overchargerButton.extraButtonColor = new Color(44, 80, 190);
                }
                else
                {
                    overchargerButton.extraButtonColor = new Color(36, 36, 36);
                }

                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    fluxTotalCost += (overcharger.CurrentCost * Math.Pow((1 + overcharger.CostIncrease), i));
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    overchargerButton.extraButtonColor = new Color(44, 80, 190);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        fluxTotalCost += (overcharger.CurrentCost * Math.Pow((1 + overcharger.CostIncrease), i));
                    }
                }
                else
                {
                    overchargerButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        fluxTotalCost += (overcharger.CurrentCost * Math.Pow((1 + overcharger.CostIncrease), i));
                    }
                }
            }

            if (isCubeGeneratorsSectionOpen)
            {
                if (fluxuateAmountAch2.IsUnlocked)
                {
                    overchargerButton.ButtonTexture = BuyButtonTexture;
                    expoNumeration = new BigNumber(fluxTotalCost);
                    overchargerButton.Text = $"Cost: {expoNumeration.ToString()} Flux";
                }
                else
                {
                    overchargerButton.ButtonTexture = EmptyTexture;
                    overchargerButton.Text = "";
                }
            }
            else
            {
                overchargerButton.ButtonTexture = EmptyTexture;
                overchargerButton.Text = "";
            }
        }

        #region shit for Upgrades
        public static int _prevProdCount;
        public static int _prevProdCount2;
        public static int _prevProdCount3;
        public static int _prevArchCount;
        public static int _prevArchCount2;
        public static int _prevEngiCount;
        public static int _prevEngiCount2;
        public static int _prevVisCount;
        public static int _prevPrimerLevel;
        public static int _prevPrimerLevel2;
        public static int _prevPrimerLevel3;
        public static int _prevOverchargerLevel;
        public static int _prevOverchargerLevel2;
        public static double _crossFunctionalOmni = 1.0;
        public static double _crossFunctionalContribution = 1.0;
        public static double _crossFunctionalContribution2 = 1.0;
        public static double _crossFunctionalContribution3 = 1.0;
        public static double _crossFunctionalContribution4 = 1.0;
        public static double _architectMultiplierContribution = 1.0;
        public static double _architectContribution = 1.0;
        public static double _engineerMultiplierContribution = 1.0;
        public static double _visionaryMultiplierContribution = 1.0;

        public static double _previousArchitectMultiplier;
        public static double _previousVisionaryMultiplier;
        public static double _previousEngineerMultiplier;

        public static double _prevOverchargerLevel3;
        public static double _prevPrimerLevel4;
        public static double _prevPrimerQuantity;
        public static double _prevOverchargerQuantity;
        #endregion
        private void CubeUpgradeUpdate(GameTime gameTime)
        {
            if (cubeAmountAch7.IsUnlocked) // If New Upgrades Post-Visionary Pre-Omnificent Unlocked
            {
                if (threeMultiUpFromVis.IsActive)
                {
                    double visMultiplier = 0.5 * cubeVisionary.Quantity;
                    cubeProducer.CubeMultiplier = _baseProducerMultiplier + visMultiplier;
                    cubeArchitect.CubeMultiplier = _baseArchitectMultiplier + visMultiplier;
                    cubeEngineer.CubeMultiplier = _baseEngineerMultiplier + visMultiplier;
                }        
                if (prodFromPrimer.IsActive)
                {
                    double primerDiff = primer.Quantity - _prevPrimerQuantity;
                    cubeProducer.Quantity += primerDiff;
                    _prevPrimerQuantity = primer.Quantity;
                }
                if (archFromPrimer.IsActive)
                {
                    double primerDiff = primer.Quantity - _prevPrimerQuantity;
                    cubeArchitect.Quantity += primerDiff / 2;
                    _prevPrimerQuantity = primer.Quantity;
                }
                if (engiFromPrimer.IsActive)
                {
                    double primerDiff = primer.Quantity - _prevPrimerQuantity;
                    cubeEngineer.Quantity += primerDiff / 3;
                    _prevPrimerQuantity = primer.Quantity;
                }
                if (visFromOvercharger.IsActive)
                {
                    double overchargerDiff = overcharger.Quantity - _prevOverchargerQuantity;
                    cubeVisionary.Quantity += overchargerDiff;
                    _prevOverchargerQuantity = overcharger.Quantity;
                }
            } 
            if(cubeAmountAch8.IsUnlocked) // If Omnificent Unlocked
            {
                if (omniFromOvercharger.IsActive)
                {
                    double overchargerDiff = overcharger.Quantity - _prevOverchargerQuantity;
                    cubeOmni.Quantity += overchargerDiff / 2;
                    _prevOverchargerQuantity = overcharger.Quantity;
                }
                if (allGen100ToOmniMult.IsActive) 
                {
                    double currentVisionaryMultiplier = cubeVisionary.CubeMultiplier;
                    if (_previousVisionaryMultiplier != currentVisionaryMultiplier)
                    {
                        // Calculate the difference between the current and previous architect multipliers
                        double multiplierDifference = currentVisionaryMultiplier - _previousVisionaryMultiplier;

                        // Update the cubeProducer multiplier by adding the multiplier difference
                        _baseOmniMultiplier += multiplierDifference;
                        cubeOmni.CubeMultiplier += multiplierDifference;

                        // Update the previous architect multiplier
                        _previousVisionaryMultiplier = currentVisionaryMultiplier;
                    }
                }
            }        
            if (cubeAmountAch13.IsUnlocked) // If 1e100
            {
                if (trueFinalCubeUpgrade.IsActive)
                {
                    double prodMultiplier = 5 * cubeProducer.Quantity;
                    cubeProducer.CubeMultiplier = _baseProducerMultiplier + prodMultiplier;
                    cubeArchitect.CubeMultiplier = _baseArchitectMultiplier + prodMultiplier;
                    cubeEngineer.CubeMultiplier = _baseEngineerMultiplier + prodMultiplier;
                    cubeVisionary.CubeMultiplier = _baseVisionaryMultiplier + prodMultiplier;
                    cubeOmni.CubeMultiplier = _baseOmniMultiplier + prodMultiplier;
                }
            }
            if (cubeAmountAch6.IsUnlocked) // If Visionary Unlocked
            {
                if (visMultFromProd.IsActive)
                {
                    double prodMultiplier = 0.25 * cubeProducer.Quantity;
                    cubeVisionary.CubeMultiplier = _baseVisionaryMultiplier + prodMultiplier;
                }
                if (visMultFromArch.IsActive)
                {
                    double archMultiplier = 0.75 * cubeArchitect.Quantity;
                    cubeVisionary.CubeMultiplier += archMultiplier;
                }
                if (visMultFromEngi.IsActive)
                {
                    double engiMultiplier = 1.25 * cubeEngineer.Quantity;
                    cubeVisionary.CubeMultiplier += engiMultiplier;
                }
            }          
            if (prodMultiFromArch.IsActive)
            {
                double architectMultiplier = 0.05 * cubeArchitect.Quantity;
                cubeProducer.CubeMultiplier = _baseProducerMultiplier + architectMultiplier;
            }

            if (prodMultiFromArchMulti.IsActive)
            {
                double currentArchitectMultiplier = cubeArchitect.CubeMultiplier;

                if (_previousArchitectMultiplier != currentArchitectMultiplier)
                {
                    // Calculate the difference between the current and previous architect multipliers
                    double multiplierDifference = currentArchitectMultiplier - _previousArchitectMultiplier;

                    // Update the cubeProducer multiplier by adding the multiplier difference
                    _baseProducerMultiplier += multiplierDifference;
                    cubeProducer.CubeMultiplier += multiplierDifference;

                    // Update the previous architect multiplier
                    _previousArchitectMultiplier = currentArchitectMultiplier;
                }
                
            }
            if (archMultiFromEngi.IsActive)
            {
                double engiMultiplier = 0.1 * cubeEngineer.Quantity;
                cubeArchitect.CubeMultiplier = _baseArchitectMultiplier + engiMultiplier;
            }
            if (cube10GenToMulti.IsActive) // Every 5 Producers, Architects and Engineers, add 5% to all cube generators(Producer, Architect and Engineer)
            {
                double minNumberOfUnits = Math.Min(cubeProducer.Quantity, Math.Min(cubeArchitect.Quantity, cubeEngineer.Quantity));
                double setsOfTen = minNumberOfUnits / 5;
                double newCrossFunctionalContribution = 1 + (0.05 * setsOfTen);

                if (setsOfTen > 0 && _crossFunctionalContribution != newCrossFunctionalContribution)
                {
                    double scaleFactor = newCrossFunctionalContribution / _crossFunctionalContribution;
                    _crossFunctionalContribution = newCrossFunctionalContribution;

                    _baseProducerMultiplier *= scaleFactor;
                    cubeProducer.CubeMultiplier *= scaleFactor;

                    _baseArchitectMultiplier *= scaleFactor;
                    cubeArchitect.CubeMultiplier *= scaleFactor;

                    _baseEngineerMultiplier *= scaleFactor;
                    cubeEngineer.CubeMultiplier *= scaleFactor;
                }
            }
            if (archMultiFromEngiMulti.IsActive)
            {
                double currentEngineerMultiplier = cubeEngineer.CubeMultiplier;
                if (_previousEngineerMultiplier != currentEngineerMultiplier)
                {
                    // Calculate the difference between the current and previous architect multipliers
                    double multiplierDifference = currentEngineerMultiplier - _previousEngineerMultiplier;

                    // Update the cubeProducer multiplier by adding the multiplier difference
                    _baseArchitectMultiplier += multiplierDifference;
                    cubeArchitect.CubeMultiplier += multiplierDifference;

                    // Update the previous architect multiplier
                    _previousEngineerMultiplier = currentEngineerMultiplier;
                }
            }
            if (engiMultiFromProd.IsActive)
            {
                double prodMultiplier = 0.15 * cubeProducer.Quantity;
                cubeEngineer.CubeMultiplier = _baseEngineerMultiplier + prodMultiplier;
            }

            if (cube10GenToSale.IsActive) // Every 25 Producers, Architects, and Engineers, reduce the cost of all cube generators by 3%
            {
                double minNumberOfUnits = Math.Min(cubeProducer.Quantity, Math.Min(cubeArchitect.Quantity, cubeEngineer.Quantity));
                double setsOfTwentyFive = minNumberOfUnits / 25;
                double newCrossFunctionalContribution = Math.Pow(0.97, setsOfTwentyFive);

                if (setsOfTwentyFive > 0 && _crossFunctionalContribution2 != newCrossFunctionalContribution)
                {
                    double scaleFactor = newCrossFunctionalContribution / _crossFunctionalContribution2;
                    _crossFunctionalContribution2 = newCrossFunctionalContribution;

                    _baseProducerCostMulti *= scaleFactor;
                    cubeProducer.CurrentCost *= scaleFactor;

                    _baseArchitectCostMulti *= scaleFactor;
                    cubeArchitect.CurrentCost *= scaleFactor;

                    _baseEngineerCostMulti *= scaleFactor;
                    cubeEngineer.CurrentCost *= scaleFactor;
                }
            }
            if (cube50ProdToProdMult.IsActive) // Every 50 producers, increase Engineers base multiplier by 25%
            {
                double minNumberOfUnits = cubeProducer.Quantity;
                double setsOfFifty = minNumberOfUnits / 50;
                double newCrossFunctionalContribution = 1 + (5 * setsOfFifty);

                if (setsOfFifty > 0 && _crossFunctionalContribution3 != newCrossFunctionalContribution)
                {
                    double scaleFactor = newCrossFunctionalContribution / _crossFunctionalContribution3;
                    _crossFunctionalContribution3 = newCrossFunctionalContribution;
                    _baseProducerMultiplier += scaleFactor;
                    cubeProducer.CubeMultiplier *= scaleFactor;
                }
            }

            UpdateHoverText();
            UpdateUpgradeButton(prodUpgrade1Button, prodUpgrade1, UpgradeTexture, BaseCubeUpgradeIcon, 0, true);
            UpdateUpgradeButton(archUpgrade1Button, archUpgrade1, UpgradeTexture, BaseCubeUpgradeIcon, 0, true);
            UpdateUpgradeButton(engiUpgrade1Button, engiUpgrade1, UpgradeTexture, BaseCubeUpgradeIcon, 0, true);
            UpdateUpgradeButton(prodMultiFromArchButton, prodMultiFromArch, UpgradeTexture, CubeUpgradeRecycleIcon, 0, true);
            UpdateUpgradeButton(prodMultiFromArchMultiButton, prodMultiFromArchMulti, UpgradeTexture, CubeUpgradeRecycleIcon, 0, true);
            UpdateUpgradeButton(allCubeMultiUpButton, allCubeMultiUp, UpgradeTexture, BaseCubeUpgradeIcon, 0, true);
            UpdateUpgradeButton(archMultiFromEngiButton, archMultiFromEngi, UpgradeTexture, CubeUpgradeRecycleIcon, 0, true);
            UpdateUpgradeButton(cube10GenToMultiButton, cube10GenToMulti, UpgradeTexture, MultiCubeUpgradeIcon, 0, true);
            UpdateUpgradeButton(prod5MultiButton, prod5Multi, UpgradeTexture, BaseCubeUpgradeIcon, 0, true);
            UpdateUpgradeButton(arch5MultiButton, arch5Multi, UpgradeTexture, BaseCubeUpgradeIcon, 0, true);
            UpdateUpgradeButton(engi5MultiButton, engi5Multi, UpgradeTexture, BaseCubeUpgradeIcon, 0, true);
            UpdateUpgradeButton(archMultiFromEngiMultiButton, archMultiFromEngiMulti, UpgradeTexture, CubeUpgradeRecycleIcon, 0, true);
            UpdateUpgradeButton(prodSaleUpgradeButton, prodSaleUpgrade, UpgradeTexture, CubeUpgradeSaleIcon, 0, true);
            UpdateUpgradeButton(archSaleUpgradeButton, archSaleUpgrade, UpgradeTexture, CubeUpgradeSaleIcon, 0, true);
            UpdateUpgradeButton(engiSaleUpgradeButton, engiSaleUpgrade, UpgradeTexture, CubeUpgradeSaleIcon, 0, true);
            UpdateUpgradeButton(engiMultiFromProdButton, engiMultiFromProd, UpgradeTexture, CubeUpgradeRecycleIcon, 0, true);          
            UpdateUpgradeButton(cube50ProdToProdMultButton, cube50ProdToProdMult, UpgradeTexture, CubeUpgradeRecycleIcon, 0, true);

            
            UpdateUpgradeButton(cube10GenToSaleButton, cube10GenToSale, UpgradeTexture, MultiCubeSaleIcon, 0, cubeAmountAch6.IsUnlocked);
            UpdateUpgradeButton(visMultFromProdButton, visMultFromProd, UpgradeTexture, CubeUpgradeRecycleIcon, 0, cubeAmountAch6.IsUnlocked);
            UpdateUpgradeButton(visMultFromArchButton, visMultFromArch, UpgradeTexture, CubeUpgradeRecycleIcon, 0, cubeAmountAch6.IsUnlocked);
            UpdateUpgradeButton(visMultFromEngiButton, visMultFromEngi, UpgradeTexture, CubeUpgradeRecycleIcon, 0, cubeAmountAch6.IsUnlocked);
            UpdateUpgradeButton(visBaseMultUpButton, visBaseMultUp, UpgradeTexture, BaseCubeUpgradeIcon, 0, cubeAmountAch6.IsUnlocked);
           
            UpdateUpgradeButton(threeMultiUpFromVisButton, threeMultiUpFromVis, UpgradeTexture, BaseCubeUpgradeIcon, 0, cubeAmountAch7.IsUnlocked);
            UpdateUpgradeButton(prodFromPrimerButton, prodFromPrimer, UpgradeTexture, CubeUpgradeRecycleIcon, 0, cubeAmountAch7.IsUnlocked);
            UpdateUpgradeButton(archFromPrimerButton, archFromPrimer, UpgradeTexture, CubeUpgradeRecycleIcon, 0, cubeAmountAch7.IsUnlocked);
            UpdateUpgradeButton(engiFromPrimerButton, engiFromPrimer, UpgradeTexture, CubeUpgradeRecycleIcon, 0, cubeAmountAch7.IsUnlocked);
            UpdateUpgradeButton(visFromOverchargerButton, visFromOvercharger, UpgradeTexture, CubeUpgradeRecycleIcon, 0, cubeAmountAch7.IsUnlocked);      
            
            UpdateUpgradeButton(omniFromOverchargerButton, omniFromOvercharger, UpgradeTexture, CubeUpgradeRecycleIcon, 0, cubeAmountAch8.IsUnlocked);         
            UpdateUpgradeButton(baseOmniMultiUpButton, baseOmniMultiUp, UpgradeTexture, BaseCubeUpgradeIcon, 0, cubeAmountAch8.IsUnlocked);         
            UpdateUpgradeButton(allGen100ToOmniMultButton, allGen100ToOmniMult, UpgradeTexture, MultiCubeUpgradeIcon, 0, cubeAmountAch8.IsUnlocked);         
            
            UpdateUpgradeButton(cubeFinalUpgrade1Button, cubeFinalUpgrade1, UpgradeTexture, BaseCubeUpgradeIcon, 0, cubeAmountAch10.IsUnlocked);         
            UpdateUpgradeButton(cubeFinalUpgrade2Button, cubeFinalUpgrade2, UpgradeTexture, MultiCubeSaleIcon, 0, cubeAmountAch10.IsUnlocked);         
            UpdateUpgradeButton(trueFinalCubeUpgradeButton, trueFinalCubeUpgrade, UpgradeTexture, BaseCubeUpgradeIcon, 0, cubeAmountAch13.IsUnlocked);         
        }
        
        private void AutomateUpgradeUpdate(GameTime gameTime)
        {
           
            UpdateHoverText();
            UpdateUpgradeButton(autoProducersButton, autoProducers, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch3.IsUnlocked);
            UpdateUpgradeButton(autoArchitectsButton, autoArchitects, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch3.IsUnlocked);
            UpdateUpgradeButton(autoEngineersButton, autoEngineers, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch3.IsUnlocked);
            UpdateUpgradeButton(autoVisionaryButton, autoVisionary, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch3.IsUnlocked);
            UpdateUpgradeButton(autoOmniButton, autoOmni, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch3.IsUnlocked);
            UpdateUpgradeButton(autoPrimerButton, autoPrimer, UpgradeTexture, AutoFluxUpgradeIcon, 2, fluxuateAmountAch7.IsUnlocked);
            UpdateUpgradeButton(autoOverchargerButton, autoOvercharger, UpgradeTexture, AutoFluxUpgradeIcon, 2, fluxuateAmountAch7.IsUnlocked);
            UpdateUpgradeButton(autoProducersBoostButton, autoProducersBoost, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch8.IsUnlocked);
            UpdateUpgradeButton(autoArchitectsBoostButton, autoArchitectsBoost, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch8.IsUnlocked);
            UpdateUpgradeButton(autoEngineersBoostButton, autoEngineersBoost, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch8.IsUnlocked);
            UpdateUpgradeButton(autoVisionaryBoostButton, autoVisionaryBoost, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch8.IsUnlocked);
            UpdateUpgradeButton(autoOmniBoostButton, autoOmniBoost, UpgradeTexture, AutoCubeUpgradeIcon, 1, fluxuateAmountAch8.IsUnlocked);
            UpdateUpgradeButton(autoPrimerBoostButton, autoPrimerBoost, UpgradeTexture, AutoFluxUpgradeIcon, 2, fluxuateAmountAch9.IsUnlocked);
            UpdateUpgradeButton(autoOverchargerBoostButton, autoOverchargerBoost, UpgradeTexture, AutoFluxUpgradeIcon, 2, fluxuateAmountAch9.IsUnlocked);
                
        }
            
        private void FluxUpgradeUpdate(GameTime gameTime)
        {

            if (fluxUpgrade1.IsActive)
            {
                primer.BoostPower = 0.45;
            }
            else primer.BoostPower = 0.25; 
            if (fluxUpgrade2.IsActive)
            {
                overcharger.BoostPower = 0.25;
            }
            else overcharger.BoostPower = 0.15;
            if (fluxUpgrade3.IsActive)
            {
                double overchargerLevelDiff = (overcharger.Quantity / 5) - _prevOverchargerLevel3;
                if (overchargerLevelDiff != 0)
                {
                    double primersToAdd = overchargerLevelDiff;
                    primer.Quantity += primersToAdd;
                    _prevOverchargerLevel3 += overchargerLevelDiff;
                }
            }
            if (fluxUpgrade6.IsActive)
            {
                double primerLevelDiff = (primer.Quantity / 10) - _prevPrimerLevel4;
                if (primerLevelDiff != 0)
                {
                    double overchargersToAdd = primerLevelDiff;
                    overcharger.Quantity += overchargersToAdd;
                    _prevPrimerLevel4 += primerLevelDiff;
                }
            }

            UpdateHoverText();
            UpdateUpgradeButton(fluxUpgrade1Button, fluxUpgrade1, UpgradeTexture, PrimerUpgradeIcon, 1, fluxuateAmountAch5.IsUnlocked);
            UpdateUpgradeButton(fluxUpgrade2Button, fluxUpgrade2, UpgradeTexture, PrimerUpgradeIcon, 1, fluxuateAmountAch5.IsUnlocked);
            UpdateUpgradeButton(fluxUpgrade3Button, fluxUpgrade3, UpgradeTexture, PrimerUpgradeRecycleIcon, 1, fluxuateAmountAch5.IsUnlocked);
            UpdateUpgradeButton(fluxUpgrade4Button, fluxUpgrade4, UpgradeTexture, PrimerUpgradeSaleIcon, 1, fluxuateAmountAch5.IsUnlocked);
            UpdateUpgradeButton(fluxUpgrade5Button, fluxUpgrade5, UpgradeTexture, PrimerUpgradeSaleIcon, 1, fluxuateAmountAch5.IsUnlocked);
            UpdateUpgradeButton(fluxUpgrade6Button, fluxUpgrade6, UpgradeTexture, PrimerUpgradeRecycleIcon, 1, fluxuateAmountAch5.IsUnlocked);
            UpdateUpgradeButton(fluxUpgrade7Button, fluxUpgrade7, UpgradeTexture, Content.Load<Texture2D>("UI/UpgradeIcons/FluxIcon"), 1, fluxuateAmountAch6.IsUnlocked);
            UpdateUpgradeButton(fluxUpgrade8Button, fluxUpgrade8, UpgradeTexture, PrimerUpgradeSaleIcon, 1, fluxuateAmountAch6.IsUnlocked);
            UpdateUpgradeButton(fluxUpgrade9Button, fluxUpgrade9, UpgradeTexture, PrimerUpgradeSaleIcon, 1, fluxuateAmountAch6.IsUnlocked);

                 
        }
       
        public static double _previousWeaverMultiplier;
        public static double _previousForgerMultiplier;
        public static double _prismUpgrade1Multi = 0;
        public static int _prevRitualAmount1;
        public static int _prevRitualAmount2;
        public static int _prevRitualAmount3;
        public static int _prevRitualAmount4;
        public static int _prevRitualAmount5;
        public static int howManyTimes = 1;
        public static int howManyTimes2 = 1;
        public static int howManyTimes3 = 1;
        public static double _prismUpgrade11Contri = 1.0;
        private void PrismUpgradeUpdate(GameTime gameTime)
        {
            if (prismUpgrade1.IsActive)
            {
                _prismUpgrade1Multi = (resourceManager.GetPrism() / 10);
            }
            else _prismUpgrade1Multi = 0;

            if (prismUpgrade3.IsActive)
            {
                int toAdd = 25 * (resourceManager.GetRitualAmount() - _prevRitualAmount1);
                primer.Quantity += toAdd;
                overcharger.Quantity += toAdd;
                _prevRitualAmount1 = resourceManager.GetRitualAmount();
            }

            if (prismUpgrade5.IsActive)
            {
                int toAdd = (resourceManager.GetRitualAmount() - _prevRitualAmount2);
                fractalWeaver.Quantity += toAdd;
                _prevRitualAmount2 = resourceManager.GetRitualAmount();
            }

            if (prismUpgrade18.IsActive)
            {
                int toAdd = (resourceManager.GetRitualAmount() - _prevRitualAmount4) / 2;
                fractalForger.Quantity += toAdd;
                _prevRitualAmount4 = resourceManager.GetRitualAmount();
            }
            if (prismUpgrade19.IsActive)
            {
                int toAdd = (resourceManager.GetRitualAmount() - _prevRitualAmount5) / 5;
                fractalNexus.Quantity += toAdd;
                _prevRitualAmount5 = resourceManager.GetRitualAmount();
            }

            if (prismUpgrade8.IsActive)
            {
                int rittieDiff = resourceManager.GetRitualAmount() - _prevRitualAmount3;
                if (rittieDiff != 0)
                {
                    double toAdd = Math.Pow(0.98, rittieDiff);
                    _baseForgerCostMulti *= toAdd;
                    fractalForger.CurrentCost *= toAdd;
                    _prevRitualAmount3 = resourceManager.GetRitualAmount();
                }
            }



            if (prismUpgrade10.IsActive)
            {
                double currentWeaverMultiplier = fractalWeaver.FractalMultiplier;

                if (_previousWeaverMultiplier != currentWeaverMultiplier)
                {
                    double multiplierDifference = currentWeaverMultiplier - _previousWeaverMultiplier;
                    fractalForger.FractalMultiplier += multiplierDifference;
                    _previousWeaverMultiplier = currentWeaverMultiplier;
                }
            }
            if (prismUpgrade11.IsActive)
            {
                double minNumberOfUnits = fractalWeaver.Quantity;
                double setsOfFive = minNumberOfUnits / 5;
                double newCrossFunctionalContribution = 1 + (0.5 * setsOfFive);

                if (setsOfFive > 0 && _prismUpgrade11Contri != newCrossFunctionalContribution)
                {
                    double scaleFactor = newCrossFunctionalContribution / _prismUpgrade11Contri;
                    _prismUpgrade11Contri = newCrossFunctionalContribution;
                    _baseWeaverMultiplier += scaleFactor;
                    fractalWeaver.FractalMultiplier *= scaleFactor;
                }
            }

            if (prismUpgrade14.IsActive)
            {
                double currentForgerMultiplier = fractalForger.FractalMultiplier;

                if (_previousForgerMultiplier != currentForgerMultiplier)
                {
                    double multiplierDifference = currentForgerMultiplier - _previousForgerMultiplier;
                    fractalNexus.FractalMultiplier += multiplierDifference;
                    _previousForgerMultiplier = currentForgerMultiplier;
                }
            }



            UpdateHoverText();
            UpdateUpgradeButton(prismUpgrade1Button, prismUpgrade1, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch1.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade2Button, prismUpgrade2, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch1.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade3Button, prismUpgrade3, UpgradeTexture, PrismUpgradeRecycleIcon, 2, ritualAmountAch1.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade4Button, prismUpgrade4, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch2.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade5Button, prismUpgrade5, UpgradeTexture, PrismUpgradeRecycleIcon, 2, ritualAmountAch2.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade6Button, prismUpgrade6, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch2.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade7Button, prismUpgrade7, UpgradeTexture, PrismUpgradeSaleIcon, 2, ritualAmountAch3.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade8Button, prismUpgrade8, UpgradeTexture, PrismUpgradeSaleIcon, 2, ritualAmountAch3.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade9Button, prismUpgrade9, UpgradeTexture, PrismUpgradeSaleIcon, 2, ritualAmountAch3.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade10Button, prismUpgrade10, UpgradeTexture, PrismUpgradeRecycleIcon, 2, ritualAmountAch5.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade11Button, prismUpgrade11, UpgradeTexture, PrismUpgradeRecycleIcon, 2, ritualAmountAch5.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade12Button, prismUpgrade12, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch5.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade13Button, prismUpgrade13, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch5.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade14Button, prismUpgrade14, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch5.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade15Button, prismUpgrade15, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch6.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade16Button, prismUpgrade16, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch6.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade17Button, prismUpgrade17, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch6.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade18Button, prismUpgrade18, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch7.IsUnlocked);       
            UpdateUpgradeButton(prismUpgrade19Button, prismUpgrade19, UpgradeTexture, PrismUpgradeIcon, 2, ritualAmountAch7.IsUnlocked);       
        }

        public static double _prevFractCount;
        public static double _prevFractCount2;
        public static double _prevWeaverCount;
        public static double _prevForgerCount;
        public static double _prevNexusCount;
        public static double _fractalFluxuateMulti = 1.0;
        public static double _fractalRitualMulti = 1.0;
        public static int _prevFluxuateCount;    
        public static int _prevFluxuateCount2;
        public static int _prevRitualCount1;
        public static int _prevRitualCount2;
        public static int _prevRitualCount3;
        public static int _prevRitualCount4;
        public static bool fluxuateFromRitual;
        private void FractalUpgradeUpdate(GameTime gameTime)
        {
            if (fractalUpgrade1.IsActive)
            {
                _fractalFluxuateMulti = 1 + (resourceManager.GetFractals() / 20);
            }
            else _fractalFluxuateMulti = 1;

            if (fractalUpgrade2.IsActive)
            {
                double fractCountDiff = (int)resourceManager.GetFractals() - _prevFractCount;
                if (fractCountDiff != 0)
                {
                    double costDecreaseBase = 0.9975;
                    double costDecreaseFactor;

                    for (int i = 0; i < fractCountDiff; i++)
                    {
                        costDecreaseFactor = Math.Min(costDecreaseBase + (0.000025 * Math.Log(1 + _prevFractCount)), 0.9999);
                        _baseProducerCostMulti *= costDecreaseFactor;
                        cubeProducer.CurrentCost *= costDecreaseFactor;

                        _baseArchitectCostMulti *= costDecreaseFactor;
                        cubeArchitect.CurrentCost *= costDecreaseFactor;

                        _baseEngineerCostMulti *= costDecreaseFactor;
                        cubeEngineer.CurrentCost *= costDecreaseFactor;

                        _prevFractCount++;
                    }
                }
            }


            
            if (fractalUpgrade3.IsActive)
            {
                double fractCountDiff = resourceManager.GetFractals() - _prevFractCount2;
                if (fractCountDiff != 0)
                {
                    double costDecreaseBase = 0.9975;
                    double costDecreaseFactor;

                    for (int i = 0; i < fractCountDiff; i++)
                    {
                        costDecreaseFactor = Math.Min(costDecreaseBase + (0.000025 * Math.Log(1 + _prevFractCount2)), 0.999999);
                        _baseVisionaryCostMulti *= costDecreaseFactor;
                        cubeVisionary.CurrentCost *= costDecreaseFactor;

                        _baseOmniCostMulti *= costDecreaseFactor;
                        cubeOmni.CurrentCost *= costDecreaseFactor;

                        _prevFractCount2++;
                    }
                }
            }

            
            if (fractalUpgrade4.IsActive)
            {
                double weaverDiff = fractalWeaver.Quantity - _prevWeaverCount;
                if (weaverDiff != 0)
                {
                    double toAdd = weaverDiff;
                    cubeProducer.Quantity += toAdd;
                    cubeArchitect.Quantity += toAdd;
                    cubeEngineer.Quantity += toAdd;

                    _prevWeaverCount += weaverDiff;
                }
            }
            
            if (fractalUpgrade5.IsActive)
            {
                double forgerDiff = fractalForger.Quantity - _prevForgerCount;
                if (forgerDiff != 0)
                {
                    double toAdd = forgerDiff; 
                    cubeVisionary.Quantity += toAdd;
                    cubeOmni.Quantity += toAdd;

                    _prevForgerCount += forgerDiff;
                }
            }
           
            if (fractalUpgrade6.IsActive)
            {
                double nexusDiff = fractalNexus.Quantity - _prevNexusCount;
                if (nexusDiff != 0)
                {
                    double toAdd = 0.5 * nexusDiff;
                    _baseProducerMultiplier += toAdd;
                    cubeProducer.CubeMultiplier += toAdd;

                    _baseArchitectMultiplier += toAdd;
                    cubeArchitect.CubeMultiplier += toAdd;

                    _baseEngineerMultiplier += toAdd;
                    cubeEngineer.CubeMultiplier += toAdd;

                    _baseVisionaryMultiplier += toAdd;
                    cubeVisionary.CubeMultiplier += toAdd;

                    _baseOmniMultiplier += toAdd;
                    cubeOmni.CubeMultiplier += toAdd;

                    _prevNexusCount += nexusDiff;
                }
            }

            if (fractalUpgrade7.IsActive)
            {
                _fractalRitualMulti = 1 + (resourceManager.GetFractals() / 100);
            }
            else _fractalRitualMulti = 1;
           
            if (fractalUpgrade9.IsActive)
            {
                int fluxuationDiff = resourceManager.GetFluxuateAmount() - _prevFluxuateCount;
                if (fluxuationDiff != 0)
                {
                    int toAdd = 5 * fluxuationDiff;
                    primer.Quantity += toAdd;

                    _prevFluxuateCount += fluxuationDiff;
                }
            }
            
            if (fractalUpgrade12.IsActive)
            {
                int ritualDiff = resourceManager.GetRitualAmount() - _prevRitualCount1;
                if (ritualDiff != 0)
                {
                    int toAdd = 100 * ritualDiff;
                    cubeProducer.Quantity += toAdd;

                    _prevRitualCount1 += ritualDiff;
                }
            }

            if (fractalUpgrade13.IsActive)
            {
                int ritualDiff = resourceManager.GetRitualAmount() - _prevRitualCount2;
                if (ritualDiff != 0)
                {
                    int toAdd = 75 * ritualDiff;
                    cubeArchitect.Quantity += toAdd;

                    _prevRitualCount2 += ritualDiff;
                }
            }

            if (fractalUpgrade14.IsActive)
            {
                int ritualDiff = resourceManager.GetRitualAmount() - _prevRitualCount3;
                if (ritualDiff != 0)
                {
                    int toAdd = 50 * ritualDiff;
                    cubeEngineer.Quantity += toAdd;

                    _prevRitualCount3 += ritualDiff;
                }
            }

            if (fractalUpgrade15.IsActive)
            {
                int ritualDiff = resourceManager.GetRitualAmount() - _prevRitualCount4;
                if (ritualDiff != 0)
                {
                    int toAdd = 10 * ritualDiff;
                    cubeVisionary.Quantity += toAdd;
                    cubeOmni.Quantity += toAdd;

                    _prevRitualCount4 += ritualDiff;
                }
            }

            if (fractalUpgrade10.IsActive)
            {
                int fluxuationDiff = resourceManager.GetFluxuateAmount() - _prevFluxuateCount2;
                if (fluxuationDiff != 0)
                {
                    int toAdd = 2 * fluxuationDiff;
                    overcharger.Quantity += toAdd;

                    _prevFluxuateCount2 += fluxuationDiff;
                }
            }

            if (fractalUpgrade11.IsActive)
            {
                fluxuateFromRitual = true;
            }
            else fluxuateFromRitual = false;


            UpdateHoverText();
            UpdateFractalUpgradeButton(fractalUpgrade1Button, fractalUpgrade1, UpgradeTexture, FractalUpgradeIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade2Button, fractalUpgrade2, UpgradeTexture, FractalUpgradeSaleIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade3Button, fractalUpgrade3, UpgradeTexture, FractalUpgradeSaleIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade4Button, fractalUpgrade4, UpgradeTexture, FractalUpgradeRecycleIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade5Button, fractalUpgrade5, UpgradeTexture, FractalUpgradeRecycleIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade6Button, fractalUpgrade6, UpgradeTexture, FractalUpgradeRecycleIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade7Button, fractalUpgrade7, UpgradeTexture, FractalUpgradeIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade8Button, fractalUpgrade8, UpgradeTexture, FractalUpgradeSaleIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade9Button, fractalUpgrade9, UpgradeTexture, FractalUpgradeRecycleIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade10Button, fractalUpgrade10, UpgradeTexture, FractalUpgradeRecycleIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade11Button, fractalUpgrade11, UpgradeTexture, FractalUpgradeIcon, 3, true);             
            UpdateFractalUpgradeButton(fractalUpgrade12Button, fractalUpgrade12, UpgradeTexture, FractalUpgradeRecycleIcon, 3, fractalAmountAch5.IsUnlocked);             
            UpdateFractalUpgradeButton(fractalUpgrade13Button, fractalUpgrade13, UpgradeTexture, FractalUpgradeRecycleIcon, 3, fractalAmountAch5.IsUnlocked);             
            UpdateFractalUpgradeButton(fractalUpgrade14Button, fractalUpgrade14, UpgradeTexture, FractalUpgradeRecycleIcon, 3, fractalAmountAch5.IsUnlocked);             
            UpdateFractalUpgradeButton(fractalUpgrade15Button, fractalUpgrade15, UpgradeTexture, FractalUpgradeRecycleIcon, 3, fractalAmountAch5.IsUnlocked);             
        }
        
        private void FractalWeaverUpdate(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            double fracsGenerated = elapsedTime * fractalWeaver.FullFPS();
            resourceManager.AddFractals(fracsGenerated);
            int maxBuyable = fractalWeaver.CalculateMaxBuyable(resourceManager.GetPrism(), 1);
            double fracTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {
                if (fractalWeaver.CanAfford(resourceManager.GetPrism()))
                {
                    fractalWeaverButton.extraButtonColor = new Color(213, 73, 103);
                }
                else
                {
                    fractalWeaverButton.extraButtonColor = new Color(36, 36, 36);
                }


                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    fracTotalCost += (fractalWeaver.CurrentCost * Math.Pow((1 + fractalWeaver.CostIncrease), i));
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    fractalWeaverButton.extraButtonColor = new Color(213, 73, 103);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        fracTotalCost += (fractalWeaver.CurrentCost * Math.Pow((1 + fractalWeaver.CostIncrease), i));
                    }
                }
                else
                {
                    fractalWeaverButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        fracTotalCost += (fractalWeaver.CurrentCost * Math.Pow((1 + fractalWeaver.CostIncrease), i));
                    }
                }
            }

            if (isFractalGeneratorsSectionOpen)
            {
                fractalWeaverButton.ButtonTexture = BuyButtonTexture;
                expoNumeration = new BigNumber(fracTotalCost);
                fractalWeaverButton.Text = $"Cost: {expoNumeration.ToString()} Prisms";

            }
            else
            {
                fractalWeaverButton.ButtonTexture = EmptyTexture;
                fractalWeaverButton.Text = "";
            }

        }
        private void FractalForgerUpdate(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            double fracsGenerated = elapsedTime * fractalForger.FullFPS();
            resourceManager.AddFractals(fracsGenerated);
            int maxBuyable = fractalForger.CalculateMaxBuyable(resourceManager.GetPrism(), 1);
            double fracTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {
                if (fractalForger.CanAfford(resourceManager.GetPrism()))
                {
                    fractalForgerButton.extraButtonColor = new Color(213, 73, 103);
                }
                else
                {
                    fractalForgerButton.extraButtonColor = new Color(36, 36, 36);
                }


                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    fracTotalCost += (fractalForger.CurrentCost * Math.Pow((1 + fractalForger.CostIncrease), i));
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    fractalForgerButton.extraButtonColor = new Color(213, 73, 103);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        fracTotalCost += (fractalForger.CurrentCost * Math.Pow((1 + fractalForger.CostIncrease), i));
                    }
                }
                else
                {
                    fractalForgerButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        fracTotalCost += (fractalForger.CurrentCost * Math.Pow((1 + fractalForger.CostIncrease), i));
                    }
                }
            }

            if (isFractalGeneratorsSectionOpen)
            {
                fractalForgerButton.ButtonTexture = BuyButtonTexture;
                expoNumeration = new BigNumber(fracTotalCost);
                fractalForgerButton.Text = $"Cost: {expoNumeration.ToString()} Prisms";

            }
            else
            {
                fractalForgerButton.ButtonTexture = EmptyTexture;
                fractalForgerButton.Text = "";
            }

        }
        private void FractalNexusUpdate(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            double fracsGenerated = elapsedTime * fractalNexus.FullFPS();
            resourceManager.AddFractals(fracsGenerated);
            int maxBuyable = fractalNexus.CalculateMaxBuyable(resourceManager.GetPrism(), 1);
            double fracTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {
                if (fractalNexus.CanAfford(resourceManager.GetPrism()))
                {
                    fractalNexusButton.extraButtonColor = new Color(213, 73, 103);
                }
                else
                {
                    fractalNexusButton.extraButtonColor = new Color(36, 36, 36);
                }


                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    fracTotalCost += (fractalNexus.CurrentCost * Math.Pow((1 + fractalNexus.CostIncrease), i));
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    fractalNexusButton.extraButtonColor = new Color(213, 73, 103);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        fracTotalCost += (fractalNexus.CurrentCost * Math.Pow((1 + fractalNexus.CostIncrease), i));
                    }
                }
                else
                {
                    fractalNexusButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        fracTotalCost += (fractalNexus.CurrentCost * Math.Pow((1 + fractalNexus.CostIncrease), i));
                    }
                }
            }

            if (isFractalGeneratorsSectionOpen)
            {
                fractalNexusButton.ButtonTexture = BuyButtonTexture;
                expoNumeration = new BigNumber(fracTotalCost);
                fractalNexusButton.Text = $"Cost: {expoNumeration.ToString()} Prisms";

            }
            else
            {
                fractalNexusButton.ButtonTexture = EmptyTexture;
                fractalNexusButton.Text = "";
            }

        }

        private void CubeProducerUpdate(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            double cubesGenerated = elapsedTime * cubeProducer.FullCPS();
            resourceManager.AddCubes(cubesGenerated);
            int maxBuyable = cubeProducer.CalculateMaxBuyable(resourceManager.GetCubes(), _baseProducerCostMulti);
            double cubeTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {          
                if (cubeProducer.CanAfford(resourceManager.GetCubes()))
                {
                    cubeProducerButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                }
                else
                {
                    cubeProducerButton.extraButtonColor = new Color(36, 36, 36);
                }
                

                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    cubeTotalCost += (cubeProducer.CurrentCost * Math.Pow((1 + cubeProducer.CostIncrease), i));
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    cubeProducerButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        cubeTotalCost += (cubeProducer.CurrentCost * Math.Pow((1 + cubeProducer.CostIncrease), i));
                    }
                }
                else
                {
                    cubeProducerButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        cubeTotalCost += (cubeProducer.CurrentCost * Math.Pow((1 + cubeProducer.CostIncrease), i));
                    }
                }
            }
           
            if (isCubeGeneratorsSectionOpen)
            {
                cubeProducerButton.ButtonTexture = BuyButtonTexture;
                expoNumeration = new BigNumber(cubeTotalCost);
                cubeProducerButton.Text = $"Cost: {expoNumeration.ToString()} Cubes";

            }
            else
            {
                cubeProducerButton.ButtonTexture = EmptyTexture;
                cubeProducerButton.Text = "";
            }
 
        }
        private void CubeArchitectUpdate(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            double cubesGenerated = elapsedTime * cubeArchitect.FullCPS();
            resourceManager.AddCubes(cubesGenerated);
            int maxBuyable = cubeArchitect.CalculateMaxBuyable(resourceManager.GetCubes(), _baseArchitectCostMulti);
            double cubeTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {            
                if (cubeArchitect.CanAfford(resourceManager.GetCubes()))
                {
                    cubeArchitectButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                }
                else
                {
                    cubeArchitectButton.extraButtonColor = new Color(36, 36, 36);
                }
                

                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    cubeTotalCost += cubeArchitect.CurrentCost * Math.Pow((1 + cubeArchitect.CostIncrease), i);
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    cubeArchitectButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        cubeTotalCost += (cubeArchitect.CurrentCost * Math.Pow((1 + cubeArchitect.CostIncrease), i));
                    }
                }
                else
                {
                    cubeArchitectButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        cubeTotalCost += (cubeArchitect.CurrentCost * Math.Pow((1 + cubeArchitect.CostIncrease), i));
                    }
                }
            }
           
            if (isCubeGeneratorsSectionOpen)
            {
                cubeArchitectButton.ButtonTexture = BuyButtonTexture;
                expoNumeration = new BigNumber(cubeTotalCost);
                cubeArchitectButton.Text = $"Cost: {expoNumeration.ToString()} Cubes";
            }
            else
            {
                cubeArchitectButton.ButtonTexture = EmptyTexture;
                cubeArchitectButton.Text = "";
            }
   
        }
        private void CubeEngineerUpdate(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            double cubesGenerated = elapsedTime * cubeEngineer.FullCPS();
            resourceManager.AddCubes(cubesGenerated);
            int maxBuyable = cubeEngineer.CalculateMaxBuyable(resourceManager.GetCubes(), _baseEngineerCostMulti);
            double cubeTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {
                if (cubeEngineer.CanAfford(resourceManager.GetCubes()))
                {
                    cubeEngineerButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                }
                else
                {
                    cubeEngineerButton.extraButtonColor = new Color(36, 36, 36);
                }
                

                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    cubeTotalCost += cubeEngineer.CurrentCost * Math.Pow((1 + cubeEngineer.CostIncrease), i);
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    cubeEngineerButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        cubeTotalCost += (cubeEngineer.CurrentCost * Math.Pow((1 + cubeEngineer.CostIncrease), i));
                    }
                }
                else
                {
                    cubeEngineerButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        cubeTotalCost += (cubeEngineer.CurrentCost * Math.Pow((1 + cubeEngineer.CostIncrease), i));
                    }
                }
            }
            
            if (isCubeGeneratorsSectionOpen)
            {
                cubeEngineerButton.ButtonTexture = BuyButtonTexture;
                expoNumeration = new BigNumber(cubeTotalCost);
                cubeEngineerButton.Text = $"Cost: {expoNumeration.ToString()} Cubes";
            }
            else
            {
                cubeEngineerButton.ButtonTexture = EmptyTexture;
                cubeEngineerButton.Text = "";
            }

        }
        private void CubeVisionaryUpdate(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            double cubesGenerated = elapsedTime * cubeVisionary.FullCPS();
            resourceManager.AddCubes(cubesGenerated);
            int maxBuyable = cubeVisionary.CalculateMaxBuyable(resourceManager.GetCubes(), _baseVisionaryCostMulti);
            double cubeTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {
                if (cubeVisionary.CanAfford(resourceManager.GetCubes()))
                {
                    cubeVisionaryButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                }
                else
                {
                    cubeVisionaryButton.extraButtonColor = new Color(36, 36, 36);
                }
               
                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    cubeTotalCost += (cubeVisionary.CurrentCost * Math.Pow((1 + cubeVisionary.CostIncrease), i));
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    cubeVisionaryButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        cubeTotalCost += (cubeVisionary.CurrentCost * Math.Pow((1 + cubeVisionary.CostIncrease), i));
                    }
                }
                else
                {
                    cubeVisionaryButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        cubeTotalCost += (cubeVisionary.CurrentCost * Math.Pow((1 + cubeVisionary.CostIncrease), i));
                    }
                }
            }

            if (isCubeGeneratorsSectionOpen)
            {
                if (cubeAmountAch6.IsUnlocked)
                {
                    cubeVisionaryButton.ButtonTexture = BuyButtonTexture;
                    expoNumeration = new BigNumber(cubeTotalCost);
                    cubeVisionaryButton.Text = $"Cost: {expoNumeration.ToString()} Cubes";
                }
                else
                {
                    cubeVisionaryButton.ButtonTexture = EmptyTexture;
                    cubeVisionaryButton.Text = "";
                }
            }
            else
            {
                cubeVisionaryButton.ButtonTexture = EmptyTexture;
                cubeVisionaryButton.Text = "";
            }
        }
        private void CubeOmniUpdate(GameTime gameTime)
        {
            double elapsedTime = gameTime.ElapsedGameTime.TotalSeconds;
            double cubesGenerated = elapsedTime * cubeOmni.FullCPS();
            resourceManager.AddCubes(cubesGenerated);
            int maxBuyable = cubeOmni.CalculateMaxBuyable(resourceManager.GetCubes(), _baseOmniCostMulti);
            double cubeTotalCost = 0;
            if (CubeGenerator.BuyAmount != -1)
            {
                if (cubeOmni.CanAfford(resourceManager.GetCubes()))
                {
                    cubeOmniButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                }
                else
                {
                    cubeOmniButton.extraButtonColor = new Color(36, 36, 36);
                }
                
                for (int i = 0; i < CubeGenerator.BuyAmount; i++)
                {
                    cubeTotalCost += (cubeOmni.CurrentCost * Math.Pow((1 + cubeOmni.CostIncrease), i));
                }
            }
            else
            {
                if (maxBuyable > 0)
                {
                    cubeOmniButton.extraButtonColor = new Color(36 * 3, 24 * 3, 71 * 3);
                    for (int i = 0; i < maxBuyable; i++)
                    {
                        cubeTotalCost += (cubeOmni.CurrentCost * Math.Pow((1 + cubeOmni.CostIncrease), i));
                    }
                }
                else
                {
                    cubeOmniButton.extraButtonColor = new Color(36, 36, 36);
                    for (int i = 0; i < 1; i++)
                    {
                        cubeTotalCost += (cubeOmni.CurrentCost * Math.Pow((1 + cubeOmni.CostIncrease), i));
                    }
                }
            }
            if (isCubeGeneratorsSectionOpen)
            {
                if (cubeAmountAch8.IsUnlocked)
                {
                    cubeOmniButton.ButtonTexture = BuyButtonTexture;
                    expoNumeration = new BigNumber(cubeTotalCost);
                    cubeOmniButton.Text = $"Cost: {expoNumeration.ToString()} Cubes";
                }
                else
                {
                    cubeOmniButton.ButtonTexture = EmptyTexture;
                    cubeOmniButton.Text = "";
                }
            }
            else
            {
                cubeOmniButton.ButtonTexture = EmptyTexture;
                cubeOmniButton.Text = "";
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(24, 24, 24));


            var scaleX = (float)GraphicsDevice.Viewport.Width / DesignWidth;
            var scaleY = (float)GraphicsDevice.Viewport.Height / DesignHeight;
            var matrix = Matrix.CreateScale(scaleX, scaleY, 1.0f);

            spriteBatch.Begin(transformMatrix: matrix);
            DrawMidArea(spriteBatch);
            //spriteBatch.Draw(MainGame.RightPanelTexture, rightPanelPos, rightPanelColor);
            if (autoProducers.IsActive)
            {
                if(isCubeGeneratorsSectionOpen) _prodAutoButton.Draw(gameTime, spriteBatch);
            }
            if (autoArchitects.IsActive)
            {
                if(isCubeGeneratorsSectionOpen) _archAutoButton.Draw(gameTime, spriteBatch);
            }
            if (autoEngineers.IsActive)
            {
                if(isCubeGeneratorsSectionOpen) _engiAutoButton.Draw(gameTime, spriteBatch);
            }
            if (autoVisionary.IsActive && cubeAmountAch6.IsUnlocked)
            {
                if(isCubeGeneratorsSectionOpen) _visAutoButton.Draw(gameTime, spriteBatch);
            }
            if (autoOmni.IsActive && cubeAmountAch8.IsUnlocked)
            {
                if(isCubeGeneratorsSectionOpen) _omniAutoButton.Draw(gameTime, spriteBatch);
            }
            if (autoPrimer.IsActive && fluxuateAmountAch1.IsUnlocked)
            {
                if(isCubeGeneratorsSectionOpen) _primerAutoButton.Draw(gameTime, spriteBatch);
            }
            if (autoOvercharger.IsActive && fluxuateAmountAch2.IsUnlocked)
            {
                if(isCubeGeneratorsSectionOpen) _overchargerAutoButton.Draw(gameTime, spriteBatch);
            }
            if (fluxuateAmountAch4.IsUnlocked)
            {
                 _fluxuateAutoButton.Draw(gameTime, spriteBatch);
            }
            if (ritualAmountAch4.IsUnlocked)
            {
                _ritualAutoButton.Draw(gameTime, spriteBatch);
            }

            if(!isUpgradeSectionOpen && !isFractalGeneratorsSectionOpen && !isCubeGeneratorsSectionOpen && !isAchievementSectionOpen && !isSigilsSectionOpen)
            {
                spriteBatch.Draw(Content.Load<Texture2D>("UI/CubefinityLogo"), new Vector2(1920 / 2 + 250 - 300 - Content.Load<Texture2D>("UI/CubefinityLogo").Width / 2, 1080 / 2 - Content.Load<Texture2D>("UI/CubefinityLogo").Height / 2), Color.White);
            }

            if(isFractalGeneratorsSectionOpen)
            {
                
                spriteBatch.Draw(Content.Load<Texture2D>("UI/UpgradeIcons/FractalIcon"), new Vector2((1920 / 2) - 55 - Content.Load<Texture2D>("UI/UpgradeIcons/FractalIcon").Width / 2, cubeProducerPos.Y + 340 - Content.Load<Texture2D>("UI/UpgradeIcons/FractalIcon").Height / 2), Color.White);
                string fractalUpgradeText1 = "FRACTAL UPGRADES";
                spriteBatch.DrawString(MainGame.font, fractalUpgradeText1, new Vector2(((1920 / 2) - 54 - MainGame.font.MeasureString(fractalUpgradeText1).X / 2), cubeProducerPos.Y + 375 - MainGame.font.MeasureString(fractalUpgradeText1).Y / 2), new Color(213, 73, 103), 0, default, 1f, SpriteEffects.None, 0);

            }

            if (isUpgradeSectionOpen)
            {
                //spriteBatch.Draw(MainGame.UpgradePanelTexture, rightPanelPos, colorLineColor);
                spriteBatch.Draw(Content.Load<Texture2D>("UI/UpgradeIcons/CubeIcon"), new Vector2(cubeUpgrade1Pos.X - 100 - Content.Load<Texture2D>("UI/UpgradeIcons/CubeIcon").Width / 2, cubeUpgrade1Pos.Y + 70 - Content.Load<Texture2D>("UI/UpgradeIcons/CubeIcon").Height / 2), Color.White);
                string cubeUpgradeText1 = "CUBE UPGRADES";
                spriteBatch.DrawString(MainGame.font, cubeUpgradeText1, new Vector2((cubeUpgrade1Pos.X - 100 - MainGame.font.MeasureString(cubeUpgradeText1).X / 2), cubeUpgrade1Pos.Y + 120 - MainGame.font.MeasureString(cubeUpgradeText1).Y / 2), new Color(136, 194, 252), 0, default, 1f, SpriteEffects.None, 0);
                if(fluxuateAmountAch3.IsUnlocked)
                {
                    spriteBatch.Draw(Content.Load<Texture2D>("UI/UpgradeIcons/AutoIcon"), new Vector2(cubeUpgrade1Pos.X - 90 - Content.Load<Texture2D>("UI/UpgradeIcons/AutoIcon").Width / 2, cubeUpgrade1Pos.Y + 290 - Content.Load<Texture2D>("UI/UpgradeIcons/AutoIcon").Height / 2), Color.White);
                    string autoUpgradeText1 = "AUTO UPGRADES";
                    spriteBatch.DrawString(MainGame.font, autoUpgradeText1, new Vector2((cubeUpgrade1Pos.X - 90 - MainGame.font.MeasureString(autoUpgradeText1).X / 2), cubeUpgrade1Pos.Y + 330 - MainGame.font.MeasureString(autoUpgradeText1).Y / 2), new Color(136, 252, 252), 0, default, 1f, SpriteEffects.None, 0);

                }
                if(fluxuateAmountAch5.IsUnlocked)
                {
                    spriteBatch.Draw(Content.Load<Texture2D>("UI/UpgradeIcons/FluxIcon"), new Vector2(cubeUpgrade1Pos.X - 90 - Content.Load<Texture2D>("UI/UpgradeIcons/FluxIcon").Width / 2, cubeUpgrade1Pos.Y + 500 - Content.Load<Texture2D>("UI/UpgradeIcons/FluxIcon").Height / 2), Color.White);
                    string fluxUpgradeText1 = "FLUX UPGRADES";
                    spriteBatch.DrawString(MainGame.font, fluxUpgradeText1, new Vector2((cubeUpgrade1Pos.X - 90 - MainGame.font.MeasureString(fluxUpgradeText1).X / 2), cubeUpgrade1Pos.Y + 540 - MainGame.font.MeasureString(fluxUpgradeText1).Y / 2), new Color(136, 252, 252), 0, default, 1f, SpriteEffects.None, 0);

                }
                if(ritualAmountAch1.IsUnlocked)
                {
                    spriteBatch.Draw(Content.Load<Texture2D>("UI/UpgradeIcons/PrismIcon"), new Vector2(cubeUpgrade1Pos.X - 90 - Content.Load<Texture2D>("UI/UpgradeIcons/PrismIcon").Width / 2, cubeUpgrade1Pos.Y + 710 - Content.Load<Texture2D>("UI/UpgradeIcons/FluxIcon").Height / 2), Color.White);
                    string prismUpgradeText1 = "PRISM UPGRADES";
                    spriteBatch.DrawString(MainGame.font, prismUpgradeText1, new Vector2((cubeUpgrade1Pos.X - 90 - MainGame.font.MeasureString(prismUpgradeText1).X / 2), cubeUpgrade1Pos.Y + 750 - MainGame.font.MeasureString(prismUpgradeText1).Y / 2), new Color(252, 135, 136), 0, default, 1f, SpriteEffects.None, 0);

                }
            }

            if (isFractalGeneratorsSectionOpen)
            {
                //FRACTAL WEAVER
                spriteBatch.Draw(Content.Load<Texture2D>("UI/WeaverTexture"), new Vector2(cubeProducerPos.X + 130 - Content.Load<Texture2D>("UI/WeaverTexture").Width / 2, cubeProducerPos.Y - 72 - Content.Load<Texture2D>("UI/WeaverTexture").Height / 2), Color.White);
                expoNumeration = new BigNumber(fractalWeaver.FullFPS());
                string fractalWeaverCPS = $"[Fractals/Sec: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, fractalWeaverCPS, new Vector2((cubeProducerPos.X + 136 - MainGame.font.MeasureString(fractalWeaverCPS).X / 2), cubeProducerPos.Y + 66 - MainGame.font.MeasureString(fractalWeaverCPS).Y / 2), new Color(213, 73, 103), 0, default, 0.5f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(fractalWeaver.FractalMultiplier);
                string fractalWeaverMulti = $"[Multiplier: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, fractalWeaverMulti, new Vector2((cubeProducerPos.X + 160 - MainGame.font.MeasureString(fractalWeaverMulti).X / 2), cubeProducerPos.Y + 102 - MainGame.font.MeasureString(fractalWeaverMulti).Y / 2), new Color(213, 73, 103), 0, default, 0.4f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(fractalWeaver.Quantity);
                string fractalWeaverInfo = $"{fractalWeaver.Quantity} Weavers";
                if (fractalWeaver.Quantity < 1000000)
                {
                    fractalWeaverInfo = $"{fractalWeaver.Quantity} Weavers";
                }
                else fractalWeaverInfo = $"{expoNumeration} Weavers";
                spriteBatch.DrawString(MainGame.infoFont, fractalWeaverInfo, new Vector2((cubeProducerPos.X + 130 - MainGame.font.MeasureString(fractalWeaverInfo).X / 2), cubeProducerPos.Y - 40 - MainGame.font.MeasureString(fractalWeaverInfo).Y / 2), new Color(213, 73, 103), 0, default, 0.5f, SpriteEffects.None, 0);
                fractalWeaverButton.Draw(gameTime, spriteBatch);
                

                //FRACTAL FORGER
                spriteBatch.Draw(Content.Load<Texture2D>("UI/ForgerTexture"), new Vector2(cubeProducerPos.X + 520 - Content.Load<Texture2D>("UI/ForgerTexture").Width / 2, cubeProducerPos.Y - 72 - Content.Load<Texture2D>("UI/ForgerTexture").Height / 2), Color.White);
                expoNumeration = new BigNumber(fractalForger.FullFPS());
                string fractalForgerCPS = $"[Fractals/Sec: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, fractalForgerCPS, new Vector2((cubeProducerPos.X + 526 - MainGame.font.MeasureString(fractalForgerCPS).X / 2), cubeProducerPos.Y + 66 - MainGame.font.MeasureString(fractalForgerCPS).Y / 2), new Color(213, 73, 103), 0, default, 0.5f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(fractalForger.FractalMultiplier);
                string fractalForgerMulti = $"[Multiplier: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, fractalForgerMulti, new Vector2((cubeProducerPos.X + 550 - MainGame.font.MeasureString(fractalForgerMulti).X / 2), cubeProducerPos.Y + 102 - MainGame.font.MeasureString(fractalForgerMulti).Y / 2), new Color(213, 73, 103), 0, default, 0.4f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(fractalForger.Quantity);
                string fractalForgerInfo = $"{fractalForger.Quantity} Forgers";
                if (fractalForger.Quantity < 1000000)
                {
                    fractalForgerInfo = $"{fractalForger.Quantity} Forgers";
                }
                else fractalForgerInfo = $"{expoNumeration} Forgers";
                spriteBatch.DrawString(MainGame.infoFont, fractalForgerInfo, new Vector2((cubeProducerPos.X + 520 - MainGame.font.MeasureString(fractalForgerInfo).X / 2), cubeProducerPos.Y - 40 - MainGame.font.MeasureString(fractalForgerInfo).Y / 2), new Color(213, 73, 103), 0, default, 0.5f, SpriteEffects.None, 0);
                fractalForgerButton.Draw(gameTime, spriteBatch);
                
                //FRACTAL NEXUS
                spriteBatch.Draw(Content.Load<Texture2D>("UI/NexusTexture"), new Vector2(cubeProducerPos.X + 910 - Content.Load<Texture2D>("UI/NexusTexture").Width / 2, cubeProducerPos.Y - 82 - Content.Load<Texture2D>("UI/NexusTexture").Height / 2), Color.White);
                expoNumeration = new BigNumber(fractalNexus.FullFPS());
                string fractalNexusCPS = $"[Fractals/Sec: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, fractalNexusCPS, new Vector2((cubeProducerPos.X + 916 - MainGame.font.MeasureString(fractalNexusCPS).X / 2), cubeProducerPos.Y + 66 - MainGame.font.MeasureString(fractalNexusCPS).Y / 2), new Color(213, 73, 103), 0, default, 0.5f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(fractalNexus.FractalMultiplier);
                string fractalNexusMulti = $"[Multiplier: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, fractalNexusMulti, new Vector2((cubeProducerPos.X + 940 - MainGame.font.MeasureString(fractalNexusMulti).X / 2), cubeProducerPos.Y + 102 - MainGame.font.MeasureString(fractalNexusMulti).Y / 2), new Color(213, 73, 103), 0, default, 0.4f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(fractalNexus.Quantity);
                string fractalNexusInfo = $"{fractalNexus.Quantity} Nexus";
                if (fractalNexus.Quantity < 1000000)
                {
                    fractalNexusInfo = $"{fractalNexus.Quantity} Nexus";
                }
                else fractalNexusInfo = $"{expoNumeration} Nexus";
                spriteBatch.DrawString(MainGame.infoFont, fractalNexusInfo, new Vector2((cubeProducerPos.X + 910 - MainGame.font.MeasureString(fractalNexusInfo).X / 2), cubeProducerPos.Y - 40 - MainGame.font.MeasureString(fractalNexusInfo).Y / 2), new Color(213, 73, 103), 0, default, 0.5f, SpriteEffects.None, 0);
                fractalNexusButton.Draw(gameTime, spriteBatch);
            }

            if (isCubeGeneratorsSectionOpen)
            {
                //CUBE PRODUCER
                spriteBatch.Draw(Content.Load<Texture2D>("UI/ProducerTexture"), new Vector2(cubeProducerPos.X + 130 - Content.Load<Texture2D>("UI/ProducerTexture").Width / 2, cubeProducerPos.Y - 72 - Content.Load<Texture2D>("UI/ProducerTexture").Height / 2), Color.White);
                expoNumeration = new BigNumber(cubeProducer.FullCPS());
                string cubeProducerCPS = $"[Cubes/Sec: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, cubeProducerCPS, new Vector2((cubeProducerPos.X + 136 - MainGame.font.MeasureString(cubeProducerCPS).X / 2), cubeProducerPos.Y + 66 - MainGame.font.MeasureString(cubeProducerCPS).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(cubeProducer.CubeMultiplier * (1 + _prismUpgrade1Multi)) * new BigNumber(primer.FullBoostPower() * overcharger.FullBoostPower());
                string cubeProducerMulti = $"[Multiplier: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, cubeProducerMulti, new Vector2((cubeProducerPos.X + 160 - MainGame.font.MeasureString(cubeProducerMulti).X / 2), cubeProducerPos.Y + 102 - MainGame.font.MeasureString(cubeProducerMulti).Y / 2), new Color(136, 194, 252), 0, default, 0.4f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(cubeProducer.Quantity);
                string cubeProducerInfo = $"{cubeProducer.Quantity} Producers";
                if (cubeProducer.Quantity < 1000000)
                {
                    cubeProducerInfo = $"{cubeProducer.Quantity} Producers";
                }
                else cubeProducerInfo = $"{expoNumeration} Producers";
                spriteBatch.DrawString(MainGame.infoFont, cubeProducerInfo, new Vector2((cubeProducerPos.X + 130 - MainGame.font.MeasureString(cubeProducerInfo).X / 2), cubeProducerPos.Y - 40 - MainGame.font.MeasureString(cubeProducerInfo).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                cubeProducerButton.Draw(gameTime, spriteBatch);

                //CUBE ARCHITECT
                spriteBatch.Draw(Content.Load<Texture2D>("UI/ArchitectTexture"), new Vector2(cubeProducerPos.X + 520 - Content.Load<Texture2D>("UI/ArchitectTexture").Width / 2, cubeProducerPos.Y - 82 - Content.Load<Texture2D>("UI/ArchitectTexture").Height / 2), Color.White);
                expoNumeration = new BigNumber(cubeArchitect.FullCPS());
                string cubeArchitectCPS = $"[Cubes/Sec: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, cubeArchitectCPS, new Vector2((cubeProducerPos.X + 526 - MainGame.font.MeasureString(cubeArchitectCPS).X / 2), cubeProducerPos.Y + 66 - MainGame.font.MeasureString(cubeArchitectCPS).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(cubeArchitect.CubeMultiplier * (1 + _prismUpgrade1Multi)) * new BigNumber(primer.FullBoostPower() * overcharger.FullBoostPower());
                string cubeArchitectMulti = $"[Multiplier: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, cubeArchitectMulti, new Vector2((cubeProducerPos.X + 550 - MainGame.font.MeasureString(cubeArchitectMulti).X / 2), cubeProducerPos.Y + 102 - MainGame.font.MeasureString(cubeArchitectMulti).Y / 2), new Color(136, 194, 252), 0, default, 0.4f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(cubeArchitect.Quantity);
                string cubeArchitectInfo = $"{cubeArchitect.Quantity} Architects";
                if (cubeArchitect.Quantity < 1000000)
                {
                    cubeArchitectInfo = $"{cubeArchitect.Quantity} Architects";
                }
                else cubeArchitectInfo = $"{expoNumeration} Architects";
                spriteBatch.DrawString(MainGame.infoFont, cubeArchitectInfo, new Vector2((cubeProducerPos.X + 520 - MainGame.font.MeasureString(cubeArchitectInfo).X / 2), cubeProducerPos.Y - 40 - MainGame.font.MeasureString(cubeArchitectInfo).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                cubeArchitectButton.Draw(gameTime, spriteBatch);

                //CUBE ENGINEER
                spriteBatch.Draw(Content.Load<Texture2D>("UI/EngineerTexture"), new Vector2(cubeProducerPos.X + 910 - Content.Load<Texture2D>("UI/EngineerTexture").Width / 2, cubeProducerPos.Y - 82 - Content.Load<Texture2D>("UI/EngineerTexture").Height / 2), Color.White);
                expoNumeration = new BigNumber(cubeEngineer.FullCPS());
                string cubeEngineerCPS = $"[Cubes/Sec: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, cubeEngineerCPS, new Vector2((cubeProducerPos.X + 916 - MainGame.font.MeasureString(cubeEngineerCPS).X / 2), cubeProducerPos.Y + 66 - MainGame.font.MeasureString(cubeEngineerCPS).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(cubeEngineer.CubeMultiplier * (1 + _prismUpgrade1Multi)) * new BigNumber(primer.FullBoostPower() * overcharger.FullBoostPower());
                string cubeEngineerMulti = $"[Multiplier: {expoNumeration.ToString()}]";
                spriteBatch.DrawString(MainGame.infoFont, cubeEngineerMulti, new Vector2((cubeProducerPos.X + 940 - MainGame.font.MeasureString(cubeEngineerMulti).X / 2), cubeProducerPos.Y + 102 - MainGame.font.MeasureString(cubeEngineerMulti).Y / 2), new Color(136, 194, 252), 0, default, 0.4f, SpriteEffects.None, 0);
                expoNumeration = new BigNumber(cubeEngineer.Quantity);
                string cubeEngineerInfo = $"{cubeEngineer.Quantity} Designers";
                if (cubeEngineer.Quantity < 1000000)
                {
                    cubeEngineerInfo = $"{cubeEngineer.Quantity} Designers";
                }
                else cubeEngineerInfo = $"{expoNumeration} Designers";
                spriteBatch.DrawString(MainGame.infoFont, cubeEngineerInfo, new Vector2((cubeProducerPos.X + 910 - MainGame.font.MeasureString(cubeEngineerInfo).X / 2), cubeProducerPos.Y - 40 - MainGame.font.MeasureString(cubeEngineerInfo).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                cubeEngineerButton.Draw(gameTime, spriteBatch);

                if (cubeAmountAch6.IsUnlocked)
                {
                    //CUBE VISIONARY
                    spriteBatch.Draw(Content.Load<Texture2D>("UI/VisionaryTexture"), new Vector2(cubeProducerPos.X - 190 + 520 - Content.Load<Texture2D>("UI/VisionaryTexture").Width / 2, cubeProducerPos.Y + 300 - 96 - Content.Load<Texture2D>("UI/VisionaryTexture").Height / 2), Color.White);
                    expoNumeration = new BigNumber(cubeVisionary.FullCPS());
                    string cubeVisionaryCPS = $"[Cubes/Sec: {expoNumeration.ToString()}]";
                    spriteBatch.DrawString(MainGame.infoFont, cubeVisionaryCPS, new Vector2((cubeProducerPos.X - 190 + 520 - MainGame.font.MeasureString(cubeVisionaryCPS).X / 2), cubeProducerPos.Y + 300 + 66 - MainGame.font.MeasureString(cubeVisionaryCPS).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                    expoNumeration = new BigNumber(cubeVisionary.CubeMultiplier * (1 + _prismUpgrade1Multi)) * new BigNumber(primer.FullBoostPower() * overcharger.FullBoostPower());
                    string cubeVisionaryMulti = $"[Multiplier: {expoNumeration.ToString()}]";
                    spriteBatch.DrawString(MainGame.infoFont, cubeVisionaryMulti, new Vector2((cubeProducerPos.X - 190 + 544 - MainGame.font.MeasureString(cubeVisionaryMulti).X / 2), cubeProducerPos.Y + 300 + 102 - MainGame.font.MeasureString(cubeVisionaryMulti).Y / 2), new Color(136, 194, 252), 0, default, 0.4f, SpriteEffects.None, 0);
                    expoNumeration = new BigNumber(cubeVisionary.Quantity);
                    string cubeVisionaryInfo = $"{cubeVisionary.Quantity} Visionaries";
                    if (cubeVisionary.Quantity < 1000000)
                    {
                        cubeVisionaryInfo = $"{cubeVisionary.Quantity} Visionaries";
                    }
                    else cubeVisionaryInfo = $"{expoNumeration} Visionaries";
                    spriteBatch.DrawString(MainGame.infoFont, cubeVisionaryInfo, new Vector2((cubeProducerPos.X - 190 + 520 - MainGame.font.MeasureString(cubeVisionaryInfo).X / 2), cubeProducerPos.Y + 300 - 40 - MainGame.font.MeasureString(cubeVisionaryInfo).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                    cubeVisionaryButton.Draw(gameTime, spriteBatch);
                }

                if (cubeAmountAch8.IsUnlocked)
                {
                    //CUBE OMNI
                    spriteBatch.Draw(Content.Load<Texture2D>("UI/OmniTexture"), new Vector2(cubeProducerPos.X - 190 + 910 - Content.Load<Texture2D>("UI/OmniTexture").Width / 2, cubeProducerPos.Y + 300 - 96 - Content.Load<Texture2D>("UI/OmniTexture").Height / 2), Color.White);
                    expoNumeration = new BigNumber(cubeOmni.FullCPS());
                    string cubeOmniCPS = $"[Cubes/Sec: {expoNumeration.ToString()}]";
                    spriteBatch.DrawString(MainGame.infoFont, cubeOmniCPS, new Vector2((cubeProducerPos.X - 190 + 910 - MainGame.font.MeasureString(cubeOmniCPS).X / 2), cubeProducerPos.Y + 300 + 66 - MainGame.font.MeasureString(cubeOmniCPS).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                    expoNumeration = new BigNumber(cubeOmni.CubeMultiplier * (1 + _prismUpgrade1Multi)) * new BigNumber(primer.FullBoostPower() * overcharger.FullBoostPower());
                    string cubeOmniMulti = $"[Multiplier: {expoNumeration.ToString()}]";
                    spriteBatch.DrawString(MainGame.infoFont, cubeOmniMulti, new Vector2((cubeProducerPos.X - 190 + 910 + 24 - MainGame.font.MeasureString(cubeOmniMulti).X / 2), cubeProducerPos.Y + 300 + 102 - MainGame.font.MeasureString(cubeOmniMulti).Y / 2), new Color(136, 194, 252), 0, default, 0.4f, SpriteEffects.None, 0);
                    expoNumeration = new BigNumber(cubeOmni.Quantity);
                    string cubeOmniInfo = $"{cubeOmni.Quantity} Omnificents";
                    if (cubeOmni.Quantity < 1000000)
                    {
                        cubeOmniInfo = $"{cubeOmni.Quantity} Omnificents";
                    }
                    else cubeOmniInfo = $"{expoNumeration} Omnificents";
                    spriteBatch.DrawString(MainGame.infoFont, cubeOmniInfo, new Vector2((cubeProducerPos.X - 190 + 910 - MainGame.font.MeasureString(cubeOmniInfo).X / 2), cubeProducerPos.Y + 300 - 40 - MainGame.font.MeasureString(cubeOmniInfo).Y / 2), new Color(136, 194, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                    cubeOmniButton.Draw(gameTime, spriteBatch);
                }

                if (fluxuateAmountAch1.IsUnlocked)
                {
                    //PRIMER
                    spriteBatch.Draw(Content.Load<Texture2D>("UI/PrimerTexture"), new Vector2(cubeProducerPos.X + 130 - Content.Load<Texture2D>("UI/PrimerTexture").Width / 2, cubeProducerPos.Y + 600 - 72 - Content.Load<Texture2D>("UI/PrimerTexture").Height / 2), Color.White);
                    string primerDesc = $"[All Cube generation 0.25x/Level]";
                    if(fluxUpgrade1.IsActive)
                    {
                        primerDesc = $"[All Cube generation 0.45x/Level]";
                    }
                    else primerDesc = $"[All Cube generation 0.25x/Level]";
                    spriteBatch.DrawString(MainGame.infoFont, primerDesc, new Vector2((cubeProducerPos.X + 145 - MainGame.font.MeasureString(primerDesc).X / 2), cubeProducerPos.Y + 662 - MainGame.font.MeasureString(primerDesc).Y / 2), new Color(136, 252, 252), 0, default, 0.5f, SpriteEffects.None, 0);

                    expoNumeration = new BigNumber(primer.FullBoostPower() * overcharger.FullBoostPower());
                    string primerPower = $"[All Cube Multiplier: {expoNumeration.ToString()}]";
                    spriteBatch.DrawString(MainGame.infoFont, primerPower, new Vector2((cubeProducerPos.X + 175 - MainGame.font.MeasureString(primerPower).X / 2), cubeProducerPos.Y + 702 - MainGame.font.MeasureString(primerPower).Y / 2), new Color(136, 252, 252), 0, default, 0.4f, SpriteEffects.None, 0);
                    expoNumeration = new BigNumber(primer.Quantity);
                    string primerLevel = $"Primer Level: {primer.Quantity}";
                    if (primer.Quantity < 1000000)
                    {
                        primerLevel = $"Primer Level: {primer.Quantity}";
                    }
                    else primerLevel = $"Primer Level: {expoNumeration}";
                    spriteBatch.DrawString(MainGame.infoFont, primerLevel, new Vector2((cubeProducerPos.X + 135 - MainGame.font.MeasureString(primerLevel).X / 2), cubeProducerPos.Y + 600 - 35 - MainGame.font.MeasureString(primerLevel).Y / 2), new Color(136, 252, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                    primerButton.Draw(gameTime, spriteBatch);
                }
                if (fluxuateAmountAch2.IsUnlocked)
                {
                    //OVERCHARGER
                    spriteBatch.Draw(Content.Load<Texture2D>("UI/OverchargerTexture"), new Vector2(cubeProducerPos.X + 780 + 130 - Content.Load<Texture2D>("UI/OverchargerTexture").Width / 2, cubeProducerPos.Y + 600 - 72 - Content.Load<Texture2D>("UI/OverchargerTexture").Height / 2), Color.White);
                    string overchargerDesc = $"[Primer multiplier 0.15x/Level]";
                    if (fluxUpgrade2.IsActive)
                    {
                        overchargerDesc = $"[Primer multiplier boost 0.25x/Level]";
                    }
                    else overchargerDesc = $"[Primer multiplier boost 0.15x/Level]";
                    spriteBatch.DrawString(MainGame.infoFont, overchargerDesc, new Vector2((cubeProducerPos.X + 780 + 142 - MainGame.font.MeasureString(overchargerDesc).X / 2), cubeProducerPos.Y + 662 - MainGame.font.MeasureString(overchargerDesc).Y / 2), new Color(136, 252, 252), 0, default, 0.5f, SpriteEffects.None, 0);

                    expoNumeration = new BigNumber(overcharger.FullBoostPower());
                    string overchargerPower = $"[Primer Multiplier: {expoNumeration.ToString()}]";
                    spriteBatch.DrawString(MainGame.infoFont, overchargerPower, new Vector2((cubeProducerPos.X + 780 + 170 - MainGame.font.MeasureString(overchargerPower).X / 2), cubeProducerPos.Y + 702 - MainGame.font.MeasureString(overchargerPower).Y / 2), new Color(136, 252, 252), 0, default, 0.4f, SpriteEffects.None, 0);
                    expoNumeration = new BigNumber(overcharger.Quantity);
                    string overchargerLevel = $"Overcharger Level: {overcharger.Quantity}";
                    if (overcharger.Quantity < 1000000)
                    {
                        overchargerLevel = $"Overcharger Level: {overcharger.Quantity}";
                    }
                    else overchargerLevel = $"Overcharger Level: {expoNumeration}";
                    spriteBatch.DrawString(MainGame.infoFont, overchargerLevel, new Vector2((cubeProducerPos.X + 780 + 135 - MainGame.font.MeasureString(overchargerLevel).X / 2), cubeProducerPos.Y + 600 - 35 - MainGame.font.MeasureString(overchargerLevel).Y / 2), new Color(136, 252, 252), 0, default, 0.5f, SpriteEffects.None, 0);
                    overchargerButton.Draw(gameTime, spriteBatch);
                }
            }
            spriteBatch.Draw(Content.Load<Texture2D>("UI/CubeTexture"), new Vector2(1620 - 23, 50 - 6), Color.White);
            if (cubeAmountFluxUnlock.IsUnlocked)
            {
                spriteBatch.Draw(Content.Load<Texture2D>("UI/FluxTexture"), new Vector2(1620 - 23, 50 + 44), Color.White);
            }
            if (cubeAmountAch9.IsUnlocked)
            {
                spriteBatch.Draw(Content.Load<Texture2D>("UI/PrismTexture"), new Vector2(1620 - 23, 50 + 94), Color.White);
            }
            if (ritualAmountAch1.IsUnlocked)
            {
                spriteBatch.Draw(Content.Load<Texture2D>("UI/FractalTexture"), new Vector2(1620 - 23, 50 + 144), Color.White);
            }

            // Draw UI elements
            foreach (var component in _gameComponents) component.Draw(gameTime, spriteBatch);
            if (ritualAmountAch1.IsUnlocked) fractGenButton.Draw(gameTime, spriteBatch);
            if (cubeAmountAch17.IsUnlocked) sigilsButton.Draw(gameTime, spriteBatch);
            titleLabel.Draw(spriteBatch);
            cubeLabel.Draw(spriteBatch);
            if(cubeAmountFluxUnlock.IsUnlocked) fluxLabel.Draw(spriteBatch);
            if(cubeAmountAch9.IsUnlocked) prismLabel.Draw(spriteBatch);
            if(ritualAmountAch1.IsUnlocked) fractalLabel.Draw(spriteBatch);
            if(cubeAmountAch17.IsUnlocked) sigilCubeLabel.Draw(spriteBatch);
            DrawColorLines(spriteBatch);
            DrawHoverText(spriteBatch);
            DrawFluxHoverText(spriteBatch);
            _achievementPopup.Draw(spriteBatch, font);
            if (_confirmationPopup != null)
            {
                MouseState mouseState = Mouse.GetState();
                _confirmationPopup.Draw(spriteBatch, new Point(mouseState.X, mouseState.Y));
            }
            spriteBatch.End();

            
            
            

            base.Draw(gameTime);
        }
       
        private void DrawMidArea(SpriteBatch spriteBatch)
        {
            Rectangle backgroundRect = new Rectangle(250 + 25, 0, 1280, 2000);
            Color backgroundColor = new Color(36, 36, 36, 255); 
            Texture2D backgroundTexture = new Texture2D(GraphicsDevice, 1, 1);
            backgroundTexture.SetData(new[] { Color.White });
            spriteBatch.Draw(backgroundTexture, backgroundRect, backgroundColor);
        }  
        private void DrawColorLines(SpriteBatch spriteBatch)
        {
            Rectangle backgroundRect = new Rectangle(250 + 25, 0, 16, 2000);
            Rectangle backgroundRect2 = new Rectangle(250 + 1280 + 25, 0, 16, 2000);
            Color colorColorCOLOR = new Color(29, 29, 29, 255); 
            Texture2D backgroundTexture = new Texture2D(GraphicsDevice, 1, 1);
            backgroundTexture.SetData(new[] { colorColorCOLOR });
            spriteBatch.Draw(backgroundTexture, backgroundRect, colorLineColor);
            spriteBatch.Draw(backgroundTexture, backgroundRect2, colorLineColor);
 
        } 
        private void DrawHoverText(SpriteBatch spriteBatch)
        {
            if (!string.IsNullOrEmpty(currentHoverText))
            {
                var scaleX = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / MainGame.DesignWidth;
                var scaleY = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / MainGame.DesignHeight;

                Vector2 textSize = font.MeasureString(currentHoverText);
                Vector2 textPosition = new Vector2(Mouse.GetState().X + 10, Mouse.GetState().Y + 10);
                int screenWidth = 1920;
                int screenHeight = 1080;
                Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

                textSize *= new Vector2(scaleX, scaleY);

                Vector2 adjustedTextPosition = new Vector2(MathHelper.Clamp(mousePosition.X + 10, 0, screenWidth - textSize.X), MathHelper.Clamp(mousePosition.Y + 10, 0, screenHeight - textSize.Y));
                adjustedTextPosition *= new Vector2(scaleX, scaleY);

                // Create the background texture with a padding around the text
                int padding = 5; // Adjust the padding value as desired
                Rectangle backgroundRect = new Rectangle((int)adjustedTextPosition.X - padding, (int)adjustedTextPosition.Y - padding, (int)textSize.X + padding * 2, (int)textSize.Y + padding * 2);

                // Draw the background texture
                Color backgroundColor = new Color(0, 0, 0, 168); // Adjust the background color and transparency as desired
                Texture2D backgroundTexture = new Texture2D(GraphicsDevice, 1, 1);
                backgroundTexture.SetData(new[] { Color.White });
                spriteBatch.Draw(backgroundTexture, backgroundRect, backgroundColor);

                DrawColoredText(spriteBatch, font, currentHoverText, adjustedTextPosition, new Vector2(scaleX, scaleY));
            }
        }
        private void DrawFluxHoverText(SpriteBatch spriteBatch)
        {
            if (!string.IsNullOrEmpty(currentFluxHoverText))
            {
                var scaleX = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / MainGame.DesignWidth;
                var scaleY = (float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / MainGame.DesignHeight;

                Vector2 textSize = font.MeasureString(currentFluxHoverText);
                Vector2 textPosition = new Vector2(Mouse.GetState().X + 10, Mouse.GetState().Y + 10);
                int screenWidth = 1920;
                int screenHeight = 1080;
                Vector2 mousePosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

                textSize *= new Vector2(scaleX, scaleY);

                Vector2 adjustedTextPosition = new Vector2(MathHelper.Clamp(mousePosition.X + 10, 0, screenWidth - textSize.X), MathHelper.Clamp(mousePosition.Y + 10, 0, screenHeight - textSize.Y));
                adjustedTextPosition *= new Vector2(scaleX, scaleY);

                // Create the background texture with a padding around the text
                int padding = 5; // Adjust the padding value as desired
                Rectangle backgroundRect = new Rectangle((int)adjustedTextPosition.X - padding, (int)adjustedTextPosition.Y - padding, (int)textSize.X + padding * 2, (int)textSize.Y + padding * 2);

                // Draw the background texture
                Color backgroundColor = new Color(0, 0, 0, 168); // Adjust the background color and transparency as desired
                Texture2D backgroundTexture = new Texture2D(GraphicsDevice, 1, 1);
                backgroundTexture.SetData(new[] { Color.White });
                spriteBatch.Draw(backgroundTexture, backgroundRect, backgroundColor);

                // Scale the font
                DrawColoredText(spriteBatch, font, currentFluxHoverText, adjustedTextPosition, new Vector2(scaleX, scaleY));
            }
        }

        public void DrawColoredText(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 position, Vector2 scale)
        {
            string[] lines = text.Split('\n');
            float lineHeight = font.MeasureString("A").Y;

            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "[c:" }, StringSplitOptions.None);
                Vector2 currentPos = position;

                for (int i = 0; i < parts.Length; i++)
                {
                    int colorEndIndex = parts[i].IndexOf("]");

                    if (colorEndIndex > -1)
                    {
                        string hexColor = parts[i].Substring(0, colorEndIndex);
                        string content = parts[i].Substring(colorEndIndex + 1);

                        Color color = Color.FromNonPremultiplied(
                            int.Parse(hexColor.Substring(0, 2), NumberStyles.HexNumber),
                            int.Parse(hexColor.Substring(2, 2), NumberStyles.HexNumber),
                            int.Parse(hexColor.Substring(4, 2), NumberStyles.HexNumber),
                            255);

                        spriteBatch.DrawString(font, content, currentPos, color, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
                        currentPos.X += font.MeasureString(content).X;
                    }
                    else
                    {
                        spriteBatch.DrawString(font, parts[i], currentPos, Color.White, 0, Vector2.Zero, scale, SpriteEffects.None, 0);
                        currentPos.X += font.MeasureString(parts[i]).X;

                    }
                }
                position.Y += lineHeight;
            }
        }
        public void ShowAchievementPopup(string achievementText, string achievementReqs)
        {
            _achievementPopup.Show(achievementText, achievementReqs, GraphicsDevice);
        }

        
    }
}