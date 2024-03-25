using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    // New members for moving and attacking
    private Vector2 initialPosition;
    private Vector2 targetPosition;
    private float moveDuration = 3f;
    private float elapsedTime = 0f;
    private bool isAttacking = false;

    // New method for moving and attacking
    public void MoveAndAttack(God attackingGod, God defendingGod, GameObject attackingPrefab, GameObject defendingPrefab)
    {
        // Calculate the initial position of the attacking prefab
        initialPosition = attackingPrefab.transform.position;
        Vector3 offset = new Vector3(10f, 0f, 0f);
        targetPosition = defendingPrefab.transform.position + offset;

        // Start the attack animation
        isAttacking = true;
    }

    // Update method to handle moving and attacking
    private void Update()
    {
        if (isAttacking)
        {
            if (elapsedTime < moveDuration)
            {
                // Calculate the current position based on the interpolation factor
                float t = elapsedTime / moveDuration;
                Vector2 currentPosition = Vector2.Lerp(initialPosition, targetPosition, t);

                // Move the attacking prefab towards the target position smoothly over time
                // Note: You may need to reference the attacking prefab in some way to move it
                // For example, you might have a reference to it as a member variable of the God class
                // or pass it as a parameter to the MoveAndAttack method
                // attackingPrefab.transform.position = currentPosition;

                // Update elapsed time
                elapsedTime += Time.deltaTime;
            }
            else
            {
                // Ensure that the attacking prefab reaches the target position exactly
                // Note: You may need to set the final position here
                // attackingPrefab.transform.position = targetPosition;

                // Perform the attack after the movement is completed
                // Note: You may need to call the attack function here
                // attackFunction(attackingPrefab, defendingPrefab);

                // Reset variables for the next attack
                isAttacking = false;
                elapsedTime = 0f;
            }
        }
    }
    public void attackFunction(God attackingGod, God defendingGod, GameObject attackingPrefab, GameObject defendingPrefab)
    {

        int damage = attackingGod.attack - defendingGod.defense;
        int newhealth = defendingGod.health - damage;
        Debug.Log($"{attackingGod.godName} attacks {defendingGod.godName} for {damage} damage.");
        defendingGod.health = newhealth;


    }

}
