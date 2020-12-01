using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * This component attached to each enemy and count them
 */
public class EnemyCounter : MonoBehaviour
{

    private static int count = 0;
    public void Awake()
    {
        count++;
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
