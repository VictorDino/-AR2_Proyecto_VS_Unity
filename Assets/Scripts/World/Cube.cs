using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private SceneGod sceneManager;
    public AudioClip destructionSound; 

    public void SetSceneManager(SceneGod manager)
    {
        sceneManager = manager;
    }

    private void OnDestroy()
    {
        if (sceneManager != null)
        {
            sceneManager.CubeDestroyed();
        }
        PlayDestructionSound();
    }

    private void PlayDestructionSound()
    {
        if (destructionSound != null)
        {
            
            GameObject tempGameObject = new GameObject("TempAudio");
            AudioSource tempAudioSource = tempGameObject.AddComponent<AudioSource>();

            
            tempAudioSource.clip = destructionSound;
            tempAudioSource.playOnAwake = false;

            tempAudioSource.Play();
            Destroy(tempGameObject, destructionSound.length);
        }
    }
}
