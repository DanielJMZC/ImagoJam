
public class Survivor
{
    public string name { get; set; }

    public int sanity { get; set; }
    public int hunger { get; set; }
    public int thirst { get; set; }

    public bool busy { get; set; }
    public int timeBusy { get; set; }

    public int currentPlaceIndex { get; set; }



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

}

