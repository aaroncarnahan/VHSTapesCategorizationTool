using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models
{
	public class CollectionTapeCreate
	{
		[Required]
		public int CollectionID { get; set; }
		[Required]
		public int VHSTapeID { get; set; }
	}
}
