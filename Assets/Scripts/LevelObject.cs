using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Level", fileName = "Level.asset")]
public class LevelObject : ScriptableObject
{
    [Tooltip("The waves for this level.")]
    public WaveObject[] waves;

    [Tooltip("Time in seconds between enemy spawns.")]
    public float timeBetweenSpawns = 1;
}
