
namespace app.helpers
{
    public class ReturnClassDefault
    {
        public Reply returnDataDefault(int code, object data, string message)
        {
            var records = new Reply
            {
                code = code,
                data = data,
                message = message

            };

            return records;
        }

        public PaginateReturn returnDataPaginate(object[] paginate, int code, object data, string message)
        {
            return new PaginateReturn
            {
                pages = (int)paginate[3],
                objects_page = (int)paginate[2],
                current_page = (int)paginate[1],
                records = this.returnDataDefault(code, data, message)
            };
        }
    }
}