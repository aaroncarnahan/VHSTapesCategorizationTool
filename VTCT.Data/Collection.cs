using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Data
{
	public class Collection
	{
		[Key]
		public int CollectionID { get; set; }
		[Required]
		public Guid CollectionOwnerID { get; set; }
		[Required]
		public string CollectionName { get; set; }

		public string CollectionDescription { get; set; }

		[Required]
		public DateTimeOffset CreatedUtc { get; set; }

		public DateTimeOffset? ModifiedUtc { get; set; }

		public virtual List<CollectionTape> CollectionTapes { get; set; } = new List<CollectionTape>();

		public virtual List<Comment> Comments { get; set; } = new List<Comment>();
	}
}
