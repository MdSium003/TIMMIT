using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Healt : MonoBehaviour
{
    [SerializeField] private float startingHealth;

    [SerializeField] private AudioClip hurtsound;
    [SerializeField] private AudioClip diesound;


 private float RespawnDelay;

    public float currentHealth {get; private set; }

    private Animator anim;

    public  bool death{get;private set;}

    AudioManager audioManager;
     private PlayerRespawn playerRespawn;

     

    private void Awake()
    {
        currentHealth = startingHealth;
        anim=GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
         playerRespawn = FindObjectOfType<PlayerRespawn>();
         }

    public void Taka_damage(float _damage)
    {

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
          anim.SetTrigger("hurt");
          //SoundManager.instance.PlaySound(hurtsound);
          audioManager.PlaySFX(audioManager.hurt);
        }
        else
        {  
            if(!death){
                death=true;
            anim.SetTrigger("die");
            //SoundManager.instance.PlaySound(diesound);
            audioManager.PlaySFX(audioManager.death);
           GetComponent<PlayerMovement>().enabled=false;
           //GetComponent<PlayerMovement>(Jump())
         
          //StartCoroutine(playerRespawn.RespawnWithDelay(RespawnDelay));

            
            }
        }
    }

    public void AddHealth(float _value){
        currentHealth = Mathf.Clamp(currentHealth +_value, 0, startingHealth);

    }

    public void Respawn(){

        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idle");
        GetComponent<PlayerMovement>().enabled=true;
            death=false;

    }



    }

