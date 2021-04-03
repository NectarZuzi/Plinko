using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene1 : MonoBehaviour
{
    public GameObject peg;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = -10; x < 20; x++)
        {
            for (int y = -10; y < 20; y++)
            {
                int horizontal = x * 2;
                if(y % 2 == 0)
                {
                    horizontal += 1;
                }
                int vertical = y * 2;
                Instantiate(peg, new Vector3(horizontal, vertical, 0), Quaternion.identity);
            }
        }
    }
}
