using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Enemies
{
    public class Sponge : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;

        [SerializeField]
        private GameObject _smallFishPrefab;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Rigidbody2D _rb;

        [SerializeField]
        private int _maxCount;

        private void Awake()
        {
            Spawn().Forget();
        }

        private void OnEnable()
        {
            _target = FindAnyObjectByType<Player>().transform;
        }

        private void Update()
        {
            if (_rb.velocity == Vector2.zero)
            {
                return;
            }
            else
            {
                _animator.SetBool("Run", true);
            }
        }

        private async UniTaskVoid Spawn()
        {
            var ct = gameObject.GetCancellationTokenOnDestroy();
            int count = 0;

            while (Application.isPlaying)
            {
                await UniTask.Delay(Random.Range(500, 5000), cancellationToken: ct);

                if (Vector2.Distance(transform.position, _target.position) < 5f)
                {
                    _animator.SetTrigger("Attack");

                    if (_maxCount <= count)
                    {
                        return;
                    }

                    Instantiate(
                        _smallFishPrefab,
                        transform.position
                            + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)),
                        Quaternion.identity
                    );
                    count++;
                }
            }
        }
    }
}
