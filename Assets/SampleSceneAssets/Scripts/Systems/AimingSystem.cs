using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;
using UnityTemplateProjects.DataComponents;

namespace UnityTemplateProjects.Systems
{
    [AlwaysSynchronizeSystem]
    public class AimingSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            Translation target = new Translation();
            bool targetFound = false;
            
            Entities
                .WithAll<BallInputMovementData>()
                .ForEach((in Translation translation, in Entity entity) =>
            {
                target = translation;
                targetFound = true;
                Debug.Log(string.Format("Target found: {0}", entity.Index));
            }).Run();

            if (targetFound)
            {
                Entities.ForEach((ref BarrelAimAtData aimData) => { aimData.aimAt = target.Value; }).Run();
            }
            else
            {
                Debug.Log("No target to aim at");
            }

            return default;
        }
    }
}