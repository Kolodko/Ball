using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _forceUp;
    private Rigidbody2D _ballRigidbody;
    
    public float Speed;

    private void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody2D>();
    }

    //Перемещение шара
    private void FixedUpdate()
    {
        if (Input.GetButton("Vertical"))
            _ballRigidbody.velocity = new Vector2(0, _forceUp);

        transform.localPosition += transform.right * Speed;
    }

    //Проверка на столкновение с обьектом
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.GetComponent<EnumsManager>() != null && coll.GetComponent<EnumsManager>().enums == EnumsManager.Enums.barrier)
        {
            SceneController.Instance.LossGame();
            Destroy(gameObject);
        }
    }
}