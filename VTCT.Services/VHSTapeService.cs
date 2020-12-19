using System;
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

		// GET VHSTAPES
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
	}
}
