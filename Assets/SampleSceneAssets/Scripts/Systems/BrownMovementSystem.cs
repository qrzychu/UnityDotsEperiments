using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Rendering;
using UnityEngine;
using UnityTemplateProjects.DataComponents;
using Random = UnityEngine.Random;

[AlwaysSynchronizeSystem]
public class BrownMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities
            .WithNone<BallInputMovementData>()
            .ForEach((ref BallData ballData, in Entity entity) =>
        {
            float3 movementSpeed = new float3();
            movementSpeed.x = Random.Range(-1f, 1f);
            movementSpeed.y = Random.Range(-1f, 1f);
            movementSpeed.z = Random.Range(-1f, 1f);
           
            ballData.movementSpeed = math.normalize(movementSpeed) * 10;
            // Debug.Log(string.Format("Brown movement for entity {0}", entity.Index));
        }).Run();

        return default;
    }
}