using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeon_system : MonoBehaviour {


    public Enemy[][] current_dungeon;

    Dictionary<string, Enemy> Dico_enemy = new Dictionary<string, Enemy>();

    //      NAME HP LEVEL POWER ATB DEF
    Enemy Box1 = new Enemy("Boxter", 10, 1, 2, 2, 2);
    Enemy Box2 = new Enemy("Boxtosor", 15, 2, 3, 2.5f, 4);


    // Use this for initialization
    void Start () {



        Dico_enemy.Add("Boxter", Box1);
        Dico_enemy.Add("Boxtosor", Box2);

        Enemy[] enemy_group1 = { Box1 };
        Enemy[] enemy_group2 = { Box2, Box1 };
        Enemy[] enemy_group3 = { Box1, Box1, Box1 };


        Enemy[][] dungeon1 = { enemy_group1, enemy_group2, enemy_group3 };

        current_dungeon = dungeon1;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
