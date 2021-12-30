
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public float health=100;
     public Image Healthbar;
    public float MaxHealth=100;
    public Animator enemyAnimator;
    private int State = 0;
    public LayerMask whatIsGround, whatIsPlayer;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public NavMeshAgent agent;

    public Transform player;

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //public GameObject projectile;






    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator.SetInteger("State",State);
    }

    // Update is called once per frame
    void Update()
    {
        
        Healthbar.fillAmount = health / MaxHealth;


        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) setState(0);
        if (playerInSightRange && !playerInAttackRange) setState(1);
        if (playerInAttackRange && playerInSightRange) setState(2);



    }

    public void setState(int n)
    {

        enemyAnimator.SetInteger("State", n);

        switch (n)
            {
                case 4:
                //dead
                    break;
                case 3:
                //staggering
                    break;
                case 2:
                //shooting
                agent.SetDestination(transform.position);
                enemyAnimator.SetInteger("State", n);

                transform.LookAt(player);

                if (!alreadyAttacked)
                {
                    ///Attack code here

                    ///End of attack code

                    alreadyAttacked = true;
                    Invoke(nameof(ResetAttack), timeBetweenAttacks);
                }
                break;
                case 1:
                //running
                agent.SetDestination(player.position);
                enemyAnimator.SetInteger("State", n);

                break;
                case 0:
                //idle
                enemyAnimator.SetInteger("State", n);

                break;
                default:

                    break;
            }
        

    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
