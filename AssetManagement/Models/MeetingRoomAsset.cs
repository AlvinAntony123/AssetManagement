using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManagementAPI.Models
{
    public class MeetingRoomAsset
    {
        [Key]
        public int MeetingRoomAssetId { get; set; }
        [ForeignKey("MeetingRoom")]
        public int MeetingRoomId { get; set; }
        [ForeignKey("Asset")]
        public int AssetId { get; set; }

        public int NoOfItems { get; set; }

        public virtual MeetingRoom MeetingRoom { get; set; }

        public virtual Asset Asset { get; set; }
    }
}
