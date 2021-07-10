using Unity.Entities;
using UnityEngine;

namespace UnityTemplateProjects.DataComponents
{
    [GenerateAuthoringComponent]
    public struct BallInputMovementData : IComponentData
    {
        public KeyCode UpKey;
        public KeyCode DownKey;
        public KeyCode LeftKey;
        public KeyCode RightKey;
    }
}