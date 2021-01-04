using Assets.Network;
using Assets.Scripts.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MultiplayerMenuController : MonoBehaviour
    {
        public Button addServer;
        public Button directConnect;
        public Button serverConnect;
        public Button cancel;
        public Button refresh;
        public Button delete;
        public Button edit;
        public ScrollRect servers;

        int selectedServer = -1;
        private void Start() {
            addServer.onClick.AddListener(AddServerCallback);
            directConnect.onClick.AddListener(DirectConnectCallbacl);
            serverConnect.onClick.AddListener(ConnectToServerCallback);
            cancel.onClick.AddListener(CancelCallback);
            refresh.onClick.AddListener(RefreshCallback);
            delete.onClick.AddListener(DeleteCallback);
            edit.onClick.AddListener(EditServerInfoCallback);
        }

        private void EditServerInfoCallback()
        {
            action.Invoke(MultiplayerMenuEvents.OnEditClicked);
        }

        private void DeleteCallback()
        {
            if (selectedServer > -1 && selectedServer < servers.content.childCount)
            {
                Destroy(servers.content.GetChild(selectedServer));
                Debug.Log($"Server #{selectedServer} was deleted from list.");
            }
        }

        private void RefreshCallback()
        {
            for (int i = 0; i < servers.content.childCount; i++)
            {
                var serverInfo = servers.content.GetChild(i).GetComponentsInChildren<TextMeshProUGUI>();
                var result = TcpClient.GetStatus(serverInfo[4].text);
                if (result == null)
                {
                    serverInfo[1].text = "";
                    serverInfo[2].text = "Server not answer";
                    serverInfo[2].color = Color.red;
                    serverInfo[3].text = "";
                }
                else
                {
                    serverInfo[1].text = result.version;
                    if (Client.version != result.version)
                    {
                        serverInfo[1].color = Color.red;
                    }
                    else
                    {
                        serverInfo[1].color = Color.gray;
                    }
                    serverInfo[2].text = result.description;
                    serverInfo[2].color = Color.gray;
                    serverInfo[3].text = $"{result.connected}/{result.maxConnections}";
                    serverInfo[4].text = result.address;
                }
            }
        }

        private void CancelCallback()
        {
            action.Invoke(MultiplayerMenuEvents.OnCancelClicked);
        }

        private void ConnectToServerCallback()
        {
            var serverInfo = servers.content.GetChild(selectedServer).GetComponentsInChildren<TextMeshProUGUI>();
            TcpClient.Connect(serverInfo[4].text);
        }

        private void DirectConnectCallbacl()
        {
            action.Invoke(MultiplayerMenuEvents.OnDirectConnectClicked);
        }

        private void AddServerCallback()
        {
            action.Invoke(MultiplayerMenuEvents.OnAddServerClicked);
        }

        protected UnityAction<MultiplayerMenuEvents> action;
        public void AddListener(UnityAction<MultiplayerMenuEvents> action)
        {
            this.action = action;
        }

    }
}
