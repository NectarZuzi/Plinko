using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene1 : MonoBehaviour
{
    public GameObject peg;
    public GameObject dropBall;
    public GameObject enemyObject;
    public GameObject nommerObject;
    public int height;
    public int width;
    private List<GameObject> enemies = new List<GameObject>();
    private GameObject nommer;

    // Start is called before the first frame update
    void Start()
    {
        int left = -(width / 2);
        int right = (width / 2);
        if (width % 2 != 0)
        {
            right++;
        }
        int bot = -(height / 2);
        int top = (height / 2);
        if (height % 2 != 0)
        {
            top++;
        }
        for (int x = left; x < right; x++)
        {
            for (int y = bot; y < top; y++)
            {
                int horizontal = x * 2;
                if (y % 2 == 0)
                {
                    horizontal += 1;
                }
                int vertical = y * 2;
                enemies.Add(Instantiate(enemyObject, new Vector3(horizontal, vertical, 0), Quaternion.identity));
            }
        }
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetMouseButtonDown(0))
        {
            nommer = Instantiate(nommerObject, worldPosition, Quaternion.identity);
        }
        if (!nommer)
        {
            return;
        }

        Rigidbody2D closestBody = null;
        float closestDistance = -1;
        foreach (GameObject enemy in enemies)
        {
            if (!enemy)
            {
                continue;
            }
            Rigidbody2D body1 = enemy.GetComponent<Rigidbody2D>();
            Rigidbody2D body2 = nommer.GetComponent<Rigidbody2D>();
            float distance = Vector2.Distance(body1.position, body2.position);
            if (closestDistance == -1 || closestDistance > distance)
            {
                closestDistance = distance;
                closestBody = body1;
            }
            if (distance < 5)
            {
                //moveRelativeToObject(body1, body2, 25, false);
            }
        }
        if (!closestBody)
        {
            return;
        }
        moveRelativeToObject(nommer.GetComponent<Rigidbody2D>(), closestBody, 50, true);
    }

    void moveRelativeToObject(Rigidbody2D body1, Rigidbody2D body2, float speed, bool towards)
    {
        Vector2 difference = body2.position - body1.position;
        difference = difference.normalized * Time.deltaTime * speed;
        if (!towards)
        {
            difference *= -1;
        }
        body1.MovePosition(body1.position + difference);
    }
}
