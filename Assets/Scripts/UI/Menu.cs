using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    public void SetMusicVolume()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }


    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
