using Unity.Entities;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UnityTemplateProjects
{
    public class BallSpawner : MonoBehaviour
    {
        public GameObject Prefab;
        public int Count = 10000;
        public int SpawnAreaSize = 500;

        private void Awake()
        {
            var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, null);
            var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, settings);
            var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            for (int i = 0; i < Count; i++)
            {
                var instance = entityManager.Instantiate(prefab);
                var position = transform.TransformPoint(
                    Random.Range(-SpawnAreaSize, SpawnAreaSize),
                    Random.Range(-SpawnAreaSize, SpawnAreaSize),
                    Random.Range(-SpawnAreaSize, SpawnAreaSize));

                entityManager.SetComponentData(instance, new Translation {Value = position});
            }
        }
    }
}