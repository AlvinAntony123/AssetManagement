namespace AssetManagementAPI.Exceptions
{
    public class EmployyeNotFoundException : Exception
    {
        public EmployyeNotFoundException()
            : base(String.Format("Employee Not Found"))
        {

        }
    }
}
