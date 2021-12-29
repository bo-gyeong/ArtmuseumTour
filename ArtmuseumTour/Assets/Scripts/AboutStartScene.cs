using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class AboutStartScene : MonoBehaviour
{

    public string SceneToLoad;
    AudioSource audioSource;
    public AudioClip clickSound;

    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(clickSound);
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(clickSound);
            SceneManager.LoadScene(SceneToLoad);
        }

    }
}
