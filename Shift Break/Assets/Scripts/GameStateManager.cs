using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameStateManager : MonoBehaviour
{
    public RectTransform losePanel;
    public RectTransform winPanel;

    AudioSource gameOverSound;
    AudioSource winSound;
    AudioSource levelLoop;

    public static GameStateManager mainInstance;

    private void Awake()
    {
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
        winSound = GameObject.Find("Credits").GetComponent<AudioSource>();
        gameOverSound = GameObject.Find("Game Over").GetComponent<AudioSource>();
        levelLoop = GameObject.Find("Level Loop").GetComponent<AudioSource>();
        losePanel.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lose()
    {
        levelLoop.Stop();
        gameOverSound.Play();
        SceneController.PauseScene();
        losePanel.gameObject.SetActive(true);
        losePanel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Tweener tweeer = losePanel.transform.DOScale(1.0f, 0.3f);
        tweeer.SetUpdate(true);
    }

    public void win()
    {
        levelLoop.Stop();
        winSound.Play();
        SceneController.PauseScene();
        winPanel.gameObject.SetActive(true);
        winPanel.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        Tweener tweeer = winPanel.transform.DOScale(1.0f, 0.3f);
        tweeer.SetUpdate(true);
    }
}
