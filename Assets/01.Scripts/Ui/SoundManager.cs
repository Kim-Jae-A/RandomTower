using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGMSource;
    public AudioSource SEFSource;

    public AudioClip BGM;
    public AudioClip[] SEF;
    public AudioMixer mixer;

    public Slider Master_Slider;
    public Slider BGM_Slider;
    public Slider SEF_Slider;

    public static SoundManager instance;


    private void Start()
    {
        BGMSource.clip = BGM;
        BGMSource.loop = true;
        BGMSource.Play();
    }
    public void SEFClip(int num)
    {
        SEFSource.PlayOneShot(SEF[num]);
    }
    public void BGMVolume()
    {
        mixer.SetFloat("BGM", Mathf.Log10(BGM_Slider.value) * 20);
    }
    public void MasterVolume()
    {
        mixer.SetFloat("Master", Mathf.Log10(Master_Slider.value) * 20);
    }
    public void SEFVolume()
    {
        mixer.SetFloat("SEF", Mathf.Log10(SEF_Slider.value) * 20);
    }
}