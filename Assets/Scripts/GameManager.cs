using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject enemyPrefab;

    public Transform mainSphere;

    public float verticalMouseSpeed = 9f;
    public float horizontalMouseSpeed = 9f;
    public float fireballSpeed = 8f;

    public float sorcerersSpeed = 2f;

    public int sorceryHp = 2;

    [NonSerialized] public int activeEnemy;

    private void Awake()
    {
        Instance = this;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, new Vector3(-3, 1.59f, 0), Quaternion.identity).transform.Rotate(0, 90, 0);
        Instantiate(enemyPrefab, new Vector3(3, 1.59f, 0), Quaternion.identity).transform.Rotate(0, -90, 0);
        Instantiate(enemyPrefab, new Vector3(0, 1.59f, -3), Quaternion.identity);
        Instantiate(enemyPrefab, new Vector3(0, 1.59f, 3), Quaternion.identity).transform.Rotate(0, -180, 0);

        activeEnemy += 4;
    }

    public void BallOpacity()
    {
        Color color = mainSphere.GetComponent<Renderer>().material.color;

        color.a -= 0.25f;
        if (color.a == 0) { color.a = 1; }

        mainSphere.GetComponent<Renderer>().material.color = color;
    }
}
