using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

namespace Sample_SceneManagement
{
    public class MainMenu : MonoBehaviour
    {

        private void Awake()
        {
            transform.Find("playBtn").GetComponent<Button_UI>().ClickFunc = () =>
            {
                Debug.Log("Click Play");
                Loader.Load(Loader.Scene.GameScene);
            };
        }

    } 
}
