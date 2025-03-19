
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    

    [Header("-------Audio Source-------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXsource;

[Header("-------Audio Clip-------")]
    public AudioClip background;
    public AudioClip Jump;

    public AudioClip checkpoint;

    public AudioClip Attack;

    public AudioClip death;

 public AudioClip hurt;

 public AudioClip Health;


   private void Awake(){

    if(instance==null){
        instance=this;
        DontDestroyOnLoad(gameObject);
    }
   
   else {

    Destroy(gameObject); 

   }}
   private void Start(){

    musicSource.clip=background;

   musicSource.Play();

   }

   public void PlaySFX(AudioClip clip){

    SFXsource.PlayOneShot(clip);
   }

    
}
