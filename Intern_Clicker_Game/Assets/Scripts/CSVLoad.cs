using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CSVLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("SampleMonster");
        for(int i = 0; i < data.Count; i++)
        {
            Debug.Log("Test CSVfileReader : " + data[i]["Name"]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
