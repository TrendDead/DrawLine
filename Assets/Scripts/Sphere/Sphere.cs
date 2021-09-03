using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Sphere : MonoBehaviour
{
    // Временное решение. С какой стороны косается шар линии
    public Transform[] lineCheck;
    Vector2 vectorModifier;

    // Поля для проверки движения по линии
    // - - - - - - - - - - - - -
    Transform sphereTransform;
    Vector2 newPosition;
    float radiusSphere;
    bool isLine = false;
    // - - - - - - - - - - - - - 

    // Поля для ускорения движения по линии
    // - - - - - - - - - - - - -
    Vector2 oldPosition;
    public float speed = 1;
    public float speedMax = 10;
    Rigidbody2D sphereRigidbody;
    // - - - - - - - - - - - - - 
    bool StartTimer;
    float TimeStart;
    float velocityY;
    float velocityX;

    void Start()
    {
        sphereTransform = gameObject.GetComponent<Transform>();
        radiusSphere = sphereTransform.localScale.x;
        newPosition = new Vector2(sphereTransform.position.x, sphereTransform.position.y);
        sphereRigidbody = GetComponent<Rigidbody2D>();
        //vectorModifier = new Vector2(0f, 0f);

    }

    void FixedUpdate()
    {
        
        oldPosition = newPosition;
        newPosition = new Vector2(sphereTransform.position.x, sphereTransform.position.y); 
        CheckLine();
        if (isLine) //Если двигаемся по линии, то шар ускоряется
        {
            //touchingSide();
            accelerationSphere();
        }
        if (!isLine && (sphereRigidbody.velocity.y < -5)) // Замедление ускорения если velocity to much || Math.Abs(sphereRigidbody.velocity.x) > 0.3f )
        {
            // sphereRigidbody.velocity = new Vector2(sphereRigidbody.velocity.x, -5f);
            // StartTimer = true;
            sphereRigidbody.AddForce(new Vector2(0f, 0f));
            if (sphereRigidbody.velocity.y < -20)
                sphereRigidbody.velocity = new Vector2(velocityX, -15f);
            else
            {
                if (StartTimer)
                {
                    TimeStart = Time.time;
                    StartTimer = false;
                    velocityY = sphereRigidbody.velocity.y;
                    velocityX = sphereRigidbody.velocity.x;
                }
                if (velocityX > 0.7f) // замедление при свободном падении по x и y
                    sphereRigidbody.velocity = new Vector2(velocityX - (Time.time - TimeStart) * 2, velocityY + (Time.time - TimeStart) * 1f); // замедление при x > 0
                else if (velocityX < -0.7f)
                    sphereRigidbody.velocity = new Vector2(velocityX + (Time.time - TimeStart) * 2, velocityY + (Time.time - TimeStart) * 1f); // замедление при x < 0
                else
                    sphereRigidbody.velocity = new Vector2(0f, velocityY + (Time.time - TimeStart) * 1f);
            }

        }
        else
        {
            StartTimer = true;
        }
            
        Debug.Log(sphereRigidbody.velocity);
    }

    void CheckLine() //Проверка на количество collidres near sphere
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, radiusSphere / 2);
        isLine = colliders.Length > 1;
    }

    void accelerationSphere() //Ускорение шара при движениии по линии
    {
        //touchingSide();
        if (oldPosition != newPosition)
        {
           /* vectorModifier.x = 0f;
            vectorModifier.y = 0f;*/
            
            sphereRigidbody.AddForce(new Vector2((newPosition.x - oldPosition.x) * speed, (newPosition.y - oldPosition.y) * speed), ForceMode2D.Force);
            /*Debug.Log((newPosition.x - oldPosition.x + (vectorModifier.x)) * speed);
            Debug.Log((newPosition.y - oldPosition.y + (vectorModifier.y)) * speed);*/
        }
    }
    /*void touchingSide() //Корректировка направления вектора
    {
        int i = 9;
        float a = 1f;
        for (i = 7; i >= 0; i--)
        {
            Collider2D[] collidersLine = Physics2D.OverlapCircleAll(lineCheck[i].position, 0.05f);

            if (collidersLine.Length > 1)
            {
                Debug.Log(i);
                
                break;
            }
        }
        switch (i)
        {
            
            case 0:
                vectorModifier.x = -a;
                vectorModifier.y = 0f;  
                break;
            case 1:
                if (newPosition.y - oldPosition.y < 0)
                {
                    vectorModifier.y = -a;
                    vectorModifier.x = 0;
                } else
                {
                    vectorModifier.y = 0f;
                    vectorModifier.x = -a;
                }           
                break;
            case 2:
                vectorModifier.x = 0f;
                vectorModifier.y = -a;
                break;
            case 3:
                if (newPosition.y - oldPosition.y < 0)
                {
                    vectorModifier.y = -a;
                    vectorModifier.x = 0;
                }
                else
                {
                    vectorModifier.y = 0f;
                    vectorModifier.x = a;
                }
                break;
            case 4:
                vectorModifier.x = a;
                vectorModifier.y = 0f;
                break;
            case 5:
                if (newPosition.y - oldPosition.y < 0)
                {
                    vectorModifier.y = 0f;
                    vectorModifier.x = a;
                }
                else
                {
                    vectorModifier.y = a;
                    vectorModifier.x = 0f;
                }
                break;
            case 6:
                vectorModifier.x = 0f;
                vectorModifier.y = a;
                break;
            case 7:
                if (newPosition.y - oldPosition.y < 0)
                {
                    vectorModifier.y = 0f;
                    vectorModifier.x = -a;
                }
                else
                {
                    vectorModifier.y = a;
                    vectorModifier.x = 0f;
                }
                break;
        }
    }*/
}
