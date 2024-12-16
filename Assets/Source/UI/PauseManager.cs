using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    public bool Permanent;
    public bool Paused;

    private void Start()
    {
        Hide();
    }

    public void Show(bool withPausePanel = true)
    {
        PausePanel.SetActive(withPausePanel);
        Time.timeScale = 0;
        Paused = true;
    }

    public void Hide()
    {
        if (Permanent)
        {
            return;
        }

        PausePanel.SetActive(false);
        Time.timeScale = 1;
        Paused = false;
    }
}
