using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitBookMvcApp.Models.ViewModels
{
    public class Status
    {
        public string Name { get; set; }
        public int? ProPicId { get; set; }
        public Post Post { get; set; }
        public List<Like> Likes { get; set; }
        public List<Comment> Comments { get; set; }
        }
}