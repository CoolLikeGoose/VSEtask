using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShootConrtoller : MonoBehaviour
{
    [SerializeField] private GameObject fireBall;

    [SerializeField] private Image strenghtIndicator;

    private Coroutine nowCoroutine;

    private int avaibleShots = 0;

    private int frames = 0;

    //private bool shootReady = true;

    private void Start()
    {
        strenghtIndicator.fillAmount = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nowCoroutine = StartCoroutine(StrenghtCharging());
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(nowCoroutine);
            StartCoroutine(Shoots(avaibleShots));
        }
    }

    private IEnumerator Shoots(int shootsAmount)
    {
        //shootReady = false;

        avaibleShots = 0;
        strenghtIndicator.fillAmount = 0;
        frames = 0;

        for (; shootsAmount != 0; shootsAmount--)
        {
            Instantiate(fireBall, transform.position, transform.rotation);

            yield return new WaitForSeconds(0.5f);
        }

        //yield return new WaitForSeconds(3f);

        //shootReady = true;
    }

    private IEnumerator StrenghtCharging()
    {
        while (true)
        {
            strenghtIndicator.fillAmount += 0.01f;

            yield return new WaitForSeconds(0.01f);

            if (frames % 25 == 0) { avaibleShots += 1; }
            frames += 1;

            if (strenghtIndicator.fillAmount == 1) { break; }
        }
    }
}
