using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class S_camara : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; 
    public Vector3 offset;
    public Vector3 offsetog;
    public Vector3 lk;
    public bool rotar;
    
    bool lookp;
    bool looked;

    public bool mirarBomba;
    Vector3 bombapos;
    public GameObject lvl2;
    bool oncelvl2;
    /*public static S_camara Instancia;

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
    }*/

    void Start()
    {
        oncelvl2 = false;
        bombapos = GameObject.Find("bomb").transform.position;
        mirarBomba = false;
        rotar = false;
        looked = true;
        lk = Vector3.zero;
        lookp = false;
        if (GameObject.Find("ScriptsGlobal").GetComponent<ScriptsGlobal>().destroyEnemy1)
        {
            lookp=true;
            StartCoroutine(looklvl2());
        }
        target = GameObject.Find("Jugador").GetComponent<Transform>();
        offsetog = offset;
        transform.LookAt(target);
        StartCoroutine(camera2());
        //offset = new Vector3(0,9.66f,-10.8f);
    }

    // Update is called once per frame
    void Update()
    {
        lookup();
        lookbomb();
        //Debug.Log(transform.position-GameObject.Find("Jugador").GetComponent<Transform>().position);
    }
    void LateUpdate()
    {
        //transform.LookAt(target.transform);
        if (mirarBomba)
            return;
        transform.position = target.position + offset;
    }
    void lookup()
    {
        if (lookp)
        {            
            transform.LookAt(GameObject.Find("target").transform);
            if (!oncelvl2)
            {
                StartCoroutine(Fade(lvl2.GetComponent<TextMeshProUGUI>(), 1));
                oncelvl2 = true;
            }
            

        }
        else if (looked)
        {
            transform.LookAt(target.transform);
            looked = false;
        }
    }
    IEnumerator Fade(TextMeshProUGUI image, float duration)
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
        //Destroy(gameObject);
    }
        void lookbomb()
    {
        if (mirarBomba)
        {
            bombapos = GameObject.Find("bomb").transform.position;
            transform.LookAt(bombapos);
            StartCoroutine(mirarB());
            
        }
    }
    IEnumerator looklvl2()
    {
        yield return new WaitForSeconds(6);
        lookp = false;
        looked = true;
    }

    IEnumerator camera2()
    {
        yield return new WaitForSeconds(1);
        Camera.main.GetComponent<Transform>().LookAt(GameObject.Find("Jugador").transform);
    }

    IEnumerator mirarB()
    {
        yield return new WaitForSeconds(2);
        Camera.main.GetComponent<Transform>().LookAt(GameObject.Find("Jugador").transform);
        mirarBomba = false;
    }

}
