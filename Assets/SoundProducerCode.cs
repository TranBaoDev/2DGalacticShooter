using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sound Producer Code
public class SoundProducerCode : MonoBehaviour
{
    // Static instance, so we can access it from everywhere. This will be a reference to this SoundProducerCode.
    static SoundProducerCode instance; // "ins" is a common abbreviation for "instance"

    // Each sound is passed as an audio clip.
    [SerializeField] List<AudioClip> _audioClips; // "sesKlipleri" means sound clips

    // AudioClip: sound file
    // AudioSource: playback tool
    // AudioListener: can be thought of as the listener
    AudioSource _source;

    // Enum defining different types of sounds
    public enum SoundTypes // "SesTurleri" means Sound Types
    {
        Fire = 0,    // "Ates" means Fire/Shoot
        Explosion = 1, // "Patlama" means Explosion
        Hit = 2      // "Vurma" means Hit
    }

    // Start is called before the first frame update
    void Start()
    {
        // When Start is executed, this value will be automatically assigned.
        instance = this;
        _source = GetComponent<AudioSource>();
    }

    // Static function to produce/play a sound based on the type
    public static void ProduceSound(SoundTypes type) // "SesUret" means Produce Sound
    {
        // Convert the enum type to its integer index
        int index = (int)type;

        // Since this is a static function, we cannot access the non-static members directly and use 'instance' instead.
        // Set the AudioSource's clip to the appropriate clip from the list
        instance._source.clip = instance._audioClips[index];

        // Play the sound
        instance._source.Play();
    }


    // Update is called once per frame
    void Update()
    {

    }
}