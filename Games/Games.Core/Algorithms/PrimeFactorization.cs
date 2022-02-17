namespace Games.Core.Algorithm;
public class PrimeFactorization
{
    private List<int> PrimesList = new();
    private static (bool, List<int>) IsPrime(int nr, List<int> primesList)
    {
        if(primesList.Contains(nr))
        {
            return (true, primesList); 
        }
        foreach (var divisor in primesList)
        {
            if(divisor > Math.Sqrt(nr))
            {
                break;
            }
            if (nr % divisor == 0)
            {
                return (false, primesList);
            }
        }
        primesList.Add(nr);
        return (true, primesList);
    }

    public int Factorize(int nr)
    {
        int divisor = 2;
        while (nr > 1)
        {
            (bool isPrime, PrimesList) = IsPrime(divisor, PrimesList);
            if (isPrime)
            {
                if (nr % divisor == 0)
                {
                    nr /= divisor;
                }
                else
                {
                    divisor += 1;
                }
            }
            else
            {
                divisor += 1;
            }
        }
        return divisor;
    }

}

