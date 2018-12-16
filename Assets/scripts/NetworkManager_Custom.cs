using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization;
public class NetworkManager_Custom : NetworkManager {

	public void StartupHost()
	{
		SetPort();
		NetworkManager.singleton.StartHost();
	}

	public void JoinGame()
	{
        try
        {
            SetIPAddress();
            SetPort();
            NetworkManager.singleton.StartClient();
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("Partie introuvable" +ex);
        }
    }

    void SetIPAddress()
    {
        Text txt = GameObject.FindObjectOfType<Canvas>().transform.Find("InputField").Find("Text").gameObject.GetComponent<Text>();
        string ipAddress = "127.0.0.1";
        Debug.Log(txt.text);
        if (txt.text!= ""){
            ipAddress = txt.text;
        }
        Debug.Log(ipAddress);
		NetworkManager.singleton.networkAddress = ipAddress;
	}

	void SetPort()
	{
		NetworkManager.singleton.networkPort = 7777;
	}

	void OnLevelWasLoaded (int level)
	{
		if(level == 0)
		{
      
            StartCoroutine(SetupMenuSceneButtons());
		}

		else
		{
			SetupOtherSceneButtons();
		}
	}

	IEnumerator SetupMenuSceneButtons()
	{
        yield return new WaitForSeconds(0.3f);
		GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonStartHost").GetComponent<Button>().onClick.AddListener(StartupHost);

		GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.RemoveAllListeners();
		GameObject.Find("ButtonJoinGame").GetComponent<Button>().onClick.AddListener(JoinGame);
	}

	void SetupOtherSceneButtons()
	{
		//GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.RemoveAllListeners();
		//GameObject.Find("ButtonDisconnect").GetComponent<Button>().onClick.AddListener(NetworkManager.singleton.StopHost);
	}

}
