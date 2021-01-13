using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models
{
	public class VHSTapeCreate
	{
		[Display(Name = "Title")]
		public string VHSTitle { get; set; }

		[Display(Name = "Description")]
		public string VHSDescription { get; set; }

		[Display(Name = "Genre")]
		public string VHSGenre { get; set; }

		[Display(Name = "Collection Name")]
		public string CollectionName { get; set; }
	}
}
