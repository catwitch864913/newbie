using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 血 : MonoBehaviour
{
    public float 刪除特效時間 = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 刪除特效時間);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
