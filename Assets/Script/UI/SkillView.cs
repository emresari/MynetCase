using System;
using Script.Managers;
using Script.Skills;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    [RequireComponent(typeof(Button))]
    public class SkillView : MonoBehaviour
    {
        [SerializeField] private ScriptableSkill scriptableSkill;
        [SerializeField] private Image skillImage;
        [SerializeField] private Image border;

        public Button Button { get; private set; }

        public bool IsUsed { get; private set; }

        public event Action SkillUsed;

        private void Awake()
        {
            Button = GetComponent<Button>();
            if (scriptableSkill != null)
                skillImage.sprite = scriptableSkill.SkillSprite;
        }

        public void UseSkill()
        {
            if (scriptableSkill == null || IsUsed) return;
            IsUsed = true;
            
            foreach (var entity in GameManager.Instance.entities)
                scriptableSkill.TryUse(entity);
            
            border.gameObject.SetActive(true);
            SkillUsed?.Invoke();
        }
    }
}