using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Arcane : IComparable<Arcane> {

    // ----------------------------------------------------------------------------------------------------------
    // !!!!!!!!! CLASS ARCANE !!!!!!!!!
    // ----------------------------------------------------------------------------------------------------------


    public string name;
    public Color color;
    public float coef;
    public int level;
    public float shield;

    public Arcane(string newName, Color newColor, float newcoef, int newlevel, float newshield)
    {
        name = newName;
        color = newColor;
        coef = newcoef;
        level = newlevel;
        shield = newshield;
    }
    

    public int CompareTo(Arcane other)
    {
        if (other == null)
        {
            return 1;
        }

        return level - other.level;
    }

    public static void LaunchArcane(string name)
    {
        // get power, element
        float _power = 0;
        string _element = "";
        switch (name)
        {
            case "Fire Rune":
                _power = 5;
                _element = "fire";
                break;
            case "Water Rune":
                _power = 5;
                _element = "water";
                break;
            case "Wind Rune":
                _power = 5;
                _element = "wind";
                break;
            case "Earth Rune":
                _power = 5;
                _element = "earth";
                break;

            case "Fire Ball":
                _power = 8;
                _element = "fire";
                break;

               
            default: Debug.Log("LaunchArcane(), name not found" + "  found name: " + name); break;

        }

        if (_power != 0)
        {
            Attack_monster(_power, _element);
        }

    }

    public static void Attack_monster(float power, string _element)
    {
        float _HP_loss = 0;
        int _t_index = GameObject.Find("Magic_wheel").GetComponent<Magic_wheel_behavior>().target_index;

        Enemy_behavior target = GameObject.Find("Enemies").GetComponent<Enemy_system>().List_target[_t_index].GetComponent<Enemy_behavior>();
        _HP_loss = power;
        _HP_loss -= target.DEF;
        if (target.vulnerabilities.Contains(_element))
        {
            _HP_loss += _HP_loss*0.5f;
        }
        if (target.resistances.Contains(_element))
        {
            _HP_loss -= _HP_loss * 0.5f;
        }

        target.HP -= _HP_loss;

        if(target.skill_shield < power)
        {
            target.BreakSkill();
        }
    }

}
