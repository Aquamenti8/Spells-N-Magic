using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arcane : IComparable<Arcane> {


    public string name;
    public Color color;
    public float coef;
    public int level;

    public Arcane(string newName, Color newColor, float newcoef, int newlevel)
    {
        name = newName;
        color = newColor;
        coef = newcoef;
        level = newlevel;
    }
    

    public int CompareTo(Arcane other)
    {
        if (other == null)
        {
            return 1;
        }

        return level - other.level;
    }

}
