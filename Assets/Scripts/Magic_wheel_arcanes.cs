using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Magic_wheel_arcanes : MonoBehaviour {


    public Arcane neutral = new Arcane("neutral", Color.grey, 1f, 0);
    /*
    public Arcane Fire_Rune = new Arcane("Fire Rune", Color.red, 2f, 0);
    public Arcane Water_Rune = new Arcane("Water Rune", Color.red, 2f, 0);
    public Arcane Wind_Rune = new Arcane("Wind Rune", Color.red, 1f, 0);
    public Arcane Earth_Rune = new Arcane("Earth Rune", Color.red, 2f, 0);
    */
    public Arcane Fire_Rune = new Arcane("Fire Rune", new Color(1,0.28f,0.28f), 2f, 0);
    public Arcane Water_Rune = new Arcane("Water Rune", new Color(0.32f,0.85f,1), 2f, 0);
    public Arcane Wind_Rune = new Arcane("Wind Rune", new Color(0.86f, 0.5f, 0.9f), 1f, 0);
    public Arcane Earth_Rune = new Arcane("Earth Rune", new Color(0.73f, 1, 0.28f), 2f, 0);
    
    public Arcane Fire_Ball = new Arcane("Fire Ball", Color.red, 1.5f, 0);

    public Arcane[] Magic_Wheel;
    public Arcane[] Wheel_000;
    public Arcane[] Fire_000;
    public Arcane[] Fire_101;
    public Arcane[] Neutral;

    void Start()
    {
         List<Arcane> known_arcanes = new List<Arcane>();
        known_arcanes.Add(Fire_Rune);
        known_arcanes.Add(Water_Rune);
        known_arcanes.Add(Wind_Rune );
        known_arcanes.Add(Earth_Rune);

        Neutral = new Arcane[4];
        Wheel_000 = new Arcane[4];
        Magic_Wheel = new Arcane[4];
        Fire_000 = new Arcane[4];
        Fire_101 = new Arcane[4];

        Neutral[0] = neutral;

        Wheel_000[0] = Wind_Rune;
        Wheel_000[1] = Fire_Rune;
        Wheel_000[2] = Earth_Rune;
        Wheel_000[3] = Water_Rune;

        Fire_000[0] = neutral;
        Fire_000[1] = Fire_Ball;
        Fire_000[2] = neutral;
        Fire_000[3] = neutral;

        Fire_101[0] = neutral;
        Fire_101[1] = neutral;
        Fire_101[2] = neutral;
        Fire_101[3] = neutral;

        Neutral[0] = neutral;
        Neutral[1] = neutral;
        Neutral[2] = neutral;
        Neutral[3] = neutral;


        Magic_Wheel = Wheel_000;
    }


}
