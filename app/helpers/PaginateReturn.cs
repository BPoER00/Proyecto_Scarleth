using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.helpers
{
    public class PaginateReturn
    {
        //total de paginas
        public int pages { get; set; }
        
        //total de objetos en pagina
        public int objects_page { get; set; }
        
        //pagina actual
        public int current_page { get; set; }
        
        //data
        public Object records { get; set; }
    }
}