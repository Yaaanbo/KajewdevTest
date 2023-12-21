using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemDetector))]
public class ItemDetectorEditor : Editor
{
    private void OnSceneGUI()
    {
        ItemDetector detector = (ItemDetector)target;

        Handles.color = Color.red;

        //Draw view radius
        float maxAngle = 360f;
        Handles.DrawWireArc(detector.transform.position, Vector3.up, Vector3.forward, maxAngle, detector.viewRadius);

        //Draw view angle
        Vector3 viewAngle1 = DirectionFromAngle(detector.transform.eulerAngles.y, -detector.viewAngle / 2);
        Vector3 viewAngle2 = DirectionFromAngle(detector.transform.eulerAngles.y, detector.viewAngle / 2);

        Handles.color = Color.blue;
        Handles.DrawLine(detector.transform.position, detector.transform.position + viewAngle1 * detector.viewRadius);
        Handles.DrawLine(detector.transform.position, detector.transform.position + viewAngle2 * detector.viewRadius);

        if (detector.isItemInReach)
        {
            Debug.Log("Item Is In Reach");
        }
    }

    private Vector3 DirectionFromAngle(float _eulerY, float _angleInDegrees)
    {
        _angleInDegrees += _eulerY;

        return new Vector3(Mathf.Sin(_angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(_angleInDegrees * Mathf.Deg2Rad));
    }
}
