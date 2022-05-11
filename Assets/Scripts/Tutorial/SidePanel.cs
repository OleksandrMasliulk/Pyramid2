using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePanel : MonoBehaviour
{
    public Animation anim;

    public void ShowPanel()
    {
        gameObject.SetActive(true);
        anim.Play("Show");
    }

    public void HidePanel()
    {
        StartCoroutine(HidePanelCoroutine());
    }

    IEnumerator HidePanelCoroutine()
    {
        anim.Play("Hide");
        yield return new WaitForSeconds(anim["Hide"].length * anim["Hide"].speed);

        gameObject.SetActive(false);
    }
}
