using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app.Models
{
    public class Reply
    {
        //Codigos locales de estado
        public const int SUCCESSFULL = 1;
        public const int FAIL = 0;

        //objeto
        public int code { get; set; }
        public object data { get; set; }
        public string message { get; set; }
    }
}