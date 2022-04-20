using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    [Tooltip("TMP element that holds the text for the timer.")]
    private TextMeshPro timer;

    [SerializeField]
    [Tooltip("TMP element that holds the text for the life counter.")]
    private TextMeshPro livesCounter;

    [SerializeField]
    [Tooltip("TMP element that holds the text for the money display.")]
    private TextMeshProUGUI moneyDisplay;

    [SerializeField]
    [Tooltip("Level object to be loaded. If empty, will generate a level dynamically.")]
    private LevelObject loadedLevel;

    [SerializeField]
    [Tooltip("Enemy prefab that will be spawned.")]
    private Transform enemy;

    [SerializeField]
    [Tooltip("Seconds of rest time between wave spawns.")]
    private int secondsBetweenWaves;

    [SerializeField]
    [Tooltip("Amount of money that is provided at game start.")]
    private int startingMoney = 30;

    [SerializeField]
    [Tooltip("Amount of lives that is provided at game start.")]
    private int startingLives = 20;

    private int secondsTillNextWave;

    private int lives;
    private int money;

    private WaveObject[] waves;
    private int currentWave = 1;
    private Vector3 spawnPosition = new Vector3(5, 0, 0.07f);	// Spawn position for the enemies

    private TowerObject selectedTower = null;	// Used for tower placement

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        waves = loadedLevel.waves;
        StartCoroutine(StartSpawning());
        secondsTillNextWave = secondsBetweenWaves;
        StartCoroutine(Timer());
        lives = startingLives;
        livesCounter.text = "" + lives;
        money = startingMoney;
        moneyDisplay.text = "$" + money;
        PauseGame();
    }

    IEnumerator StartSpawning()
    {
        WaveObject wave = waves[currentWave - 1];
        for (int index = 0; index < wave.spawns; index++)
        {
            Transform e = Instantiate(enemy, spawnPosition, new Quaternion(0, 90, 0, 90));
            e.gameObject.SetActive(true);
            yield return new WaitForSeconds(loadedLevel.timeBetweenSpawns);
        }
    }

    IEnumerator Timer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            if (--secondsTillNextWave <= 0)
            {
                secondsTillNextWave = secondsBetweenWaves;
            }
            timer.text = "" + secondsTillNextWave;
        }
    }

    private void LoseGame()
    {
        // Lose game
    }

    public void AddMoney(int amt)
    {
        money += amt;
        moneyDisplay.text = "$" + money;
    }

    public void RemoveMoney(int amt)
    {
        money -= amt;
        moneyDisplay.text = "$" + money;
    }

    public bool HasEnoughMoney(int amt)
    {
        if (money >= amt)
            return true;
        return false;
    }

    public void RemoveLife()
    {
        this.lives--;
        livesCounter.text = "" + lives;
        if (lives <= 0)
        {
            LoseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void SelectTower(TowerObject tower)
    {
        this.selectedTower = tower;
    }

    public TowerObject GetSelectedTower()
    {
        return selectedTower;
    }
}
