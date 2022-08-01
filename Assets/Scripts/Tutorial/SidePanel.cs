using System.Collections;
using UnityEngine;

public class SidePanel : UIPanel {
    public Animation anim;

    public override void EnablePanel() {
        base.EnablePanel();
        anim.Play("Show");
    }

    public override void DisablePanel() => StartCoroutine(HidePanelCoroutine());

    IEnumerator HidePanelCoroutine() {
        anim.Play("Hide");
        yield return new WaitForSeconds(anim["Hide"].length * anim["Hide"].speed);

        base.DisablePanel();
    }
}
