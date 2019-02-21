using System.Collections.Generic;

namespace Actors.Models
{
	public class ActorInfo
	{
		public int ActorId { get; set; }
		public string FullName { get; set; }
		public List<PhotoModel> Photos { get; set; }
	}
}