using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.helpers
{
    public class Reply
    {
        //Codigos locales de estado
        public const int SUCCESSFULL = 1;
        public const int FAIL = 0;

        //Estado si falla la data
        public const object DATA_FAIL = null;

        //objeto
        public int code { get; set; }
        public object data { get; set; }
        public string message { get; set; }
    }
}