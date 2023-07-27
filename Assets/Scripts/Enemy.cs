using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody enemyRb;
    private GameObject player;
    private SpawnManager spawnManager;
    public float speed = 3f;
    
    void Start()
    {
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }
    
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            spawnManager.RemoveEnemy();
        }
    }
}
