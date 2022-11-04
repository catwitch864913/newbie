using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class 怪物 : MonoBehaviour
{
    public int hp;
    public int damage = 1;
    private SpriteRenderer spriteRenderer;
    private Color 原顏色;
    private Color 受傷顏色 = new Color(255, 0, 0, 1);
    private float 無敵時間 = 0.2f;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        原顏色 = spriteRenderer.color;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }
    public void 受傷(int damage)
    {
        hp -= damage;
        受傷動畫();
        GameController.cameraFollow.shake();
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    protected virtual void 受傷動畫()
    {
        spriteRenderer.color = 受傷顏色;
        Invoke("回復", 無敵時間);
    }
    protected virtual void 回復()
    {
        spriteRenderer.color = 原顏色;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //UnityEngine.CapsuleCollider2D
        if (other.gameObject.tag==("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerHealth != null)
            {
                playerHealth.DamegePlayer(damage);
            }
        }
    }
}
