namespace AssetManagementAPI.Exceptions
{
    public class SameAbbreviationException : Exception
    {
        public SameAbbreviationException()
            : base(String.Format("Same Abbrv cannot be used again"))
        {

        }
    }
}
