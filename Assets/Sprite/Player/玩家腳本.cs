using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 玩家腳本 : MonoBehaviour
{
    public float 速度X;
    public float 跳躍高度y;
    public float 雙跳高度y;
    private Rigidbody2D rb;
    private BoxCollider2D box2D;
    private Animator ani;
    private bool isGround;
    private bool CanDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        box2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        run();
        鏡像();
        跳躍();
        檢測地板();
        //攻擊();
    }

    //private void 攻擊()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        ani.SetTrigger("攻擊");
    //    }
    //    else if (Input.GetMouseButtonUp(0))
    //    {
            
    //    }

    //}

    private void 檢測地板()
    {
        print(rb.velocity.y);
        isGround = box2D.IsTouchingLayers(LayerMask.GetMask("地板"));
        ani.SetBool("跳躍", !isGround&&rb.velocity.y>0);
        ani.SetBool("墮落", !isGround&&rb.velocity.y<0);
    }

    private void 鏡像()
    {
        if (Mathf.Abs(rb.velocity.x) > Mathf.Epsilon)
        {
            if (rb.velocity.x>0)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
    private void run()
    {
        float x = Input.GetAxis("Horizontal"); // ad 
        rb.velocity = new Vector2(速度X * Input.GetAxis("Horizontal"), rb.velocity.y);
        ani.SetBool("跑步",Mathf.Abs(rb.velocity.x) > Mathf.Epsilon);
    }
    private void 跳躍()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                // vector2.up =  new Vector2(0,1)
                rb.velocity = Vector2.up * 跳躍高度y;
                ani.SetBool("跳躍", true);
            }
            else
            {
                if (CanDoubleJump)
                {
                    rb.velocity = Vector2.up * 雙跳高度y;
                    CanDoubleJump = false;
                    ani.SetBool("雙跳", true);
                    ani.SetBool("跳躍", false);
                    ani.SetBool("墮落", false);
                }
            }
        }
        if (isGround)
        {
            CanDoubleJump = true;
            ani.SetBool("跳躍", false);
            ani.SetBool("雙跳", false);
            ani.SetBool("高處墮落", false);
            ani.SetBool("墮落", false);
        }
        else if (!isGround && rb.velocity.y < 0)
        {
            if (ani.GetBool("跳躍"))
            {
                ani.SetBool("跳躍", false);
                ani.SetBool("墮落", true);
            }
            else if(ani.GetBool("雙跳"))
            {
                ani.SetBool("雙跳", false);
                ani.SetBool("高處墮落", true);
            }
        }

    }
}
