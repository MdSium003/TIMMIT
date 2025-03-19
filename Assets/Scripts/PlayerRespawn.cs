using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip chkpntsnd;
    private Transform currentchkpnt;

    private Healt playerhealth;
      AudioManager audioManager;

    private void Awake(){
        playerhealth=GetComponent<Healt>();
           audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Respawn(){

        if(currentchkpnt!=null){
        transform.position=currentchkpnt.position;
        playerhealth.Respawn();
        }
    }


    
private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("CheckPoint")){

            currentchkpnt=other.transform;
            other.GetComponent<Collider2D>().enabled=false;
            other.GetComponent<Animator>().SetTrigger("check");
            audioManager.PlaySFX(audioManager.checkpoint);
        }
    }
 
//  public IEnumerator RespawnWithDelay(float delay)
//     {
//         yield return new WaitForSeconds(delay);

//         // Move player to the checkpoint and reset health and movement
//         if (currentchkpnt != null)
//         {
//             transform.position = currentchkpnt.position;
//              playerhealth.Respawn();
//             GetComponent<PlayerMovement>().enabled = true;  // Ensure movement is enabled
//         }
//     }



}
