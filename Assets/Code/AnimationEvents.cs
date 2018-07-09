using UnityEngine;

/// <summary>
/// Handle animation events
/// </summary>
public class AnimationEvents : MonoBehaviour
{
    /// <summary>
    /// Called from animation
    /// </summary>
    public void OnHit()
    {
        Debug.Log("on hit");
    }
}