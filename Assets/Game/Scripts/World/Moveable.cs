using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

public class Moveable : MonoBehaviour
{
    [field: SerializeField]
    [field: ContextMenuItem("Left", nameof(MoveLeft))]
    [field: ContextMenuItem("Right", nameof(MoveRight))]
    [field: ContextMenuItem("Reset", nameof(ResetPosition))]
    private float moveMe;

    [ContextMenu(nameof(DoSth),false,5)]
    private void DoSth()
    {
        Debug.Log("Sth happened");
    }

    private void MoveRight()
    {
        if (!Application.isPlaying) transform.position += Vector3.right * 5;

        transform.DOMoveX(transform.position.x + 5f, 3f).SetEase(Ease.InOutSine);
    }

    private void MoveLeft()
    {
        if (!Application.isPlaying) transform.position += Vector3.left * 5;

        transform.DOMoveX(transform.position.x - 5f, 3f).SetEase(Ease.InOutSine);
    }

    private void ResetPosition()
    {
        if (!Application.isPlaying) transform.position = Vector3.zero;

        transform.DOMoveX(0f, 3f).SetEase(Ease.InOutSine);
    }
}
