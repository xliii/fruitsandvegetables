using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Levels")]
public class Levels : ScriptableObject
{
    public LevelConfig[] levels;
}
