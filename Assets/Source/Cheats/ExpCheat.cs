using UnityEngine;

namespace Cheats
{
    public class ExpCheat : MonoBehaviour
    {
        [SerializeField]
        private Player _player;

        [SerializeField]
        private float _value;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                _player.Expirience.AddExp(_value);
            }
        }
    }
}
