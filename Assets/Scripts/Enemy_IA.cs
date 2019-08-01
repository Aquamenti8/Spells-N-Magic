using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_IA {

    // Decrit l'IA d'un enemi
    // Dictionnaire de skills

    // ----------------------------------------------------------------------------------------------------------
    // !!!!!!!!! SELECT NEXT MOVE !!!!!!!!!
    // ----------------------------------------------------------------------------------------------------------

    public static string Next_Move(Enemy_behavior enemy)        
    {
        string _name = "";

        //  THINK, GET A NAME

        switch (enemy.enemy_name)       
        {
            case "Boxter":

                if (Random.Range(0.0f, 1.0f) > 0.9)
                {
                    _name = "Sk_Large_Attack";
                }
                else _name = "Sk_Attack";

                    break;

            case "Boxtosor": _name = "Sk_Attack";  break;

            default: break;
        }

        // ASSIGN NEXT MOVE

        return _name;
    }
    public static float Next_Move_duration(string _name)
    {
        float _duration = 0;

        // WITH THE NAME, GET A DURATION
        switch (_name)
        {
            case "Sk_Attack": _duration = 3 + Random.Range(-0.1f,0.1f); break;
            case "Sk_Large_Attack": _duration = 5f + Random.Range(-0.1f, 0.1f) ; break;
            default: break;
        }

        return _duration;
    }

    public static float Next_Move_shield(string _name)
    {
        float _shield = 0;

        // WITH THE NAME, GET A DURATION
        switch (_name)
        {
            case "Sk_Attack": _shield = 3 ; break;
            case "Sk_Large_Attack": _shield = 5; break;
            default: break;
        }

        return _shield;
    }

    // ----------------------------------------------------------------------------------------------------------
    // !!!!!!!!! LAUNCH NEXT MOVE !!!!!!!!!
    // ----------------------------------------------------------------------------------------------------------

    public static void LaunchSkill (string skill, Enemy_behavior enemy)
    {
        switch (skill)
        {
            case "Sk_Attack": Sk_Attack(enemy);break;
            case "Sk_Large_Attack": Sk_Large_Attack(enemy); break;
            default: break;
        }
    }


    // ----------------------------------------------------------------------------------------------------------
    // !!!!!!!!!!!!!!! SKILLS FONCTIONS !!!!!!!!!!!!!!!!!
    // ----------------------------------------------------------------------------------------------------------
    static void Sk_Attack(Enemy_behavior enemy)
    {
        float _coef = 1;
        Attack_player(enemy.POW * _coef);
    }
    static void Sk_Large_Attack(Enemy_behavior enemy)
    {
        float _coef = 2f;
        Attack_player(enemy.POW * _coef);

    }
    // ----------------------------------------------------------------------------------------------------------
    // !!!!!!!!!!!!!!! EFFECTS !!!!!!!!!!!!!!!!!
    // ----------------------------------------------------------------------------------------------------------
    static void Attack_player(float power)
    {
        Magic_wheel_behavior magic = GameObject.Find("Magic_wheel").GetComponent<Magic_wheel_behavior>();
        Saika_behaviour saika = GameObject.Find("Saika").GetComponent<Saika_behaviour>();

        float _damage = power;

        magic.shield_value_3 -= _damage;
        if (magic.shield_value_3 < 0) magic.shield_value_3 = 0;
        _damage -= magic.shield_value_3;
        if (_damage < 0) _damage = 0;

        magic.shield_value_2 -= _damage;
        if (magic.shield_value_2 < 0) magic.shield_value_2 = 0;
        _damage -= magic.shield_value_2;
        if (_damage < 0) _damage = 0;

        magic.shield_value_1 -= _damage;
        if (magic.shield_value_1 < 0)
        {
            magic.break_magic();
            magic.shield_value_1 = 0;
        }
        _damage -= magic.shield_value_1;
        if (_damage < 0) _damage = 0;


        if (_damage >0) saika.HP -= _damage;
    

        Debug.Log("Hit " + _damage);
    }
}


