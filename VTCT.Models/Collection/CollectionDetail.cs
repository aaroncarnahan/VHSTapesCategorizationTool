using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTCT.Models.Comment;

namespace VTCT.Models
{
	public class CollectionDetail
	{
		[Display(Name = "ID")]
		public int CollectionID { get; set; }
		[Display(Name = "Collection")]
		public string CollectionName { get; set; }
		[Display(Name = "Description")]
		public string CollectionDescription { get; set; }

		[Display(Name = "Created")]
		public DateTimeOffset CreatedUtc { get; set; }

		[Display(Name = "Modified")]
		public DateTimeOffset? ModifiedUtc { get; set; }

		public List<VHSTapeListItem> Films { get; set; }
		public List<CommentListItem> CommentList { get; set; }

	}
}
