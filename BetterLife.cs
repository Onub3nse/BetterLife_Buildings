using Mafi.Base;
using Mafi.Core;
using Mafi.Core.Mods;
using System;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using System.Reflection;
using Mafi;
using Mafi.Collections;
using Mafi.Core.Game;
using Mafi.Core.Products;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace BetterLife_Buildings
{
    public sealed class BetterLifeBuildings: IDisposable, IMod, IModConfig
    {
        public BetterLifeBuildings(ModManifest modManifest)

        {
            this.manifest = modManifest;
            //Log.Info($"BetterLife: Applying harmony patch...");
            //var harmony = new Harmony("BetterLifePatch");
            //harmony.PatchAll(Assembly.GetExecutingAssembly());
            //Log.Info($"BetterLife: Harmony patch finished...");
        }
        public void Dispose()
        {
        }
        public ModJsonConfig JsonConfig
        {
            get
            {
                return new ModJsonConfig(this);
            }
        }

        public void ChangeConfigs(Lyst<IConfig> configs)
        {
        }
        private ModManifest manifest;

        public ModManifest Manifest
        {
            get
            {
                return this.manifest;
            }
        }
        public void MigrateJsonConfig(VersionSlim savedVersion, Dict<string, object> savedValues)
        {
        }
        public Option<IConfig> ModConfig { get; }
        public static Version ModVersion
        {
            get
            {
                return typeof(BetterLifeBuildings).Assembly.GetName().Version;
            }
        }
        public string Name
        {
            get
            {
                return typeof(BetterLifeBuildings).Assembly.GetName().Name;
            }
        }
        public int Version
        {
            get
            {
                return typeof(BetterLifeBuildings).Assembly.GetName().Version.Major * 100 + typeof(BetterLifeBuildings).Assembly.GetName().Version.Minor * 10 + typeof(BetterLifeBuildings).Assembly.GetName().Version.Build;
            }
        }

        public bool IsUiOnly => false;

        public void RegisterPrototypes(ProtoRegistrator registrator)
        {
            ProtosDb prototypesDb = registrator.PrototypesDb;

            Log.Info("$BetterLife.Buildings: Registering toolbars...");
            ToolbarCategoryProto toolbarParent = prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(BetterLIDs.ToolBars.buildingsParent, Proto.CreateStr(BetterLIDs.ToolBars.buildingsParent, "BL Buildings" ), 110f, "Assets/Buildings/icons/toolbar_Building.png", false, "BL BUILDINGS", null,null,null));
            Proto.ID building1 = BetterLIDs.ToolBars.buildings;
            Proto.Str str1 = Proto.CreateStr(BetterLIDs.ToolBars.buildings,"BL Buildings","",null );
            ToolbarCategoryProto parentCategory1 = toolbarParent;
            prototypesDb.Add<ToolbarCategoryProto>(new ToolbarCategoryProto(building1, str1, 110f, "Assets/Buildings/icons/toolbar_Building.png", false,"",null,null,parentCategory1));

            registrator.RegisterData<McDonaldBuilding>();
            registrator.RegisterData<KFCBuilding>();

            registrator.RegisterDataWithInterface<IResearchNodesData>();
 
        }
        public bool GameWasLoaded; 

        public void RegisterDependencies(DependencyResolverBuilder depBuilder, ProtosDb protosDb, bool gameWasLoaded)
        {
            //ProductColorManager myManager = new ProductColorManager(protosDb);
            //IOrderedEnumerable<ProductProto> sortedProductProtos = protosDb.Filter<ProductProto>(pp => pp.IsAvailable).OrderBy(x => x.Strings.Name.TranslatedString);
            //string pColorsFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //string pColorsFile = pColorsFolder + "\\ProductColors.xml";
            //Log.Debug($"BeTTerLife: ----------------------------> Found {sortedProductProtos.Count()} products");
            //Log.Debug($"BeTTerLife: ----------------------------> Reading Product Color Info...({pColorsFile})");
            //if (File.Exists(pColorsFile))
            //{
            //    myManager.pColor.Clear();
            //    XDocument doc = XDocument.Load(pColorsFile);
            //    foreach (var el in doc.Element("ProductColor").Elements())
            //    {   
            //        myManager.pColor.Add(new ProductProto.ID(el.Name.ToString()), myManager.ToColor(el.Value));
            //    }                
            //    Log.Debug($"BeTTerLife: ----------------------------> Found...{myManager.pColor.Count} products added.");
            //} else
            //{
            //    XDocument doc = new XDocument();
            //    XElement el = new XElement("ProductColor");
            //    int rv, gv, bv, av;
            //    foreach (var vl in myManager.pColor)
            //    {
            //        rv = vl.Value.r >= 1.0 ? 255 : (vl.Value.r <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.r * 256.0));
            //        gv = vl.Value.g >= 1.0 ? 255 : (vl.Value.g <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.g * 256.0));
            //        bv = vl.Value.b >= 1.0 ? 255 : (vl.Value.b <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.b * 256.0));
            //        av = vl.Value.a >= 1.0 ? 255 : (vl.Value.a <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.a * 256.0));
            //        el.Add(new XElement(vl.Key.ToString(), rv.ToString() + "," + gv.ToString() + "," + bv.ToString() + "," + av.ToString())); 
            //    }

            //    foreach(ProductProto productProto in sortedProductProtos)
            //    {
            //        if (myManager.Find(productProto.Id) == false)
            //        {
            //            el.Add(new XElement(productProto.Id.ToString(), "255,0,255,255"));
            //        }
            //    }
            //    doc.Add(el);

            //    doc.Save(pColorsFile);
                
                
            //    //StreamWriter writer = new StreamWriter(pColorsFile);
            //    //foreach(var iD in myManager.pColor)
            //    //{
            //    //    string pLine = iD.Key + ":" + iD.Value;
            //    //    writer.WriteLine(pLine);
            //    //}

            //    //writer.Close();
            //}


        }
        public void Initialize(DependencyResolver resolver, bool gameWasLoaded)
        {
            GameWasLoaded = gameWasLoaded;

        }

        public void EarlyInit(DependencyResolver resolver)
        {

        }

    }

}
