using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Lever : MonoBehaviour, IInterractible
{
    [SerializeField] private UnityEvent _toggleOnAction;
    [SerializeField] private UnityEvent _toggleOffAction;
    [SerializeField] private Animator _anim;
    private bool isOn;

    [SerializeField] private string _tooltip;
    public string Tooltip => _tooltip;

    private void Start()
    {
        isOn = false;
        _anim.SetBool("On", isOn);
    }

    private void On()
    {
        _toggleOnAction?.Invoke();
        isOn = true;
    }

    private void Off()
    {
        _toggleOffAction?.Invoke();
        isOn = false;
    }

    public void Interract(CharacterBase user)
    {
        if (isOn)
            Off();
        else
            On();
        _anim.SetBool("On", isOn);
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<InterractibleSoundBoard>().lever, transform.position, 1f);
    }
}
