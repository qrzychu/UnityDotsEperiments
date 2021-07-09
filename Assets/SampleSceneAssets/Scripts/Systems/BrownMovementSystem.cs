using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Random = UnityEngine.Random;

[AlwaysSynchronizeSystem]
public class BrownMovementSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        Entities
            .ForEach((ref BallData ballData) =>
        {
            float3 movementSpeed = new float3();
            movementSpeed.x = Random.Range(-1f, 1f);
            movementSpeed.y = Random.Range(-1f, 1f);
            movementSpeed.z = Random.Range(-1f, 1f);
           
            ballData.movementSpeed = math.normalize(movementSpeed);
        }).Run();

        return default;
    }
}