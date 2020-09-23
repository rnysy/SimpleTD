using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public static int Money;
    public int startMoney = 500;

    private void Start()
    {
        Money = startMoney;
    }
}
