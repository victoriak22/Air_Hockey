using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControlScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float fixedY = 8.0f;   // Posição fixa no eixo Y
    private float minX = -4f;
    private float maxX = 4f;

    public float speed = 4f;      // Velocidade do movimento da IA

    private Transform ballTransform;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Encontra a bola pela tag "Ball"
        GameObject ball = GameObject.FindGameObjectWithTag("Ball");
        if (ball != null)
        {
            ballTransform = ball.transform;
        }
        else
        {
            Debug.LogError("Nenhuma bola com tag 'Ball' encontrada na cena.");
        }
    }

    void FixedUpdate()
    {
        if (ballTransform == null) return;

        Vector2 currentPos = rb2d.position;

        // Alvo X é a posição X da bola
        float targetX = ballTransform.position.x;

        // Move gradualmente para o alvo no eixo X, respeitando velocidade e limites
        float newX = Mathf.MoveTowards(currentPos.x, targetX, speed * Time.fixedDeltaTime);

        // Limita dentro do campo horizontal
        newX = Mathf.Clamp(newX, minX, maxX);

        // Mantém Y fixo
        Vector2 targetPos = new Vector2(newX, fixedY);

        rb2d.MovePosition(targetPos);
    }
}
