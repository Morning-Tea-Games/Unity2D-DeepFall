using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private TMP_Text _snippetField;
    [SerializeField] private GameObject _shopPanel;
    private bool _inTrigger;

    private void Start()
	{
        _snippetField.gameObject.SetActive(false);
        _shopPanel.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
    	_snippetField.gameObject.SetActive(true); 
    	_inTrigger = true;     
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    	_snippetField.gameObject.SetActive(false);  
    	_inTrigger = false;    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _inTrigger)
		{
            _shopPanel.SetActive(!_shopPanel.activeSelf);
        }
    }
}