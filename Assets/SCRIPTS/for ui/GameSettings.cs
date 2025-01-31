using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public static class GameSettings
{
    public static int difficulty = 1;  // 1=简单, 2=中等, 3=困难

    // 也可以直接存速度、切换间隔
    public static float targetMoveSpeed = 2f;
    public static float targetSwitchInterval = 2f;

    // 设置难度的函数
    public static void SetDifficulty(int level)
    {
        difficulty = level;

        switch (level)
        {
            case 1:
                targetMoveSpeed = 2f;
                targetSwitchInterval = 2f;
                UnityEngine.Debug.Log("asy 111 ");
                break;
            case 2:
                targetMoveSpeed = 4f;
                targetSwitchInterval = 1.5f;
                break;
            case 3:
                targetMoveSpeed = 6f;
                targetSwitchInterval = 1f;
                break;
        }
    }
}

