using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    [SerializeField] private int _hearts = 3;
    public TMP_Text textHearts;
    public GameObject _deathCanvas;

    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }



    // убрать из сохранений
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        PlayerPrefs.SetInt("tutorial", 0);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            TakeEnemy();
        }
        else
        {
            if (collision.CompareTag("Boss"))
            {
                Destroy(collision.gameObject);
                textHearts.text = "0";
                Death();
            }
        }
    }

    public int GetHearts()
    {
        return _hearts;
    }

    public void SetHearts(int amount)
    {
        _hearts += amount;
        textHearts.text = _hearts.ToString();
    }

    private void TakeEnemy()
    {
        if (_hearts > 0)
        {
            _hearts--;
            textHearts.text = _hearts.ToString();
        }
        else
        {
            Death();
        }
    }

    private void Death()
    {
        Time.timeScale = 0;
        _deathCanvas.SetActive(true);
        _audioManager.StopMusic();
        _audioManager.PlaySFX(_audioManager.gameover);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Menu");
    }
}