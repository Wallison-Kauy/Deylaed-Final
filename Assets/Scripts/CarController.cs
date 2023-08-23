using UnityEngine;

public class CarController : MonoBehaviour
{
    public Transform[] waypoints; // Array de waypoints.
    public float speed = 5.0f;   // Velocidade do carro.

    private int currentWaypointIndex = 0; // O waypoint atual que o carro está se movendo em direção.

    private void Update()
    {
        // Se o carro alcançou o último waypoint, pare.
        if (currentWaypointIndex >= waypoints.Length)
        {
            return;
        }

        // Mova o carro em direção ao waypoint atual.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);

        // Se o carro alcançou o waypoint atual, mude para o próximo waypoint.
        if (transform.position == waypoints[currentWaypointIndex].position)
        {
            currentWaypointIndex++;
        }
    }
}