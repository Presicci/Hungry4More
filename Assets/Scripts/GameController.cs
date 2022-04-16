using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField]
    private LevelObject loadedLevel;

    //[SerializeField]
    //private int lives = 50;

    [SerializeField]
    private Transform enemy;

    private WaveObject[] waves;
    private int currentWave = 1;
    private Vector3 spawnPosition = new Vector3(5, 0, 0);

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

    public void SelectTower(TowerObject tower)
    {
        this.selectedTower = tower;
    }

    public TowerObject GetSelectedTower()
    {
        return selectedTower;
    }
}
