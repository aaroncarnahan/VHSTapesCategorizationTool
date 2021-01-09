using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTCT.Data;
using VTCT.Models;
using VTCT.Models.Comment;

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
		public bool CreateCollection(CollectionCreate model)
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


		//GET COLLECTION DETAIL(BY ID)
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
						ModifiedUtc = entity.ModifiedUtc,
						Films = entity.CollectionTapes.Select(f => new VHSTapeListItem
						{
							VHSTapeID = f.VHSTape.VHSTapeID,
							VHSTitle = f.VHSTape.VHSTitle,
							VHSDescription = f.VHSTape.VHSDescription,
							VHSGenre = f.VHSTape.VHSGenre,
							CollectionName = f.VHSTape.CollectionTapes.Single().Collection.CollectionName,
							CreatedUtc = f.VHSTape.CreatedUtc
						}).ToList(),
						//TEST ............................
						CommentList = entity.Comments.Select(f => new CommentListItem
						{
							CommentID = f.CommentID,
							CommentContent = f.CommentContent,
							CreatedUtc = f.CreatedUtc
						}).ToList()
						//TEST ............................
					};
			}
		}

		// TESTING -------------------------------------------------
		//public CollectionTapeDetail GetCollectionWithTapes(int id) 
		//{
		//	using (var ctx = new ApplicationDbContext()) 
		//	{
		//		var entity =
		//			ctx
		//				.CollectionTapes
		//				.Single(e => e.Collection.CollectionID == id && e.Collection.CollectionOwnerID == _userID);

		//		return
		//			new CollectionTapeDetail
		//			{
		//				CollectionTapeID = entity.CollectionTapeID,
		//				CollectionID = entity.CollectionID,
		//				VHSTapeID = entity.VHSTapeID
		//			};

		//	}
		//}
		// TESTING -------------------------------------------------

		// TESTING -------------------------------------------------
		// GET COLLECTION LIST
		public IEnumerable<VHSTapeListItem> GetCollectionWithTapes1()
		{
			using (var ctx = new ApplicationDbContext())
			{
				var query =
					ctx
						.CollectionTapes
						.Where(e => e.VHSTape.VHSOwnerID == _userID)

						.Select(
							e =>
								new VHSTapeListItem
								{
									VHSTapeID = e.VHSTapeID,
									VHSTitle = e.VHSTape.VHSTitle,
									VHSGenre = e.VHSTape.VHSGenre,
									VHSDescription = e.VHSTape.VHSDescription,
									CollectionName = e.VHSTape.CollectionTapes.FirstOrDefault().Collection.CollectionName
								}
						);
				return query.ToArray();
			}

		}
		// TESTING -------------------------------------------------

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
