using Actors.DataAccess;
using Actors.Models;
using System.Collections.Generic;
using System.Linq;

namespace Actors.Repositories
{
	public class ActorsRepository
	{
		public static List<MainPageViewModel> GetAllActors()
		{
			List<Actor> actors;
			List<Photo> mainPhotos;

			using (ActorsDb db = new ActorsDb())
			{
				actors = db.Actors.ToList();
				mainPhotos = db.Photos.Where(p => p.IsMain).ToList();
			}

			var res = actors.Select(a => new MainPageViewModel
			{
				ActorId = a.Id,
				ActorName = a.FullName,
				Gender = a.Gender,
				PhotoPath = mainPhotos.SingleOrDefault(p => p.ActorId.Equals(a.Id))?.Path
			})
				.ToList();

			return res;
		}

		public static ActorInfo ActorInfo(int actorId)
		{
			ActorInfo fullInfo = new ActorInfo();
			List<Photo> allPhotos;

			using (ActorsDb db = new ActorsDb())
			{
				allPhotos = db.Photos.Where(p => p.ActorId.Equals(actorId)).ToList();
			}

			fullInfo.Photos = allPhotos.Select(r => new PhotoModel
			{
				PhotoId = r.Id,
				PhotoPath = r.Path
			}).ToList();

			return fullInfo;
		}

		/*
			// fake data before DB implementation
			var fakeActors = new Faker<Actor>()
				.RuleFor(a => a.ActorId, f => f.UniqueIndex)
				.RuleFor(a => a.FullName, f => f.Internet.UserName())
				.RuleFor(a => a.ActorGender, f => f.PickRandom(new[] { "male", "female" }))
				.Generate(10).ToList();

			var fakePhotos = new Faker<PhotoModel>()
				.RuleFor(p => p.ActorId, f => f.PickRandom(new List<int>(actors.Select(a => a.Id))))
				.RuleFor(p => p.PhotoPath, f => f.Lorem.Word() + ".png")
				.RuleFor(p => p.PhotoId, f => f.UniqueIndex)
				.RuleFor(p => p.IsMain, f => f.PickRandom(new[] { true, false }))
				.Generate(50).ToList();
				*/
	}
}