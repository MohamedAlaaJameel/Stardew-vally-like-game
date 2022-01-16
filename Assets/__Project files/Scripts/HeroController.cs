using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    [SerializeField] string xAxisBlendParam="X";
    [SerializeField] string yAxisBlendParam="Y";
    [SerializeField] InventoryItemList inventory;
   
    //

    #region the Hitter tool parameters
    [SerializeField] float toolMaxDist = .9f, toolDiameter=.5f;
    [SerializeField] float pickMaxDist = .9f, pickDiameter=.5f;
    [SerializeField] float interactMaxDist = .9f, InteractDiameter=.5f;
    #endregion

    //
    [SerializeField]Player Hero;
    
    Rigidbody2D rb2d;
    Animator animator;
    IController controller;
    float speed = 2f;
    Vector2 directionVector;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        controller = new KeyboardMouse();
 
        Hero = new Player(transform, rb2d, controller, speed, animator, inventory);
    }
    private void FixedUpdate()
    {
        Hero.Move();
    }
    private void Update()
    {
        CheckForUserInterActions();

        #region Animation run in update
        Hero.RunBlendedAnimation(xAxisBlendParam, yAxisBlendParam); 
        #endregion
    }

    private void CheckForUserInterActions()
    {
        if ((controller as IControllerShortCuts).CollectBtn)
        {
            Hero.PickItem(pickMaxDist, pickDiameter);
        }
        if ((controller as IControllerShortCuts).AttackBtn)
        {
            Hero.Interact(interactMaxDist, InteractDiameter);//open chest..
            Hero.UseTool(toolMaxDist, toolDiameter);//cut trees.. todo attack enemy

        }
    }

    #region Edit mode  Calls (Run time scripts)
    private void OnDrawGizmos()
    {
        if (rb2d != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(rb2d.position + Hero.lastFaceDirection * toolMaxDist, toolDiameter);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(rb2d.position + Hero.lastFaceDirection * pickMaxDist, pickDiameter);

            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(rb2d.position + Hero.lastFaceDirection * interactMaxDist, InteractDiameter);

        }




    } 
    #endregion
}
