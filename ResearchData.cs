using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace BetterLife_Buildings

{
    internal class ResearchDt : IResearchNodesData
    {
        public void RegisterData(ProtoRegistrator registrator)
        {


            //ResearchNodeProto barrierNodeProto =
            //    registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.VehicleCapIncrease3);

            ResearchNodeProto nodeProto = registrator.ResearchNodeProtoBuilder
                
                .Start("Buildings, Decorations", BetterLIDs.Research.Buildings,6)
                .Description("McDonalds, KFC, more to come...")
                .AddLayoutEntityToUnlock(BetterLIDs.Buildings.McDonalds)
                .AddLayoutEntityToUnlock(BetterLIDs.Buildings.KFC)
                .AddRequiredProto(Ids.Research.Cp3Packing)
                .AddRequirementForLifetimeProduction(Ids.Products.ConstructionParts2,100)
                 
                .BuildAndAdd();

            nodeProto.GridPosition = new Vector2i(0, -8);
            nodeProto.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.CpPacking));

        }
    }
}
