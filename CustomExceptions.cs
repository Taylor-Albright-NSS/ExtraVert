public class TooLongException : Exception
{
    public TooLongException(string message) : base(message){}
}

public class TooShortException : Exception
{
    public TooShortException(string message) : base(message){}
}

