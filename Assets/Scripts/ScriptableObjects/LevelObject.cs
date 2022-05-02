using UnityEngine;

/// <summary>
/// Scriptable object template for a level.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
[System.Serializable]
[CreateAssetMenu(menuName = "Level", fileName = "Level.asset")]
public class LevelObject : ScriptableObject
{
    [Tooltip("The waves for this level.")]
    public WaveObject[] waves;

    [Tooltip("Time in seconds between enemy spawns.")]
    public float timeBetweenSpawns = 1;
}
