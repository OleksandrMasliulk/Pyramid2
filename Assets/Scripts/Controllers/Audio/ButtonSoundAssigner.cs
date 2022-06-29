using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSoundAssigner : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    private Button btn;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnSelect(BaseEventData eventData)
    {

    }

    private void Awake()
    {
        btn = GetComponent<Button>();

        if(btn == null)
        {
            Debug.Log("No Button Component attached");
            Destroy(this.gameObject);
        }
    }
}
