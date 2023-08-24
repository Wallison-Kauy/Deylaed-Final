using System.Linq; // necessário para o uso de Linq
using UnityEngine;

public class CarControllerDown : MonoBehaviour
{
    public Transform[] waypoints; // Array de waypoints.
    public float speed = 5.0f;   // Velocidade do carro.

    private int currentWaypointIndex = 0; // O waypoint atual que o carro está se movendo em direção.

    [SerializeField]
    private Transform waypointsParent;

    private void Awake()
    {
        GameObject waypointsParent = GameObject.Find("WayPointsDown");

        if (waypointsParent != null)
        {
            waypoints = waypointsParent.GetComponentsInChildren<Transform>()
                .Where(t => t != waypointsParent.transform)  // Isso exclui o transform do próprio WayPoints
                .ToArray();
        }
        else
        {
            UnityEngine.Debug.LogWarning("Objeto 'WayPoints' não encontrado!");
        }
    }

    private void Start()
    {
       
    }

    private void Update()

    {

        if (waypoints == null || waypoints.Length == 0)
        {
            return; // Se não houver waypoints, saia do Update
        }

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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Victory")
        {
            //Destroy(this.gameObject); // Destrua o carro
        }
    }
}