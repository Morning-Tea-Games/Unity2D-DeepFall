using UnityEngine;

namespace PlayerSystem
{
    public class PlayerSpawner : MonoBehaviour
    {
        private void OnEnable()
        {
            FindAnyObjectByType<Player>().transform.position = transform.position;
        }
    }
}
