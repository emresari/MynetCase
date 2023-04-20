using UnityEngine;

namespace Script.Game
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "ScriptableObjects/Game Data")]

    public class ScriptableGameData : ScriptableObject
    {
       [SerializeField]private int maxUseableSkillCount;

       public int MaxUseableSkillCount => maxUseableSkillCount;
    }
}
