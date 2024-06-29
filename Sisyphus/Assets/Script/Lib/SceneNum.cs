using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SceneNum 
{
    public const int start = 0;
    public const int baseNum = 1;
    public const int level_1 = 2;
    public static int SceneOfCurrentStage => DataStorage.stage + 1;
}
