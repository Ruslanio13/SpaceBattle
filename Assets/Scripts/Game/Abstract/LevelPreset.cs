using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelPreset", menuName = "LevelPreset", order = 1)]
public class LevelPreset : ScriptableObject
{
    public List<int> Lines;
    public List<GameObject> Walls;
    public int[] EnemiesCount;
    public Enemy[] EnemiesPrefabs;
    public int MinLen;
    public int MaxLen;

}
