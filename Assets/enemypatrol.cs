using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypatrol : MonoBehaviour
{

    [SerializeField] public Transform leftEdge;
    [SerializeField] public Transform rightEdge;
    [SerializeField] private Transform enemy;

    public HelperScript helper;


    public float speed = 2f;
    private Vector3 initScale;
    private bool movingLeft;

    [SerializeField]private Animator anim;

    [SerializeField] private float idleDuration;
    private float idleTimer;
    // Start is called before the first frame update
    void Awake()
    {
        initScale = enemy.localScale;
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
                 MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }

    }


    private void DirectionChange()
    {

        anim.SetBool("Run", false);
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
        movingLeft = !movingLeft;
    }



    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Run",true);
        
        helper.FlipObject(gameObject, -_direction);
   
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime*_direction*speed,enemy.position.y , enemy.position.z);



    }
}
