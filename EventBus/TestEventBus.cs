using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventBus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EventBus.AddListenOnce<EventBusMsg<string>>(OnMsg);
            EventBus.AddListen<EventBusMsg<string>>(OnMsg);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            EventBus.Fire(new EventBusMsg<string>() { Value = "2" });
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EventBus.FireAllChannel(new EventBusMsg<string>() { Value = "all" });
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            EventBus.RemoveListenWithChannel<EventBusMsg<string>>("1",OnMsg);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            EventBus.AddListenWithChannel<EventBusMsg<string>>("1", OnMsg);
        }
    }

    void OnMsg(EventBusMsg<string> msg)
    {
        Debug.Log(msg.Value);
    }


}

public class TestMsg
{
    public string name;
}

