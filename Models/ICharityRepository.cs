using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WaterProject.Models
{
    //interface template (not a class), meant to be inherited...to help us control what's in the class?
    public interface ICharityRepository
    {
        IQueryable<Project> Projects { get; }

        //IQueryable = getting data out of memory; generally drawing from outside databases to get data
        //IEnumerable = getting stuff out of memory that exists in the app at that moment
    }
}
