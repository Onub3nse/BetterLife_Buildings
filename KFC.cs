
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities;
using Mafi.Core;
using Mafi.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Notifications;
using Mafi.Unity.Entities.Static;
using Mafi.Unity.Entities;
using UnityEngine;
using Mafi.Unity;
using Color = UnityEngine.Color;
using Mafi.Localization;
using Mafi.Core.Syncers;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.Ui;
using Mafi.Unity.UiToolkit.Library;
using Mafi.Unity.UiToolkit.Component;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Events;
namespace BetterLife_Buildings
{

    internal class KFCBuilding : IModData
    {
        public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();

        public void RegisterData(ProtoRegistrator registrator)
        {
            string[] KFCLayout =
            {
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
                "[1][1][1][1][1][1][1][1][1][1]<1><1><1><1><1><1><1>[1]",
            };
            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[2];
            array[0] = new CustomLayoutToken("<0>", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight5 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight5 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight5, maxTerrainHeight5, vehicleHeight2, null, IdsCore.TerrainTileSurfaces.DefaultConcrete, false, false, 0);
            });
            array[1] = new CustomLayoutToken("-0-", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight5 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight5 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.Ground | LayoutTileConstraint.NoRubbleAfterCollapse , heightFrom, minTerrainHeight5, maxTerrainHeight5, vehicleHeight2,Ids.TerrainMaterials.Gravel,Ids.TerrainTileSurfaces.DefaultConcrete , false, false, 0);
            });

            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, null,null, default,false,null,null);



            EntityCostsTpl costs = Build.CP(5);


            EntityLayout ltemp = registrator.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, KFCLayout);


            Proto.Str ps = Proto.CreateStr(BetterLIDs.Buildings.KFC, "KFC", "CHICKEN!!!, recieve each 30 secs, 0.5 units!!!");
            EntityCosts ec = costs.MapToEntityCosts(registrator);

            LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx
                (
                    prefabPath: "Assets/Buildings/kfc.prefab",
                    useInstancedRendering: false,
                    useSemiInstancedRendering: false,
                    customIconPath: "Assets/Buildings/icons/kfc.png",
                    categories: registrator.GetCategoriesProtos(BetterLIDs.ToolBars.buildings)

                );
            registrator.PrototypesDb.Add<KFCPrototype>(new KFCPrototype(BetterLIDs.Buildings.KFC, ps, ltemp, ec, lg));
        }

    }

    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    public class KFCMbFactory :  IEntityMbFactory<KFCEntity>, IFactory<KFCEntity, EntityMb>
    {

        private readonly ProtoModelFactory modelFactory;

        public KFCMbFactory(ProtoModelFactory mFactory)
        {
            modelFactory = mFactory;
        }

        public EntityMb Create(KFCEntity transp)
        {
            KFCMb transpMb = modelFactory.CreateModelFor<KFCPrototype>(transp.Prototype).AddComponent<KFCMb>();
            transpMb.Initialize(transp);
            return (EntityMb)transpMb;
        }
    }
    public class KFCMb : StaticEntityMb, IEntityMbWithSyncUpdate, IEntityMb, IDestroyableEntityMb
    {
        KFCEntity thisEntity;
        //      private Transform m_logo;
        //    private float logoRotationSpeed = 2f;
        public void SyncUpdate(GameTime time)
        {
      //      if (thisEntity.m_timerWorking == true)
      //      {
                
      //          m_logo.Rotate(Vector2.up, logoRotationSpeed);
      //      }
        }
        public void Initialize(KFCEntity kFC)
        {
            base.Initialize((ILayoutEntity)kFC);
            thisEntity = kFC;
//            this.m_logo = base.gameObject.transform.Find("logoani_base");
        }
        static KFCMb()
        {

        }
    }
    public class KFCPrototype : LayoutEntityProto, IProto
    {


        public KFCPrototype(ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics)
             : base(id, strings, layout, costs, graphics)
        {
            //AnimationParams = ap;
        }
        public override Type EntityType => typeof(KFCEntity);
        public int actionDuration;

    }


    [GenerateSerializer(false, null, 0)]
    public class KFCEntity : LayoutEntity, IEntity, ILayoutEntity

    {
        public bool m_timerWorking = false;
        private KFCPrototype _proto;
        public IEntitiesManager EntitiesManager { get; private set; }
        public INotificationsManager NotificationsManager { get; private set; }
        public float UPointsGenerated = 0;

        public KFCEntity(EntityId id, KFCPrototype proto, TileTransform transform, EntityContext context, IEntitiesManager entitiesManager, INotificationsManager notificationsManager)
            : base(id, proto, transform, context)
        {
            _proto = proto;
            EntitiesManager = entitiesManager;
            NotificationsManager = notificationsManager;
        }
        public void GetUPointsGenerated(float upPointsGenerated)
        {
            UPointsGenerated = upPointsGenerated;
        }

        protected override void OnAddedToWorld(EntityAddReason reason)
        {
                        
            base.OnAddedToWorld(reason);
            int entities = EntitiesManager.Entities.Where<IEntity>(x => x.DefaultTitle.Value == "KFCEntity").Count();
            if (entities == 3) 
            { 
                this.StartDeconstructionIfCan();
            }
            
        }
        public new KFCPrototype Prototype
        {
            get
            {
                return _proto;

            }
            protected set
            {
                _proto = value;
                base.Prototype = value;
            }
        }

        public override bool CanBePaused => true;


        private static readonly Action<object, BlobWriter> s_serializeDataDelayedAction;

        private static readonly Action<object, BlobReader> s_deserializeDataDelayedAction;

        public static void Serialize(KFCEntity value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization(value))
            {
                writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
            }
        }

        protected override void SerializeData(BlobWriter writer)
        {
            base.SerializeData(writer);
            writer.WriteGeneric<KFCPrototype>(_proto);
        }

        public static KFCEntity Deserialize(BlobReader reader)
        {
            if (reader.TryStartClassDeserialization(out KFCEntity obj, (Func<BlobReader, Type, KFCEntity>)null))
            {
                reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
            }
            return obj;
        }

        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            reader.SetField(this, "_proto", reader.ReadGenericAs<KFCPrototype>());
            //reader.RegisterInitAfterLoad<McDonalds>(this, "initSelf", InitPriority.Normal);
        }

        /*        [InitAfterLoad(InitPriority.Normal)]
                private void initSelf(int saveVersion, DependencyResolver resolver)
                {
                    AnimationStatesProvider = resolver.GetResolvedInstance<AnimationStateFactory>().Value.CreateProviderFor(this);
                } */

        static KFCEntity()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((KFCEntity)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((KFCEntity)obj).DeserializeData(reader);
            };
        }
    }
    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    internal class KFCInspector : BaseInspector<KFCEntity>
    {
        public KFCInspector(UiContext context) : base(context)
        {
            Label upointsLabel = new Label().FontBold();
            WindowSize(400.px(), Px.Auto);
            AddPanelWithHeader(upointsLabel)
                .Title("KFC Information".AsLoc());

            this.Observe(() => Entity.UPointsGenerated)
                .Do(upoints => upointsLabel.Value($"KFC: {upoints:F0} upoints generated".AsLoc()));
        }
    }
}