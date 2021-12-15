using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{

    private CharacterController m_CharacterController;

    private bool m_Crouch = false;

    private float m_OriginalHeight;

    [SerializeField] private float m_CrouchHeight = 0.5f;

    public KeyCode crouchKey = KeyCode.C;

    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
        m_OriginalHeight = m_CharacterController.height;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
            m_Crouch = false; CheckCrouch();
        }


        if (Input.GetKeyDown(crouchKey))
        {
            m_Crouch = !m_Crouch;

            CheckCrouch();
        }
    }
    void CheckCrouch()
    {
        if (m_Crouch == true)
        {
            m_CharacterController.height = m_CrouchHeight;
        }
        else
        {
            m_CharacterController.height = m_OriginalHeight;
        }
    }
}