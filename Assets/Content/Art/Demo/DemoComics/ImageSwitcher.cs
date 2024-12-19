using UnityEngine;

public class ImageSwitcher : MonoBehaviour
{
    public GameObject[] images; 
    private int currentIndex = 0; 

    void Start()
    {
        foreach (GameObject img in images)
        {
            img.SetActive(false);
        }
        if (images.Length > 0)
        {
            images[0].SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            images[currentIndex].SetActive(false);

            currentIndex++;
            if (currentIndex >= images.Length) 
            {
                currentIndex = 0;
            }

            images[currentIndex].SetActive(true);
        }
    }
}

