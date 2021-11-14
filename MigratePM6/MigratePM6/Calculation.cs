using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigratePM6
{
    public class Calculation
    {
        //List<Pm6optChon300nosalt> _pm6OptChon300salt;
        //dbContext dbContext;

        //public Action(List<Pm6optChon300nosalt> pm6OptChon300salt, dbContext dbContext)
        //{
        //    _pm6OptChon300salt = pm6OptChon300salt;
        //    this.dbContext = dbContext;
        //}

        public Calculation()
        {

        }

        public async Task WriteToExternal(dbContext remoteConext, List<Pm6optChon300nosalt> records ) 
        {
            foreach (var r in records)
            {
                remoteConext.Pm6optChon300nosalts.Add(r);
            }
        }
    }
}
