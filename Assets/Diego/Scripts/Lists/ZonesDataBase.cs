using System.Collections.Generic;

public static class ZoneDatabase
{
    public static List<ExplorablePoints> AllZones = new List<ExplorablePoints>()
    {
        new ExplorablePoints()
    
        {
            name = "Old Storage",
            dangerLevel = 2,
            foodProb = 0.65f,
            waterProb = 0.60f,
            EnergyProb = 0.10f,
            maxFood = 15,
            maxWater = 15,
            maxEnergy = 8,
            distance = 2
        },

        new ExplorablePoints()
        {
            name = "Corrupted Tree",
            dangerLevel = 6,
            foodProb = 0.55f,
            waterProb = 0.55f,
            EnergyProb = 0.65f,
            maxFood = 10,
            maxWater = 8,
            maxEnergy = 15,
            distance = 2
        },

        new ExplorablePoints()
        {
            name = "Collapsed Investigation Center",
            dangerLevel = 5,
            foodProb = 0.50f,
            waterProb = 0.10f,
            EnergyProb = 0.60f,
            maxFood = 10,
            maxWater = 10,
            maxEnergy = 18,
            distance = 3
        },


        // POBLADOS (riesgo medio, recursos moderados)

        new ExplorablePoints()
        {
            name = "Hospital",
            dangerLevel = 5,
            foodProb = 0.15f,
            waterProb = 0.75f,
            EnergyProb = 0.15f,
            maxFood = 15,
            maxWater = 30,
            maxEnergy = 10,
            distance = 4
        },

        new ExplorablePoints()
        {
            name = "Nuclear Plant",
            dangerLevel = 6,
            foodProb = 0.25f,
            waterProb = 0.30f,
            EnergyProb = 0.90f,
            maxFood = 25,
            maxWater = 20,
            maxEnergy = 60,
            distance = 5
        },


        // CIUDADES (alto riesgo, gran recompensa)

        new ExplorablePoints()
        {
            name = "Devastated City",
            dangerLevel = 8,
            foodProb = 0.85f,
            waterProb = 0.80f,
            EnergyProb = 0.85f,
            maxFood = 60,
            maxWater = 50,
            maxEnergy = 50,
            distance = 7
        },

        new ExplorablePoints()
        {
            name = "Infected Metropolis",
            dangerLevel = 10,
            foodProb = 0.95f,
            waterProb = 0.90f,
            EnergyProb = 0.95f,
            maxFood = 80,
            maxWater = 80,
            maxEnergy = 70,
            distance = 10
        },

        new ExplorablePoints()
        {
            name = "Home",
            dangerLevel = 0,
            foodProb = 0f,
            waterProb = 0f,
            EnergyProb = 0f,
            maxFood = 0,
            maxWater = 0,
            maxEnergy = 0,
            distance = 0
        }
    };
}