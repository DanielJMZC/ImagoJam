using System.Collections.Generic;

public static class ZoneDatabase
{
    public static List<ExplorablePoints> AllZones = new List<ExplorablePoints>()
    {
        new ExplorablePoints()
    
        {
            name = "Abandoned Camp",
            dangerLevel = 2,
            foodProb = 0.65f,
            waterProb = 0.60f,
            EnergyProb = 0.40f,
            maxFood = 15,
            maxWater = 15,
            maxEnergy = 8,
            distance = 2
        },

        new ExplorablePoints()
        {
            name = "Destroyed Gas Station",
            dangerLevel = 3,
            foodProb = 0.50f,
            waterProb = 0.45f,
            EnergyProb = 0.65f,
            maxFood = 10,
            maxWater = 8,
            maxEnergy = 15,
            distance = 2
        },

        new ExplorablePoints()
        {
            name = "Collapsed Investigation Center",
            dangerLevel = 4,
            foodProb = 0.40f,
            waterProb = 0.50f,
            EnergyProb = 0.70f,
            maxFood = 8,
            maxWater = 10,
            maxEnergy = 18,
            distance = 3
        },


        // POBLADOS (riesgo medio, recursos moderados)

        new ExplorablePoints()
        {
            name = "Phantom Village",
            dangerLevel = 5,
            foodProb = 0.70f,
            waterProb = 0.65f,
            EnergyProb = 0.55f,
            maxFood = 30,
            maxWater = 25,
            maxEnergy = 20,
            distance = 4
        },

        new ExplorablePoints()
        {
            name = "Inhospitable Refuge",
            dangerLevel = 6,
            foodProb = 0.75f,
            waterProb = 0.70f,
            EnergyProb = 0.60f,
            maxFood = 35,
            maxWater = 30,
            maxEnergy = 25,
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
            maxFood = 100,
            maxWater = 80,
            maxEnergy = 90,
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