using System.Collections;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [Header("UI & Audio References")]
    [Header("Player Reference")]
public PlayerMovement playerMovement; // Drag Player here in the Inspector
    public TMP_Text textBox;
    public AudioSource audioSource;
    public AudioClip typingLoopSound;     // Drag your 4-second audio file here

    [Header("Timing Settings")]
    public float startDelay = 1.2f;       // Silence in the dark before typing starts
    public float timePerCharacter = 0.12f; // Speed of left-to-right reveal
    public float commaPause = 0.5f;       // Creepy pause on punctuation

    void Start()
    {
        if (textBox == null)
            textBox = GetComponent<TMP_Text>();

        // Hide all letters initially
        textBox.maxVisibleCharacters = 0;

        // Prep the AudioSource with your 4-second clip
        if (audioSource != null && typingLoopSound != null)
        {
            audioSource.clip = typingLoopSound;
            audioSource.loop = true;      // Loops seamlessly if typing takes longer than 4 secs
            audioSource.playOnAwake = false;
        }

        StartCoroutine(RevealLeftToRight());
    }

    IEnumerator RevealLeftToRight()
    {
        yield return new WaitForSeconds(startDelay);

        textBox.ForceMeshUpdate();
        int totalCharacters = textBox.textInfo.characterCount;

        // Start playing the 4-second typing sound
        if (audioSource != null && typingLoopSound != null)
        {
            audioSource.Play();
        }

        for (int i = 0; i < totalCharacters; i++)
        {
            // Reveal one more character from left to right
            textBox.maxVisibleCharacters = i + 1;

            char currentChar = textBox.textInfo.characterInfo[i].character;

            // If we hit a comma or period, PAUSE the sound during the dramatic wait
            if (currentChar == ',' || currentChar == '.')
            {
                if (audioSource != null) audioSource.Pause();
                yield return new WaitForSeconds(commaPause);
                
                // Resume sound only if there are still more letters left to type
                if (i < totalCharacters - 1 && audioSource != null)
                {
                    audioSource.UnPause();
                }
            }
            else
            {
                yield return new WaitForSeconds(timePerCharacter);
            }
        }

        // Stop the 4-second audio immediately when the last character finishes
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        // Hold the finished text on screen for 2.5 seconds, then hide the black IntroScreen
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);

        // Find the player in the scene and trigger their wake up routine
     if (playerMovement != null)
     {
     playerMovement.WakeUpAndPlay();
     }
    }
}