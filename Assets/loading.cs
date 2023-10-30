using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class loading : MonoBehaviour
{
   [SerializeField] private GameObject loadingScreen;
   [SerializeField] private GameObject mainMenu;
   [Header("Slider")]
   [SerializeField] private Slider loadingSlider;

   public void LoadGame(string levelToLoad)
   {
    mainMenu.SetActive(false);
    loadingScreen.SetActive(true);
    StartCoroutine(LoadLevelASync(levelToLoad));

   }
   IEnumerator LoadLevelASync(string levelToLoad)
   {
    yield return new WaitForSeconds(8f);
    AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
    
    while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress /0.9f);
            loadingSlider.value = progressValue;
            yield return null; 
        }
   }
   [Header("TEEEEEXT")]
    public TMP_Text RndText; 
    public float timeInterval; 
    private float nextTextTime;

    private void Start()
    {
        
        nextTextTime = Time.time + timeInterval;

        ShowRandomText();
        
    }
     private void ShowRandomText()
    {
        string[] textArray = new string[]
        {
            "Please wait while we catch some digital butterflies for you.",
            "Loading... Assembling fairy gnomes to speed things up.",
            "In our world, death is just the next respawn point. So, don't be shy about trying out new ways to meet it!",
            "Don't take death too seriously. After all, even the Grim Reaper needs a coffee break sometimes.",
            "If you die, blame the developer, not your skills. We promise it's not you, it's us!",
            "When death comes knocking, tell it you'll be right back... after you finish this level",
            "Don't fear the reaper; just make sure to pack some extra health potions."
        };
        if (textArray.Length > 0 && RndText != null)
        {
            int randomIndex = Random.Range(0, textArray.Length);
            RndText.text = textArray[randomIndex];
        }
    }
    private void Update()
    {
         if (Time.time >= nextTextTime)
        {
            ShowRandomText();

            nextTextTime = Time.time + timeInterval;
        }
        
    }

          
   


   

}
