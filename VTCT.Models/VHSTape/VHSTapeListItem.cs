using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models
{
	public class VHSTapeListItem
	{
		[Display(Name = "ID")]
		public int VHSTapeID { get; set; }
		[Display(Name = "Title")]
		public string VHSTitle { get; set; }
		[Display(Name = "Description")]
		public string VHSDescription { get; set; }
		[Display(Name = "Genre")]
		public string VHSGenre { get; set; }
		[Display(Name = "Collection")]
		public string CollectionName { get; set; }

		[Display(Name = "Created")]
		public DateTimeOffset CreatedUtc { get; set; }

	}
}
