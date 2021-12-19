using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c_player : MonoBehaviour
{
    private float g_player_moveSpeed = 0f;
    bool g_player_isGrounded;

    public Animator g_player_animator;
    public Rigidbody2D g_player_rbody;

    void m_player_behaviour()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            this.transform.Translate(Vector2.left * g_player_moveSpeed * Time.deltaTime);

            m_animation_switch(1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            this.transform.Translate(Vector2.right * g_player_moveSpeed * Time.deltaTime);

            m_animation_switch(1);
        }
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            g_player_animator.SetBool("Run", false);
        }
        
        m_player_attack(); m_player_jump();
    }

    void m_player_attack()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            m_animation_switch(3);
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            g_player_animator.SetBool("Attack", false);
        }
    }

    void m_player_jump()
    {
        if(Input.GetKeyDown(KeyCode.W) && g_player_isGrounded)
        {
            print("Jump");
            g_player_rbody.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }

    void m_animation_switch(int l_anim_value)
    {

        if (l_anim_value == 0)
        {
            g_player_animator.SetBool("Idle", true);
        }
        if (l_anim_value == 1)
        {
            g_player_animator.SetBool("Run", true);
        }
        if (l_anim_value == 2)
        {

        }
        if (l_anim_value == 3)
        {
            g_player_animator.SetBool("Attack", true);
        }
    }
    
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Grass")
        {
            g_player_isGrounded = true;
        }
        if(collision.transform.tag != "Grass")
        {
            g_player_isGrounded = false;
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
        print(g_player_isGrounded);
        m_player_behaviour();
    }
}
