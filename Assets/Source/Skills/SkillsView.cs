using System;
using TMPro;
using UnityEngine;

namespace Skills
{
    public class SkillsView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text[] _skillFields;

        [SerializeField]
        private SkillButton[] _skillButtons;

        [SerializeField]
        private GameObject _skillPanel;

        private void Awake()
        {
            Hide();
        }

        private void OnEnable()
        {
            foreach (var button in _skillButtons)
            {
                button.Button.onClick.AddListener(() => ChoiseSkill(button));
            }
        }

        private void OnDisable() { }

        public void Show()
        {
            _skillPanel.SetActive(true);
        }

        public void Hide()
        {
            _skillPanel.SetActive(false);
        }

        public void SetSkills(Skill[] skills)
        {
            if (_skillButtons.Length != skills.Length)
            {
                throw new ArgumentException(
                    "Длина массива скиллов не совпадает с длиной массива кнопок скиллов"
                );
            }

            for (int i = 0; i < _skillButtons.Length; i++)
            {
                _skillButtons[i].NameField.text = skills[i].Name;
                _skillButtons[i].DescriptionField.text = skills[i].Description;
            }
        }

        private void ChoiseSkill(SkillButton skill)
        {
            Debug.Log($"Выбран скилл {skill.NameField.text}");
            Hide();
        }
    }
}
