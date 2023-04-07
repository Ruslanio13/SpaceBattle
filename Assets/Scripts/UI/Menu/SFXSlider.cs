using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SFXSlider : Slider
{
    [SerializeField] private AudioSource _audioSource;

    protected override void Start()
    {
        base.Start();
        _audioSource = GetComponent<AudioSource>();
    }
    
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _audioSource.volume = value;
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
