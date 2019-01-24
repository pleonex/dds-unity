using System;
using UnityEngine;
using RTI.Connext.Connector;

public class Cube : MonoBehaviour
{
    const string configPath = "/sdcard/Configuration.xml";
    const string configName = "MyParticipantLibrary::Zero";
    const string readerName = "MySubscriber::MySquareReader";

    Connector connector;
    RTI.Connext.Connector.Input reader;

    void Start()
    {
        try {
            connector = new Connector(configName, configPath);
            reader = connector.GetInput(readerName);
        } catch (Exception e) {
            Debug.LogError($"Cannot create connector: {e}");
            return;
        }

        // Change color to confirm visually that we could start connector
        GetComponent<Renderer>().material.color = new Color(0.5f, 1, 1);
    }

    void Update()
    {
        if (reader == null)
            return;

        reader.Take();
        foreach (var sample in reader.Samples) {
            if (sample.Data.GetStringValue("color") != "BLUE") {
                continue;
            }

            float x = sample.Data.GetInt32Value("x");
            float y = sample.Data.GetInt32Value("y");
            float z = sample.Data.GetInt32Value("z");

            // Map [240, 270, 10] into a plan dimensions [4.5, 4.5, 4.5]
            x = x * 9 / 240 - 4.5f;
            y = y * 9 / 270 - 4.5f;
            z = z * 9 / 10 - 4.5f;

            transform.position = new Vector3(x, -y, z);
        }
    }
}
