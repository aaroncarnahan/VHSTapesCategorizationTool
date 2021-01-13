using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models
{
	public class CollectionListItem
	{
		[Display(Name = "ID")]
		public int CollectionID { get; set; }
		[Display(Name = "Collection")]
		public string CollectionName { get; set; }
		[Display(Name = "Description")]
		public string CollectionDescription { get; set; }

		[Display(Name = "Created")]
		public DateTimeOffset CreatedUtc { get; set; }

	}
}
