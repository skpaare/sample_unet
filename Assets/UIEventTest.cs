using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventTest : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public void RpcMethod(uint netIdValue)
    {
        _text.text = $"Call RPC {netIdValue}";
    }
    
    public void RpcMethodFromCommand(uint netIdValue)
    {
        _text.text = $"Call RPC from Command {netIdValue}";
    }

    public void CmdMethod(uint netIdValue)
    {
        _text.text = $"Call Command {netIdValue}";
    }

    public void MethodClient(uint netIdValue)
    {
        _text.text = $"Call Client {netIdValue}";
    }

    public void MethodServer(uint netIdValue)
    {
        _text.text = $"Call Server {netIdValue}";
    }

    public void MethodServerFromCommand(uint netIdValue)
    {
        _text.text = $"Call Server from Command {netIdValue}";
    }
}