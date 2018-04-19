using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingCosts {

    

    public static int FarmUpgradeCost()
    {
        return 80;
    }
    public static int TowerUpgradeCost()
    {
        return 90;
    }
    public static int LumbermillUpgradeCost()
    {
        return 80;
    }

    public static int BarracksCost()
    {
        return 150;
    }
    public static int BarracksSoldierCost()
    {
        return 80;
    }
    public static int FarmCost(int level)
    {

        switch (level)
        {
            case 0:
                {
                    return 100;
                }
            case 1:
                {
                    return 150;
                }
            case 2:
                {
                    return 220;
                }
            case 3:
                {
                    return 300;
                }
            default: return 10000;
        }
    }
    public static int TowerCost(int level)
    {
        switch (level)
        {
            case 0:
                {
                    return 80;
                }
            case 1:
                {
                    return 120;
                }
            case 2:
                {

                    return 170;
                }
            case 3:
                {
                    return 220;
                }
            default: return 10000;
        }
    }
    public static int LumbermillCost(int level)
    {
        switch (level)
        {
            case 0:
                {
                    return 30;
                }
            case 1:
                {
                    return 70;
                }
            case 2:
                {

                    return 120;
                }
            case 3:
                {
                    return 150;
                }
            default: return 10000;
        }
    }
}
