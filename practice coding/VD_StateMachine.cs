using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAction.Manager;
namespace GameAction.Controller
{
    public enum StatePlayer
    {
        Idle,
        Run,
        Attack,
        jump_rising,
        jump_falling,
        die,
    }

    public class StateMachine : MonoBehaviour
    {
        public StatePlayer currentState;
        public Animator _anim;
        [SerializeField] Player_Controller Player_Controller;

        // Start is called before the first frame update
        void Start()
        {
            _anim = GetComponent<Animator>();
            ChangeState(StatePlayer.Idle);
        }

        // Update is called once per frame
        void Update()
        {
            switch (currentState )
            {
                case StatePlayer.Idle:
                    _anim.CrossFade("playeridle", 0f);
                    break;
                case StatePlayer.Run:
                    _anim.CrossFade("runplayer", 0f); 
                    break;
                case StatePlayer.Attack:
                    _anim.CrossFade("attackplayer",0f);
                    break;
                case StatePlayer.jump_rising:
                    if (Player_Controller.rigid.velocity.y > -2f)
                    {
                        _anim.CrossFade("jumprising", 0f);
                    }
                    break;
                case StatePlayer.jump_falling:
                    if (Player_Controller.rigid.velocity.y < -2f)
                    {
                        _anim.CrossFade("jumpfalling", 0f);
                    }
                    break;
                case StatePlayer.die:
                    _anim.CrossFade("Die", 0f);
                    break;
            }
        }
        public void ChangeState(StatePlayer newState)
        {
            // Chuyển state hiện tại sang state mới
            currentState = newState;
        }   
     }  
}
