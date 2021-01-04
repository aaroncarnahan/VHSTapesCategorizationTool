using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Data
{
	public class CollectionTape

	{
		[Key]
		public int CollectionTapeID { get; set;}

		[ForeignKey(nameof (Collection))]
		public int CollectionID { get; set; }
		public virtual Collection Collection { get; set; }

		[ForeignKey(nameof(VHSTape))]
		public int VHSTapeID { get; set; }
		public virtual VHSTape VHSTape { get; set; }

	}
}
