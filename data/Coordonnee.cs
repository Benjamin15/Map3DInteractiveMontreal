using UnityEngine;
using System.Collections;

public class Coordonnee : MonoBehaviour {

    public float x;
    public float y;
    public float z;
    public Vector3 coord;
    public Coordonnee(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.coord = new Vector3(x, y, z);
    }
    public void setCoord(Vector3 vect)
    {
        coord = vect;
    }
    public void updateCoord()
    {
        this.coord = new Vector3(x, y, z);
    }
}
