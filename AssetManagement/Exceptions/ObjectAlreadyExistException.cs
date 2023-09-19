namespace AssetManagementAPI.Exceptions
{
    public class ObjectAlreadyExistException : Exception
    {
        public ObjectAlreadyExistException()
            : base(String.Format("Object Already Exists"))
        {

        }
    }
}
