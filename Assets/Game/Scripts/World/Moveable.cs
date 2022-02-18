using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

public class Moveable : MonoBehaviour
{
    [SerializeField,
        ContextMenuItem("Right", "MoveRight"),
        ContextMenuItem("Left", "MoveLeft"),
        ContextMenuItem("Reset", "ResetPosition")]
    private float MoveMe;

    [ContextMenu("Sth")]
    void DoSth()
    {
        Debug.Log("Sth happened");
    }

    void MoveRight()
    {
        if (!Application.isPlaying) transform.position += Vector3.right * 5;

        transform.DOMoveX(transform.position.x + 5f, 3f).SetEase(Ease.InOutSine);
    }
    void MoveLeft()
    {
        if (!Application.isPlaying) transform.position += Vector3.left * 5;

        transform.DOMoveX(transform.position.x - 5f, 3f).SetEase(Ease.InOutSine);
    }
    void ResetPosition()
    {
        if (!Application.isPlaying) transform.position = Vector3.zero;

        transform.DOMoveX(0f, 3f).SetEase(Ease.InOutSine);
    }
}
