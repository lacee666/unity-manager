using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingCosts {

    public static int FarmCost(int level)
    {

        switch (level)
        {
            case 0:
                {
                    return 10;
                }
            case 1:
                {
                    return 20;
                }
            case 2:
                {
                    return 30;
                }
            case 3:
                {
                    return 40;
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
                    return 50;
                }
            case 1:
                {
                    return 100;
                }
            case 2:
                {

                    return 150;
                }
            case 3:
                {
                    return 200;
                }
            default: return 10000;
        }
    }
}
