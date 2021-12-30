
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    public float health=100;
     public Image Healthbar;
    public GameObject HealthbarAll;
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
    bool dead = false;
    //public GameObject projectile;






    public void TakeDamage(float amount)
    {
        setState(3);
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }


    public void Die()
    {
        setState(4);
        dead = true;
        HealthbarAll.SetActive(false);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator.SetInteger("State",State);
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            Healthbar.fillAmount = health / MaxHealth;


            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) setState(0);
            if (playerInSightRange && !playerInAttackRange) setState(1);
            if (playerInAttackRange && playerInSightRange) setState(2);
        }


    }

    public void setState(int n)
    {

        enemyAnimator.SetInteger("State", n);

        switch (n)
            {
                case 4:
                //dead
                enemyAnimator.SetInteger("State", n);

                break;
                case 3:
                //staggering
                enemyAnimator.SetInteger("State", n);

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
