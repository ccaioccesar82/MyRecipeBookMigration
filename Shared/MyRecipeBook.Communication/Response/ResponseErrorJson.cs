using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Communication.Response
{
    public class ResponseErrorJson
    {

        public IList<string> ErroMessages { get; set; } = new List<string>();

        public ResponseErrorJson(IList<string> erroMessages)
        {
            ErroMessages = erroMessages;
        }
        public ResponseErrorJson(string message)
        {
           ErroMessages.Add(message);
        }
    }
}
