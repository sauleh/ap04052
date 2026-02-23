public enum AccountStatus
{
    Active = 1, Closed = 2, OpenedNotActive = 3
}

public class Account
{
    private Person AccountHolder;
    private double _Balance;
    private AccountStatus Status = AccountStatus.OpenedNotActive;

    public Account(string name, int natId, double deposit=0)
    {
        this.AccountHolderId = natId;
        this.AccountHolderName = name;
        if (deposit > 0)
        {
            this._Balance = deposit;
            Status = AccountStatus.Active;
        }        
    }

    public bool Deposit(int sectoken, double amount)
    {
        if (amount < 0)
            return false;
     
        this._Balance += amount;
        if (this._Balance > 0)
            Status = AccountStatus.Active;
        return true;
    }

    public bool Withdraw(int sectoken, double amount)
    {
        if (this.Status != AccountStatus.Active || amount >= this._Balance)
            return false;

        this._Balance -= amount;
        return true;
    }

    public double Balance
    {
        get
        {
            return this._Balance;
        }
    }

}