using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saika_behaviour : MonoBehaviour {

    public float HP;
    public float HP_max;

    // UI
    public GameObject HP_fill;
    float HP_w;
    float HP_h;
    public GameObject HP_text;

	// Use this for initialization
	void Start () {
        HP_w = HP_fill.GetComponent<RectTransform>().sizeDelta.x;
        HP_h = HP_fill.GetComponent<RectTransform>().sizeDelta.y;
        HP_fill.GetComponent<RectTransform>().sizeDelta = new Vector2(HP/HP_max * HP_w, HP_h);
	}
	
	// Update is called once per frame
	void Update () {
        HP_fill.GetComponent<RectTransform>().sizeDelta = new Vector2(HP / HP_max * HP_w, HP_h);
        HP_text.GetComponent<Text>().text = "HP " + HP + " / " + HP_max;
    }
}
