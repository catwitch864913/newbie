using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 玩家攻擊 : MonoBehaviour
{
    public int 傷害 = 1;
    private Animator ani;
    private PolygonCollider2D box;
    

    private void Start()
    {
        ani = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        box = GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        攻擊();
    }

    private void 攻擊()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("攻擊");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("怪物"))
        {
            other.GetComponent<怪物>().受傷(傷害);
        }
    }
}
