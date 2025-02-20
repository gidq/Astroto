using System;
using UnityEngine;

public class Snapshot : MonoBehaviour
{
    public LayerMask mask;
    public Light mainLight;
    public City city;
    public Transform RayOriginTransform;
    public SearchByEQCoords searchByEQCoords;
    public float ra;
    public float dec;

    

    // Start is called before the first frame update
    void Start()
    {
        
        
        Vector3 conversion = ConvertFromHorizontalToCartesian(148.88916f, 69.0604f);
        Debug.Log(conversion);

        Debug.Log($"Cartesian: {conversion.x}, {conversion.y}, {conversion.z}");

        Debug.Log($"RA&DEC: {0f}&{0f} Dst: {(transform.position - conversion).magnitude}");

        ConvertFromCartesianToHorizontal(conversion);
    }

    Vector3 ConvertFromHorizontalToCartesian(float RA, float DEC)
    {
        float radRA = Mathf.Deg2Rad * RA;
        float radDEC = Mathf.Deg2Rad * DEC;

        float x = Mathf.Cos( radRA ) * Mathf.Cos(radDEC);
        float y = Mathf.Sin( radRA )* Mathf.Cos(radDEC);
        float z = Mathf.Sin(radDEC);


        return new Vector3( x, y, z );

    }

    float CalculateMaxDistanceUsingRotation()
    {
        float CamXRotation = transform.eulerAngles.x;

        if (CamXRotation > 180) // Convert 180-360 range to -180 to 0
            CamXRotation -= 360;

        CamXRotation = Mathf.Clamp(CamXRotation, -90f, 90f);

        float zValue = Mathf.Lerp(2f, -2f, (CamXRotation + 90f) / 180f);

        Debug.Log($"Camera X Rotation: {CamXRotation}, Mapped Z Value: {zValue}");

        return zValue;
    }

    void ConvertFromCartesianToHorizontal(Vector3 hitPoint)
    {
        float x = hitPoint.x;
        float y = hitPoint.y;
        float z = hitPoint.z;
        float r = Mathf.Sqrt(x*x + y*y + z*z);

        ra = Mathf.Rad2Deg * Mathf.Atan2(y, x);
        if (ra < 0) {
            ra += 360;
        }
        dec = Mathf.Rad2Deg * Mathf.Asin(z / r);
        Debug.Log($"RA: {ra} DEC: {dec}");

        
        searchByEQCoords.Scrape(ra, dec);

        
    }

    double CalculateLST(double GST, double lon)
    {
        double LST = GST + lon;
        LST = LST % 360.0f;
        if (LST < 0) LST += 360.0;
        return LST;
    }

    double JulianDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (month <= 2)
        {
            month += 12;
            year -= 1;
        }

        int A = year / 100;
        int B = 2 - A + A / 4;

        double JD = (int)(365.25 * (year + 4716)) + (int)(30.6001 * (month + 1)) + day + B - 1524.5;
        JD += date.Hour / 24.0 + date.Minute / 1440.0 + date.Second / 86400.0;

        return JD;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse down!");
            float maxDistance = CalculateMaxDistanceUsingRotation();
            RaycastHit hit;

            //if (maxDistance < 0) maxDistance = maxDistance * maxDistance;

            Debug.Log($"Max Distance: {maxDistance}");

            // Perform the raycast
            if (Physics.Raycast(RayOriginTransform.position, RayOriginTransform.forward, out hit, maxDistance, mask))
            {
                // Handle raycast hit (if needed)
                Vector3 hitPoint = hit.point;
                Debug.Log("Hit point: " + hitPoint);
                ConvertFromCartesianToHorizontal(hitPoint);
                
            }
            else
            {
                // When ray doesn't hit, create a virtual point at maxDistance
                Vector3 virtualPoint = RayOriginTransform.position + RayOriginTransform.forward * maxDistance;
                Debug.Log("Virtual point: " + virtualPoint);
                ConvertFromCartesianToHorizontal(virtualPoint);
            }
        }
    }

}
