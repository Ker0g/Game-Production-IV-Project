using UnityEngine;

public class SoundLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundManager.AddSound("specialagent", Resources.Load<AudioClip>("specialagent"), SoundType.SOUND_MUSIC);
        SoundManager.AddSound("takeme", Resources.Load<AudioClip>("takeme"), SoundType.SOUND_MUSIC);
        SoundManager.AddSound("eyeinthesky", Resources.Load<AudioClip>("eyeinthesky"), SoundType.SOUND_MUSIC);

        SoundManager.AddSound("hey", Resources.Load<AudioClip>("hey"), SoundType.SOUND_SFX);
        SoundManager.AddSound("turretbeep", Resources.Load<AudioClip>("turretbeep"), SoundType.SOUND_SFX);
        SoundManager.AddSound("playerbeep", Resources.Load<AudioClip>("playerbeep"), SoundType.SOUND_SFX);
        SoundManager.AddSound("guard", Resources.Load<AudioClip>("guard"), SoundType.SOUND_SFX);



        SoundManager.PlayMusic("takeme");
    }
}
