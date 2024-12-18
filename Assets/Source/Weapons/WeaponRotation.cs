using UnityEngine;

namespace Weapons
{
    public class WeaponRotation : MonoBehaviour
    {
        [SerializeField]
        private PauseManager _pauseManager;

        [SerializeField]
        private Transform _nocitel;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        private void Update()
        {
            if (_pauseManager.Paused)
            {
                return;
            }

            // Получаем позицию мыши
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            // Направление и угол
            Vector2 direction = (mousePosition - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Поворот объекта
            transform.rotation = Quaternion.Euler(0, 0, angle);

            // Позиция оружия совпадает с носителем
            transform.position = _nocitel.position;

            // Проверка угла и отражение по Y
            if (angle > 90 || angle < -90)
            {
                _spriteRenderer.flipY = true;
            }
            else
            {
                _spriteRenderer.flipY = false;
            }
        }
    }
}
