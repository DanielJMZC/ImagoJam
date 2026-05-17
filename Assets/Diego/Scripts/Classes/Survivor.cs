using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Survivor", menuName = "Survivor")]
public class Survivor : ScriptableObject
{
    public string survivorName;
    public int id;

    public int sanity;
    public int hunger;
    public int thirst;

    public bool busy;
    public int timeBusy;

    public int currentPlaceIndex;

    public bool alive;

    public void reduceSanity(int val)
    {
        sanity -= val;
    }

    public void increaseSanity(int val)
    {
        sanity += val;
    }

    public void reduceHunger(int val)
    {
        hunger -= val;
    }

    public void increaseHunger(int val)
    {
        hunger += val;
    }

    public void reduceThirst(int val)
    {
        thirst -= val;
    }

    public void increaseThirst(int val)
    {
        thirst += val;
    }

    public void occupy(bool val)
    {
        busy = val;
    }

    public void reduceTime(int val)
    {
        timeBusy -= val;
    }

    public void increaseTime(int val)
    {
        timeBusy += val;
    }

    public int getSanity()
    {
        Debug.Log("Sanity value for " + survivorName + ": " + sanity);
        return sanity;
    }

    public int getHunger()
    {
        Debug.Log("Hunger value for " + survivorName + ": " + hunger);
        return hunger;
    }

    public int getThirst()
    {
        Debug.Log("Thirst value for " + survivorName + ": " + thirst);
        return thirst;
    }

    public bool getAlive()
    {
        Debug.Log("Alive status for " + survivorName + ": " + alive);
        return alive;
    }
}