using System;
using UnityEngine;

public class RigidbodyMovement2D
{
    public event Action<Vector2> OnMove;

    public void Move(Rigidbody2D target, Vector2 direction, float speed)
    {
        target.MovePosition(target.position + speed * Time.fixedDeltaTime * direction);
        OnMove?.Invoke(direction);
    }
}
