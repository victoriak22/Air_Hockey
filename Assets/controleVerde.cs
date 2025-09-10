using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 lastPosition;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Guarda a posição inicial do Rigidbody
        lastPosition = rb2d.position;
    }

    private float minX = -10.0f;
    private float maxX = 10.0f;
    private float minY = -4f;
    private float maxY = 4f;


    void FixedUpdate()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPos = new Vector2(mousePos.x, mousePos.y);

        // Limitar posição dentro do campo
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        // Move a raquete exatamente para a posição do mouse limitado
        rb2d.MovePosition(targetPos);

        // Atualiza lastPosition (não é mais necessário para velocidade)
        lastPosition = targetPos;
    }


}