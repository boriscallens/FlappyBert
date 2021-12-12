using UnityEditor;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // Start is called before the first frame update
    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipe), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPipe));
    }

    // Update is called once per frame
    private void SpawnPipe()
    {
        var pipes = Instantiate(pipe, transform.position, Quaternion.identity);
        pipes.transform.position += new Vector3(0, Random.Range(minHeight, maxHeight), 0);
    }
}