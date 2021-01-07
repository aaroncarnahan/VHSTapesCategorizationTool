﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTCT.Models
{
	public class CollectionDetail
	{
		public int CollectionID { get; set; }
		public string CollectionName { get; set; }
		public string CollectionDescription { get; set; }

		[Display(Name = "Created")]
		public DateTimeOffset CreatedUtc { get; set; }

		[Display(Name = "Modified")]
		public DateTimeOffset? ModifiedUtc { get; set; }

		public List<VHSTapeListItem> Films { get; set; }

	}
}