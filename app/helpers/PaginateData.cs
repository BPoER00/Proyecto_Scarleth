using Microsoft.AspNetCore.Mvc;

namespace app.helpers
{
    public class PaginateData
    {
        //tamano de pagina context (tamano de objetos que contiene la pagina)
        private const int TPC = 10;

        //numero de pagina context
        private const int NPC = 1;
        public int[] paginateData(int tp, int np)
        {
            tp = tp > 0 ? tp : TPC;
            np = np > 0 ? np : NPC;

            int offset = ((np - 1) * tp);

            return new int[] { offset, tp };
        }
    }
}