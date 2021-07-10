using System;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class GameManager : ScriptableObject
    {
        private GameManager(){}

        private static readonly Lazy<GameManager> _instance = new Lazy<GameManager>(CreateInstance<GameManager>);
        public static GameManager Instance => _instance.Value;

        public float ballMovementSpeed = 5;

        private void Awake()
        {
            Cursor.visible = true;
        }
    }
}