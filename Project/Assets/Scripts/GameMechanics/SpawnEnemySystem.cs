using System.Collections;
using TMPro;
using UnityEngine;

public class SpawnEnemySystem : MonoBehaviour
{
    public int _amountDiamonds;
    [SerializeField] private Transform placeForSpawn;
    [SerializeField] private int amountOfEnemy = 10;
    [SerializeField] private GameObject[] _enemys;

    [SerializeField] private float delayForSpawn;
    [SerializeField] private float currentDelay;
    [SerializeField] private float amountOfDelDelay = 0.4f;
    private WaitForSeconds waitForSeconds;
    [SerializeField] private int currentCountOfEnemy;
    [SerializeField] private int addedAmount = 10;
    public bool activeWave = false;
    public int currentWave = 1;

    public GameObject _canvasWinGame;

    private AudioManager _audioManager;

    public TMP_Text _textWaves;

    private void Awake()
    {
        Time.timeScale = 0f;
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        waitForSeconds = new WaitForSeconds(delayForSpawn);
        currentDelay = delayForSpawn;
        activeWave = true;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (currentCountOfEnemy <= amountOfEnemy + addedAmount)
            {
                Instantiate(_enemys[Random.Range(0, _enemys.Length)], placeForSpawn);
                _audioManager.PlaySFX(_audioManager.spawn);
                currentCountOfEnemy += 1;
                yield return waitForSeconds;
            }
            else
            {
                if (placeForSpawn.childCount <= 0)
                {
                    currentWave += 1;
                    if (currentWave == 4)
                    {
                        WinGame();
                        StopCoroutine(SpawnEnemy());
                        break;
                    }
                    currentCountOfEnemy = 0;
                    activeWave = false;
                    addedAmount += 10;
                    _textWaves.text = currentWave.ToString() + " of 3";
                    if (currentDelay > 1f)
                    {
                        currentDelay -= amountOfDelDelay;
                        waitForSeconds = new WaitForSeconds(currentDelay);
                    }
                    yield return waitForSeconds;
                }
                else
                    yield return null;
            }
        }
    }

    private void WinGame()
    {
        _audioManager.StopMusic();
        _audioManager.PlaySFX(_audioManager.gameover);
        Time.timeScale = 0f;
        if (PlayerPrefs.HasKey("diamonds"))
        {
            var a = PlayerPrefs.GetInt("diamonds");
            _amountDiamonds += a;
            PlayerPrefs.SetInt("diamonds", _amountDiamonds);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("diamonds", _amountDiamonds);
            PlayerPrefs.Save();
        }

        _canvasWinGame.SetActive(true);
    }
}