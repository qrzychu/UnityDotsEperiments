using Unity.Entities;

namespace UnityTemplateProjects.DataComponents
{
    [GenerateAuthoringComponent]
    public struct ShootingData : IComponentData
    {
        public Entity target;
        public float cooldown;
    }
}