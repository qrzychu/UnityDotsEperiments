using System;
using Unity.Entities;
using UnityEngine;

namespace UnityTemplateProjects
{
    public class GameManager : MonoBehaviour
    {
        private GameManager(){}

        private static readonly Lazy<GameManager> _instance = new Lazy<GameManager>(() => new GameManager());
        public static GameManager Instance => _instance.Value;

        public float BallMovementSpeed = 5;
    }
}