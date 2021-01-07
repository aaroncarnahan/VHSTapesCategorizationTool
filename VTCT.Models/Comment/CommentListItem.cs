using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models.Comment
{
	public class CommentListItem
	{
		public int CommentID { get; set; }
		public string CommentContent { get; set; }

		[Display(Name = "Created")]
		public DateTimeOffset CreatedUtc { get; set; }
	}
}
