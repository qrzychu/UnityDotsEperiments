using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityTemplateProjects.DataComponents;

namespace UnityTemplateProjects.Systems
{
    [AlwaysSynchronizeSystem]
    public class KeyboardMoveBallSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            float3 direction = new float3();

            Entities.ForEach((ref BallData ballData, in BallInputMovementData inputData) =>
            {
                if(Input.GetKey(inputData.UpKey))
                {
                    direction.z += 1;
                }

                if(Input.GetKey(inputData.DownKey))
                {
                    direction.z -= 1;
                }

                if(Input.GetKey(inputData.LeftKey))
                {
                    direction.x -= 1;
                }

                if(Input.GetKey(inputData.RightKey))
                {
                    direction.x += 1;
                }

                ballData.movementSpeed = direction;
            }).Run();

            return default;
        }
    }
}