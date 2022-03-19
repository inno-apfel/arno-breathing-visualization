using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using System.Globalization;

public class RespirationBeltScaling : MonoBehaviour
{
    Thread mThread;
    public string connectionIP = "localhost";
    public int connectionPort = 2500;
    IPAddress localAdd;
    TcpListener listener;
    TcpClient client;
    public float previousScalar = 0f;
    public float receivedScalar = 0f;
    public float speed = 0f;
    public float rate = 0f;

    public void ParseServerMessage(string inputData)
    {
        receivedScalar = float.Parse(inputData);
        
        float i = 0.0f;
        float rate = (1.0f / 100f) * speed;

        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(new Vector3(previousScalar, previousScalar, previousScalar), new Vector3(receivedScalar, receivedScalar, receivedScalar), i);
        }
        previousScalar = receivedScalar;


    }
}