using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Check if there is at least one microphone connected
        if (Microphone.devices.Length <= 0)
        {
            Debug.LogWarning("Microphone not found");
            return;
        }

        // Get the default microphone recording capabilities
        audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        audioSource.loop = true; // Set the AudioClip to loop
        // Check that the microphone is recording, if not, start the playback
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play(); // Play the audio source!
    }
}
