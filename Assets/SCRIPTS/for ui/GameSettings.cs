using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public static class GameSettings
{
    public static int difficulty = 1;  // 1=��, 2=�е�, 3=����

    // Ҳ����ֱ�Ӵ��ٶȡ��л����
    public static float targetMoveSpeed = 2f;
    public static float targetSwitchInterval = 2f;

    // �����Ѷȵĺ���
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

