using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

namespace Sample_SceneManagement
{
    public class GameSceneUI : MonoBehaviour
    {

        [SerializeField] private Transform mainMenuBtn;
        private void Awake()
        {
            mainMenuBtn.GetComponent<Button_UI>().ClickFunc = () =>
            {
                Debug.Log("Clicked Main Menu");
                Loader.Load(Loader.Scene.MainMenu);
            };
        }

    } 
}
