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
	public class CommentService
	{
		private readonly Guid _userId;

		public CommentService(Guid userId)
		{
			_userId = userId;
		}

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    CommentOwnerID = _userId,
                    CommentContent = model.CommentContent,
                    CollectionID = model.CollectionID,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.CommentOwnerID == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentID = e.CommentID,
                                    CommentContent = e.CommentContent,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentID == id && e.CommentOwnerID == _userId);
                return
                    new CommentDetail
                    {
                        CommentID = entity.CommentID,
                        CommentContent = entity.CommentContent,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentID == model.CommentID && e.CommentOwnerID == _userId);

                entity.CommentContent = model.CommentContent;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentID == commentId && e.CommentOwnerID == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
