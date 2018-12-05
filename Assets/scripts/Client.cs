using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;

public class Client : MonoBehaviour
{
    private bool socketReady;
    private TcpClient socket;
    private NetworkStream stream;
    private StreamReader reader;
    private StreamWriter writer;
    public string NomClient;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public bool ConnectionServeur(string hote, int port)
    {
        if (socketReady) { return false; }
        try
        {
            socket = new TcpClient(hote, port);
            stream = socket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);

            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Erreur de socket: " + e.Message);

        }
        return socketReady;
    }

    private void Update()
    {
        if (socketReady)
        {
            if (stream.DataAvailable)
            {
                string donnees = reader.ReadLine();
                if (donnees != null)
                {
                    DonneesEntrante(donnees);
                }
            }
        }
    }
    private void OnApplicationQuit()
    {
        CloseSocket();
    }
    private void OnDisable()
    {
        CloseSocket();
    }
    private void CloseSocket()
    {
        if (!socketReady)
        {
            return;
        }
        writer.Close();
        reader.Close();
        socket.Close();
        socketReady = false;
    }
    private void DonneesEntrante(string donnees)
    {
        Debug.Log(donnees);
    }
    public void Envoi(string donnees)
    {
        if (!socketReady)
        {
            return;
        }
        writer.WriteLine(donnees);
        writer.Flush();
    }
}
public class ClientJeu
{
    public string name;
    public bool estHote;
}
