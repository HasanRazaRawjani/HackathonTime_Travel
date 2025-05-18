using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class TimeTravel : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    public GameObject PlayerSpawn;
    public GameObject fpscam;
    private GameObject effect1;
    private GameObject effect2;
    private GameObject dieEffect;
    public int time;
    private PlayerController playerController;
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.2f;
    private Coroutine shakeCoroutine;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        timeText = GameObject.Find("CanvasUI").transform.Find("GameUI").transform.Find("TimeText").GetComponent<TextMeshProUGUI>();
        effect1 = PlayerSpawn.transform.Find("Effect1").gameObject;
        effect2 = PlayerSpawn.transform.Find("Effect2").gameObject;
        dieEffect = PlayerSpawn.transform.Find("DieEffect").gameObject;
        effect1.SetActive(false);
        effect2.SetActive(false);
        dieEffect.SetActive(false);

        StartCoroutine(AddTimeEverySecond());
    }

    IEnumerator AddTimeEverySecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            time += 1;
        }
    }

    void Update()
    {
        if(timeText.gameObject.activeSelf == true)
        {
            timeText.text = "Time: " + time.ToString();
        }
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            TimeTravelToSpawn();
        }
    }

    void TimeTravelToSpawn()
    {
        gameObject.transform.localScale = new Vector3(1.712111f, gameObject.transform.localScale.y/2, 1.712111f);
        playerController.moveSpeed -= 1f;
        gameObject.transform.position = PlayerSpawn.transform.position; 
        gameObject.transform.rotation = PlayerSpawn.transform.rotation; 

        if (shakeCoroutine != null)
            StopCoroutine(shakeCoroutine);
        shakeCoroutine = StartCoroutine(ScreenShake());
    }

    public void die()
    {
        time += 10;
        playerController.moveSpeed = 7f;
        gameObject.transform.localScale = new Vector3(1.712111f, 1.712111f, 1.712111f);
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