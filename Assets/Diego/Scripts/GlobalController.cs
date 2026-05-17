using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;

    List<Survivor> survivors;

    public List<Survivor> survivorTemplates;
    public List<NPCDialogueManager> npcDialogueManagers;

    List<ExplorablePoints> zones = ZoneDatabase.AllZones;

    [Header("NPCs")]
    public GameObject Lisa;
    public GameObject Katherine;
    public GameObject Jim;
    public GameObject Albert;
    public GameObject Antoine;


    int day;
    float attackProb = 0.20f;
    float randAttack;

    float deadByAttack = 0.05f;
    float charDead;

    public int charResourcesRedu = 2;

    void Awake()
    {
        Instance = this;

        survivors = new List<Survivor>();

        foreach (var s in survivorTemplates)
        {
            Survivor clone = Instantiate(s);
            clone.name = s.name;

            survivors.Add(clone);
        }
    }

    void Start()
    {
        day = 0;

        foreach (var npc in npcDialogueManagers)
        {

            if (npc != null)
            {
                npc.AssignBestConversation();
            }
        }
        Debug.Log("Simulation Started");
    }

    public void NextDay()
    {
        day += 1;
        Debug.Log("----- DAY " + day + " -----");


        foreach (var npc in npcDialogueManagers)
        {

            if (npc != null)
            {
                npc.AssignBestConversation();
            }
        }

        if (!survivors[0].alive) SceneChanger.Instance.changeScene("LoseScene");

        attackControl();


        foreach (Survivor survivor in survivors)
        {
            if (!survivor.alive)
                continue;

            if (survivor.busy)
            {
                ResolveExploration(survivor);
            }
            else
            {
                ResolveIdleSurvivor(survivor);
            }

        }

        GameBalanceManager.Instance.zoneProbIncrease();
        GameBalanceManager.Instance.resourcesNeedGrowth();
        GameBalanceManager.Instance.difZonesScale();

        Debug.Log("Day " + day + " ended");
        MapCanvasManager.Instance.showProfilesInfo(MapCanvasManager.Instance.currentSurvIndex);
    }

    void attackControl()
    {
        randAttack = UnityEngine.Random.Range(0f, 1f);

        if (DecisionControllerManager.Instance.Energy <= 0)
        {
            StartCoroutine(MapCanvasManager.Instance.ShowEmergencyAlert("Base Has Been Attacked"));
            Debug.Log("Base Has Been Attacked");

            DecisionControllerManager.Instance.Energy /= 2;
            Debug.Log("Energy reduced by half");

            foreach (Survivor survivor in survivors)
            {
                if (!survivor.busy && survivor.alive)
                {
                    survivor.sanity /= 2;
                    Debug.Log(survivor.name + " lost sanity due to attack");

                    charDead = UnityEngine.Random.Range(0f, 1f);

                    if (charDead <= deadByAttack)
                    {
                        survivor.alive = false;
                        Debug.Log(survivor.name + " died during base attack");

                        eliminateNPC(survivor.id);
                    }
                }
            }

            DecisionControllerManager.Instance.UpdateResources();
        }
        else
        {
            if (randAttack > attackProb)
            {
                DecisionControllerManager.Instance.Energy -= 1;
                Debug.Log("Base stable. Energy -1");
            }
            else
            {
                StartCoroutine(MapCanvasManager.Instance.ShowEmergencyAlert("Base Has Been Attacked"));
                Debug.Log("Base Has Been Attacked");

                DecisionControllerManager.Instance.Energy /= 2;
                Debug.Log("Energy reduced by half");

                foreach (Survivor survivor in survivors)
                {
                    if (!survivor.busy && survivor.alive)
                    {
                        survivor.sanity /= 2;
                        Debug.Log(survivor.name + " lost sanity due to attack");

                        charDead = UnityEngine.Random.Range(0f, 1f);

                        if (charDead <= deadByAttack)
                        {
                            survivor.alive = false;
                            Debug.Log(survivor.name + " died during base attack");

                            eliminateNPC(survivor.id);
                        }
                    }
                }

                DecisionControllerManager.Instance.UpdateResources();
            }

        }
    }

    private void ResolveExploration(Survivor survivor)
    {
        Debug.Log(survivor.name + " is exploring " + zones[survivor.currentPlaceIndex].name);

        float travelAttackProb = zones[survivor.currentPlaceIndex].dangerLevel / 100f;
        float randAttack = UnityEngine.Random.Range(0f, 1f);

        if (randAttack <= travelAttackProb)
        {
            survivor.sanity /= 2;
            Debug.Log(survivor.name + " encountered danger and lost sanity");
        }

        if (survivor.sanity <= 0)
        {
            survivor.alive = false;
            Debug.Log(survivor.name + " died from insanity");
            return;
        }

        survivor.timeBusy -= 1;

        if (survivor.timeBusy <= 0)
        {
            CompleteExpedition(survivor);
        }
    }


    private void CompleteExpedition(Survivor survivor)
    {
        survivor.timeBusy = 0;
        survivor.busy = false;

        Debug.Log(survivor.name + " returned from expedition");

        DecisionControllerManager.Instance.RecollectResources(survivor.currentPlaceIndex);
        Debug.Log(survivor.name + " collected resources from " + zones[survivor.currentPlaceIndex].name);

        GameBalanceManager.Instance.zoneProbReduction(survivor.currentPlaceIndex);

        survivor.currentPlaceIndex = 7;

        survivor.reduceHunger(survivor.hunger / 2);
        survivor.reduceThirst(survivor.thirst / 2);
        survivor.reduceSanity(survivor.sanity / 2);

        Debug.Log(survivor.name + " suffered expedition exhaustion");
    }


    private void ResolveIdleSurvivor(Survivor survivor)
    {
        survivor.reduceHunger(charResourcesRedu);
        survivor.reduceThirst(charResourcesRedu);

        Debug.Log(survivor.name + " consumed daily resources");

        if (survivor.hunger <= 0 || survivor.thirst <= 0)
        {
            survivor.hunger = 0;
            survivor.thirst = 0;

            survivor.sanity -= 2;

            Debug.Log(survivor.name + " is starving/dehydrated and losing sanity");
        }

        if (survivor.sanity <= 0)
        {
            survivor.alive = false;
            Debug.Log(survivor.name + " died from mental collapse");
        }
    }


    public int GetDay()
    {
        return day;
    }

    public Survivor GetSurvivor(int index)
    {
        Debug.Log("ConditionID: '" + index + "'");
        return survivors.FirstOrDefault(s => s.id == index);
    }

    public List<Survivor> GetSurvivorList()
    {
        return survivors;
    }

    public void eliminateNPC(int index)
    {
        switch (index)
        {
            case 1:
                Destroy(Lisa.gameObject);
                break;

            case 2:
                Destroy(Katherine.gameObject);
                break;

            case 3:
                Destroy(Jim.gameObject);
                break;

            case 4:
                Destroy(Albert.gameObject);
                break;

            case 5:
                Destroy(Antoine.gameObject);
                break;

        }

    }
}
