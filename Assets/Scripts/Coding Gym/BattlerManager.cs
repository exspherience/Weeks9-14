using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattlerManager : MonoBehaviour
{
    public Button player1Button;
    public Button player2Button;
    public TurnBasedBattler player1;
    public TurnBasedBattler player2;
    public bool player1Turn = true;
    public bool player2Turn = false;
    public Coroutine buttonOnCoroutine;

    // Make another sprite with the same script and hook it up to a second button: label one button player A attacks,
    // and the other player B attacks.Disable both buttons in the inspector. Make a manager script with a coroutine
    // that enables player AÅfs button and waits for them to take their turn before disabling the button and enabling
    // player BÅfs button

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // start coroutine when game starts
        buttonOnCoroutine = StartCoroutine(ButtonActive());        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator ButtonActive()
    {
        // needs to be running the whole game
        // so it gets an infinite-ish loop
        // doesn't break because of yield return 
        while (true)
        {
            // toggles the buttons interactable value so P1 can attack
            if (player1Turn)
            {
                player1Button.interactable = true;
                player2Button.interactable = false;

                // disables button while P1 attack animation
                // yields for attacking for length of attack duration from TurnBasedBattler script
                // swaps turn to P2
                if (player1.attacking)
                {
                    player1Button.interactable = false;
                    yield return new WaitForSeconds(player1.attackDuration);
                    player1Turn = false;
                    player2Turn = true;
                }
            }

            // inverse of above but for P2
            if (player2Turn)
            {
                player1Button.interactable = false;
                player2Button.interactable = true;

                if (player2.attacking)
                {
                    player2Button.interactable = false;
                    yield return new WaitForSeconds(player2.attackDuration);
                    player2Turn = false;
                    player1Turn = true;
                }
            }
            // allow for other actions to occur
            yield return null;
        }
    }
}