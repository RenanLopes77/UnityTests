using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private static CameraManager _instance;

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
}
