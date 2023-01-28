using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _barrier;

    //Спавн барьеров
    private void Start()
    {
        int i = Random.Range(-2, 2);
        GameObject barrier = Instantiate(_barrier, new Vector2(transform.position.x, i), transform.rotation);
        barrier.transform.SetParent(transform);
        barrier.SetActive(true);
    }
}