using UnityEngine;

namespace ShopSystem
{
    public class ShopTrigger : MonoBehaviour
    {
        [SerializeField]
        private PauseManager _pauseManager;

        [SerializeField]
        private GameObject _shopMenuPanel;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                _pauseManager.Permanent = true;
                _pauseManager.Show(false);
                _shopMenuPanel.SetActive(true);
            }
        }

        public void CloseShop()
        {
            _pauseManager.Permanent = false;
            _pauseManager.Hide();
            _shopMenuPanel.SetActive(false);
        }
    }
}
