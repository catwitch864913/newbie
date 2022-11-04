using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFlash : MonoBehaviour
{
    public Image img;
    public float time;
    public Color flashColor;
    public Color defaltColor;
    // Start is called before the first frame update
    void Start()
    {
        defaltColor = img.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlashScreen()
    {
        StartCoroutine(Flash(img));
    }
    IEnumerator Flash(Image image)
    {
        img.color = flashColor;
        yield return new WaitForSeconds(time);
        image.color = defaltColor;
    }
}
