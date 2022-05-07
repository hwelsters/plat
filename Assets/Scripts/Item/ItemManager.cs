using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static int lives = 3;
    private static int gems = 0;
    private static bool[] wasPickedUp = new bool[1000];
    private static bool hasGun = false;

    public static bool GetHasGun()
    {
        return hasGun;
    }

    public static void SetHasGun()
    {
        hasGun = true;
    }

    public static bool GetWasPickedUp(int itemId) 
    {
        return wasPickedUp[itemId];
    }

    public static void SetWasPickedUp(int itemId) 
    {
        wasPickedUp[itemId] = true;
    }
}
