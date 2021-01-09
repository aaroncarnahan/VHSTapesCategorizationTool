using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Data
{
	public class Comment
	{
		[Key]
		public int CommentID { get; set; }

		[Required]
		public Guid CommentOwnerID { get; set; }

		[Required]
		public string CommentContent { get; set; }

		[Required]
		public int CollectionID { get; set; }

		[Required]
		public DateTimeOffset CreatedUtc { get; set; }

		public DateTimeOffset? ModifiedUtc { get; set; }

	}
}
