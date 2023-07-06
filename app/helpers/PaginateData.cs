using Microsoft.AspNetCore.Mvc;

namespace app.helpers
{
    public class PaginateData
    {
        //tamano de pagina context (tamano de objetos que contiene la pagina)
        private const int TPC = 10;

        //numero de pagina context
        private const int NPC = 1;
        public int[] paginateData(int tp, int np, int totalObjects)
        {
            tp = tp > 0 ? tp : TPC;
            np = np > 0 ? np : NPC;

            int totalPages = (int)Math.Ceiling((double) totalObjects / tp);

            int offset = ((np - 1) * tp);

            return new int[] { offset, tp, totalPages };
        }
    }
}