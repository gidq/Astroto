using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class City : ScriptableObject
{
    public string CityName;
    public double CityLat;
    public double CityLon;
    public int CityLpl;
    public City(string name_, double lat, double lon, int lpl)
    {
        CityName = name_;
        lat = CityLat;
        lon = CityLon;
        lpl = CityLpl;
    }

}
