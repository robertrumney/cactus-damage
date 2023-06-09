# Simple Cactus Repository

This is a simple repository that contains a C# script for a cactus object in a Unity game. The script is responsible for causing damage to the player when a collision occurs between the cactus and the player, and for making the damage relative to the velocity of impact.

## How it Works

The `Cactus` script is attached to a game object in the Unity scene. When a collision happens, the script checks if the collided object has a tag of "Player". If it does, the script calculates the damage based on the magnitude of the relative velocity of the collision. The damage is then passed to the `Damage` method on the playerScript component of the Game.instance.playerScript object, after being divided by a damage damping value.

## Features

- Simple implementation of cactus damage in Unity.
- Reduces the damage caused by the cactus by using a damage damping value.
- Collision detection based on tags.

## Getting Started

To use this script in your Unity project, follow these steps:

1. Download or clone the repository.
2. Copy the `Cactus.cs` file into your Unity project's scripts folder.
3. Attach the `Cactus` script to a game object in your scene that has a collider.
4. Make sure you have a player object with the "Player" tag for the collision detection to work properly.
5. Replace this line with your own player damage function call:
```csharp
// Call the Damage method on the playerScript component of the Game.instance.playerScript object.
// Pass the calculated damage divided by the damageDamping value, rounded to the nearest integer.
Game.instance.playerScript.Damage(Mathf.Round(damage / damageDamping));
```
6. If your game does not use a singleton game manager such as the `Game.instance` one shown above, you can use a GetComponent:
```csharp
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
            
            // Pass the calculated damage divided by the damageDamping value, rounded to the nearest integer.
            damage = Mathf.Round(damage/damageDamping);
            
            // Replace existing third line with this 
            x.collider.gameObject.GetComponent<Player>().Damage(damage);
        }
    }
}
```

## License

This repository is licensed under the [MIT License](LICENSE).

## Contributions

Contributions to improve the functionality or add new features to this simple repository are welcome. Feel free to open issues and submit pull requests.

## Disclaimer

This repository is meant to demonstrate a simple implementation and should not be considered a comprehensive solution. Use it as a starting point for your own development or learning purposes.

Feel free to explore and modify the code to suit your specific requirements!
