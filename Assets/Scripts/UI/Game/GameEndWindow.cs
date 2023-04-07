using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public abstract class GameEndWindow : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _newLevelButton;
    private Animator _animator;
    private AudioSource _audioSource;

    private void Start()
    {
        _menuButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));
        _newLevelButton.onClick.AddListener(LoadLevel);
        _animator = GetComponent<Animator>();
        _animator.Play("Appear");
    }

    protected void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = PlayerPrefs.GetFloat("SFX_Vol");
        _audioSource.PlayOneShot(_audioSource.clip);
    }

    protected abstract void LoadLevel();
}
