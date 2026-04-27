using Mafi.Base;
using Mafi.Core.Factory.Machines;
using Unity.Collections;
using static BetterLife.Prototypes.CustomEntity;
using ToolbarID = Mafi.Core.Prototypes.Proto.ID;


namespace BetterLife_Buildings
{
    public partial class BetterLIDs
    {
        public partial class ToolBars
        {
            public static readonly ToolbarID buildingsParent = new ToolbarID("blbuildParent");
            public static readonly ToolbarID buildings = new ToolbarID("blbuildings");
        }
    }
}