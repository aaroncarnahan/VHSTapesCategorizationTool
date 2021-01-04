using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Data
{
	public class VHSTape
	{
		[Key]
		public int VHSTapeID { get; set; }

		[Required]
		public Guid VHSOwnerID { get; set; }

		[Required]
		public string VHSTitle { get; set; }

		[Required]
		public string VHSDescription { get; set; }

		[Required]
		public string VHSGenre { get; set; }

		[Required]
		public DateTimeOffset CreatedUtc { get; set; }

		public DateTimeOffset? ModifiedUtc { get; set; }

		public virtual List<CollectionTape> CollectionTapes { get; set; } = new List<CollectionTape>();
	}
}
