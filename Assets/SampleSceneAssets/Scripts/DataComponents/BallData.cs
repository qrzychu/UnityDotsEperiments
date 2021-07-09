using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct BallData : IComponentData
{
    public float3 movementSpeed;
}