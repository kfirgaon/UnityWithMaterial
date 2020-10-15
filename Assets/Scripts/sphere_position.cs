using UnityEngine;
using UnityEngine.UI;

public class sphere_position : MonoBehaviour
{
    public Transform Sphere;
    public Text Sphere_Position;
    

    //Update the height of the ball in real time
    void Update()
    {
        Sphere_Position.text = "Sphere Height: " + Sphere.position.y.ToString() + "m";
    }
}
