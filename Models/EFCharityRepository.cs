using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    public class EFCharityRepository : ICharityRepository
    {
        private CharityDbContext _context;

        //constructor
        public EFCharityRepository (CharityDbContext context)
        {
            _context = context; //assigning parameter "context" to our private property "_context"
        }

        //projects is being set to what is in the _context.Projects
        public IQueryable<Project> Projects => _context.Projects; 
    }
}
