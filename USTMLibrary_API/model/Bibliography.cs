using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace USTMLibrary_API.model
{
	[Index("ISBN", IsUnique = true)]
	public class Bibliography
	{
		[Key]
		public int Id { get; set; }
		public int  ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public string publishComp { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public int Year { get; set; }
		public int Pages { get; set; }
		public bool Status { get; set; }
		public string PicUrl { get; set; }
		
	}
}
