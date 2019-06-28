using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magic_wheel_behavior : MonoBehaviour {

    public bool charge_V = false;
    public bool charge_X = false;
    public bool charge_O = false;
    public bool charge_U = false;

    public  bool charged = false;

    public  float charge_value_V = 0;
    public float charge_value_U = 0;
    public float charge_value_X = 0;
    public float charge_value_O = 0;

    public float charge_max_V;
    public float charge_max_U;
    public float charge_max_X;
    public float charge_max_O;

    public string codename_V;
    public string codename_U;
    public string codename_X;
    public string codename_O;

    Color color_V =Color.black;
    Color color_X= Color.black;
    Color color_O = Color.black;
    Color color_U = Color.black;

    public string charged_skill = "";


    //UI VARIABLES
    public GameObject fill_V;
    public GameObject fill_U;
    public GameObject fill_X;
    public GameObject fill_O;

    public GameObject Arcane_name;

    public GameObject text_V;
    public GameObject text_U;
    public GameObject text_X;
    public GameObject text_O;

    public GameObject dot_V;
    public GameObject dot_U;
    public GameObject dot_X;
    public GameObject dot_O;

    // Use this for initialization
    void Start () {
        Get_arcanes("Wheel_000");
    }
	
	// Update is called once per frame
	void Update () {

        InputReact();

        Interface_charge();

        

    }


    void InputReact()
    {
        // RUNE WHEEL
        //          "V" = triangle
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!charge_V && !charge_O && !charge_U && !charge_X) charge_V = true;
        }
        if (Input.GetKeyUp(KeyCode.Z)) charge_V = false;

        //          "X" = cross
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!charge_V && !charge_O && !charge_U && !charge_X) charge_X = true;
        }
        if (Input.GetKeyUp(KeyCode.S)) charge_X = false;

        //          "U" = square
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!charge_V && !charge_O && !charge_U && !charge_X) charge_U = true;
        }
        if (Input.GetKeyUp(KeyCode.Q)) charge_U = false;

        //          "O" = circle
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!charge_V && !charge_O && !charge_U && !charge_X) charge_O = true;    
        }
        if (Input.GetKeyUp(KeyCode.D)) charge_O = false;

        // LAUNCH SKILL
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchSkill(charged_skill);
            if (charged_skill != "")
            {
                
                charged_skill = "";
            }

        }

        //  CHARGING


        //          "V"
        if (charge_V) //Pressed
        {
            if (codename_V != "neutral") { 
                charge_value_V += 1 * Time.deltaTime;
            }
        }

        if (!charge_V) //Unpressed
        {
             if (charge_value_V != 0) charge_value_V = 0;
        }
        //          "O"
        if (charge_O) //Pressed
        {
            if (codename_O != "neutral")
            {
                charge_value_O += 1 * Time.deltaTime;
            }
        }

        if (!charge_O) //Unpressed
        {
             if (charge_value_O != 0) charge_value_O = 0;
        }
        //          "U"
        if (charge_U) //Pressed
        {
            if (codename_U != "neutral")
            {
                charge_value_U += 1 * Time.deltaTime;
            }
        }

        if (!charge_U) //Unpressed
        {
            if (charge_value_U != 0) charge_value_U = 0;
        }
        //          "X"
        if (charge_X) //Pressed
        {
            if (codename_X != "neutral")
            {
                charge_value_X += 1 * Time.deltaTime;
            }
        }

        if (!charge_X) //Unpressed
        {
            if (charge_value_X != 0) charge_value_X = 0;
        }

        if (charge_value_X >= charge_max_X)
        {
            charged_skill = codename_X;
            charge_value_X = charge_max_X;
            charged = true;
        }
        if (charge_value_U >= charge_max_U) { charged_skill = codename_U; charge_value_U = charge_max_U; charged = true; }
        if (charge_value_O >= charge_max_O) { charged_skill = codename_O; charge_value_O = charge_max_O; charged = true; }
        if (charge_value_V >= charge_max_V) { charged_skill = codename_V; charge_value_V = charge_max_V; charged = true; }

        if (charged)
        {
            string new_wheel = "";
            switch (charged_skill)
            {
                case "Fire Rune": new_wheel = "Fire_000";break;
                case "Fire Ball": new_wheel = "Fire_101"; break;
                default: new_wheel = ""; break;
            }
            Get_arcanes(new_wheel);
            charged = false;
        }

    }
    void LaunchSkill(string codename)
    {
        Debug.Log("SKILL FIRED : " + codename);
        Get_arcanes("Wheel_000");

        charge_V = false;
        charge_U = false;
        charge_O = false;
        charge_X = false;

    }
    void Interface_charge()
    {
        if (charge_max_V != 0)
        {
            RectTransform rect_v = fill_V.GetComponent<RectTransform>();
            rect_v.sizeDelta = new Vector2(160 * (charge_value_V / charge_max_V), 30);
        }
        else
        {
            RectTransform rect_v = fill_V.GetComponent<RectTransform>();
            rect_v.sizeDelta = new Vector2(0, 30);
        }

        if (charge_max_X != 0)
        {
            RectTransform rect_x = fill_X.GetComponent<RectTransform>();
            rect_x.sizeDelta = new Vector2(160 * (charge_value_X / charge_max_X), 30);
        }
        else
        {
            RectTransform rect_x = fill_X.GetComponent<RectTransform>();
            rect_x.sizeDelta = new Vector2(0, 30);
        }

        if (charge_max_O != 0)
        {
            RectTransform rect_o = fill_O.GetComponent<RectTransform>();
            rect_o.sizeDelta = new Vector2(160 * (charge_value_O / charge_max_O), 30);
        }
        else
        {
            RectTransform rect_o = fill_O.GetComponent<RectTransform>();
            rect_o.sizeDelta = new Vector2(0, 30);
        }

        if (charge_max_U != 0)
        {
            RectTransform rect_u = fill_U.GetComponent<RectTransform>();
            rect_u.sizeDelta = new Vector2(160 * (charge_value_U / charge_max_U), 30);
        }
        else
        {
            RectTransform rect_u = fill_U.GetComponent<RectTransform>();
            rect_u.sizeDelta = new Vector2(0, 30);
        }

        fill_V.GetComponent<Image>().color = color_V;
        fill_U.GetComponent<Image>().color = color_U;
        fill_O.GetComponent<Image>().color = color_O;
        fill_X.GetComponent<Image>().color = color_X;

        dot_V.GetComponent<Image>().color = color_V;
        dot_U.GetComponent<Image>().color = color_U;
        dot_O.GetComponent<Image>().color = color_O;
        dot_X.GetComponent<Image>().color = color_X;

        text_V.GetComponent<Text>().text = codename_V;
        text_U.GetComponent<Text>().text = codename_U;
        text_O.GetComponent<Text>().text = codename_O;
        text_X.GetComponent<Text>().text = codename_X;

        Arcane_name.GetComponent<Text>().text = charged_skill;
    }

    void Get_arcanes(string new_wheel)
    {
        charge_value_O = 0;
        charge_value_X = 0;
        charge_value_U = 0;
        charge_value_V = 0;
        charge_O = false;
        charge_X = false;
        charge_U = false;
        charge_V = false;

        Magic_wheel_arcanes Grimoire = GameObject.Find("Grimoire_system").GetComponent<Magic_wheel_arcanes>();

        switch (new_wheel)
        {
            case "Fire_000": Grimoire.Magic_Wheel = Grimoire.Fire_000; break;
            case "Fire_101": Grimoire.Magic_Wheel = Grimoire.Fire_101; break;
            case "Wheel_000": Grimoire.Magic_Wheel = Grimoire.Wheel_000; break;
            default: Grimoire.Magic_Wheel = Grimoire.Neutral; break;
        }

        codename_V = Grimoire.Magic_Wheel[0].name;
        codename_O = Grimoire.Magic_Wheel[1].name;
        codename_X = Grimoire.Magic_Wheel[2].name;
        codename_U = Grimoire.Magic_Wheel[3].name;

        charge_max_V = Grimoire.Magic_Wheel[0].coef;
        charge_max_O = Grimoire.Magic_Wheel[1].coef;
        charge_max_X = Grimoire.Magic_Wheel[2].coef;
        charge_max_U = Grimoire.Magic_Wheel[3].coef;

        color_V = Grimoire.Magic_Wheel[0].color;
        color_O = Grimoire.Magic_Wheel[1].color;
        color_X = Grimoire.Magic_Wheel[2].color;
        color_U = Grimoire.Magic_Wheel[3].color;

    }
}
