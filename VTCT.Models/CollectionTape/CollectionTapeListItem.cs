using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models.CollectionTape
{
	public class CollectionTapeListItem
	{
		public int CollectionTapeID { get; set; }

		// COLLECTION
		public int CollectionID { get; set; }
		public CollectionListItem Collection { get; set; }

		// VHSTape
		public int VHSTapeID { get; set; }
		public VHSTapeListItem VHSTape { get; set; }
	}
}
