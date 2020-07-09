using UnityEngine;
using Cinemachine;

public class DetectMouseClick : MonoBehaviour
{
    //[SerializeField] private GameObject bomba;
    [SerializeField] private GameObjectRuntimeSet runtimeSet;
    
    private Camera myCamera;
    private AudioManager audioMan;
    private CinemachineImpulseSource impulse;
    
    private void Start()
    {
        myCamera = Camera.main;
        audioMan = runtimeSet.GetItemIndex(0).GetComponent<AudioManager>();
        impulse = GetComponent<CinemachineImpulseSource>();
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Fire1")) return;
        var ray = myCamera.ScreenPointToRay(Input.mousePosition);
        var hit = Physics2D.Raycast(ray.origin, Vector2.zero);
        if (!hit) return;
        hit.collider.gameObject.GetComponent<BombScript>().OnBombExplosion();
        impulse.GenerateImpulse();
        audioMan.Play("Click");
    }
}
