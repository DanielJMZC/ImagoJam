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


    public void zoneProbReduction(int index)
    {
        zones[index].foodProb -= probReduction;
        zones[index].waterProb -= probReduction;
        zones[index].EnergyProb -= probReduction;
    }

    public void zoneProbIncrease()
    {
        foreach (ExplorablePoints zone in zones)
        {
            zone.foodProb += probIncrease;
            zone.waterProb += probIncrease;
            zone.EnergyProb += probIncrease;
        }
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
                zone.dangerLevel += difScale;
                difCounter = 3;  
            }
            
        }
    }
}
