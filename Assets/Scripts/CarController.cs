using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints; // Array de waypoints.
    public float speed = 5.0f;   // Velocidade do carro.

    private int currentWaypointIndex = 0; // O waypoint atual que o carro est� se movendo em dire��o.

    private void Update()
    {
        // Se o carro alcan�ou o �ltimo waypoint, pare.
        if (currentWaypointIndex >= waypoints.Length)
        {
            return;
        }

        // Mova o carro em dire��o ao waypoint atual.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Se o carro alcan�ou o waypoint atual, mude para o pr�ximo waypoint.
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            currentWaypointIndex++;
        }
    }
}