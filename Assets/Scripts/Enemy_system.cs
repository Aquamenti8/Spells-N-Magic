using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_system : MonoBehaviour {



    public GameObject enemyPrefab;

    public Vector3 pos1_1;
    public Vector3 pos2_1;
    public Vector3 pos2_2;
    public Vector3 pos3_1;
    public Vector3 pos3_2;
    public Vector3 pos3_3;

    public List<GameObject> List_target;

    public int dungeon_room;
    public Enemy[][] Dungeon;

    // UI
    public GameObject Menu_battleend;
    public GameObject Menu_Leveling;
    public GameObject Menu_NextRoom;



    void Start () {

        Dungeon = GameObject.Find("Dungeon_system").GetComponent<Dungeon_system>().current_dungeon;
        Enemy[] enemy_group = Dungeon[0];

        // Debut Combat
        Instanciate_Enemy(enemy_group);
    }
	
	// Update is called once per frame
	void Update () {


        // Tous les ennemis sont morts
        if(List_target.Count == 0)
        {
            Menu_battleend.SetActive(true);
            Menu_Leveling.SetActive(true);
        }

        if(Menu_NextRoom.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Menu_NextRoom.SetActive(false);
                Menu_battleend.SetActive(false);


                dungeon_room += 1;
                int _lenght = Dungeon.Length;
                if (dungeon_room < Dungeon.Length)
                {
                    ChargeDungeonRoom(Dungeon[dungeon_room]);
                }
                else Application.Quit();

            }
        }
        if (Menu_Leveling.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Menu_NextRoom.SetActive(true);
                Menu_Leveling.SetActive(false);
            }
        }

    }

    public void ChargeDungeonRoom(Enemy[] room)
    {
        Instanciate_Enemy(room);
    }

    public void AssignTargetIndex()
    {
        for (int i = 0; i < List_target.Count; i++)
        {
            List_target[i].GetComponent<Enemy_behavior>().Target_index = i;
        }
    }

    void Instanciate_Enemy(Enemy[] array)
    {
        List_target.Clear();

        if (array.Length == 1)
        {
            GameObject Target1 = Instantiate(enemyPrefab, pos1_1, Quaternion.identity);
            List_target.Add(Target1);
            Target1.GetComponent<Enemy_behavior>().GetClassIntel(array[0]);
            Target1.transform.parent = gameObject.transform;
        }
        else if (array.Length == 2)
        {
            GameObject Target1 = Instantiate(enemyPrefab, pos2_1, Quaternion.identity);
            GameObject Target2 = Instantiate(enemyPrefab, pos2_2, Quaternion.identity);

            Target1.GetComponent<Enemy_behavior>().GetClassIntel(array[0]);
            Target2.GetComponent<Enemy_behavior>().GetClassIntel(array[1]);

            Target1.transform.parent = gameObject.transform;
            Target2.transform.parent = gameObject.transform;


            List_target.Add(Target1);
            List_target.Add(Target2);

        }
        else if (array.Length == 3)
        {
            GameObject Target1 = Instantiate(enemyPrefab, pos3_1, Quaternion.identity);
            GameObject Target2 = Instantiate(enemyPrefab, pos3_2, Quaternion.identity);
            GameObject Target3 = Instantiate(enemyPrefab, pos3_3, Quaternion.identity);

            Target1.GetComponent<Enemy_behavior>().GetClassIntel(array[0]);
            Target2.GetComponent<Enemy_behavior>().GetClassIntel(array[1]);
            Target3.GetComponent<Enemy_behavior>().GetClassIntel(array[2]);

            Target1.transform.parent = gameObject.transform;
            Target2.transform.parent = gameObject.transform;
            Target3.transform.parent = gameObject.transform;

            List_target.Add(Target1);
            List_target.Add(Target2);
            List_target.Add(Target3);
        }

    }
}
