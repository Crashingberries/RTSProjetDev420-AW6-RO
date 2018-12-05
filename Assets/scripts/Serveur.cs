using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;


public class Serveur : MonoBehaviour
{
    public int port = 1234;

    private List<ServeurClient> clients;
    private List<ServeurClient> listedeconnection;

    private TcpListener serveur;
    private bool serveurDemarre;

    public void Init()
    {
        DontDestroyOnLoad(gameObject);
        clients = new List<ServeurClient>();
        listedeconnection = new List<ServeurClient>();

        try
        {
            serveur = new TcpListener(IPAddress.Any, port);
            serveur.Start();
            StartListening();
            serveurDemarre = true;
        }
        catch(Exception e)
        {
            Debug.Log("Erreur de socket: "+e.Message);
        }
    }
    private void Update()
    {
        if (!serveurDemarre)
            return;
        foreach(ServeurClient c in clients)
        {
            if (!EstConnecte(c.tcp))
            {
                c.tcp.Close();
                listedeconnection.Add(c);
                continue;
            }
            else
            {
                NetworkStream s = c.tcp.GetStream();
                if (s.DataAvailable)
                {
                    StreamReader reader = new StreamReader(s, true);
                    string donnees = reader.ReadLine();

                    if (donnees != null)
                    {
                        DonneesEntrantes(c, donnees);
                    }
                }
            }
        }
        for (int i = 0; i < listedeconnection.Count - 1; i++)
        {
            clients.Remove(listedeconnection[i]);
            listedeconnection.RemoveAt(i);
        }
    }
    private void StartListening()
    {
        serveur.BeginAcceptTcpClient(AcceptTcpClient,serveur);
    }
    private void AcceptTcpClient(IAsyncResult ar)
    {
        TcpListener listener= (TcpListener)ar.AsyncState;

        ServeurClient sc = new ServeurClient(listener.EndAcceptTcpClient(ar));
        clients.Add(sc);

        StartListening();

        Debug.Log("Quelqu'un s'est connecté!");
    }

    private bool EstConnecte(TcpClient c)
    {
        try
        {
            if (c != null && c.Client != null && c.Client.Connected)
            {
                if (c.Client.Poll(0, SelectMode.SelectRead))
                {
                    return !(c.Client.Receive(new byte[1], SocketFlags.Peek) == 0);
                }
                return true;
            }
            else { return false; }
        }
        catch
        {
            return false;
        }
    }
    //Envoi des données
    private void Broadcast(string donnees, List<ServeurClient> cl)
    {
        foreach (ServeurClient sc in cl)
        {
            try
            {
                StreamWriter writer = new StreamWriter(sc.tcp.GetStream());
                writer.WriteLine(donnees);
                writer.Flush();
            }
            catch(Exception e)
            {
                Debug.Log("Erreur en ecriture: "+e.Message);
            }
        }
    }
    //Reception des données
    private void DonneesEntrantes(ServeurClient c, string donnees)
    {
        Debug.Log(donnees);
    }
}

public class ServeurClient
{
    public string nomClient;
    public TcpClient tcp;

    public ServeurClient(TcpClient tcp)
    {
        this.tcp = tcp;
    }

}
