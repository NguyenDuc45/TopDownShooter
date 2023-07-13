using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public Player player;

    Vector2 movementInput;
    Vector2 smoothedMovementInput;
    Vector2 smoothVelocity;
    Vector2 mousePos;

    public float movementSpeed;
    public float angle;
    private bool isAddingForce = false;

    public Camera cam;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementSpeed = player._movementSpeed;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput, movementInput, ref smoothVelocity, 0.1f);
        
        if (!isAddingForce)
            rb2d.velocity = smoothedMovementInput * movementSpeed;

        Vector2 lookDir = mousePos - rb2d.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    /*public void AddForceToPlayer(bool isForward, float force, float distance)
    {
        isAddingForce = true;
        var direction = transform.up;

        if (!isForward)
            direction = direction * -1;

        rb2d.AddForce(transform.up * force, ForceMode2D.Impulse);
        StartCoroutine(ForceDuration(distance / force));
    }

    private IEnumerator ForceDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        isAddingForce = false;
    }*/
}
