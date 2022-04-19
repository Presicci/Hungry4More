using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private TextMeshPro timer;

    [SerializeField]
    private TextMeshPro livesCounter;

    [SerializeField]
    private TextMeshProUGUI moneyDisplay;

    [SerializeField]
    private LevelObject loadedLevel;

    [SerializeField]
    private Transform enemy;

    [SerializeField]
    private int secondsBetweenWaves;

    [SerializeField]
    private int startingMoney = 30;

    [SerializeField]
    private int startingLives = 20;

    private int secondsTillNextWave;

    private int lives;
    private int money;

    

    private WaveObject[] waves;
    private int currentWave = 1;
    private Vector3 spawnPosition = new Vector3(5, 0, 0.07f);

    private TowerObject selectedTower = null;

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
            // Lose game
        }
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
