using System.Collections;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private float ballSpeed;

    private void Start()
    {
        //do that later
        StartCoroutine(DestroySphere());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * GameManager.Instance.fireballSpeed * Time.deltaTime);
    }

    private IEnumerator DestroySphere()
    {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("Player")) { return; }
        Destroy(gameObject);
    }
}
