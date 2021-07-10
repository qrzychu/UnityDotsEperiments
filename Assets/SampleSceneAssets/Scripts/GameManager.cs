using UnityEngine;

namespace UnityTemplateProjects
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public float ballMovementSpeed = 5;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            
            Cursor.visible = true;
        }
    }
}