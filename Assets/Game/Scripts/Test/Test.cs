using UnityEngine;
using NaughtyAttributes;
using CodeMonkey.Utils;

public class Test : MonoBehaviour
{
    [SerializeField] private float pi;

    private void Awake()
    {
        GetComponent<Button_UI>().ClickFunc = () => { }; 
    }



}
