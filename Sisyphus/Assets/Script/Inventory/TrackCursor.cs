using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCursor : MonoBehaviour
{
    public bool isKeepTracking;
    public IEnumerator Track()
    {
        transform.position = Input.mousePosition;
        yield return null;
        while (isKeepTracking)
        {
            transform.position = Input.mousePosition;
            yield return null;
        }
    }
}
