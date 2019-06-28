using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic_circles_behavior : MonoBehaviour
{

    public GameObject[] Fx_parts;
    public Material[] Fx_materials;
    public int arcane_level = 0;
    public Magic_wheel_behavior wheel;

    public bool Animating_primary;

    public string _previous_skill;

    public int _current_index;


    //
    //
    //              FAIRE QUE CA SOIT DEPENDANT D'UN DICTIONNAIRE! LA CLEF EST LE CODENAME, AVEC LE CODENAME, JE VEUX L'ARCANE QUI ME DONNERA TOUT LE RESTE (material, arcane_level)
    //              AJOUTER L'EXCEPETION: PAS D'ANIM NI RIEN SI C'EST UN NEUTRAL
    //


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Charging animation
        if (wheel.charge_O || wheel.charge_U || wheel.charge_V || wheel.charge_X)
        {
            if(Animating_primary == false)
            {
                Material Fx_material = null;
                GameObject Fx_part = null;

                _current_index = 0;

                if (wheel.charge_O) _current_index = 1;
                else if (wheel.charge_U) _current_index = 3;
                else if (wheel.charge_V) _current_index = 0;
                else _current_index = 2;


                Fx_material = Fx_materials[_current_index];
                Fx_part = Fx_parts[arcane_level];

                // SEt ACTIVE
                Fx_part.SetActive(true);
                Fx_part.GetComponent<Renderer>().material = Fx_material;

                // ANIM
                Animating_primary = true;
                StartCoroutine("Animation_Rune", Fx_part);

            }

        }

        // If not charged nor charging = RESET
        else if (wheel.charged_skill == "")
        {
            for (int i = 0; i < Fx_parts.Length; i++)
            {
                Fx_parts[i].SetActive(false);
            }
            Animating_primary = false;
            arcane_level = 0;

        }

        // Charged arcane
        if (wheel.charged_skill != _previous_skill)
        {
            Fx_parts[arcane_level].transform.localScale = new Vector3(1, 1, 1);
            arcane_level += 1;
            Animating_primary = false;
            _previous_skill = wheel.charged_skill;
            
        }

        

    }

    IEnumerator Animation_Rune(GameObject Fx_part)
    {
        float _scale = 0.2f;
        int _increment = 1;
        float _speed = 3;

        while (Animating_primary) // Descend en secondes
        {
            _scale += Time.deltaTime * _increment * _speed;

            if (_scale >= 0.8f) _increment = -1;
            if (_scale <= 0.4f) _increment = 1;

            Fx_part.transform.localScale = new Vector3(_scale,_scale,_scale);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }


}

