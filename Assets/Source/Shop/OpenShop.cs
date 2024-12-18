using UnityEngine;

public class OpenShop : MonoBehaviour
{
    [SerializeField]
    private MapController _mapController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _mapController.ChangeMap(0);
        }
    }
}
