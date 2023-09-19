using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.DTO
{
    public class MeetingRoomAssetDTO
    {
        public int MeetingRoomId { get; set; }
        public int AssetId { get; set; }

        public int NoOfItems { get; set; }
    }
}
