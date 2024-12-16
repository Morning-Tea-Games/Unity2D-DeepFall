using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;

    private void Start()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Show()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Hide()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
