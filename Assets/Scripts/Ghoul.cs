using UnityEngine;
using UnityEngine.UIElements;

public class Ghoul : MonoBehaviour
{
public Transform[] players; 
    public float attractionStrength = 5f;
    public float repulsionStrength = 10f;
    public float repulsionRange = 3f;
    public float speed = 1f;

    private Transform targetPlayer;

    private int health = 4;

    public GameObject dieParticle;

    void Start(){
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        players[0] = playerList[0].transform;
        //players[1] = playerList[1].transform;
    }

    void Update()
    {
        targetPlayer = GetClosestPlayer(); // Wähle den nächstgelegenen Spieler
        if (targetPlayer != null)
        {
            Vector3 force = CalculatePotentialField();
            transform.position += force * speed * Time.deltaTime;
            transform.LookAt(targetPlayer);
        }
    }

    Transform GetClosestPlayer()
    {
        Transform closestPlayer = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Transform player in players)
        {
            if (player == null) continue;

            float distance = Vector3.Distance(transform.position, player.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }

    Vector3 CalculatePotentialField()
    {
        Vector3 attractionForce = (targetPlayer.position - transform.position).normalized * attractionStrength;
        Vector3 repulsionForce = Vector3.zero;

        Collider[] colliders = Physics.OverlapSphere(transform.position, repulsionRange);

        foreach (Collider col in colliders)
        {
            if (col.gameObject != gameObject && !IsPlayerCollider(col) && !IsBarrierCollider(col))
            {
                Vector3 direction = transform.position - col.ClosestPoint(transform.position);
                float distance = direction.magnitude;
                if (distance > 0)
                {
                    repulsionForce += direction.normalized * (repulsionStrength / distance);
                }
            }
        }

        return (attractionForce + repulsionForce).normalized;
    }

    bool IsPlayerCollider(Collider col)
    {
        return col.CompareTag("Player");
    }

    bool IsBarrierCollider(Collider col)
    {
        return col.CompareTag("GhoulBarrier");
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("GhoulBarrier")){
            GetComponent<AudioSource>().Play();
            health--;
            if(health > 0){
                transform.position = new Vector3(-2.45000005f,24.3899994f,-5.13000011f);
            } else{
                Die();
            }
        }
    }

    private void Die(){
        Instantiate(dieParticle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
