using Mafi.Base;
using Mafi.Core.Research;
using ResNodeID = Mafi.Core.Research.ResearchNodeProto.ID;

namespace BetterLife_Buildings;


public partial class BetterLIDs
{
    public partial class Research
    {
//        [ResearchCosts(difficulty: 1)]
        public static readonly ResNodeID Buildings = Ids.Research.CreateId("buildings");
    }
}
