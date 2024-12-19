using UnityEngine;
using UnityEngine.SceneManagement;

public class Maps : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemies;

    [SerializeField]
    private int _currentMapIndex = 1;

    [SerializeField]
    private MapController _mapController;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in _enemies)
        {
            if (item != null)
            {
                return;
            }
        }

        _currentMapIndex++;
        _mapController.ChangeMap(_currentMapIndex);

        if (_currentMapIndex == 4)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
