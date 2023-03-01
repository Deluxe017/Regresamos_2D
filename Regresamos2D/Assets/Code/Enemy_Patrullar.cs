using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrullar : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float distanciaMinima;
    private int numero_Aleatorio;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        numero_Aleatorio = Random.Range(0, puntosMovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        Girar();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[numero_Aleatorio].position, velocidadMovimiento * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[numero_Aleatorio].position) < distanciaMinima)
        {
            numero_Aleatorio = Random.Range(0, puntosMovimiento.Length);
            Girar();
        }
    }

    private void Girar()
    {
        if(transform.position.x < puntosMovimiento[numero_Aleatorio].position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}