using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models.ViewModels
{
    public class ProjectListViewModel
    {
        //creates a number for each project that can be iterated through
        public IEnumerable<Project> Projects { get; set; }
      
        public PagingInfo PagingInfo { get; set; }
        public string Type { get; set; }
    }
}
