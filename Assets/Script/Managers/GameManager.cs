using System.Collections.Generic;
using Script.Game;
using Script.Other;
using Script.Player;
using UnityEngine;

namespace Script.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private ScriptableGameData gameData;
        [HideInInspector] public List<Entity> entities;

        public ScriptableGameData GameData => gameData;

    }
}