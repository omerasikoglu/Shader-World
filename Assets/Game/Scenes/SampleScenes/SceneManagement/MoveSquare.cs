using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace Codemonkey_SceneManagement
{
    public class MoveSquare : MonoBehaviour
    {

        private void Awake()
        {
            transform.DOMoveY(transform.position.y + 1f, 2f).
                SetEase(Ease.InOutSine).
                SetLoops(-1, LoopType.Yoyo);
        }






    }
}
