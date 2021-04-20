using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;
using MLAPI.NetworkVariable;
using MLAPI.Messaging;

namespace DroneWork
{
    public class IP_Drone_Health : NetworkBehaviour
    {
        public NetworkVariableFloat health = new NetworkVariableFloat(100f);
        MeshRenderer[] renderers;


        private void Start()
        {
            renderers = GetComponentsInChildren<MeshRenderer>();
        }

        public void TakeDamage(float damage)
        {
            health.Value -= damage;

            if (health.Value <= 0)
            {
                //respawn
                health.Value = 100f;
                Vector3 pos = new Vector3(Random.Range(-10, 10), 3, Random.Range(-10, 10));
                RespawnClientRpc(pos);

            }
        }

        [ClientRpc]
        void RespawnClientRpc(Vector3 position)
        {
            StartCoroutine(Respawn(position));
        }
        IEnumerator Respawn(Vector3 position)
        {
            foreach(var renderer in renderers)
            {
                renderer.enabled = false;
            }
            yield return new WaitForSeconds(1f);

            IP_Drone_Controller dc = GetComponent<IP_Drone_Controller>();
            dc.enabled = false;
            //delay
            transform.position = position;
            dc.enabled = true;
            foreach (var renderer in renderers)
            {
                renderer.enabled = true;
            }
        }
    }
}