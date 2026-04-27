
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
using Mafi.Localization;
using Mafi.Core.Syncers;
using Mafi.Unity.Ui.Library.Inspectors;
using Mafi.Unity.Ui;
using Mafi.Unity.UiToolkit.Library;
using Mafi.Unity.UiToolkit.Component;

namespace BetterLife_Buildings
{

    internal class McDonaldBuilding : IModData
    {
        public static EntityCostsTpl.Builder Build => new EntityCostsTpl.Builder();

        public void RegisterData(ProtoRegistrator registrator)
        {
            string[] McDonaldsLayout =
            {
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]",
            "<1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1>",
            "<1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1>",
            "<1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1>",
            "<1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1>",
            "<1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1>",
            "<1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1>",
            "<1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1><1>",
            "[1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1][1]"
        };
            Predicate<LayoutTile> predicate = null;
            CustomLayoutToken[] array = new CustomLayoutToken[1];
            array[0] = new CustomLayoutToken("<0>", delegate (EntityLayoutParams p, int h)
            {
                int heightFrom = h - 1;
                int? maxTerrainHeight5 = new int?(h - 1);
                Fix32? vehicleHeight2 = new Fix32?(h - 1);
                int? minTerrainHeight5 = new int?(-5);
                return new LayoutTokenSpec(heightFrom, h, LayoutTileConstraint.Ground| LayoutTileConstraint.NoRubbleAfterCollapse | LayoutTileConstraint.None, null, minTerrainHeight5, maxTerrainHeight5, vehicleHeight2, null,IdsCore.TerrainTileSurfaces.DefaultConcrete , false, false, 0);
            });

            EntityLayoutParams entityLayoutParams = new EntityLayoutParams(predicate, array, false, null, null, null, null, null,null,default,false,null , null);



            EntityCostsTpl costs = Build.CP(5);


            EntityLayout ltemp = registrator.LayoutParser.ParseLayoutOrThrow(entityLayoutParams, McDonaldsLayout);


            Proto.Str ps = Proto.CreateStr(BetterLIDs.Buildings.McDonalds, "McDonalds", "Let the vehicles get close, recieve each 30 secs, 0.5 units!!!");
            EntityCosts ec = costs.MapToEntityCosts(registrator);

            LayoutEntityProto.Gfx lg = new LayoutEntityProto.Gfx
                (
                    prefabPath: "Assets/Buildings/McDonalds.prefab",
                    useInstancedRendering: false,
                    useSemiInstancedRendering: false,
                    customIconPath: "Assets/Buildings/icons/mcdonalds.png",
                    categories: registrator.GetCategoriesProtos(BetterLIDs.ToolBars.buildings)

                );
            registrator.PrototypesDb.Add<McDonaldsPrototype>(new McDonaldsPrototype(BetterLIDs.Buildings.McDonalds, ps, ltemp, ec, lg));
        }

    }

    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    public class McDonaldsMbFactory :
        IEntityMbFactory<McDonalds>,
        IFactory<McDonalds, EntityMb>
    {

        private readonly ProtoModelFactory modelFactory;

        public McDonaldsMbFactory(ProtoModelFactory mFactory)
        {
            modelFactory = mFactory;
        }

        public EntityMb Create(McDonalds transp)
        {
            McDonaldsMb transpMb = modelFactory.CreateModelFor<McDonaldsPrototype>(transp.Prototype).AddComponent<McDonaldsMb>();
            transpMb.Initialize(transp);
            McDonaldsColliderMB transpMb2 = modelFactory.CreateModelFor<McDonaldsPrototype>(transp.Prototype).AddComponent<McDonaldsColliderMB>();
            transpMb2.Initialize(transp);
            return (EntityMb)transpMb;
        }
    }
    public class McDonaldsColliderMB : MonoBehaviour
    {
        McDonalds thisEntity;
        BoxCollider thisCollider;
        public void Initialize(McDonalds staticEntity)
        {
              
            thisEntity = staticEntity;
            thisCollider = gameObject.GetComponent<BoxCollider>();
            if (thisCollider != null)
            {
                Log.Info($"BoxCollider {thisCollider.name.ToString()} retrieved...");
                thisCollider.providesContacts = true;
                thisCollider.enabled = true;
                thisCollider.gameObject.SetActive(true);
                   
                 
            } else { Log.Info("Error getting collider component..."); }
        }
        public void OnCollisionEnter(Collision collision)
        {
            Log.Info("Collision enter...");
        }
        public void OnTriggerEnter(Collider other)
        {
            Log.Info("Trigger enter...");
        }
    }
    public class McDonaldsMb : StaticEntityMb, IEntityMbWithSyncUpdate, IEntityMb, IDestroyableEntityMb
    {
        McDonalds thisEntity;
        private Transform m_logo;
        private float logoRotationSpeed = 2f;

        public void SyncUpdate(GameTime time)
        {
            if (thisEntity.m_timerWorking == true)
            {
                m_logo.Rotate(Vector2.up, logoRotationSpeed);
            }
        }
        public void Initialize(McDonalds mcDonalds)
        {
            base.Initialize((ILayoutEntity)mcDonalds);
            thisEntity = mcDonalds;
            //Animator component2;
            //if (this.gameObject.TryFindChild("logoani", out insideGo) && insideGo.TryGetComponent<Animator>(out component2))
            m_logo = base.gameObject.transform.Find("logoani_base");
        }
        static McDonaldsMb()
        {

        }
    }
    public class McDonaldsPrototype : LayoutEntityProto, IProto
    {


        public McDonaldsPrototype(ID id, Str strings, EntityLayout layout, EntityCosts costs, Gfx graphics)
             : base(id, strings, layout, costs, graphics)
        {
            //AnimationParams = ap;
        }
        public override Type EntityType => typeof(McDonalds);
        public int actionDuration;

    }


    [GenerateSerializer(false, null, 0)]
    public class McDonalds : LayoutEntity, IEntity, ILayoutEntity

    {
        public bool m_timerWorking = false;
        private McDonaldsPrototype _proto;
        public IEntitiesManager EntitiesManager { get; private set; }
        public INotificationsManager NotificationsManager { get; private set; }
        public float UPointsGenerated = 0;

        public McDonalds(EntityId id, McDonaldsPrototype proto, TileTransform transform, EntityContext context, IEntitiesManager entitiesManager, INotificationsManager notificationsManager)
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
            int entities = EntitiesManager.Entities.Where<IEntity>(x => x.DefaultTitle.Value == "McDonalds").Count();
            if (entities == 3) 
            { 
                this.StartDeconstructionIfCan();
            }
            
        }
        private int _pushCount = 0;
        public int pushCount
        {
            get { return _pushCount; }
        }
        public new McDonaldsPrototype Prototype
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

        public static void Serialize(McDonalds value, BlobWriter writer)
        {
            if (writer.TryStartClassSerialization(value))
            {
                writer.EnqueueDataSerialization(value, s_serializeDataDelayedAction);
            }
        }

        protected override void SerializeData(BlobWriter writer)
        {
            base.SerializeData(writer);
            writer.WriteGeneric<McDonaldsPrototype>(_proto);
            writer.WriteInt(_pushCount);
        }

        public static McDonalds Deserialize(BlobReader reader)
        {
            if (reader.TryStartClassDeserialization(out McDonalds obj, (Func<BlobReader, Type, McDonalds>)null))
            {
                reader.EnqueueDataDeserialization(obj, s_deserializeDataDelayedAction);
            }
            return obj;
        }

        protected override void DeserializeData(BlobReader reader)
        {
            base.DeserializeData(reader);
            reader.SetField(this, "_proto", reader.ReadGenericAs<McDonaldsPrototype>());
            reader.SetField(this, "_pushCount", reader.ReadInt());
            //reader.RegisterInitAfterLoad<McDonalds>(this, "initSelf", InitPriority.Normal);
        }

        /*        [InitAfterLoad(InitPriority.Normal)]
                private void initSelf(int saveVersion, DependencyResolver resolver)
                {
                    AnimationStatesProvider = resolver.GetResolvedInstance<AnimationStateFactory>().Value.CreateProviderFor(this);
                } */

        static McDonalds()
        {
            s_serializeDataDelayedAction = delegate (object obj, BlobWriter writer)
            {
                ((McDonalds)obj).SerializeData(writer);
            };
            s_deserializeDataDelayedAction = delegate (object obj, BlobReader reader)
            {
                ((McDonalds)obj).DeserializeData(reader);
            };
        }
    }
    [GlobalDependency(RegistrationMode.AsAllInterfaces, false, false)]
    internal class McDonaldsInspector : BaseInspector<McDonalds>
    {
        public McDonaldsInspector(UiContext context) : base(context)
        {
            Label upointsLabel = new Label().FontBold();
            WindowSize(400.px(), Px.Auto);
            AddPanelWithHeader(upointsLabel)
                .Title("McDonalds Information".AsLoc());

            this.Observe(() => Entity.UPointsGenerated)
                .Do(upoints => upointsLabel.Value($"McDonalds: {upoints:F0} upoints generated".AsLoc()));
        }
    }
}