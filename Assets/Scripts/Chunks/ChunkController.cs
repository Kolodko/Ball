using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ChunkController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _newChunks = new List<GameObject>();
    [SerializeField] private GameObject _chunks, _collector;
    private float _count;

    //Старт спавна чанков
    public void StartChunkSpawner()
    {
        _count = 0;
        StartCoroutine(ChunkSpawner());
    }

    //Рестарт чанков
    public void ChunkRestart()
    {
        for (int i = 0; i < _newChunks.Count; i++)
        {
            Destroy(_newChunks[i]);
        }
        _newChunks.Clear();
        _count = 0;
    }

    IEnumerator ChunkSpawner()
    {
        while (true)
        {
            GameObject newChunk = Instantiate(_chunks, transform.position, transform.rotation);
            newChunk.transform.localPosition = transform.localPosition = new Vector3(_count += 17.75f, 0, 0);
            newChunk.transform.SetParent(_collector.transform);
            _newChunks.Add(newChunk);
            yield return new WaitForSeconds(0.2f);
        }   
    }

}