using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
    public class SkillsController
    {
        private readonly SkillsView _view;
        private readonly ExpBank _expBank;
        private readonly List<SkillSO> _skillPool;
        private int _previousLevel = 0;

        public SkillsController(SkillsView view, ExpBank expBank, List<SkillSO> skillPool)
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

        private Skill[] GenerateSkills(int count, List<SkillSO> data)
        {
            var skills = new Skill[count];
            var awaible = new List<SkillSO>();

            awaible.AddRange(data);

            for (int i = 0; i < count; i++)
            {
                var index = Random.Range(0, awaible.Count);
                var randomSkill = awaible[index];

                skills[i] = new Skill(randomSkill);
                awaible.Remove(randomSkill);
            }

            return skills;
        }

        public void Reroll()
        {
            _view.SetSkills(GenerateSkills(_view.SkillsCount, _skillPool));
        }
    }
}
