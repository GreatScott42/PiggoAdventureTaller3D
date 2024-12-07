using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_MouseOverExit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //gameObject.GetComponentInChildren<TextMeshPro>().color = Color.white;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        //gameObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.localScale = new Vector3(1.5f, 1.5f, 2);
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1);
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        //gameObject.GetComponentInChildren<TextMeshProUGUI>().rectTransform.localScale = new Vector3(1f, 1f, 1f);
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
        //throw new System.NotImplementedException();
    }
}
