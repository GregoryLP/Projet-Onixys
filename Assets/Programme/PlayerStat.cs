using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {
    public static int money;
    public int startMoney = 1000;

    public void Start()
    {
        money = startMoney;
        Debug.Log("money :" + money);
    }
}
