using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform trage;
    public float smoothing;//¥­·Æ«×
    public Animator ani;
    public Vector2 maxPos, minPos;

    private void Start()
    {
        trage = GameObject.FindGameObjectWithTag("Player").transform;
        ani = GetComponentInChildren<Animator>();
        GameController.cameraFollow = gameObject.GetComponent<CameraFollows>();
    }
    private void FixedUpdate()
    {
        if (trage != null)
        {
            Vector3 pos = trage.position;
            pos = new Vector2(Mathf.Clamp(pos.x, minPos.x, maxPos.x), Mathf.Clamp(pos.y, minPos.y, maxPos.y));
            transform.position = Vector3.Lerp(transform.position, pos, smoothing);
        }
    }
    public void shake()
    {
        ani.SetTrigger("shake");
    }
    public void SetCameraScope(Vector2 minPos,Vector2 maxPos)
    {
        this.minPos = minPos;
        this.maxPos = maxPos;
    }
}
