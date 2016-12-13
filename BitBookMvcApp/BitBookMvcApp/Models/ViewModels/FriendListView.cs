using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitBookMvcApp.Models.ViewModels
{
    public class FriendListView
    {
        public int? FriendId { get; set; }
        public string Name { get; set; }
        public string PicUrl { get; set; }
    }
}