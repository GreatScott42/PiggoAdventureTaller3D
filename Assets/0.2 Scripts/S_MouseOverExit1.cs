using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_MouseOverExit1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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
        //C54F4F
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = new Color(0.7735849f, 0.3101638f, 0.3101638f);
        //throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
        //throw new System.NotImplementedException();
    }
}
