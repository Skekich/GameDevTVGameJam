using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour
{
    [SerializeField] private GameObjectRuntimeSet audioSet;
    
    private AudioManager audioManager;
    private void Start()
    {
        audioManager = audioSet.GetItemIndex(0).GetComponent<AudioManager>();
    }

    private void HideExplosion()
    {
        audioManager.Play("Explosion");
        audioManager.Play("Explosion");
        Destroy(gameObject);
    }
}
