using System;
namespace LensDotNet.Models
{
	public abstract class BasePagingModel
	{
        public int? Limit { get; set; }
        public int? Cursor { get; set; }
    }
}

