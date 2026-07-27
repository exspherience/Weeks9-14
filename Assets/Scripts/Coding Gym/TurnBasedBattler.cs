using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;
public class TurnBasedBattler : MonoBehaviour
{
    // 1 Write a coroutine that makes a sprite do something (grow, move, rotate, etc) using an AnimationCurve.
    // 2 Write a function that gets called by a button that starts this coroutine. Set the buttonÅfs interactable
    //   variable to false when the coroutine starts, and wait for the coroutine to end before setting it back to true
    //   (so that you canÅft click the button while the ÅgattackÅh is happening)
    // 3 Make another sprite with the same script and hook it up to a second button: label one button player A attacks,
    //   and the other player B attacks.Disable both buttons in the inspector.Make a manager script with a coroutine
    //   that enables player AÅfs button and waits for them to take their turn before disabling the button and enabling
    //   player BÅfs button

    public float speed = 2;
    Coroutine attackCoroutine;
    public AnimationCurve attackCurve;
    public float attackDuration = 2;
    Vector3 playerTransform;
    public bool isPlayerLeft = false;
    public float startPosition;
    bool attacking;
    public Button attackButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isPlayerLeft)
        {
            playerTransform = new Vector3(-5, 0, 0);
        }
        else
        {
            playerTransform = new Vector3(4, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!attacking && attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        if (!attacking) attackButton.interactable = true;
    }

    private IEnumerator Attack()
    {
        float t = 0;

        while (t < attackDuration)
        {
            t += Time.deltaTime;
            playerTransform.x = startPosition + attackCurve.Evaluate(t / attackDuration);// * Vector3.one;
            transform.position = playerTransform;
            yield return null;
        }
        attacking = false;
        t = 0;

    }

    public void StartAttack()
    {
        if (!attacking)
        {
            attackCoroutine = StartCoroutine(Attack());
            attacking = true;
            attackButton.interactable = false;
        }
    }
}
