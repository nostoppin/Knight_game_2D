using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_player : MonoBehaviour
{
    private float g_player_moveSpeed = 0f;

    public Animator g_player_animator;

    void m_player_movement()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * g_player_moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            
            this.transform.Translate(Vector2.right * g_player_moveSpeed * Time.deltaTime);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        g_player_moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        m_player_movement();
    }
}
