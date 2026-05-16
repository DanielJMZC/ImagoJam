using UnityEngine;
using System.Collections.Generic;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;
    List<Survivor> survivors = SurvivorDatabase.AllSurvivors;
    int day;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        day = 0;
    }


    public void NextDay()
    {
        day += 1;

        foreach (Survivor survivor in survivors)
        {
            if (survivor.busy)
            {
                survivor.timeBusy -= 1;

                if (survivor.timeBusy <= 0)
                {
                    survivor.timeBusy = 0;
                    survivor.busy = false;

                    DecisionControllerManager.Instance.RecollectResources(survivor.currentPlaceIndex);

                    survivor.currentPlaceIndex = 7;

                    survivor.reduceHunger(survivor.hunger / 2);
                    survivor.reduceThirst(survivor.thirst / 2);
                    survivor.reduceSanity(survivor.sanity / 2);
                }

            }
            else
            {
                survivor.reduceHunger(2);
                survivor.reduceThirst(2); 
            }

            
        }
    }


    public int getDay()
    {
        return day;
    }
}
