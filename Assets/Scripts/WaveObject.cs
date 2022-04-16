using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Wave", fileName = "Wave.asset")]
public class WaveObject : ScriptableObject
{
    [Tooltip("How many enemies will spawn in the wave.")]
    public int spawns = 15;

    [Tooltip("How much health the enemies will have.")]
    public int health = 100;

    [Tooltip("The speed of the enemies.")]
    public float speed = 1;
}
