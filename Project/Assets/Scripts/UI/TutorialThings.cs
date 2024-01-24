using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialThings : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("tutorial") != 1)
        {
            PlayerPrefs.SetInt("tutorial", 1);
            PlayerPrefs.Save();
        }
        else
        {
            Time.timeScale = 1.0f;
            Destroy(gameObject);
        }
    }
    public void CloseTutorialMenu()
    {
        Time.timeScale = 1.0f;
        Destroy(gameObject);
    }
}
