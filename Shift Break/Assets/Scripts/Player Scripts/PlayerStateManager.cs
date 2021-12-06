using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PlayerStateManager : MonoBehaviour
{

    public static PlayerStateManager mainInstance;


    public Transform player1;
    public Transform player2;
    public Transform combinedPlayer;
    public float maxCombinedTime = 5.0f;
    public float maxMeter = 100.0f;
    public Slider sliderUI;

    InputMaster controls;

    private IEnumerator useMeterRoutine;
    private float currentMeter = 0.0f;
    private static bool combined = false;
    private bool canCombine = false;
    private bool isUsingMeter = false;
    private float combinedTime = 0.0f;
    
    private void Awake()
    {
        controls = InputManager._controls;
        mainInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (mainInstance == null)
        {
            mainInstance = this;
        } 
        else if (mainInstance != this)
        {
            Destroy(this);
        }
        
        useMeterRoutine = UseMeter(maxCombinedTime);
        combinedPlayer.gameObject.SetActive(false);
        sliderUI.value = currentMeter;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUsingMeter && canCombine && controls.PlayerMovement.Combine.triggered)
        {
            CombinePlayers();
        }
    }

    public void CombinePlayers()
    {
        Vector2 midPoint = new Vector2();
        midPoint.x = player1.position.x + (player2.position.x - player1.position.x) / 2;
        midPoint.y = player1.position.y + (player2.position.y - player1.position.y) / 2;

        player1.DOMove(midPoint, 0.2f);
        player2.DOMove(midPoint, 0.2f).OnComplete(() => {
            player1.DOScale(0.1f, 0.2f);
            player2.DOScale(0.1f, 0.2f).OnComplete(() => {
                player1.gameObject.SetActive(false);
                player2.gameObject.SetActive(false);
                player1.localScale = new Vector3(0.7f, 0.7f, 1);
                player2.localScale = new Vector3(0.7f, 0.7f, 1);
                combinedPlayer.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                combinedPlayer.transform.position = midPoint;
                combinedPlayer.gameObject.SetActive(true);
                combinedPlayer.DOScale(1.0f, 0.2f).OnComplete(() => {
                    combined = true;
                    canCombine = false;
                    isUsingMeter = true;
                    useMeterRoutine = UseMeter(maxCombinedTime);
                    StartCoroutine(useMeterRoutine);
                });
            });
        });
        
        //combinedPlayer.transform.position = midPoint;
        //player1.gameObject.SetActive(false);
        //player2.gameObject.SetActive(false);
        //combinedPlayer.gameObject.SetActive(true);
    }

    public void SeperatePlayers()
    {

        combinedPlayer.DOScale(0.1f, 0.2f).OnComplete(() => {
            combinedPlayer.gameObject.SetActive(false);
            player1.gameObject.SetActive(true);
            player2.gameObject.SetActive(true);
            player1.position = combinedPlayer.position;
            player2.position = combinedPlayer.position;
            player1.DOScale(0.7f, 0.2f);
            player2.DOScale(0.7f, 0.2f).OnComplete(() => {
                player1.DOMove(new Vector2(combinedPlayer.position.x - 2.0f, combinedPlayer.position.y), 0.1f);
                player2.DOMove(new Vector2(combinedPlayer.position.x + 2.0f, combinedPlayer.position.y), 0.1f).OnComplete(() => {

                    combinedTime = 0.0f;
                    combined = false;
                    isUsingMeter = false;

                });
            });
        });      
        
    }

    public static bool isCombined()
    {
        return combined;
    }

    public void BuildMeter(float meterAmount)
    {

        if (isUsingMeter || canCombine)
            return;

        currentMeter += meterAmount;
        if (currentMeter >= maxMeter)
        {
            currentMeter = maxMeter;
            canCombine = true;
        }
        sliderUI.value = currentMeter;
    }

    public void depleteMeter(float meterAmount)
    {
        currentMeter -= meterAmount;
        if (currentMeter <= 0.0f)
        {
            if (isUsingMeter)
            {
                StopCoroutine(useMeterRoutine);
                SeperatePlayers();
            }
            
            currentMeter = 0.0f;
        }
        if (isUsingMeter)
        {
            StopCoroutine(useMeterRoutine);
            useMeterRoutine = UseMeter(maxCombinedTime - combinedTime);
            StartCoroutine(useMeterRoutine);
        }
        sliderUI.value = currentMeter;
    }

    IEnumerator UseMeter(float timeToDeplete)
    {

        float counter = 0.0f;
        float meterStart = currentMeter;
        while (counter < timeToDeplete)
        {
            counter += Time.deltaTime;
            combinedTime += Time.deltaTime;
            currentMeter = Mathf.Lerp(meterStart, 0.0f, counter / timeToDeplete);
            sliderUI.value = currentMeter;
            yield return null;
        }
        currentMeter = 0.0f;
        sliderUI.value = currentMeter;

        SeperatePlayers();
    }

  


}
