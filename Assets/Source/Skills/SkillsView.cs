using System;
using TMPro;
using UnityEngine;

namespace Skills
{
    public class SkillsView : MonoBehaviour
    {
        public event Action Reroll;
        public int SkillsCount => _skillButtons.Length;
        public int SkillsPoolZize => _skillFields.Length;
        public int ActivatedSkillCount { get; private set; }

        [SerializeField]
        private string _defaultSkillLabel;

        [SerializeField]
        private TMP_Text[] _skillFields;

        [SerializeField]
        private SkillButton[] _skillButtons;

        [SerializeField]
        private GameObject _skillPanel;

        private void Awake()
        {
            Hide();

            for (int i = 0; i < _skillFields.Length; i++)
            {
                _skillFields[i].text = string.Format(_defaultSkillLabel, i);
            }
        }

        private void OnEnable()
        {
            foreach (var button in _skillButtons)
            {
                button.Button.onClick.AddListener(() => ChoiseSkill(button));
            }
        }

        private void OnDisable()
        {
            foreach (var button in _skillButtons)
            {
                button.Button.onClick.RemoveAllListeners();
            }
        }

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
                _skillButtons[i].NameField.text = skills[i].Param.Name;
                _skillButtons[i].DescriptionField.text = skills[i].Param.Description;
                _skillButtons[i].CurrentEvent = skills[i].Param.Event;
            }
        }

        private void ChoiseSkill(SkillButton skill)
        {
            Debug.Log($"Выбран скилл {skill.NameField.text}");

            if (skill.CurrentEvent == SkillEvent.Reroll)
            {
                Reroll.Invoke();
                return;
            }

            Hide();
            ActivatedSkillCount++;

            for (int i = 0; i < _skillFields.Length; i++)
            {
                if (_skillFields[i].text == string.Format(_defaultSkillLabel, i))
                {
                    _skillFields[i].text = skill.NameField.text;
                    return;
                }
            }
        }
    }
}
