using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField]
    private GameObject _startMap;

    [SerializeField]
    private GameObject[] _maps;
    private GameObject _currentMap;

    private void Start()
    {
        foreach (var item in _maps)
        {
            item.SetActive(false);
        }

        _currentMap = _startMap;
        _currentMap.SetActive(true);
    }

    public void ChangeMap(int index)
    {
        _currentMap.SetActive(false);
        _currentMap = _maps[index];
        _maps[index]?.SetActive(true);
    }
}
