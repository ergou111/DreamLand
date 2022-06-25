using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject eventObj;
    public Button playGame;
    public Button settingGame;
    public Button quitGame;
    public Animator animator;
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
        GameObject.DontDestroyOnLoad(this.eventObj);

        playGame.onClick.AddListener(PlayGame);
        settingGame.onClick.AddListener(SettingGame);
        quitGame.onClick.AddListener(QuitGame);
    }

    void Update() 
    {
        
    }
    private void PlayGame()
    {
        StartCoroutine(LoadScene(1));
    }

    private void SettingGame()
    {
        StartCoroutine(LoadScene(5));

    }

    private void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(int index)
    {
        animator.SetBool("Fadein",true);
        animator.SetBool("Fadeout",false);

        yield return new WaitForSeconds(1);

        AsyncOperation async = SceneManager.LoadSceneAsync(index);
        async.completed += OnLoadedScene;
    }

    private void OnLoadedScene(AsyncOperation obj)
    {
        animator.SetBool("Fadein",false);
        animator.SetBool("Fadeout",true);
    }
}
