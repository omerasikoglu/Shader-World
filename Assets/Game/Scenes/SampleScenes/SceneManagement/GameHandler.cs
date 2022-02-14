using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagement
{
    public class GameHandler : MonoBehaviour
    {

        [SerializeField] private Sprite unitSprite;

        private GameObject unitGameObject;

        private void Awake()
        {
            // Very slow code, spawn lots of units
            //float startTime = Time.realtimeSinceStartup;
            for (int i = 0; i < 50000; i++)
            {
                GameObject gameObject = new GameObject("Unit", typeof(SpriteRenderer));
                gameObject.GetComponent<SpriteRenderer>().sprite = unitSprite;

                gameObject.transform.localScale = Vector3.one * 0.3f;
                if (this.unitGameObject == null)
                {
                    this.unitGameObject = gameObject;
                }
                else
                {
                    Destroy(gameObject);
                }
                gameObject.layer = 6;
            }
            //Debug.Log(((Time.realtimeSinceStartup - startTime) * 1000f) + "ms");
        }

        private void Update()
        {
            unitGameObject.transform.eulerAngles -= new Vector3(0, 0, 360f * Time.deltaTime / 3f);
        }

    } 
}
