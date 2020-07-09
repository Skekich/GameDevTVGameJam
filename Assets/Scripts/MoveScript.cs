using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    void Update()
    {
        var movement = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).normalized;
        
        transform.Translate(movement * (moveSpeed * Time.deltaTime));
    }
}
