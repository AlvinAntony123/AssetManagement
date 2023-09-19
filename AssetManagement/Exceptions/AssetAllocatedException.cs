namespace AssetManagementAPI.Exceptions
{
    public class AssetAllocatedException : Exception
    {
        public AssetAllocatedException()
            : base(String.Format("Asset Already Allocated"))
        {

        }
    }
}
