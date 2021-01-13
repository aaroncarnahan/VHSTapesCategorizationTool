using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models
{
	public class CollectionCreate
	{
		[Display(Name = "Collection Name")]

		public string CollectionName { get; set; }
		[Display(Name = "Description")]

		public string CollectionDescription { get; set; }
	}
}
