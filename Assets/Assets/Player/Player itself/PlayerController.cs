using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip timeTickerClip, chaseClip;

    public Rigidbody triggerAPencilRb;

    void Awake
    ()
    {
    NotificationManager.Instance.ClearList("PlayerChaseAI");
    }

    private void Start() {

        source.clip = timeTickerClip;
        source.loop = true;
        source.Play();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        }

        
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("TriggerA"))
        {
            triggerAPencilRb.AddForce(-Vector3.forward * 160f, ForceMode.Impulse);
            other.GetComponent<AudioSource>().Play();
        }

        if(other.CompareTag("TriggerB"))
        {
            NotificationManager.Instance.SendNotification("Chase", "PlayerChaseAI");
            source.clip = chaseClip;
            source.loop = true;
            source.Play();
        }
    }
    
}
