using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

    private static int count = 0;
    public void Awake()
    {
        count++;
        Debug.Log(count);
    }

    public static void EnemyDie()
    {
        count--;
    }

    public static int getCount() {
        return count;
    }

    public static void setCount(int newCount)
    {
        count = newCount;
    }


}
