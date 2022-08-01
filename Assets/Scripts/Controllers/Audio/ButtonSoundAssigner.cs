using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSoundAssigner : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    private Button btn;

    public void OnPointerEnter(PointerEventData eventData) => AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<UISoundBoard>().buttonOverlap, 1f);

    public void OnSelect(BaseEventData eventData) => AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<UISoundBoard>().buttonOverlap, 1f);

    private void Awake() {
        btn = GetComponent<Button>();
        if (btn == null) {
            Debug.Log("No Button Component attached");
            Destroy(this.gameObject);
        }

        btn.onClick.AddListener(() => {
            AudioManager.Instance.PlaySound(AudioManager.Instance.GetSoundBoard<UISoundBoard>().buttonClick, 1f);
        });
    }
}

