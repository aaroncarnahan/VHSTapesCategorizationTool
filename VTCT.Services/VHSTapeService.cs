﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VTCT.Data;
using VTCT.Models;

namespace VTCT.Services
{
	public class VHSTapeService
	{
		private readonly Guid _userID;

		public VHSTapeService(Guid userId) 
		{
			_userID = userId;
		}

		// CREATE VHSTAPE
		public bool CreateVHSTape(VHSTapeCreate model) 
		{
			var entity =
				new VHSTape()
				{
					VHSOwnerID = _userID,
					VHSTitle = model.VHSTitle,
					VHSDescription = model.VHSDescription,
					VHSGenre = model.VHSGenre,
					CollectionName = model.CollectionName,
					CreatedUtc = DateTimeOffset.Now
				};

			using (var ctx = new ApplicationDbContext()) 
			{
				ctx.VHSTapes.Add(entity);
				return ctx.SaveChanges() == 1;
			}
		}

		// GET VHSTAPES LIST
		public IEnumerable<VHSTapeListItem> GetVHSTapes() 
		{
			using (var ctx = new ApplicationDbContext()) 
			{
				var query =
					ctx
						.VHSTapes
						.Where(e => e.VHSOwnerID == _userID)
						.Select(
							e =>
								new VHSTapeListItem
								{
									VHSTapeID = e.VHSTapeID,
									VHSTitle = e.VHSTitle,
									VHSDescription = e.VHSDescription,
									VHSGenre = e.VHSGenre,
									CollectionName = e.CollectionName,
									CreatedUtc = e.CreatedUtc
								}
						);
				return query.ToArray();
			}
		
		}

		// GET VHSTAPES DETAIL (BY ID)
		public VHSTapeDetail GetVHSTapeById(int id) 
		{
			using (var ctx = new ApplicationDbContext()) 
			{
				var entity =
					ctx
						.VHSTapes
						.Single(e => e.VHSTapeID == id && e.VHSOwnerID == _userID);
				return
					new VHSTapeDetail
					{
						VHSTapeID = entity.VHSTapeID,
						VHSTitle = entity.VHSTitle,
						VHSDescription = entity.VHSDescription,
						VHSGenre = entity.VHSGenre,
						CollectionName = entity.CollectionName,
						CreatedUtc = entity.CreatedUtc,
						ModifiedUtc = entity.ModifiedUtc
					};
			}
		}

		// UPDATE VHSTAPE
		public bool UpdateVHSTape(VHSTapeEdit model) 
		{
			using (var ctx = new ApplicationDbContext()) 
			{
				var entity =
					ctx
						.VHSTapes
						.Single(e => e.VHSTapeID == model.VHSTapeID && e.VHSOwnerID == _userID);

				entity.VHSTitle = model.VHSTitle;
				entity.VHSDescription = model.VHSDescription;
				entity.VHSGenre = model.VHSGenre;
				entity.CollectionName = model.CollectionName;
				entity.ModifiedUtc = DateTimeOffset.UtcNow;

				return ctx.SaveChanges() == 1;
			}
		}

		// DELETE VHSTAPE
		public bool DeleteVHSTape(int vhsTapeId) 
		{
			using (var ctx = new ApplicationDbContext()) 
			{
				var entity =
					ctx
						.VHSTapes
						.Single(e => e.VHSTapeID == vhsTapeId && e.VHSOwnerID == _userID);

				ctx.VHSTapes.Remove(entity);

				return ctx.SaveChanges() == 1;
			}
		}

	}
}
