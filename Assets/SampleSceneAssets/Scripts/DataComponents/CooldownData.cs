using Unity.Entities;

namespace UnityTemplateProjects.DataComponents
{
    [GenerateAuthoringComponent]
    public struct CooldownData : IComponentData
    {
        public float remainingTime;
    }
}