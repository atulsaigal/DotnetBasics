using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApi.WebApp._4_DataAccess.Repository
{
    public class BaseRepository
    {
        public Context _context { get; set; }

        public BaseRepository(Context _context)
        {
            this._context = _context;
        }
    }
}
