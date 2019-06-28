using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Enemy_behavior : MonoBehaviour {

    public string enemy_name;
    public float HP;
    public float HP_max;
    public int level;
    public int power;
    public float ATB;
    public float ATB_max;
    public GameObject skin;
    public Enemy_system enemy_system;

    public int Target_index;
    public GameObject UIPrefab;


    private Vector3 pos1 = new Vector3(0, 0, 0);
    private Vector3 pos2 = new Vector3(160, 0, 0);
    private Vector3 pos3 = new Vector3(320, 0, 0);


    //UI
    public GameObject ATB_gauge;
    public GameObject HP_gauge;

    public GameObject Target_UI;


    // Use this for initialization
    void Start () {

        enemy_system = GameObject.Find("Enemies").GetComponent<Enemy_system>();

        if(enemy_system.List_target.Contains(gameObject))
        {
            Target_index = enemy_system.List_target.IndexOf(gameObject);
        }

        CreateUI();

        ATB_gauge = Target_UI.transform.GetChild(1).transform.GetChild(0).gameObject;
        HP_gauge = Target_UI.transform.GetChild(0).transform.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {

        ATB += Time.deltaTime;

        //UPDATE VISUAL
        ATB_gauge.GetComponent<RectTransform>().sizeDelta = new Vector2(120 * ATB/ATB_max ,15);
        if (ATB >= ATB_max)
        {
            ATB_gauge.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 15);
        }
        HP_gauge.GetComponent<RectTransform>().sizeDelta = new Vector2(120 * HP / HP_max, 20);
        if (HP >= HP_max)
        {
            HP_gauge.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 20);
        }

    }

    public void GetClassIntel( Enemy id)
    {
        enemy_name = id.enemy_name;
        HP = id.HP;
        HP_max = id.HP_max;
        level = id.level;
        power = id.power;
        ATB = id.ATB;
        ATB_max = id.ATB_max;
        skin = id.skin;
    }

    public void CreateUI()
    {
        Target_UI = Instantiate(UIPrefab, pos1, Quaternion.identity);
        Target_UI.transform.SetParent(GameObject.Find("Canvas").transform, true);
        Target_UI.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        if (Target_index == 0)
        {
            Target_UI.GetComponent<RectTransform>().localPosition = pos1;
        }
        if (Target_index == 1)
        {
            Target_UI.GetComponent<RectTransform>().localPosition = pos2;
        }
        if (Target_index == 2)
        {
            Target_UI.GetComponent<RectTransform>().localPosition = pos3;
        }
    }
}
