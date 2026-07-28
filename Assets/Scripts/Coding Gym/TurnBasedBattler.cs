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
    public float startPosition;
    public bool attacking;
    public BattlerManager manager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // play attack animation with coroutine
    private IEnumerator Attack()
    {
        float t = 0;

        while (t < attackDuration)
        {
            t += Time.deltaTime;
            // use animation curve
            // P1 has curve that goes up like ^ while P2 goes down like v
            playerTransform.x = startPosition + attackCurve.Evaluate(t / attackDuration);// * Vector3.one;
            transform.position = playerTransform;
            yield return null;
        }
        attacking = false;
        t = 0;

    }

    // start coroutine, toggle attacking variable to true
    public void StartAttack()
    {
        attackCoroutine = StartCoroutine(Attack());
        attacking = true;
    }
}
