using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MenuManager : MonoBehaviour
{
    public InputField input;

    [SerializeField] private TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        if (DataManager.instant.bestScore != 0)
        {
            bestScoreText.SetText("Bast Score: " +DataManager.instant.bestplayerName +" : " + DataManager.instant.bestScore);
        }
        else
        {
            bestScoreText.SetText("Bast Score: 18 ");
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void StartNew()
    {
        if(input.text != string.Empty)
        {
            DataManager.instant.playerName = input.text;
            SceneManager.LoadScene(1);
        }
        else
        {
            return;
        }
        
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
