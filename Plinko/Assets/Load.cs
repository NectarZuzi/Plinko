using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public GameObject peg;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            for(int x = 0; x < 20; x++)
            {
                Instantiate(peg, new Vector3(i, x, 0), Quaternion.identity);
            }
        }
    }
}
