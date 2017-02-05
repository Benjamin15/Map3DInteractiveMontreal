using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBuildings : MonoBehaviour {

    public GameObject[] buildings;
    readData rd;

    List<Batiment> batiments; 
	// Use this for initialization
	void Start () {
        rd = new readData();
        batiments = rd.LoadFromXml();
        XMLBuildingPlace();
        //RandomBuildingPlace(1, 10, 5, 100, 1, 10, -95, 95, -95 , 95, 200);
	}
	
	// Update is called once per frame
	void Update () {
      //  rd.WriteToXml(batiments);
	}
    public void SetBuilding(float length, float height, float width, Vector3 center, int buildingType)
    {
        buildings[buildingType].transform.localScale = new Vector3(length, height, width);
        buildings[buildingType].transform.position = new Vector3(center.x, height / 2.0f, center.z);
        Instantiate(buildings[buildingType]);
    }
    public void XMLBuildingPlace()
    {
        for(int i = 0; i < batiments.Count; i++)
        {
            SetBuilding(batiments[i].GetVectorCoord().x, batiments[i].GetVectorCoord().y, batiments[i].GetVectorCoord().z,
              new Vector3(batiments[i].GetVectorCenter().x,0, batiments[i].GetVectorCenter().y) , (int)batiments[i].getType());
        }
    }

    public void RandomBuildingPlace(float lengthMin, float lengthMax,
                                    float heightMin, float heightMax,
                                    float widthMin,  float widthMax,
                                    float placeXMin, float PlaceXMax,
                                    float placeZMin, float PlaceZMax, int buildingAmount)
    {
        for(int i = 0; i < buildingAmount; i++)
        {
            SetBuilding(Random.Range(lengthMin, lengthMax), Random.Range(heightMin, heightMax), Random.Range(widthMin,widthMax),
                        new Vector3(Random.Range(placeXMin, PlaceXMax), 0, Random.Range(placeZMin,PlaceZMax)),
                        Random.Range(0, buildings.Length));
        }
    }
}
