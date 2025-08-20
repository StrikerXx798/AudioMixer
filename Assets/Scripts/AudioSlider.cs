using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private MixerVariables _mixerVariable;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    private void ChangeVolume(float volume)
    {
        var variable = Enum.GetName(typeof(MixerVariables), _mixerVariable);
        _audioMixer.SetFloat(variable, volume);
    }
}