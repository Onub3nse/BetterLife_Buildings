
using RecipeID = Mafi.Core.Factory.Recipes.RecipeProto.ID;
using ProductID = Mafi.Core.Products.ProductProto.ID;
using Mafi.Base;
using Mafi.Collections;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;
using Mafi.Serialization;
using Mafi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using Mafi.Unity;


namespace BetterLife;
[GlobalDependency(RegistrationMode.AsEverything, false, false)]
public class ProductColorManager
{

    public ProductColorManager(ProtosDb pdb)
    {
        protosDb = pdb;
        Init();
    }
    private ProtosDb protosDb;

    public Dict<ProductProto.ID, UnityEngine.Color> pColor = new Dict<ProductID, UnityEngine.Color>();

    public Dict<ProductProto.ID, UnityEngine.Color> defaultpColor = new Dict<ProductProto.ID, UnityEngine.Color>

        {
            {Ids.Products.Acid,                new UnityEngine.Color(1,1,0.5f)          },
            {Ids.Products.Ammonia,             new UnityEngine.Color(0.7f, 0.7f, 0.7f ) },
            {Ids.Products.Anesthetics,         new ColorRgba(112,138,255).ToColor32() },
            {Ids.Products.AnimalFeed,          new ColorRgba(255,244,33).ToColor32() },
            {Ids.Products.Antibiotics,         new ColorRgba(173,165,255).ToColor32() },
            {Ids.Products.Biomass,             new ColorRgba(99,127,93).ToColor32()},
            {Ids.Products.BlanketFuel,         new ColorRgba(193,133,36).ToColor32()},
            {Ids.Products.BlanketFuelEnriched, new ColorRgba(203,143,46).ToColor32()},
            {Ids.Products.Bread,               new ColorRgba(239,189,103).ToColor32()},
            {Ids.Products.Bricks,              new ColorRgba(239,143,0).ToColor32()},
            {Ids.Products.Brine,               new ColorRgba(9,239,202).ToColor32()},
            {Ids.Products.BrokenGlass,         new ColorRgba(182,239,232).ToColor32()},
            {Ids.Products.Cake,                new ColorRgba(239,157,122).ToColor32()},
            {Ids.Products.Canola,              new ColorRgba(247, 193, 60).ToColor32()},
            {Ids.Products.CarbonDioxide,       new ColorRgba(72, 72, 72).ToColor32()},
            {Ids.Products.Cement,              new ColorRgba(180, 192, 183).ToColor32()},
            {Ids.Products.Chicken,             new ColorRgba(255, 245, 235).ToColor32()},
            {Ids.Products.ChickenCarcass,      new ColorRgba(253, 206, 168).ToColor32()},
            {Ids.Products.ChilledWater,        new ColorRgba(19, 238, 237).ToColor32()},
            {Ids.Products.Chlorine,            new ColorRgba(209, 255, 211).ToColor32()},
            {Ids.Products.Coal,                new ColorRgba(64, 64, 64).ToColor32()},
            {Ids.Products.Compost,             new ColorRgba(51, 33, 22).ToColor32()},
            {Ids.Products.Computing,           new ColorRgba(51, 51, 51).ToColor32()},
            {Ids.Products.ConcreteSlab,        new ColorRgba(221, 214, 209).ToColor32()},
            {Ids.Products.ConstructionParts,   new ColorRgba(221, 221, 221).ToColor32()},
            {Ids.Products.ConstructionParts2,  new ColorRgba(227, 193, 59).ToColor32()},
            {Ids.Products.ConstructionParts3,  new ColorRgba(227, 75, 59).ToColor32()},
            {Ids.Products.ConstructionParts4,  new ColorRgba(138, 101, 215).ToColor32()},
            {Ids.Products.ConsumerElectronics, new ColorRgba(59, 153, 220).ToColor32()},
            {Ids.Products.CookingOil,          new ColorRgba(226, 187, 50).ToColor32()},
            {Ids.Products.Copper,              new ColorRgba(179, 117, 74).ToColor32()},
            {Ids.Products.CopperOre,           new ColorRgba(61, 131, 59).ToColor32()},
            {Ids.Products.CopperScrap,         new ColorRgba(201, 131, 82).ToColor32()},
            {Ids.Products.CopperScrapPressed,  new ColorRgba(201, 131, 82).ToColor32()},
            {Ids.Products.CoreFuel,            new ColorRgba(172, 45, 42).ToColor32()},
            {Ids.Products.CoreFuelDirty,       new ColorRgba(122, 94, 4).ToColor32()},
            {Ids.Products.Corn,                new ColorRgba(130, 185, 83).ToColor32()},
            {Ids.Products.CornMash,            new ColorRgba(182, 171, 62).ToColor32()},
            {Ids.Products.CrudeOil,            new ColorRgba(88, 93, 106).ToColor32()},
            {Ids.Products.Diesel,              new ColorRgba(149, 117, 31).ToColor32()},
            {Ids.Products.Dirt,                new ColorRgba(181, 115, 72).ToColor32()},
            {Ids.Products.Disinfectant,        new ColorRgba(116, 120, 213).ToColor32()},
            {Ids.Products.Eggs,                new ColorRgba(255, 201, 147).ToColor32()},
            {Ids.Products.Electronics,         new ColorRgba(215, 160, 69).ToColor32()},
            {Ids.Products.Electronics2,        new ColorRgba(1, 153, 83).ToColor32()},
            {Ids.Products.Electronics3,        new ColorRgba(120, 30, 13).ToColor32()},
            {Ids.Products.Ethanol,             new ColorRgba(185, 190, 200).ToColor32()},
            {Ids.Products.Exhaust,             new ColorRgba(71, 78, 82).ToColor32()},
            {Ids.Products.FertilizerChemical,  new ColorRgba(227, 210, 168).ToColor32()},
            {Ids.Products.FertilizerChemical2, new ColorRgba(206, 201, 41).ToColor32()},
            {Ids.Products.FertilizerOrganic,   new ColorRgba(120, 155, 97).ToColor32()},
            {Ids.Products.FilterMedia,         new ColorRgba(199, 183, 83).ToColor32()},
            {Ids.Products.FissionProduct,      new ColorRgba(60, 111, 182).ToColor32()},
            {Ids.Products.Flour,               new ColorRgba(114, 164, 226).ToColor32()},
            {Ids.Products.Flowers,             new ColorRgba(99, 160, 59).ToColor32()},
            {Ids.Products.FoodPack,            new ColorRgba(184, 134, 94).ToColor32()},
            {Ids.Products.Fruit,               new ColorRgba(227, 51, 94).ToColor32()},
            {Ids.Products.FuelGas,             new ColorRgba(204, 112, 31).ToColor32()},
            {Ids.Products.Glass,               new ColorRgba(120, 183, 180).ToColor32()},
            {Ids.Products.GlassMix,            new ColorRgba(192, 176, 150).ToColor32()},
            {Ids.Products.Gold,                new ColorRgba(212, 169, 43).ToColor32()},
            {Ids.Products.GoldOre,             new ColorRgba(119, 98, 63).ToColor32()},
            {Ids.Products.GoldOreConcentrate,  new ColorRgba(169, 137, 47).ToColor32()},
            {Ids.Products.GoldOreCrushed,      new ColorRgba(122, 101, 66).ToColor32()},
            {Ids.Products.GoldOrePowder,       new ColorRgba(107, 91, 81).ToColor32()},
            {Ids.Products.GoldScrap,           new ColorRgba(201, 194, 75).ToColor32()},
            {Ids.Products.GoldScrapPressed,    new ColorRgba(200, 192, 74).ToColor32()},
            {Ids.Products.Graphite,            new ColorRgba(104, 101, 101).ToColor32()},
            {Ids.Products.Gravel,              new ColorRgba(159, 144, 137).ToColor32()},
            {Ids.Products.Heat,                new ColorRgba(201, 24, 76).ToColor32()},
            {Ids.Products.HeavyOil,            new ColorRgba(103, 79, 21).ToColor32()},
            {Ids.Products.HouseholdAppliances, new ColorRgba(179, 206, 227).ToColor32()},
            {Ids.Products.HouseholdGoods,      new ColorRgba(138, 182, 89).ToColor32()},
            {Ids.Products.Hydrogen,            new ColorRgba(202, 200, 200).ToColor32()},
            {Ids.Products.HydrogenFluoride,    new ColorRgba(176, 172, 61).ToColor32()},
            {Ids.Products.ImpureCopper,        new ColorRgba(161, 87, 57).ToColor32()},
            {Ids.Products.Iron,                new ColorRgba(128,128,128).ToColor32()},
            {Ids.Products.IronOre,             new ColorRgba(152, 75, 53).ToColor32()},
            {Ids.Products.IronOreCrushed,      new ColorRgba(172, 77, 55).ToColor32()},
            {Ids.Products.IronScrap,           new ColorRgba(102, 102, 102).ToColor32()},
            {Ids.Products.IronScrapPressed,    new ColorRgba(92, 92, 92).ToColor32()},
            {Ids.Products.LabEquipment,        new ColorRgba(227, 227, 227).ToColor32()},
            {Ids.Products.LabEquipment2,       new ColorRgba(221, 189, 59).ToColor32()},
            {Ids.Products.LabEquipment3,       new ColorRgba(227, 75, 59).ToColor32()},
            {Ids.Products.LabEquipment4,       new ColorRgba(125, 92, 194).ToColor32()},
            {Ids.Products.LightOil,            new ColorRgba(127, 140, 67).ToColor32()},
            {Ids.Products.Limestone,           new ColorRgba(186, 186, 141).ToColor32()},
            {Ids.Products.ManufacturedSand,    new ColorRgba(168, 168, 168).ToColor32()},
            {Ids.Products.Meat,                new ColorRgba(204, 88, 97).ToColor32()},
            {Ids.Products.MeatTrimmings,       new ColorRgba(219, 137, 138).ToColor32()},
            {Ids.Products.MechanicalParts,     new ColorRgba(179, 177, 180).ToColor32()},
            {Ids.Products.MechanicalPower,     new ColorRgba(179, 179, 180).ToColor32()},
            {Ids.Products.MedicalEquipment,    new ColorRgba(84, 133, 208).ToColor32()},
            {Ids.Products.MedicalSupplies,     new ColorRgba(227, 227, 227).ToColor32()},
            {Ids.Products.MedicalSupplies2,    new ColorRgba(208, 177, 53).ToColor32()},
            {Ids.Products.MedicalSupplies3,    new ColorRgba(208, 67, 53).ToColor32()},
            {Ids.Products.MediumOil,           new ColorRgba(123, 95, 144).ToColor32()},
            {Ids.Products.Microchips,          new ColorRgba(227, 176, 76).ToColor32()},
            {Ids.Products.MicrochipsStage1A,   new ColorRgba(183, 150, 191).ToColor32()},
            {Ids.Products.MicrochipsStage1B,   new ColorRgba(227, 199, 182).ToColor32()},
            {Ids.Products.MicrochipsStage1C,   new ColorRgba(180, 149, 168).ToColor32()},
            {Ids.Products.MicrochipsStage2A,   new ColorRgba(213, 157, 226).ToColor32()},
            {Ids.Products.MicrochipsStage2B,   new ColorRgba(203, 166, 142).ToColor32()},
            {Ids.Products.MicrochipsStage2C,   new ColorRgba(184, 130, 161).ToColor32()},
            {Ids.Products.MicrochipsStage3A,   new ColorRgba(179, 116, 194).ToColor32()},
            {Ids.Products.MicrochipsStage3B,   new ColorRgba(227, 172, 136).ToColor32()},
            {Ids.Products.MicrochipsStage3C,   new ColorRgba(160, 131, 162).ToColor32()},
            {Ids.Products.MicrochipsStage4A,   new ColorRgba(206, 113, 227).ToColor32()},
            {Ids.Products.MicrochipsStage4B,   new ColorRgba(227, 157, 113).ToColor32()},
            {Ids.Products.MoltenCopper,        new ColorRgba(226, 191, 35).ToColor32()},
            {Ids.Products.MoltenGlass,         new ColorRgba(120, 183, 180).ToColor32()},
            {Ids.Products.MoltenIron,          new ColorRgba(226, 147, 35).ToColor32()},
            {Ids.Products.MoltenSilicon,       new ColorRgba(227, 177, 48).ToColor32()},
            {Ids.Products.MoltenSteel,         new ColorRgba(226, 192, 39).ToColor32()},
            {Ids.Products.Morphine,            new ColorRgba(37, 190, 134).ToColor32()},
            {Ids.Products.MoxRod,              new ColorRgba(144, 144, 81).ToColor32()},
            {Ids.Products.Naphtha,             new ColorRgba(192, 184, 66).ToColor32()},
            {Ids.Products.Nitrogen,            new ColorRgba(103, 137, 193).ToColor32()},
            {Ids.Products.Oxygen,              new ColorRgba(187, 61, 61).ToColor32()},
            {Ids.Products.Paper,               new ColorRgba(219, 219, 220).ToColor32()},
            {Ids.Products.PCB,                 new ColorRgba(8, 150, 82).ToColor32()},
            {Ids.Products.Plastic,             new ColorRgba(45, 151, 175).ToColor32()},
            {Ids.Products.Plutonium,           new ColorRgba(84, 153, 67).ToColor32()},
            {Ids.Products.PollutedAir,         new ColorRgba(38, 38, 38).ToColor32()},
            {Ids.Products.PollutedWater,       new ColorRgba(80, 47, 32).ToColor32()},
            {Ids.Products.PolySilicon,         new ColorRgba(177, 173, 155).ToColor32()},
            {Ids.Products.Poppy,               new ColorRgba(97, 188, 102).ToColor32()},
            {Ids.Products.Potato,              new ColorRgba(102, 60, 18).ToColor32()},
            {Ids.Products.Quartz,              new ColorRgba(198, 206, 217).ToColor32()},
            {Ids.Products.QuartzCrushed,       new ColorRgba(182, 181, 164).ToColor32()},
            {Ids.Products.Recyclables,         new ColorRgba(129, 93, 60).ToColor32()},
            {Ids.Products.RecyclablesPressed,  new ColorRgba(145, 111, 42).ToColor32()},
            {Ids.Products.RetiredWaste,        new ColorRgba(166, 162, 150).ToColor32()},
            {Ids.Products.Rock,                new ColorRgba(181, 164, 155).ToColor32()},
            {Ids.Products.Rubber,              new ColorRgba(89, 96, 106).ToColor32()},
            {Ids.Products.Salt,                new ColorRgba(227, 227, 227).ToColor32()},
            {Ids.Products.Sand,                new ColorRgba(203, 187, 84).ToColor32()},
            {Ids.Products.Sausage,             new ColorRgba(208, 109, 59).ToColor32()},
            {Ids.Products.Seawater,            new ColorRgba(13, 160, 227).ToColor32()},
            {Ids.Products.SiliconWafer,        new ColorRgba(227, 227, 226).ToColor32()},
            {Ids.Products.Slag,                new ColorRgba(132, 130, 128).ToColor32()},
            {Ids.Products.SlagCrushed,         new ColorRgba(173, 172, 168).ToColor32()},
            {Ids.Products.Sludge,              new ColorRgba(85, 63, 43).ToColor32()},
            {Ids.Products.Snack,               new ColorRgba(189, 63, 55).ToColor32()},
            {Ids.Products.SolarCell,           new ColorRgba(40, 135, 205).ToColor32()},
            {Ids.Products.SolarCellMono,       new ColorRgba(10, 72, 107).ToColor32()},
            {Ids.Products.SourWater,           new ColorRgba(97, 227, 138).ToColor32()},
            {Ids.Products.Soybean,             new ColorRgba(149, 193, 120).ToColor32()},
            {Ids.Products.SpentFuel,           new ColorRgba(195, 159, 76).ToColor32()},
            {Ids.Products.SpentMox,            new ColorRgba(189, 111, 64).ToColor32()},
            {Ids.Products.SteamDepleted,       new ColorRgba(128, 180, 222).ToColor32()},
            {Ids.Products.SteamHi,             new ColorRgba(189, 208, 223).ToColor32()},
            {Ids.Products.SteamLo,             new ColorRgba(139, 184, 222).ToColor32()},
            {Ids.Products.SteamSp,             new ColorRgba(188, 140, 154).ToColor32()},
            {Ids.Products.Steel,               new ColorRgba(157, 157, 157).ToColor32()},
            {Ids.Products.Sugar,               new ColorRgba(203, 176, 142).ToColor32()},
            {Ids.Products.SugarCane,           new ColorRgba(215, 185, 78).ToColor32()},
            {Ids.Products.Sulfur,              new ColorRgba(199, 180, 41).ToColor32()},
            {Ids.Products.Tofu,                new ColorRgba(227, 211, 191).ToColor32()},
            {Ids.Products.ToxicSlurry,         new ColorRgba(178, 180, 16).ToColor32()},
            {Ids.Products.TreeSapling,         new ColorRgba(108, 172, 145).ToColor32()},
            {Ids.Products.UraniumDepleted,     new ColorRgba(115, 185, 115).ToColor32()},
            {Ids.Products.UraniumEnriched,     new ColorRgba(158, 255, 158).ToColor32()},
            {Ids.Products.UraniumEnriched20,   new ColorRgba(158, 255, 158).ToColor32()},
            {Ids.Products.UraniumOre,          new ColorRgba(162, 186, 145).ToColor32()},
            {Ids.Products.UraniumOreCrushed,   new ColorRgba(156, 173, 153).ToColor32()},
            {Ids.Products.UraniumReprocessed,  new ColorRgba(87, 96, 85).ToColor32()},
            {Ids.Products.UraniumRod,          new ColorRgba(147, 147, 147).ToColor32()},
            {Ids.Products.Vegetables,          new ColorRgba(162, 170, 89).ToColor32()},
            {Ids.Products.VehicleParts,        new ColorRgba(227, 227, 227).ToColor32()},
            {Ids.Products.VehicleParts2,       new ColorRgba(202, 171, 51).ToColor32()},
            {Ids.Products.VehicleParts3,       new ColorRgba(172, 55, 43).ToColor32()},
            {Ids.Products.Waste,               new ColorRgba(177, 158, 150).ToColor32()},
            {Ids.Products.WastePressed,        new ColorRgba(106, 146, 136).ToColor32()},
            {Ids.Products.WasteWater,          new ColorRgba(183, 112, 17).ToColor32()},
            {Ids.Products.Water,               new ColorRgba(52, 186, 227).ToColor32()},
            {Ids.Products.Wheat,               new ColorRgba(209, 177, 53).ToColor32()},
            {Ids.Products.Wood,                new ColorRgba(160, 102, 38).ToColor32()},
            {Ids.Products.Woodchips,           new ColorRgba(197, 179, 123).ToColor32()},
            {Ids.Products.Yellowcake,          new ColorRgba(161, 165, 67).ToColor32()},

        };
    public ProductColorManager Init()
    {
        pColor.Clear();
        foreach (var el in defaultpColor)
        {
            pColor.Add(el.Key, el.Value);
        }
        return null;
        //string pColorsFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //string pColorsFile = pColorsFolder + "\\ProductColors.xml";

        //if (File.Exists(pColorsFile)) 
        //{
        //    pColor.Clear();
        //    XDocument doc = XDocument.Load(pColorsFile);
        //    foreach (var el in doc.Element("ProductColor").Elements())
        //    {
        //        pColor.Add(new ProductProto.ID(el.Name.ToString()), ToColor(el.Value));
        //    }
        //    return this;
        //}
        //Save();
        //return null;
    }
    public bool Save()
    {
        IOrderedEnumerable<ProductProto> sortedProductProtos = protosDb.Filter<ProductProto>(pp => pp.IsAvailable).OrderBy(x => x.Strings.Name.TranslatedString);
        string pColorsFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string pColorsFile = pColorsFolder + "\\ProductColors.xml";
        if (File.Exists (pColorsFile))
            File.Delete(pColorsFile);
        XDocument doc = new XDocument();
        XElement el = new XElement("ProductColor");
        byte rv, gv, bv, av;
        foreach (var vl in pColor)
        {
            rv = (byte)(vl.Value.r >= 1.0 ? 255 : (vl.Value.r <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.r * 256.0)));
            gv = (byte)(vl.Value.g >= 1.0 ? 255 : (vl.Value.g <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.g * 256.0)));
            bv = (byte)(vl.Value.b >= 1.0 ? 255 : (vl.Value.b <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.b * 256.0)));
            av = (byte)(vl.Value.a >= 1.0 ? 255 : (vl.Value.a <= 0.0 ? 0 : (Byte)Math.Floor(vl.Value.a * 256.0)));
            
            el.Add(new XElement(vl.Key.ToString(), vl.Value.r.ToString() + "," + vl.Value.g.ToString() + "," + vl.Value.b.ToString() + "," + vl.Value.a.ToString()));
        }

        foreach (ProductProto productProto in sortedProductProtos)
        {
            if (Find(productProto.Id) == false)
            {
                el.Add(new XElement(productProto.Id.ToString(), "255,0,255,255"));
            }
        }
        doc.Add(el);

        doc.Save(pColorsFile);
        return true;
    }
    public UnityEngine.Color ToColor(string color)
    {
        var arrColorFragments = color?.Split(',').Select(sFragment => { byte.TryParse(sFragment, out byte fragment); return fragment; }).ToArray();
        switch (arrColorFragments?.Length)
        {
            case 3:
                return new UnityEngine.Color(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2]);
            case 4:
                return new UnityEngine.Color(arrColorFragments[0], arrColorFragments[1], arrColorFragments[2], arrColorFragments[3]);
            default:
                return new UnityEngine.Color(255, 0, 255, 255);
        }
    }

    public bool AddProductColor(ProductProto.ID id, UnityEngine.Color color)
    {
        if (!pColor.TryGetValue(id, out var c))
        { 
            Log.Debug("Color allready exists."); 
            return false; 
        }
          
        else
        {
            pColor.Add(id, color);
            return true;
        }
    }
    public bool UpdateProductColor(ProductProto.ID iD, UnityEngine.Color color)
    {
        if (!pColor.TryGetValue(iD, out var c))
        {
            pColor[iD] = color;
            return true;
        }
        return false;

    }
    public bool RemoveProductColor(ProductProto.ID iD)
    {
        if (!pColor.TryGetValue(iD, out var c))
        {
            pColor.Remove(iD);
            return true;
        }
        return false;
    }
    public bool Find(ProductProto.ID id)
    {
        if (pColor.ContainsKey(id))
            return true;
        return false;
    }
    public UnityEngine.Color GetColor(ProductProto.ID iD, bool highlight)
    {

        UnityEngine.Color actualColor;
        ColorRgba colorRgba;

        if (!pColor.TryGetValue(iD, out actualColor ))
        {
            colorRgba = new ColorRgba(245, 0, 245, 245);

            if (highlight)
                colorRgba = AddToColor(new ColorRgba(245,0,245,245), 30);

            return colorRgba.ToColor32();
        }
        colorRgba = new ColorRgba((byte)actualColor.r, (byte)actualColor.g, (byte)actualColor.b);
        if (highlight)
            colorRgba = AddToColor(colorRgba, 30);

        actualColor = colorRgba.ToColor32();
        return actualColor;

    }

    public ColorRgba AddToColor(ColorRgba col, int val)
    {
        return new ColorRgba((int)((float)(int)col.R + val).Min(255f), (int)((float)(int)col.G + val).Min(255f), (int)((float)(int)col.B + val).Min(255f));
    }
//    private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

//    private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;
/*
    public static void Serialize(ProductColorManager value, BlobWriter writer)
    {
        if (writer.TryStartClassSerialization(value))
        {
            writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
        }
    }

    protected void SerializeData(BlobWriter writer)
    {
        
    }

    public static ProductColorManager Deserialize(BlobReader reader)
    {
        if (reader.TryStartClassDeserialization(out ProductColorManager obj, (Func<BlobReader, Type, ProductColorManager>)null))
        {
            reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
        }
        return obj;
    }

    protected void DeserializeData(BlobReader reader)
    {
        reader.RegisterInitAfterLoad<ProductColorManager>(this, "Init", InitPriority.Normal);
        //reader.RegisterResolvedMember<ProductColorManager>(this, "protosDb", typeof(ProtosDb), true);
    }
*/
    static ProductColorManager()
    {
  /*      s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
        {
            ((ProductColorManager)obj).SerializeData(writer);
        };
        s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
        {
            ((ProductColorManager)obj).DeserializeData(reader);
        };
  */
    }
}

public partial class BetterLIDs
{

    public partial class Recipes

    {
        public static readonly RecipeID easyRailParts = Ids.Recipes.CreateId("easyRailParts");
        public static readonly RecipeID EasyCement = Ids.Recipes.CreateId("EasyCement");
        public static readonly RecipeID SulfurBurn = Ids.Recipes.CreateId("SulfurBurn");
        public static readonly RecipeID ConstructionParts3C = Ids.Recipes.CreateId("ConstructionParts3C");
        public static readonly RecipeID ConstructionParts2C = Ids.Recipes.CreateId("ConstructionParts2C");
        public static readonly RecipeID ConstructionParts1C = Ids.Recipes.CreateId("ConstructionParts1C");
        public static readonly RecipeID EasyFertilizer1 = Ids.Recipes.CreateId("EasyFertilizer1");
        public static readonly RecipeID EasyFertilizer2 = Ids.Recipes.CreateId("EasyFertilizer2");
        public static readonly RecipeID VehiclePartsT1C = Ids.Recipes.CreateId("VehicleParts1C");
        public static readonly RecipeID VehiclePartsT2C = Ids.Recipes.CreateId("VehicleParts2C");
        public static readonly RecipeID MechanicalParts1C = Ids.Recipes.CreateId("MechanicalParts1C");
        public static readonly RecipeID Electronics1C = Ids.Recipes.CreateId("Electronics1C");
        public static readonly RecipeID HighPressTurbine1 = Ids.Recipes.CreateId("HighPressTurbine1");
        public static readonly RecipeID ResearchLab2C = Ids.Recipes.CreateId("ResearchLab2C");
        public static readonly RecipeID FuelGas1 = Ids.Recipes.CreateId("FuelGas1");
        public static readonly RecipeID Amonia1 = Ids.Recipes.CreateId("Amonia1C");
        public static readonly RecipeID MyBricks = Ids.Recipes.CreateId("MyBricks");
        public static readonly RecipeID SulfuricAcid1 = Ids.Recipes.CreateId("SulfuricAcid1");
        public static readonly RecipeID Naphtha1 = Ids.Recipes.CreateId("Naphtha1");
        public static readonly RecipeID Dummy = Ids.Recipes.CreateId("Dummy");
        public static readonly RecipeID EasyFuel = Ids.Recipes.CreateId("EasyFuel");
        public static readonly RecipeID RLab1 = Ids.Recipes.CreateId("rLab1");
        public static readonly RecipeID ScrapToIron = Ids.Recipes.CreateId("scrapIron");
        public static readonly RecipeID SourWater1 = Ids.Recipes.CreateId("Sourwater1");
        public static readonly RecipeID Maintenance1 = Ids.Recipes.CreateId("Maintenance1");
        public static readonly RecipeID Energy600mw = Ids.Recipes.CreateId("Energy600");
        
        //public static readonly RecipeID pTar = Ids.Recipes.CreateId("pTar");
        public static readonly RecipeID EasyBricks = Ids.Recipes.CreateId("EasyBricks");
        public static readonly RecipeID EasyFertilizerT3C = Ids.Recipes.CreateId("EasyFertilizer3");
        public static readonly RecipeID EasySulfur = Ids.Recipes.CreateId("EasySulfur");
        public static readonly RecipeID ConstructionParts4C = Ids.Recipes.CreateId("ConstructionParts4C");
        public static readonly RecipeID ResearchLab3C = Ids.Recipes.CreateId("ResearchLab3C");
        public static readonly RecipeID VehiclePartsT3C = Ids.Recipes.CreateId("VehicleParts3C");
        // Nuevos
        public static readonly RecipeID ResearchLab4C = Ids.Recipes.CreateId("ResearchLab4C");
        public static readonly RecipeID Cement1 = Ids.Recipes.CreateId("Cement1");
        public static readonly RecipeID Ethanol1 = Ids.Recipes.CreateId("Ethanol1");
        public static readonly RecipeID Exhaust1 = Ids.Recipes.CreateId("Exaust1");
    }


}