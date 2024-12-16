using UnityEngine;

namespace Skills
{
    public class SkillsController
    {
        private readonly SkillsView _view;
        private readonly ExpBank _expBank;
        private readonly SkillSO[] _skillPool;
        private int _previousLevel = 0;

        public SkillsController(SkillsView view, ExpBank expBank, SkillSO[] skillPool)
        {
            _view = view;
            _expBank = expBank;
            _skillPool = skillPool;
        }

        public void Subscribe()
        {
            _expBank.OnExpChanged += NewLevel;
            _view.Reroll += Reroll;
        }

        public void Unsubscribe()
        {
            _expBank.OnExpChanged -= NewLevel;
            _view.Reroll -= Reroll;
        }

        private void NewLevel(int level, float exp)
        {
            //Debug.Log($"Activated: {_view.ActivatedSkillCount} | MaxCount: {_view.SkillsPoolZize}");
            if (level <= _previousLevel || _view.ActivatedSkillCount >= _view.SkillsPoolZize)
            {
                return;
            }

            _previousLevel = level;
            Reroll();
            _view.Show();
        }

        private Skill[] GenerateSkills(int count)
        {
            var skills = new Skill[count];

            for (int i = 0; i < count; i++)
            {
                var randomSkill = _skillPool[Random.Range(0, _skillPool.Length)];
                //Debug.Log("Skill:" + randomSkill);
                skills[i] = new Skill(randomSkill);
            }

            return skills;
        }

        public void Reroll()
        {
            _view.SetSkills(GenerateSkills(_view.SkillsCount));
        }
    }
}
