using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicObject : MonoBehaviour
{
    public GameObject prefebs, generate;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateGameObjects();
    }
    void InstantiateGameObjects()
    {
        StartCoroutine("Wait3sec");
        generate = Instantiate(prefebs, transform.position, transform.rotation);
        generate.transform.Translate(new Vector3(0, 0 , 0));
        Debug.Log("CLone created");

    }
    // Update is called once per frame
    //void Update()
    //{

    //}
    public IEnumerator Wait3sec()
    {
        yield return new WaitForSeconds(3f);
        InstantiateGameObjects();
    }

}