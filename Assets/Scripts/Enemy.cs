using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Enemy {


    public string enemy_name;
    public float HP;
    public float HP_max;
    public int level;
    public int power;
    public float ATB;
    public float ATB_max;
    public GameObject skin;




    public Enemy(string newName, float newHP_max, int _level, int _power, float _ATB_max)
    {
        enemy_name = newName;
        HP_max = newHP_max;
        HP = HP_max;
        level = _level;
        power = _power;
        ATB_max = _ATB_max;
        ATB = 0;

    }


}
