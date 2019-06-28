using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_system : MonoBehaviour {

    // ENEMY 

    // creer un dictionnaire d'ennemis, qui a un nom donne un objet de class enemy
    // creer un array, chercher dans le dictionnaire 3 monstres a y mettre ( toujours en class enemy)
    // X creer des instances d'objets, les initialiser grace a la classe d'objet
    // X les placer dans la scene, aux positions necessaires celon si ya 1,2,3 enemis

    // Use this for initialization

    public GameObject enemyPrefab;

    public Vector3 pos1_1;
    public Vector3 pos2_1;
    public Vector3 pos2_2;
    public Vector3 pos3_1;
    public Vector3 pos3_2;
    public Vector3 pos3_3;

    public List<GameObject> List_target;


    void Start () {


        Dictionary<string, Enemy> Dico_enemy = new Dictionary<string, Enemy>();

        Enemy Box1 = new Enemy("Boxter", 10, 1, 2, 2);
        Enemy Box2 = new Enemy("Boxtosor", 15, 2, 3, 2.5f);

        Dico_enemy.Add("Boxter", Box1);
        Dico_enemy.Add("Boxtosor", Box2);

        Enemy[] enemy_group1 = { Box1 };
        Enemy[] enemy_group2 = { Box2, Box1 };
        Enemy[] enemy_group3 = { Box1, Box1, Box1 };

        // Debut Combat
        Instanciate_Enemy(enemy_group3);
    }
	
	// Update is called once per frame
	void Update () {
		
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
