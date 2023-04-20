using System.Collections.Generic;
using Script.Managers;
using UnityEngine;

namespace Script.UI
{
    public class SkillGroupController : MonoBehaviour
    {
        [SerializeField] private List<SkillView> skillViews;

        private int _useSkillCount;
        private int _maxUseableSkillCount;

        private void Awake()
        {
            foreach (var skillView in skillViews)
                skillView.SkillUsed += OnSkillUse;
        }

        private void Start()
        {
            _maxUseableSkillCount = GameManager.Instance.GameData.MaxUseableSkillCount;
        }

        private void OnSkillUse()
        {
            _useSkillCount++;
            if (_useSkillCount >= _maxUseableSkillCount)
                SetSkillViews();
        }

        private void SetSkillViews()
        {
            foreach (var skillView in skillViews)
            {
                skillView.Button.interactable = skillView.IsUsed;
            }
        }

        private void OnDisable()
        {
            foreach (var skillView in skillViews)
                skillView.SkillUsed -= OnSkillUse;
        }
    }
}