using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Enemy_behavior : MonoBehaviour {

    //STAT
    public string enemy_name;
    public float HP;
    public float HP_max;
    public int level;
    public int POW;
    public float ATB;
    public float ATB_max;
    public float DEF;
    public GameObject skin;
    public Enemy_system enemy_system;

    public List<string> vulnerabilities;
    public List<string> resistances;

    public float skill_shield;

    public int Target_index;
    public GameObject UIPrefab;


    private Vector3 pos1 = new Vector3(0, 0, 0);
    private Vector3 pos2 = new Vector3(160, 0, 0);
    private Vector3 pos3 = new Vector3(320, 0, 0);


    //IA
    string charging_skill;
    Enemy_IA IA;


    //UI
    public GameObject ATB_gauge;
    public GameObject HP_gauge;
    public GameObject target_indicator;

    public GameObject Target_UI;



    void Start () {

        enemy_system = GameObject.Find("Enemies").GetComponent<Enemy_system>();

        if(enemy_system.List_target.Contains(gameObject))
        {
            Target_index = enemy_system.List_target.IndexOf(gameObject);
        }

        CreateUI();

        ATB_gauge = Target_UI.transform.GetChild(1).transform.GetChild(0).gameObject;
        HP_gauge = Target_UI.transform.GetChild(0).transform.GetChild(0).gameObject;
        target_indicator = Target_UI.transform.GetChild(2).gameObject;
    }
	

	void Update () {


        // CHARGE SYSTEM
        ATB += Time.deltaTime;

        if(ATB >= ATB_max)
        {
            Enemy_IA.LaunchSkill(charging_skill, this);
            ATB = 0;
            string _next_move =  Enemy_IA.Next_Move(this);
            charging_skill = _next_move;
            float _next_move_duration = Enemy_IA.Next_Move_duration(_next_move);
            ATB_max = _next_move_duration;
            skill_shield = Enemy_IA.Next_Move_shield(_next_move);
        }



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
        if (Target_index == GameObject.Find("Magic_wheel").GetComponent<Magic_wheel_behavior>().target_index)
        {
            target_indicator.SetActive(true);
        }
        else target_indicator.SetActive(false);

        //DEATH
        if (this.HP <= 0)
        {
            Magic_wheel_behavior player_magic = GameObject.Find("Magic_wheel").GetComponent<Magic_wheel_behavior>();
            int player_target = player_magic.target_index;
            if (player_target == Target_index)
            {
                if (player_target - 1 < 0) { player_magic.target_index = 0; }
                else player_target -= 1;
                player_magic.target_index = player_target;
            }

            enemy_system.List_target.RemoveAt(Target_index);
            enemy_system.AssignTargetIndex();
            Destroy(Target_UI);
            Destroy(this.gameObject);
        }

    }


    public void GetClassIntel( Enemy id)
    {
        enemy_name = id.enemy_name;
        HP = id.HP;
        HP_max = id.HP_max;
        level = id.level;
        POW = id.POW;
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

    public void BreakSkill()
    {
        ATB = 0;
        string _next_move = Enemy_IA.Next_Move(this);
        charging_skill = _next_move;
        float _next_move_duration = Enemy_IA.Next_Move_duration(_next_move);
        ATB_max = _next_move_duration;
        skill_shield = Enemy_IA.Next_Move_shield(_next_move);
    }
}
