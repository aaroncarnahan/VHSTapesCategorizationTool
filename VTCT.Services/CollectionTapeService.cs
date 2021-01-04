using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTCT.Data;
using VTCT.Models;
using VTCT.Models.CollectionTape;

namespace VTCT.Services
{
	public class CollectionTapeService
	{
		private readonly Guid _userID;

		public CollectionTapeService(Guid userId)
		{
			_userID = userId;
		}

		public bool CreateCollectionTape(CollectionTapeCreate model)
		{
			var entity =
				new CollectionTape()
				{
					CollectionID = model.CollectionID,
					VHSTapeID = model.VHSTapeID
				};
			using (var ctx = new ApplicationDbContext())
			{
				ctx.CollectionTapes.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}

		//public IEnumerable<CollectionTapeListItem> GetCollectionTape() 
		//{
		//	using (var ctx = new ApplicationDbContext()) 
		//	{
		//		var query =
		//			ctx
		//				.CollectionTapes
		//				.Select(
		//				e =>
		//					new CollectionTapeListItem 
		//					{
		//						CollectionTapeID = e.CollectionTapeID,
		//						VHSTapeID = e.VHSTapeID,
		//						VHSTape = new VHSTapeListItem 
		//						{
								
		//						}
		//					}
						
		//				)
		//	}
		//}

	}
}
