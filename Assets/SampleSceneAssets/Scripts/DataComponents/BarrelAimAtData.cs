using Unity.Entities;
using Unity.Mathematics;

namespace UnityTemplateProjects.DataComponents
{
    [GenerateAuthoringComponent]
    public struct BarrelAimAtData : IComponentData
    {
        public float3 aimAt;
        public float rotateSpeed;
    }
}