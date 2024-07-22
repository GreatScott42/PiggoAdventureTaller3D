using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class transicionExptoComb : MonoBehaviour
{
    public static transicionExptoComb Instancia;
    // Start is called before the first frame update
    private void Awake()
    {

        
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instancia != this)
        {
            Destroy(gameObject);
        }
        //DontDestroyOnLoad(this);        
    }
    public float duration = 1f; 

    void Start()
    {
        StartCoroutine(Fade(GameObject.Find("fondo").GetComponent<RawImage>(), duration));
    }

    IEnumerator Fade(RawImage image, float duration)
    {
        Color color = image.color;
        float startAlpha = color.a;
        float endAlpha = 1f; 
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            image.color = color;
            yield return null;
        }
        
        color.a = endAlpha;
        image.color = color;
        yield return new WaitForSeconds(1f);
        color = image.color;
        startAlpha = color.a;
        endAlpha = 0f;
        elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsed / duration);
            image.color = color;
            yield return null;
        }

        color.a = endAlpha;
        image.color = color;
        Destroy(gameObject);
    }    
}
