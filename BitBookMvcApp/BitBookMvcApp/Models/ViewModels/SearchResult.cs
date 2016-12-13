namespace BitBookMvcApp.Models.ViewModels
{
    public class SearchResult
    {
        public int? SearchedProfileId { get; set; }
        public string Name { get; set; }
        public string ProPicUrl { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
        public bool? IsAccepted { get; set; }
        public int? FriendRequestId { get; set; }
    }
}