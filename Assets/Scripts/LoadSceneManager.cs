using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadSceneManager : MonoBehaviour
{
    public static LoadSceneManager instance;
    public Text txtLoading;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Config.GetSound();
        Config.GetMusic();
        Config.currCoin = Config.GetCoin();
        Config.GetCurrLevel();
        Config.currPiggyBankCoin = Config.GetPiggyBank();
        Config.GetLevelStar();
        if (Config.isMusic)
        {
            MusicManager.instance.PlayMusicBG();
        }
        // Config.SetChestCountStar(15);
        StartCoroutine(LoadingText());
        StartCoroutine(LoadMenuScene_IEnumerator());

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator LoadMenuScene_IEnumerator() {
        yield return new WaitForSeconds(2f);
        LoadMenuScene();
    }
    bool isLoadMenu = false;
    public void LoadMenuScene() {
        if (!isLoadMenu)
        {
            isLoadMenu = true;
            if (Config.currLevel == 1)
            {
                SceneManager.LoadSceneAsync("Play");

            }
            else
            {
                SceneManager.LoadSceneAsync("Menu");
            }

           
        }
    }
    IEnumerator LoadingText()
    {
        var wait = new WaitForSeconds(1f);
        while (true)
        {
            txtLoading.text = "LOADING .";
            yield return wait;

            txtLoading.text = "LOADING ..";
            yield return wait;

            txtLoading.text = "LOADING ...";
            yield return wait;

        }
    }
}
