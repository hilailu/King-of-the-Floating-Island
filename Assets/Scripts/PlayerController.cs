using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject indicator;
    private bool _hasPowerUp;
    public float powerUpStrength = 15f;
    public float speed = 5f;
    
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        rb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        indicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            StartCoroutine(PowerUpCountdown());
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _hasPowerUp)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(away * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + " with power up active");
        }
    }

    private IEnumerator PowerUpCountdown()
    {
        SetPowerUp(true);
        yield return new WaitForSeconds(7f);
        SetPowerUp(false);
    }

    private void SetPowerUp(bool isActive)
    {
        _hasPowerUp = isActive;
        indicator.SetActive(isActive);
    }
}
