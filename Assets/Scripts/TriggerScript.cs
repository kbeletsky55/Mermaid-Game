using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    private int times = 0;
    public LogicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && times == 0)
        {
            logic.addScore(1);
            times++;
        }
    }

}
