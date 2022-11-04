using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 蝙蝠 : 怪物
{
    private BoxCollider2D box;
    public float 移動速度;
    public float startWaitTime;
    public float waitTime;
    private Vector3 nextPos;
    public Transform minPos;
    public Transform maxPos;
    public GameObject 受傷特效;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        box = GetComponent<BoxCollider2D>();
        nextPos = returnPos();
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        transform.position = Vector3.MoveTowards(transform.position, nextPos, 移動速度 * Time.deltaTime);
        if (Vector3.Distance(transform.position, nextPos) < 0.2f)
        {
            //距離小於0.2
            if (waitTime <= 0)
            {
                nextPos=returnPos();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    protected override void 受傷動畫()
    {
        base.受傷動畫();
        box.enabled = false;
        //Instantiate(受傷特效, transform.position, Quaternion.identity, null);
        GameObject obj = Instantiate(受傷特效, transform);
        obj.transform.parent = null;
    }
    protected override void 回復()
    {
        base.回復();
        box.enabled = true;
    }
    private Vector3 returnPos()
    {
        return new Vector3(Random.Range(minPos.position.x, maxPos.position.x), Random.Range(minPos.position.y, maxPos.position.y));
    }
}
