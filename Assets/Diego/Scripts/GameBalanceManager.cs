using System.Data;
using UnityEngine;
using UnityEngine.Rendering;
using System.Collections.Generic;

public class GameBalanceManager : MonoBehaviour
{
    public static GameBalanceManager Instance;

    int growth = 1;
    int growthCounter = 3;

    float probReduction = 0.10f;
    float probIncrease = 0.01f;

    int difScale = 2;
    int difCounter = 3;

    List<ExplorablePoints> zones = ZoneDatabase.AllZones;


    void Awake()
    {
        Instance = this;
    }


    public void resourcesNeedGrowth()
    {
        if (growthCounter > 0)
        {
            growthCounter -= 1;
        }
        else
        {
            GlobalController.Instance.charResourcesRedu += growth;
            growthCounter = 3;
        }
    }
    

    public void zoneProbReduction(int index)
    {
        zones[index].foodProb = Mathf.Clamp(zones[index].foodProb - probReduction, 0f, 1f);
        zones[index].waterProb = Mathf.Clamp(zones[index].waterProb - probReduction, 0f, 1f);
        zones[index].EnergyProb = Mathf.Clamp(zones[index].EnergyProb - probReduction, 0f, 1f);
    }       

    public void zoneProbIncrease()
    {
        foreach (ExplorablePoints zone in zones)
        {
            zone.foodProb = Mathf.Clamp(zone.foodProb + probIncrease, 0f, 1f);
            zone.waterProb = Mathf.Clamp(zone.waterProb + probIncrease, 0f, 1f);
            zone.EnergyProb = Mathf.Clamp(zone.EnergyProb + probIncrease, 0f, 1f);
        }
    }

    public void difZonesScale()
    {
        if (difCounter > 0)
        {
            difCounter -= 1;
        }
        else
        {
            foreach (ExplorablePoints zone in zones)
            {
                zone.dangerLevel = Mathf.Clamp(zone.dangerLevel + difScale, 0, 100);
            }

            difCounter = 3;
        }
    }
}
