using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models
{
	public class VHSTapeDetail
	{
		public int VHSTapeID { get; set; }
		
		public string VHSTitle { get; set; }
		
		public string VHSDescription { get; set; }

		public string VHSGenre { get; set; }

		public string CollectionName { get; set; }

		[Display(Name = "Created")]
		public DateTimeOffset CreatedUtc { get; set; }

		[Display(Name = "Modified")]
		public DateTimeOffset? ModifiedUtc { get; set; }
	}
}
