using System.Collections.Generic;
using Skills;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField]
        private Player _player;

        [SerializeField]
        private List<SkillSO> _avaibleSkills;

        [SerializeField]
        private GameObject _skillsViewPrefab;

        [SerializeField]
        private Transform _skillsViewParent;

        private SkillsController _skillsController;

        private void Start()
        {
            var skillsViewObj = Instantiate(_skillsViewPrefab, _skillsViewParent);
            var skillsView = skillsViewObj.GetComponent<SkillsView>();
            skillsView.Hide();
            _skillsController = new SkillsController(
                skillsView,
                _player.Expirience,
                _avaibleSkills
            );
            _skillsController.Subscribe();
        }

        private void OnDestroy()
        {
            _skillsController.Unsubscribe();
        }
    }
}
