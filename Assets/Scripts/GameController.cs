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
    [Tooltip("TMP element that holds the text for the wave display.")]
    private TextMeshProUGUI waveDisplay;

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
    private bool gameRunning = true;

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
        if (loadedLevel == null)
        {
            waves = null;
        }
        else
        {
            waves = loadedLevel.waves;
        }
        secondsTillNextWave = secondsBetweenWaves;
        lives = startingLives;
        livesCounter.text = "" + lives;
        money = startingMoney;
        moneyDisplay.text = "$" + money;
        waveDisplay.text = "Current wave: " + currentWave;
        StartCoroutine("StartWaves");
        PauseGame();
    }

    // Called as a coroutine, starts the wave spawning process
    IEnumerator StartWaves()
    {
        while(gameRunning)
        {
            int money = ((currentWave / 5) + 2);
            if (waves != null)
            {
                WaveObject wave = waves[currentWave - 1];
                for (int index = 0; index < wave.spawns; index++)
                {
                    Transform e = Instantiate(enemy, spawnPosition, new Quaternion(0, 90, 0, 90));
                    EnemyAI ai = e.GetComponent<EnemyAI>();
                    ai.SetHealth(wave.health);   // Update enemy hp
                    ai.SetSpeed(wave.speed);     // Update enemy speed
                    ai.SetMoneyReward(money);       // Update enemy money
                    timer.text = "" + ((wave.spawns - index) - 1);
                    yield return new WaitForSeconds(loadedLevel.timeBetweenSpawns);
                }
            }
            else
            {
                int spawns = ((currentWave / 5) * 5) + 15;
                int health = (int)(100 * Mathf.Pow(1.5f, currentWave - 1));
                float speed = ((currentWave / 10) * 1.1f) + 1;
                for (int index = 0; index < spawns; index++)
                {
                    Transform e = Instantiate(enemy, spawnPosition, new Quaternion(0, 90, 0, 90));
                    EnemyAI ai = e.GetComponent<EnemyAI>();
                    ai.SetHealth(health);   // Update enemy hp
                    ai.SetSpeed(speed);     // Update enemy speed
                    ai.SetMoneyReward(money);   // Update enemy money
                    timer.text = "" + ((spawns - index) - 1);
                    yield return new WaitForSeconds(2f);    // TODO scale this
                }
            }
            while (secondsTillNextWave > 0)
            {
                timer.text = "" + secondsTillNextWave;
                yield return new WaitForSeconds(1);
                --secondsTillNextWave;
            }
            ++currentWave;
            waveDisplay.text = "Current wave: " + currentWave;
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

    public void FastForwardGame()
    {
        Time.timeScale = 3;
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
