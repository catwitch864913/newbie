using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class 血瓶區 : MonoBehaviour
{
    public Sprite 滿血瓶;
    public Sprite 空血瓶;
    public GameObject 血瓶obj;
    public GameObject[] 血瓶all;
    public int 血瓶血量 = 5;
    
    private void Start()
    {
        血瓶all = new GameObject[HealthBar.HpMax / 血瓶血量];
        for (int i = 0; i < 血瓶all.Length; i++)
        {
            GameObject obj = Instantiate(血瓶obj, transform);
            血瓶all[i] = obj;
        }
    }

    private void Update()
    {
        //HealthBar.HpCurrent
        for (int i = 0; i < 血瓶all.Length; i++)
        {
            if (i<= HealthBar.HpCurrent / 血瓶血量)
            {
                血瓶all[i].GetComponent<Image>().sprite = 滿血瓶;
            }
            else
            {
                血瓶all[i].GetComponent<Image>().sprite = 空血瓶;
            }
        }
    }
}
