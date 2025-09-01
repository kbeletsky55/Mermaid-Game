using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject seaweed;
    public GameObject coin;

    public float spawnRate;
    public float timer = 0;

    public float heightOffset;

    // integer that shows how many seaweeds to spawn before generating a coin: random int in [0, 3]
    private int seaweedsUntilCoin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generateRandomSpaces();
        spawnSeaweed();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            spawnSeaweed();
            timer = 0;
        }

    }

    void spawnSeaweed()
    {
        float min = transform.position.y - heightOffset;
        float max = transform.position.y + heightOffset;

        Vector3 position = new Vector3(transform.position.x, Random.Range(min, max), 0);

        Instantiate(seaweed, position, transform.rotation);
        if (seaweedsUntilCoin == 0)
        {
            Instantiate(coin, position, transform.rotation);
            generateRandomSpaces();
        } else
        {
            seaweedsUntilCoin--;
        }
    }

    void generateRandomSpaces()
    {
        seaweedsUntilCoin = Random.Range(0, 4);
    }
}
