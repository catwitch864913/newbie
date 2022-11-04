using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int Blinks;
    public float time;
    public int dieTime;
    public Rigidbody2D rb;
    private Renderer myRender;
    private Animator ani;
    private ScreenFlash sf;
    private PolygonCollider2D pol;
    public float hitBoxCdTime;
    // Start is called before the first frame update
    void Start()
    {
        myRender = GetComponent<Renderer>();
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health=HealthBar.HpMax;
        sf = GetComponent<ScreenFlash>();
        pol = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamegePlayer(int damage)
    {
        sf.FlashScreen();
        health -= damage;
        if (health < 0)
        {
            health = 0;
        }
        HealthBar.HpCurrent = health;
        
        if (health <= 0)
        {
            GameController.isGameAlive = false;
            ani.SetTrigger("死亡");
            gameObject.GetComponent<玩家腳本>().enabled = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
            Invoke("KillPlayer", dieTime);
        }
        BlinkPlayer(Blinks,time);
        pol.enabled = false;
        StartCoroutine(ShowPlayerHitBox());
    }
    IEnumerator ShowPlayerHitBox()
    {
        yield return new WaitForSeconds(hitBoxCdTime);
        pol.enabled = true;
    }
    void KillPlayer()
    {
        Destroy(gameObject);
    }
    //閃爍次數
    void BlinkPlayer(int numBlinks,float seconds)
    {
        StartCoroutine(DoBlinks(numBlinks, seconds));
    }
    IEnumerator DoBlinks(int numBlinks,float seconds)
    {
        for (int i = 0; i < numBlinks*2;i++)
        {
            myRender.enabled =! myRender.enabled;
            yield return new WaitForSeconds(seconds);
        }
        myRender.enabled = true;
    }
}
