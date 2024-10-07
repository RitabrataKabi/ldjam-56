using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform spawnPoint;

    public Rigidbody triggerAPencilRb;

    private void Start() {
        transform.position = spawnPoint.position;
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
        }

        if(other.CompareTag("TriggerB"))
        {
            NotificationManager.Instance.SendNotification("Chase", "PlayerChaseAI");
        }

        if(other.CompareTag("TriggerC"))
        {
            NotificationManager.Instance.SendNotification("Marble", "Marbles");
        }
    }
    
}
