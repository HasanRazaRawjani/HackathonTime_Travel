using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public GameObject PlayerSpawn;
    public GameObject fpscam;
    private GameObject effect1;
    private GameObject effect2;
    private GameObject dieEffect;

    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.2f;
    private Coroutine shakeCoroutine;

    void Awake()
    {
        effect1 = PlayerSpawn.transform.Find("Effect1").gameObject;
        effect2 = PlayerSpawn.transform.Find("Effect2").gameObject;
        dieEffect = PlayerSpawn.transform.Find("DieEffect").gameObject;
        effect1.SetActive(false);
        effect2.SetActive(false);
        dieEffect.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TimeTravelToSpawn();
        }
    }

    void TimeTravelToSpawn()
    {
        gameObject.transform.position = PlayerSpawn.transform.position; 
        gameObject.transform.rotation = PlayerSpawn.transform.rotation; 

        if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);
        shakeCoroutine = StartCoroutine(ScreenShake());
    }

    public void die()
    {
        gameObject.transform.position = PlayerSpawn.transform.position;
        gameObject.transform.rotation = PlayerSpawn.transform.rotation;
        StartCoroutine(DeathEffectRoutine());
    }

    IEnumerator DeathEffectRoutine()
    {
        dieEffect.SetActive(true);
        yield return new WaitForSeconds(3f);
        dieEffect.SetActive(false);
    }

    IEnumerator ScreenShake()
    {
        Vector3 originalPos = fpscam.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            effect1.SetActive(true);
            effect2.SetActive(true);
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            fpscam.transform.localPosition = originalPos + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        effect1.SetActive(false);
        effect2.SetActive(false);

        fpscam.transform.localPosition = originalPos;
    }
}