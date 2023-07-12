using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;

public class MenuScene : MonoBehaviour
{
    [Header("Key PlayerPref ")]
    private string KeyVolume = "ValueVolume";


    [Header("Value Control")]
    public AudioSource VolumeMusic;
    public Slider FillValueVolume;

    public GameObject ButtonBack;
    [SerializeField]
    private string sceneName;
    [SerializeField]
    private GameObject loadingCanvas;
    [SerializeField]
    private GameObject MenuCanvas;
    [SerializeField]
    private GameObject ButtonGr;
    [SerializeField]
    private GameObject SettingGr;
   

    public Transform Up;
    public Transform Down;



    [Header("Componenet")]
    public Image FillingBar;
    public TMP_Text Value;
    public TMP_Text Narratore;
    

    [Header("Floating Manager")]
    internal float ValueBar;

    [Header("Strings Manager")]
    internal string CurrentChecking = "Loading";

    [Header("Int Manager")]
    internal int ValuePercentage;

    [Header("Boolean Manager")]
    internal bool GameLoaded = false;

    Vector3 pointup;
    Vector3 pointunder;

   
    private void Start()
    {
        ButtonBack.SetActive(false);
        loadingCanvas.SetActive(false);
        pointup = Up.position;
        pointunder = Down.position;
        FillValueVolume.value = PlayerPrefs.GetFloat(KeyVolume);

        
            
    }
    
    public void LoadScene()
    {
        Time.timeScale = 1f;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(LoadScene_Couroutine());
    }

    private IEnumerator LoadScene_Couroutine()
    {
        loadingCanvas.SetActive(true);
        yield return ShowLoadingAnimation();
        StartCoroutine(FillingController());
        StartCoroutine(TextNarrator());

    }

    private IEnumerator ShowLoadingAnimation()
    {
        CanvasGroup group = loadingCanvas.GetComponent<CanvasGroup>();
        bool isAnimating = true;
        group.DOFade(1, 1f)
            .From(0)
            .SetEase(Ease.Flash)
            .OnComplete(() => isAnimating = false);
        MenuCanvas.SetActive(false);
        yield return new WaitUntil(() => !isAnimating);
    }

   
    void Update()
    {
        GetValueVolume();


        FillingBar.fillAmount = ValueBar / 100;
        Value.text = (int)ValueBar + "%";
        if (FillingBar.fillAmount == 1)
        {
            //SceneManager.LoadSceneAsync(sceneName);
            SceneManager.LoadScene(sceneName);

            
            Destroy(gameObject);


        }

    }
  
    IEnumerator TextNarrator()
    {
        yield return new WaitForSeconds(0.3f);
        Narratore.text = CurrentChecking;
        yield return new WaitForSeconds(0.3f);
        Narratore.text = CurrentChecking + ".";
        yield return new WaitForSeconds(0.3f);
        Narratore.text = CurrentChecking + "..";
        yield return new WaitForSeconds(0.3f);
        Narratore.text = CurrentChecking + "...";
        yield return new WaitForEndOfFrame();
        StartCoroutine(TextNarrator());
    }
    IEnumerator FillingController()
    {
        yield return new WaitForSeconds(0.05f);
        ValueBar += 1;
        yield return new WaitForEndOfFrame();
        StartCoroutine(FillingController());
    }

    public void Setting()
    {
        
        StartCoroutine(EyeAnim());

    }

    
    IEnumerator EyeAnim()
    {
        Up.DOMoveY(1200, .5f).SetLoops(1).SetEase(Ease.Linear);
        Down.DOMoveY(-100,.5f).SetLoops(1).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        ButtonGr.SetActive(false);
        SettingGr.SetActive(true);
        ButtonBack.SetActive(true);
        yield return new WaitForSeconds(1);
        Up.DOMoveY(pointup.y, .5f).SetLoops(1).SetEase(Ease.Linear);
        Down.DOMoveY(-1100, .5f).SetLoops(1).SetEase(Ease.Linear);
        yield return null;

        //FadeCanvas.SetActive(false);
    }

   


    public void QuitSGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        StartCoroutine(back());

    }
    IEnumerator back()
    {
        Up.DOMoveY(1200, .5f).SetLoops(1).SetEase(Ease.Linear);
        Down.DOMoveY(-100, .5f).SetLoops(1).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1f);
        ButtonGr.SetActive(true);
        SettingGr.SetActive(false);
        ButtonBack.SetActive(false);
        yield return new WaitForSeconds(1);
        Up.DOMoveY(pointup.y, .5f).SetLoops(1).SetEase(Ease.Linear);
        Down.DOMoveY(-1100, .5f).SetLoops(1).SetEase(Ease.Linear);
        yield return null;
    }

    public void GetValueVolume()
    {
        PlayerPrefs.SetFloat(KeyVolume, FillValueVolume.value);
        VolumeMusic.volume = PlayerPrefs.GetFloat(KeyVolume);
    }

}
