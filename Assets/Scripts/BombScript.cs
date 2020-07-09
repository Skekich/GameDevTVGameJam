using UnityEngine;
using TMPro;

public class BombScript : MonoBehaviour
{
    [SerializeField] private float destructionTime = 0f;
    [SerializeField] private int minScore = 1;
    [SerializeField] private int maxScore = 5;
    [SerializeField] private TextMeshPro bombText;
    [SerializeField] private GameObject explosion;
    
    private Animator anim;
       
    private float currentDestructionTime = 0f;
    private int score = 0;

    private void OnEnable()
    {
        score = Random.Range(minScore, maxScore);
        bombText.text = score.ToString();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currentDestructionTime = destructionTime;
    }

    private void Update()
    {
        currentDestructionTime -= Time.deltaTime;
        if (currentDestructionTime >= 0) return;
        EventHandler.InvokeDeathEvent();
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    public void OnBombExplosion()
    {
        EventHandler.InvokeOnScorePass(score);
        EventHandler.InvokeDeathEvent();
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}