using UnityEngine;

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
