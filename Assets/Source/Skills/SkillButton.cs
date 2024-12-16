using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skills
{
    [RequireComponent(typeof(Button))]
    public class SkillButton : MonoBehaviour
    {
        [field: SerializeField]
        public TMP_Text NameField;

        [field: SerializeField]
        public TMP_Text DescriptionField;

        [field: SerializeField]
        public Button Button;

        private void OnValidate()
        {
            Button ??= GetComponent<Button>();
        }
    }
}
