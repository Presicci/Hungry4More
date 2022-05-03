using UnityEngine;

/// <summary>
/// Holds the money value for the coin and handles adding that money to the player's bank.
/// </summary>
/// <remarks>
/// Thomas Presicci - https://github.com/Presicci
/// </remarks>
public class Coin : MonoBehaviour
{
    private int moneyAmt;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0)
        {
            GameController.instance.AddMoney(moneyAmt);
            Destroy(gameObject);
        }
    }

    public void SetMoneyAmount(int moneyAmt)
    {
        this.moneyAmt = moneyAmt;
    }
}
