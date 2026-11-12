
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Shooting SFX")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0,1)] float shootingVolume=1f;

    [Header("damage SFX")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0,1)] float damageVolume=1f;

    public void PlayShootingSFX()
    {
        
        
             PlayAudioClip(shootingClip,shootingVolume);
          
        
    }

    public void playdamageSFX()
    {
       
            PlayAudioClip(damageClip,damageVolume);
        
            
            
            
        
    }
    void PlayAudioClip(AudioClip clip,float volume)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position,volume);
            
        }
        
    }
}
