using UnityEngine;
public class playerStats : MonoBehaviour
{
    public int dept;
    
    public float forwardVelocity=1;
    public float horizontalVelocity=1;
    public static int chance=0;
    public Transform camNewPos;
    public Transform playerNewPos;

    public void Collect(GameObject collectible)
    {
        Collectibles.cash++;
        Destroy(collectible);
    }
}
