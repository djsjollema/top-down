using Unity.VisualScripting;
using UnityEngine;

public class Pong : MonoBehaviour
{
    [SerializeField] private GameObject pongBall;
    [SerializeField] private GameObject pongBatRight;
    Vector3 velocity = new Vector3(2,3);

    Vector2 minScreen;
    Vector2 maxScreen;

    float differenceX;
    float factor;
    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));   

    }

    // Update is called once per frame
    void Update()
    {
        // Apply movement
        pongBall.transform.position += velocity * Time.deltaTime;

        

        if (pongBall.transform.position.y < minScreen.y || pongBall.transform.position.y > maxScreen.y)
        {
            velocity.y = -velocity.y;
        }

        differenceX = pongBall.transform.position.x - pongBatRight.transform.position.x;
        factor = differenceX / velocity.x;

        Debug.Log("differenceX: " + differenceX + " factor: " + factor);
        Vector3 targetPosition = new Vector3(pongBatRight.transform.position.x, pongBall.transform.position.y - factor * velocity.y, 0);
        //pos.y = Mathf.Clamp(pos.y, minScreen.y, maxScreen.y);
        //pongBall.transform.position = pos;
        pongBatRight.transform.position = targetPosition;
    }
}
