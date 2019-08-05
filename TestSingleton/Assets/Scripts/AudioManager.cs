using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    
    private void Awake()
    {
        if (_instance != null)
            DestroyPreviousInstance(_instance.gameObject);
        else
            LoadMyInstance();
        
    }

    private void LoadMyInstance()
    {
        _instance = this;
        DontDestroyOnLoad(_instance);
    }

    private void DestroyPreviousInstance(GameObject previousInstance)
    {
        if (previousInstance != null)
        {
            Destroy(previousInstance);    
        }
        LoadMyInstance();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("*********GameManager.player.genre*********");
            Debug.Log(GameManager.Instance.Player.Genre);
            Debug.Log(GameManager.Instance.Player.Ethnicity);
            Debug.Log("****************************");
            SceneManager.LoadScene("Cena1");
            GameManager.Instance.Player.Genre = Genre.Male;
            GameManager.Instance.Player.Ethnicity = Ethnicity.Black;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            SceneManager.LoadScene("Cena2");
        }
    }
}
