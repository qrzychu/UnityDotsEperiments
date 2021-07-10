using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityTemplateProjects;

[AlwaysSynchronizeSystem]
public class BallMovingSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float deltaTime = Time.DeltaTime;
        float ballMovementSpeed = GameManager.Instance.ballMovementSpeed;

        Entities
            .ForEach((ref Translation translation, in BallData ballData) =>
            {
                float3 acceleration = ballData.movementSpeed * deltaTime * ballMovementSpeed;
                translation.Value.x += acceleration.x;
                translation.Value.y += acceleration.y;
                translation.Value.z += acceleration.z;
            }).Run();

        return default;
    }
}