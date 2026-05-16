using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class MapCanvasManager : MonoBehaviour
{
    public static MapCanvasManager Instance;

    List<ExplorablePoints> zones = ZoneDatabase.AllZones;
    List<Survivor> survivors = SurvivorDatabase.AllSurvivors;

    public int currentSurvIndex;

    public TextMeshProUGUI infoText;

    [Header("NameButtonsInfo")]
    public TextMeshProUGUI intP1Text;
    public TextMeshProUGUI intP2Text;
    public TextMeshProUGUI intP3Text;
    public TextMeshProUGUI Vil1Text;
    public TextMeshProUGUI Vil2Text;
    public TextMeshProUGUI City1Text;
    public TextMeshProUGUI City2Text;

    [Header("NameButtonsAction")]
    public TextMeshProUGUI intP1Text2;
    public TextMeshProUGUI intP2Text2;
    public TextMeshProUGUI intP3Text2;
    public TextMeshProUGUI Vil1Text2;
    public TextMeshProUGUI Vil2Text2;
    public TextMeshProUGUI City1Text2;
    public TextMeshProUGUI City2Text2;


    [Header("ProfileButtons")]
    public TextMeshProUGUI profile1;
    public TextMeshProUGUI profile2;
    public TextMeshProUGUI profile3;
    public TextMeshProUGUI profile4;
    public TextMeshProUGUI profile5;
    public TextMeshProUGUI profile6;


    [Header("ActionButtons")]
    public Button giveFoodButton;
    public Button giveWaterButton;
    public Button sendPlaceButton;


    [Header("MapInfoButtons")]
    public GameObject mapInfoButtons;

    [Header("SendActionButtons")]
    public GameObject SendActionButtons;



    void Awake()
    {
        Instance = this;
    }



    void Start()
    {
        intP1Text.text = zones[0].name;
        intP2Text.text = zones[1].name;
        intP3Text.text = zones[2].name;

        Vil1Text.text = zones[3].name;
        Vil2Text.text = zones[4].name;

        City1Text.text = zones[5].name;
        City2Text.text = zones[6].name;


        intP1Text2.text = zones[0].name;
        intP2Text2.text = zones[1].name;
        intP3Text2.text = zones[2].name;

        Vil1Text2.text = zones[3].name;
        Vil2Text2.text = zones[4].name;

        City1Text2.text = zones[5].name;
        City2Text2.text = zones[6].name;


        profile1.text = survivors[0].name;
        profile2.text = survivors[1].name;
        profile3.text = survivors[2].name;
        profile4.text = survivors[3].name;
        profile5.text = survivors[4].name;
        profile6.text = survivors[5].name;

        giveFoodButton.gameObject.SetActive(false);
        giveWaterButton.gameObject.SetActive(false);
        sendPlaceButton.gameObject.SetActive(false);

        SendActionButtons.SetActive(false);
        mapInfoButtons.SetActive(true);
    }

    public void showZonesInfo(int zoneIndex)
    {
        ExplorablePoints zone = zones[zoneIndex];

        giveFoodButton.gameObject.SetActive(false);
        giveWaterButton.gameObject.SetActive(false);
        sendPlaceButton.gameObject.SetActive(false);

        SendActionButtons.SetActive(false);
        mapInfoButtons.SetActive(true);


        infoText.text = "Danger Level: " + zone.dangerLevel + "\n \n"
                        + "Food Probability: " + zone.foodProb + "\n"
                        + "Max Food: " + zone.maxFood + "\n \n"
                        + "Water Probability: " + zone.waterProb + "\n"
                        + "Max Water: " + zone.maxWater + "\n \n"
                        + "Energy Probability: " + zone.EnergyProb + "\n"
                        + "Max Energy: " + zone.maxEnergy;


    }

    public void showProfilesInfo(int profIndex)
    {
        Survivor surv = survivors[profIndex];

        currentSurvIndex = profIndex;

        giveFoodButton.gameObject.SetActive(true);
        giveWaterButton.gameObject.SetActive(true);
        sendPlaceButton.gameObject.SetActive(true);

        SendActionButtons.SetActive(false);
        mapInfoButtons.SetActive(true);


        infoText.text = "Name: " + surv.name + "\n \n"
                    + "Hunger: " + surv.hunger + "\n"
                    + "Thirst: " + surv.thirst + "\n \n"
        + "Current Place: " + zones[surv.currentPlaceIndex].name;
    }


    public void sendPlaceAction()
    {
        SendActionButtons.SetActive(true);
        mapInfoButtons.SetActive(false);
    }

    


}