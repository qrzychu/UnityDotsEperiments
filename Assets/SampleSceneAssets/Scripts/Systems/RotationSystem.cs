using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityTemplateProjects.DataComponents;

namespace UnityTemplateProjects.Systems
{
    [AlwaysSynchronizeSystem]
    [UpdateAfter(typeof(AimingSystem))]
    public class RotationSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            float deltaTime = Time.DeltaTime;
            Entities.ForEach((ref Rotation rotation, in Translation translation, in BarrelAimAtData aimData) =>
            {
                if (aimData.aimAt.x != 0 && aimData.aimAt.y != 0 && aimData.aimAt.z != 0)
                {
                    var targetRotation = quaternion.LookRotationSafe(aimData.aimAt - translation.Value, new float3(0, -1, 0));
                    rotation.Value = math.slerp(rotation.Value, targetRotation, aimData.rotateSpeed * deltaTime);
                    // rotation.Value = targetRotation;
                }
            }).Run();

            return default;
        }
    }
}