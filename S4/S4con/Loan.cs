public class Loan
{
    private Person LoanHolder;

    private double InitAmount;    
    private DateTime LoanStartDate;
    private TimeSpan LoanSpan;

    private double InterestRate;

    public string Name
    {
        get => this.LoanHolder.AccountHolderName;
    }

    // constructor
    // ...

//    public Loan(...)
}