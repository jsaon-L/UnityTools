using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiteNetLibTest : MonoBehaviour
{
    public LiteNetLibServer server;
    public LiteNetLibClient client;
    // Start is called before the first frame update
    void Start()
    {
        server = GetComponent<LiteNetLibServer>();  
        client = GetComponent<LiteNetLibClient>();

        server.OnReceiveMsg += Server_OnReceiveMsg;
        client.OnReceiveMsg += Client_OnReceiveMsg;


    }

    private void Client_OnReceiveMsg(string arg0)
    {
        Debug.Log("�ͻ����յ���Ϣ:"+arg0);
    }

    private void Server_OnReceiveMsg(string arg0)
    {
        Debug.Log("������յ���Ϣ:" + arg0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            server.Send("���Client");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            server.Send("���Server");
        }
    }
}
