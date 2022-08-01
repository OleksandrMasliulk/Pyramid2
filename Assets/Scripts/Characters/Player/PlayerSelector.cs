using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour {
    public enum SelectType {
        Nearest,
        Farest,
        LastSeeked,
        FirstSeeked
    }

    private PlayerDrivenCharacter _player;

    [SerializeField] private SelectType _type;
    [SerializeField] private Seeker_InterractibleTriggerCircle _seeker;

    private IInterractible _selectedItem;
    public IInterractible SelectedItem => _selectedItem;

    private void Awake() {
        _player = GetComponent<PlayerDrivenCharacter>();
        _selectedItem = null;
    }

    private void Update() {
        if (_seeker.ObjectsSeeked.Count <= 0) {
            Reset();
            return;
        }

        Select();
    }

    private IInterractible GetSelectedItem() {
        switch (_type) {
            case SelectType.Nearest:
                return GetNearest(_seeker.ObjectsSeeked);
            case SelectType.Farest:
                return GetFarest(_seeker.ObjectsSeeked);
            case SelectType.LastSeeked:
                return _seeker.ObjectsSeeked[_seeker.ObjectsSeeked.Count - 1];
            case SelectType.FirstSeeked:
                return _seeker.ObjectsSeeked[0];
            default:
                return null;
        }
    }

    private IInterractible GetNearest(List<IInterractible> list) {
        int nearest = 0;
        float nearestDistance = Vector3.Distance(transform.position, list[0].ObjectReference.position);

        for (int i = 1; i < list.Count; i++) {
            float dist = Vector3.Distance(transform.position, list[i].ObjectReference.position);
            if (dist < nearestDistance)
                nearest = i;
        }

        return list[nearest];
    }

    private IInterractible GetFarest(List<IInterractible> list) {
        int farest = 0;
        float farestDistance = Vector3.Distance(transform.position, list[0].ObjectReference.position);

        for (int i = 1; i < list.Count; i++) {
            float dist = Vector3.Distance(transform.position, list[i].ObjectReference.position);
            if (dist > farestDistance)
                farest = i;
        }

        return list[farest];
    } 

    private void Select() {
        IInterractible selectedItem = GetSelectedItem();
        if (selectedItem == _selectedItem)
            return;

        if(_selectedItem != null && _selectedItem.ObjectReference.TryGetComponent<IHighlight>(out IHighlight h)) 
            h.UnHighlight();
        if(selectedItem.ObjectReference.TryGetComponent<IHighlight>(out IHighlight s)) 
            s.Highlight();

        _selectedItem = selectedItem;
        _player.HUDHandler.Tooltip.ShowTooltip(_selectedItem.Tooltip);
    }

    private void Reset() {
        if (_selectedItem == null)
            return;

        if (_selectedItem.ObjectReference.TryGetComponent<IHighlight>(out IHighlight s))
            s.UnHighlight();

        _selectedItem = null;
        _player.HUDHandler.Tooltip.Hide();
    }
}
