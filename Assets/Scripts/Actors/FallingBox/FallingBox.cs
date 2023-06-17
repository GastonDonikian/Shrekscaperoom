using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingBox : MonoBehaviour
{
   [SerializeField] private float _raycastLength = 5f;
   [SerializeField] private float _deployDrag = 10f;
   [SerializeField] private float _preDeployDrag = 0f;
   [SerializeField] private bool _parachuteDeployed = false;
   [SerializeField] private int _layerGroundMask = 0;
   private Rigidbody _rb;

   private void Start()
   {
      _rb = GetComponent<Rigidbody>();
      _rb.drag = _preDeployDrag;
   }

   private void Update()
   {
      RaycastHit hit;
      Ray ray = new Ray(transform.position, Vector3.down);
      if (!_parachuteDeployed)
      {
         if (Physics.Raycast(ray, out hit, _raycastLength))
         {
            if (hit.collider.gameObject.layer == _layerGroundMask)
            {
               DeployChute();
            }
         }
      }
   }
   
   private void DeployChute()
   {
      _parachuteDeployed = true;
      _rb.drag = _deployDrag;
   }
}
