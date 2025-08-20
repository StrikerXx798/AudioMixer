using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    private const float MuteVolume = -80f;

    [SerializeField] private Button _button;
    [SerializeField] private AudioMixer _audioMixer;
    
    private readonly string _masterVolumeVariable = Enum.GetName(typeof(MixerVariables), MixerVariables.MasterVolume);
    private float _currentVolume;
    private bool _isMuted;

    private void Start()
    {
        _currentVolume = GetVolumeFromMixer();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SwitchSound);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SwitchSound);
    }

    private float GetVolumeFromMixer()
    {
        if (_audioMixer.GetFloat(_masterVolumeVariable, out var volume))
            return volume;

        return MuteVolume;
    }

    private void SwitchSound()
    {
        if (_isMuted == false)
        {
            _currentVolume = GetVolumeFromMixer();
        }

        _audioMixer.SetFloat(_masterVolumeVariable,
            _isMuted ? _currentVolume : MuteVolume);
        _isMuted = !_isMuted;
    }
}