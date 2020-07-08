using UnityEngine;

public class SorcererController : MonoBehaviour
{
    private Transform mainSphere;

    private int hp;

    private void Start()
    {
        mainSphere = GameManager.Instance.mainSphere;
        hp = GameManager.Instance.sorceryHp;
    }

    private void Update()
    {
        transform.RotateAround(mainSphere.position, Vector3.up, GameManager.Instance.sorcerersSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fireball"))
        {
            hp--;
            if (hp == 0)
            {
                GameManager.Instance.activeEnemy--;
                GameManager.Instance.BallOpacity();
                if (GameManager.Instance.activeEnemy == 0) { GameManager.Instance.SpawnEnemy(); }
                Destroy(gameObject);
            } 
        }
    }
}
