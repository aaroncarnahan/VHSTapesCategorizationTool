using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTCT.Data;
using VTCT.Models;

namespace VTCT.Services
{
	public class CollectionService
	{

		private readonly Guid _userID;

		public CollectionService(Guid userId)
		{
			_userID = userId;
		}

		// CREATE COLLECTION
		public bool CreateVHSTape(CollectionCreate model)
		{
			var entity =
				new Collection()
				{
					CollectionOwnerID = _userID,
					CollectionName = model.CollectionName,
					CollectionDescription = model.CollectionDescription,
					CreatedUtc = DateTimeOffset.Now
				};

			using (var ctx = new ApplicationDbContext())
			{
				ctx.Collections.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}

		// GET COLLECTION LIST
		public IEnumerable<CollectionListItem> GetCollections()
		{
			using (var ctx = new ApplicationDbContext())
			{
				var query =
					ctx
						.Collections
						.Where(e => e.CollectionOwnerID == _userID)
						.Select(
							e =>
								new CollectionListItem
								{
									CollectionID = e.CollectionID,
									CollectionName = e.CollectionName,
									CollectionDescription = e.CollectionDescription,
									CreatedUtc = e.CreatedUtc
								}
						);
				return query.ToArray();
			}

		}

		// GET COLLECTION DETAIL (BY ID)
		public CollectionDetail GetCollectionById(int id)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity =
					ctx
						.Collections
						.Single(e => e.CollectionID == id && e.CollectionOwnerID == _userID);
				return
					new CollectionDetail
					{
						CollectionID = entity.CollectionID,
						CollectionName = entity.CollectionName,
						CollectionDescription = entity.CollectionDescription,
						CreatedUtc = entity.CreatedUtc,
						ModifiedUtc = entity.ModifiedUtc
					};
			}
		}

		// UPDATE COLLECTION
		public bool UpdateCollection(CollectionEdit model)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity =
					ctx
						.Collections
						.Single(e => e.CollectionID == model.CollectionID && e.CollectionOwnerID == _userID);

				entity.CollectionName = model.CollectionName;
				entity.CollectionDescription = model.CollectionDescription;
				entity.CollectionDescription = model.CollectionDescription;
				entity.ModifiedUtc = DateTimeOffset.UtcNow;

				return ctx.SaveChanges() == 1;
			}
		}

		// DELETE COLLECTION
		public bool DeleteCollection(int collectionId)
		{
			using (var ctx = new ApplicationDbContext())
			{
				var entity =
					ctx
						.Collections
						.Single(e => e.CollectionID == collectionId && e.CollectionOwnerID == _userID);

				ctx.Collections.Remove(entity);

				return ctx.SaveChanges() == 1;
			}
		}

	}
}
