using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
public class UI : MonoBehaviour
{
    [Header("Upgrade Shop")]
    public Canvas shopCanvas;
    bool isShopOpen = false;
    [Space(5)]
    [Header("Game Setup")]
    public CanvasGroup loadInCanvas;
    [Space(5)]
    [Header("Score")]
    public static TMP_Text _scoreUI;
    public TMP_Text scoreUI;
    public static TMP_Text _highscoreUI;
    public TMP_Text highscoreUI;
    public static UI instance;
    [Space(5)]
    [Header("Health")]
    public RectTransform healthBar;
    [Range(0, 10)] public float healthBarWidth = 4f;

    public PostProcessVolume ppVolume;
    static Vignette ppVig;
    // Start is called before the first frame update
    void Start()
    {
        ppVolume.profile.TryGetSettings<Vignette>(out ppVig);
        StartCoroutine(FadeOut(loadInCanvas, 0.125f));
     
    }
    void Awake()
    {
        shopCanvas.enabled = false;
        instance = this;
        _scoreUI = scoreUI;
        _highscoreUI = highscoreUI;
    }
    // Update is called once per frame
    public void OpenShop()
    {
        shopCanvas.GetComponent<CanvasGroup>().alpha = 0;
        shopCanvas.enabled = true;
        StartCoroutine(FadeIn(shopCanvas.GetComponent<CanvasGroup>(), 0.125f));
        isShopOpen = true;
        GameStateManager.SetGameState(GameStateManager.GameState.Shop);
    }

    public void CloseShop()
    {
        StartCoroutine(FadeOut(shopCanvas.GetComponent<CanvasGroup>(), 0.125f));
        isShopOpen = false;
        shopCanvas.enabled = false;
        GameStateManager.SetGameState(GameStateManager.GameState.Playing);
    }
    void Update()
    {
        healthBar.sizeDelta = Vector2.Lerp(healthBar.sizeDelta, new Vector2(Gunner.health * healthBarWidth, healthBar.sizeDelta.y), Time.deltaTime * 3);
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isShopOpen) {
                OpenShop();
            } else 
            {
                CloseShop();
            }
        }
    }
    public static IEnumerator vignetteFadeIn(float intensity, float speed)
    {
        while (ppVig.intensity.value < intensity)
        {
            ppVig.intensity.value += speed;
            yield return null;
        }
    }
    public static IEnumerator vignetteFadeOut(float speed)
    {
        while (ppVig.intensity.value > 0)
        {
            ppVig.intensity.value -= speed;
            yield return null;
        }
    }
    IEnumerator FadeOut(CanvasGroup alphaController, float speed)
    {
        float a = 1;
        while (a > 0)
        {
            a -= 0.05f * speed;
            alphaController.alpha = a;
            yield return null;
        }
    }
    IEnumerator FadeIn(CanvasGroup alphaController, float speed)
    {
        float a = 0;
        while (a < 1)
        {
            a += 0.05f * speed;
            alphaController.alpha = a;
            yield return null;
        }
    }
}
