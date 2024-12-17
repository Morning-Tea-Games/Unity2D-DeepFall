using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skills
{
    [RequireComponent(typeof(Button))]
    public class SkillButton : MonoBehaviour
    {
        [field: SerializeField]
        public TMP_Text NameField { get; private set; }

        [field: SerializeField]
        public TMP_Text DescriptionField { get; private set; }

        [field: SerializeField]
        public Button Button { get; private set; }

        [field: SerializeField]
        public SkillEvent CurrentEvent;

        private void OnValidate()
        {
            Button ??= GetComponent<Button>();
        }
    }
}
