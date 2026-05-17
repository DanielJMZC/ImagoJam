using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class DecisionControllerManager : MonoBehaviour
{
    public static DecisionControllerManager Instance;

    List<ExplorablePoints> zones = ZoneDatabase.AllZones;
    List<Survivor> survivors;


    [Header("ResourcesText")]
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI energyText;

    int Food = 50;
    int Water = 50;
    public int Energy = 50;



    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        survivors = GlobalController.Instance.GetSurvivorList();
        
        UpdateResources();
    }


    public void UpdateResources()
    {
        foodText.text = "" + Food;
        waterText.text = "" + Water;
        energyText.text = "" + Energy;
    }

    public void RecollectResources(int index)
    {
        ExplorablePoints zone = zones[index];

        float foodRand = Random.Range(0f, 1f);
        float waterRand = Random.Range(0f, 1f);
        float energyRand = Random.Range(0f, 1f);

        if (foodRand <= zone.foodProb)
        {
            Food += Random.Range(1, zone.maxFood);
        }

        if (waterRand <= zone.waterProb)
        {
            Water += Random.Range(1, zone.maxWater);
        }

        if (energyRand <= zone.EnergyProb)
        {
            Energy += Random.Range(1, zone.maxEnergy);
        }

        UpdateResources();
    }


    public void giveFood()
    {
        Survivor surv = survivors[MapCanvasManager.Instance.currentSurvIndex];

        if (surv.alive && Food > 0)
        {
           if (!surv.busy)
            {
                survivors[MapCanvasManager.Instance.currentSurvIndex].increaseHunger(2);
                Food -= 2;
            }
            

            UpdateResources();
            MapCanvasManager.Instance.showProfilesInfo(MapCanvasManager.Instance.currentSurvIndex); 
        }
        

    }

    public void giveWater()
    {
        Survivor surv = survivors[MapCanvasManager.Instance.currentSurvIndex];

        if (surv.alive && Water > 0)
        {
            if (!surv.busy)
            {
                survivors[MapCanvasManager.Instance.currentSurvIndex].increaseThirst(2);
                Water -= 2;
            }

            UpdateResources();
            MapCanvasManager.Instance.showProfilesInfo(MapCanvasManager.Instance.currentSurvIndex);
        }

        

    }

    public void sendToPlace(int index)
    {
        Survivor surv = survivors[MapCanvasManager.Instance.currentSurvIndex];

        if (surv.alive && !(MapCanvasManager.Instance.currentSurvIndex == 0))
        {
            if (!surv.busy && surv.currentPlaceIndex == 7)
            {
                surv.currentPlaceIndex = index;
                surv.busy = true;
                surv.timeBusy = zones[index].distance;
            } 

            MapCanvasManager.Instance.showProfilesInfo(MapCanvasManager.Instance.currentSurvIndex);
        }

        
    }

    public int GetFood()
    {
        return Food;
    }

    public int GetWater()
    {
        return Water;
    }

    public int GetEnergy()
    {
        return Energy;
    }

}
