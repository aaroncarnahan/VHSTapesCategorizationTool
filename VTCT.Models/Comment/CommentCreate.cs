using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models
{
	public class CommentCreate
	{
		
		[Required]
		[Display(Name = "Comment")]
		public string CommentContent { get; set; }
		[Required]
		[Display(Name = "ID")]
		public int CollectionID { get; set; }

	}
}
