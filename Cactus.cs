using UnityEngine;

public class Cactus : MonoBehaviour 
{
    // The value used to reduce the damage caused by the cactus.
    private readonly float damageDamping = 4; 

    private void OnCollisionEnter(Collision x) 
    {
        // Check if the collided object has a tag of "Player".
        if (x.collider.CompareTag("Player")) 
        {
            // Calculate the damage by rounding the magnitude of the relative velocity of the collision.
            float damage = Mathf.Round(x.relativeVelocity.magnitude); 

            // Call the Damage method on the playerScript component of the Game.instance.playerScript object.
            // Pass the calculated damage divided by the damageDamping value, rounded to the nearest integer.
            Game.instance.playerScript.Damage(Mathf.Round(damage / damageDamping));
        }
    }
}
